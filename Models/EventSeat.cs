using System;

namespace StadiumMS.Models
{
    public class EventSeat
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsBooked { get; set; }
        public DateTime? BookedAt { get; set; }
    }
}
