using Microsoft.EntityFrameworkCore;
using UnitTestPresentation.DAL.Entities;

namespace UnitTestPresentation.DAL
{
    public class PresentationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingEvent> BookingEvent { get; set; }

        public PresentationDbContext(DbContextOptions<PresentationDbContext> options) : base(options)
        {

        }
    }
}
