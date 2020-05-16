using System;

namespace UnitTestPresentation.Repository.Entities
{
    public class Booking : IEntitiy<int>
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingEvent BookingEvent { get; set; }
        public User User{ get; set; }
    }
}
