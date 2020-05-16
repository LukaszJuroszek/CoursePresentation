using System.Collections.Generic;

namespace UnitTestPresentation.Repository.Entities
{
    public class User : IEntitiy<int>
    {
        public int Id { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
