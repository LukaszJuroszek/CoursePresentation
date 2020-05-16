using System.Collections.Generic;

namespace UnitTestPresentation.Repository.Entities
{
    public class BookingEvent : IEntitiy<int>
    {
        public int Id { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
