using System;
using System.Collections.Generic;

namespace UnitTestPresentation.DAL.Entities
{
    public class BookingEvent : IEntitiy<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Booking> Bookings { get; set; }
        public ApplicationType ApplicationType { get; set; }
    }

    public enum ApplicationType
    {
        Unknow = 0,
        Mobile,
        Web
    }
}
