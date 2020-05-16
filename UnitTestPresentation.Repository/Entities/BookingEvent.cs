using System;
using System.Collections.Generic;

namespace UnitTestPresentation.Repository.Entities
{
    public class BookingEvent : IEntitiy<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
