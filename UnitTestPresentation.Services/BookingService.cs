using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestPresentation.DAL;
using UnitTestPresentation.DAL.Entities;

namespace UnitTestPresentation.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetUserBookings(int userId);
        IEnumerable<BookingEvent> GetBookingEventsForAppliactionType(ApplicationType type);
        void Book(User user, BookingEvent bookingEvent);
    }

    public class BookingService : IBookingService
    {
        private readonly IRepository _repository;

        public BookingService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Booking> GetUserBookings(int userId)
        {
            var user = _repository.Find<User>(x => x.Id == userId);

            if (user != null)
            {
                return _repository.All<Booking>()
                                  .Where(x => x.User.Id == user.Id && x.BookingDate < DateTime.UtcNow);
            }

            return Enumerable.Empty<Booking>();
        }

        public IEnumerable<BookingEvent> GetBookingEventsForAppliactionType(ApplicationType type)
        {
            return _repository.All<BookingEvent>().Where(x => x.ApplicationType == type && x.Date < DateTime.UtcNow);
        }

        public void Book(User user, BookingEvent bookingEvent)
        {
            var booking = new Booking
            {
                User = user,
                BookingEvent = bookingEvent,
                BookingDate = DateTime.UtcNow
            };

            _repository.Add(booking);
        }
    }
}
