using System;

namespace StadiumMS.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int MaxTickets { get; set; }

        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}
