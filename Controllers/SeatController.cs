using System;
using System.Collections.Generic;
using MySqlConnector;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Controllers
{
    public static class SeatController
    {
        public static List<EventSeat> GetAvailable(int eventId)
        {
            List<EventSeat> list = new List<EventSeat>();
            using (MySqlConnection conn = Db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT id, event_id, seat_number, price FROM event_seats WHERE event_id = @id AND is_booked = 0 ORDER BY id", conn))
            {
                cmd.Parameters.AddWithValue("@id", eventId);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        EventSeat s = new EventSeat();
                        s.Id = r.GetInt32(0);
                        s.EventId = r.GetInt32(1);
                        s.SeatNumber = r.GetString(2);
                        s.Price = r.GetDecimal(3);
                        s.IsBooked = false;
                        list.Add(s);
                    }
                }
            }
            return list;
        }
    }
}
