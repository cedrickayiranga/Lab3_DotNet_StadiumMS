using System;
using System.Collections.Generic;
using MySqlConnector;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Controllers
{
    public static class TicketController
    {
        public static bool Buy(int userId, int eventId, int seatId, string paymentMethod, out string error)
        {
            error = null;
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlTransaction tx = conn.BeginTransaction())
            {
                decimal price;
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT price FROM event_seats WHERE id = @sid AND event_id = @eid AND is_booked = 0 FOR UPDATE", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@sid", seatId);
                    cmd.Parameters.AddWithValue("@eid", eventId);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        error = "This seat is no longer available.";
                        return false;
                    }
                    price = Convert.ToDecimal(result);
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    "UPDATE event_seats SET is_booked = 1, booked_at = NOW() WHERE id = @sid", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@sid", seatId);
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO tickets (user_id, event_id, seat_id, price, payment_method, status) " +
                    "VALUES (@uid, @eid, @sid, @price, @method, 'paid')", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@eid", eventId);
                    cmd.Parameters.AddWithValue("@sid", seatId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@method", paymentMethod);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                return true;
            }
        }

        public static List<Ticket> GetByUser(int userId)
        {
            List<Ticket> list = new List<Ticket>();
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT t.id, e.title, s.seat_number, t.price, t.payment_method, t.status, t.created_at " +
                "FROM tickets t " +
                "JOIN events e ON e.id = t.event_id " +
                "JOIN event_seats s ON s.id = t.seat_id " +
                "WHERE t.user_id = @uid ORDER BY t.created_at DESC", conn))
            {
                cmd.Parameters.AddWithValue("@uid", userId);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Ticket t = new Ticket();
                        t.Id = r.GetInt32(0);
                        t.EventTitle = r.GetString(1);
                        t.SeatNumber = r.GetString(2);
                        t.Price = r.GetDecimal(3);
                        t.PaymentMethod = r.GetString(4);
                        t.Status = r.GetString(5);
                        t.CreatedAt = r.GetDateTime(6);
                        t.UserId = userId;
                        list.Add(t);
                    }
                }
            }
            return list;
        }

        public static int CountSold()
        {
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tickets", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static decimal TotalRevenue()
        {
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand("SELECT COALESCE(SUM(price), 0) FROM tickets WHERE status = 'paid'", conn))
            {
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
    }
}
