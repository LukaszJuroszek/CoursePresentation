using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using UnitTestPresentation.DAL;
using UnitTestPresentation.DAL.Entities;
using UnitTestPresentation.Services;
using UnitTestPresentation.Web.Controllers;
using UnitTestPresentation.Web.Models;

namespace UnitTestPresentation.Tests
{
    //https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/
    [TestFixture]
    public class BookingControllerUt
    {
        //private IBookingService _sut;
        private Mock<IRepository> _repository;
        private Mock<ILogger<BookingController>> _logger;
        private Mock<IBookingService> _bookingService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IRepository>();
            _logger = new Mock<ILogger<BookingController>>();
            _bookingService = new Mock<IBookingService>();
        }

        [Test]
        public void BookingController_Should_Create_A_Booking()
        {
            //Arange
            var bookingEventId = 1;
            var userId = 1;
            _repository.Setup(x => x.Find(It.IsAny<Expression<Func<BookingEvent, bool>>>()))
                .Returns(new BookingEvent { Id = bookingEventId, ApplicationType = ApplicationType.Web, });

            _repository.Setup(x => x.Find(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User { Id = userId,Name = "jonh" });

            var sut = new BookingController(_logger.Object, _bookingService.Object, _repository.Object);
            var booking = new BookingViewModel { BookingEventId = bookingEventId, UserId = userId };

            //Act
            var result = sut.Book(booking);
            var status = result as OkResult;

            //Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(200, status.StatusCode);
        }
    }
}
