using Microsoft.EntityFrameworkCore;
using UnitTestPresentation.Repository.Entities;

namespace UnitTestPresentation.Repository
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
