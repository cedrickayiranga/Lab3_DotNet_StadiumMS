using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Controllers
{
    public static class EventController
    {
        private const string SelectSql =
            "SELECT e.id, e.title, e.description, e.start_datetime, e.end_datetime, e.max_tickets, " +
            "  (SELECT COUNT(*) FROM event_seats s WHERE s.event_id = e.id AND s.is_booked = 0) AS available_seats, " +
            "  (SELECT MIN(s.price) FROM event_seats s WHERE s.event_id = e.id) AS price " +
            "FROM events e ";

        public static List<Event> GetAll()
        {
            return Query(SelectSql + "ORDER BY e.start_datetime", null);
        }

        public static List<Event> Search(string keyword)
        {
            return Query(SelectSql + "WHERE e.title LIKE @kw ORDER BY e.start_datetime", "%" + keyword + "%");
        }

        public static int CountAll()
        {
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM events", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int Add(Event ev, decimal price)
        {
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlTransaction tx = conn.BeginTransaction())
            {
                int eventId;
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO events (title, description, start_datetime, end_datetime, max_tickets) " +
                    "VALUES (@title, @desc, @start, @end, @max)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@title", ev.Title);
                    cmd.Parameters.AddWithValue("@desc", ev.Description);
                    cmd.Parameters.AddWithValue("@start", ev.StartDatetime);
                    cmd.Parameters.AddWithValue("@end", ev.EndDatetime);
                    cmd.Parameters.AddWithValue("@max", ev.MaxTickets);
                    cmd.ExecuteNonQuery();
                    eventId = (int)cmd.LastInsertedId;
                }

                InsertSeats(conn, tx, eventId, 1, ev.MaxTickets, price);
                tx.Commit();
                return eventId;
            }
        }

        public static bool Update(Event ev, decimal price, out string error)
        {
            error = null;
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlTransaction tx = conn.BeginTransaction())
            {
                int seatCount = CountSeats(conn, tx, ev.Id, false);
                int bookedCount = CountSeats(conn, tx, ev.Id, true);

                if (ev.MaxTickets < bookedCount)
                {
                    error = "Max tickets cannot be lower than the " + bookedCount + " tickets already sold.";
                    return false;
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE events SET title = @title, description = @desc, start_datetime = @start, " +
                    "end_datetime = @end, max_tickets = @max WHERE id = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@title", ev.Title);
                    cmd.Parameters.AddWithValue("@desc", ev.Description);
                    cmd.Parameters.AddWithValue("@start", ev.StartDatetime);
                    cmd.Parameters.AddWithValue("@end", ev.EndDatetime);
                    cmd.Parameters.AddWithValue("@max", ev.MaxTickets);
                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE event_seats SET price = @price WHERE event_id = @id AND is_booked = 0", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@id", ev.Id);
                    cmd.ExecuteNonQuery();
                }

                if (ev.MaxTickets > seatCount)
                {
                    InsertSeats(conn, tx, ev.Id, seatCount + 1, ev.MaxTickets, price);
                }
                else if (ev.MaxTickets < seatCount)
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM event_seats WHERE event_id = @id AND is_booked = 0 ORDER BY id DESC LIMIT @n", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", ev.Id);
                        cmd.Parameters.AddWithValue("@n", seatCount - ev.MaxTickets);
                        cmd.ExecuteNonQuery();
                    }
                }

                tx.Commit();
                return true;
            }
        }

        public static bool Delete(int eventId, out string error)
        {
            error = null;
            using (MySqlConnection conn = Db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tickets WHERE event_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        error = "This event already has sold tickets, so it cannot be deleted.";
                        return false;
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM events WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }


        private static List<Event> Query(string sql, string keyword)
        {
            List<Event> list = new List<Event>();
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                if (keyword != null) cmd.Parameters.AddWithValue("@kw", keyword);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Event ev = new Event();
                        ev.Id = r.GetInt32(0);
                        ev.Title = r.GetString(1);
                        ev.Description = r.IsDBNull(2) ? "" : r.GetString(2);
                        ev.StartDatetime = r.GetDateTime(3);
                        ev.EndDatetime = r.GetDateTime(4);
                        ev.MaxTickets = r.GetInt32(5);
                        ev.AvailableSeats = Convert.ToInt32(r.GetValue(6));
                        ev.Price = r.IsDBNull(7) ? 0m : Convert.ToDecimal(r.GetValue(7));
                        list.Add(ev);
                    }
                }
            }
            return list;
        }

        private static int CountSeats(MySqlConnection conn, MySqlTransaction tx, int eventId, bool onlyBooked)
        {
            string sql = "SELECT COUNT(*) FROM event_seats WHERE event_id = @id";
            if (onlyBooked) sql += " AND is_booked = 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@id", eventId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private static void InsertSeats(MySqlConnection conn, MySqlTransaction tx, int eventId, int from, int to, decimal price)
        {
            const int batchSize = 500;
            for (int start = from; start <= to; start += batchSize)
            {
                int end = Math.Min(start + batchSize - 1, to);
                StringBuilder sql = new StringBuilder("INSERT INTO event_seats (event_id, seat_number, price) VALUES ");
                for (int n = start; n <= end; n++)
                {
                    if (n > start) sql.Append(", ");
                    sql.Append("(@eid, 'Seat ").Append(n).Append("', @price)");
                }

                using (MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn, tx))
                {
                    cmd.Parameters.AddWithValue("@eid", eventId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
