using System.Collections.Generic;

namespace UnitTestPresentation.DAL.Entities
{
    public class User : IEntitiy<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
