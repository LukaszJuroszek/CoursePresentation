using Moq;
using NUnit.Framework;
using System.Linq;
using UnitTestPresentation.DAL;
using UnitTestPresentation.DAL.Entities;
using UnitTestPresentation.Services;

namespace UnitTestPresentation.Tests
{
    //https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/
    [TestFixture]
    public class BookingServiceUt
    {
        private IBookingService _sut;
        private Mock<IRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IRepository>();
            _sut = new BookingService(_repository.Object);
        }

        [Test]
        public void BookingService_Should_Get_All_BookingEvents_For_ApplicationType()
        {
            //Arange
            var user = new User { Name = "Very test" };
            var applicationType = ApplicationType.Web;
            var expectedCount = 1;

            //Act
            var result = _sut.GetBookingEventsForAppliactionType(applicationType);

            //Assert
            //TODO:
            //Assert.That(result.Count(x => x.ApplicationType == applicationType), Has.Exactly(expectedCount));
            //Assert.That(result.Count(x => x.ApplicationType == applicationType), Has.Exactly(expectedCount));
        }
    }
}
