using System;

namespace StadiumMS.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int SeatId { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public string EventTitle { get; set; }
        public string SeatNumber { get; set; }
    }
}
