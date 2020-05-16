using Moq;
using NUnit.Framework;
using UnitTestPresentation.Repository;
using UnitTestPresentation.Repository.Entities;
using UnitTestPresentation.Services;

namespace UnitTestPresentation.Tests
{
    //https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/
    [TestFixture]
    public class UserServiceUt
    {
        private IUserService _sut;
        private Mock<IRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IRepository>();
            _sut = new UserService(_repository.Object);
        }

        [Test]
        public void UserService_Should_Add_Next_Id_For_User()
        {
            //Arange
            var user = new User { Name = "Very test" };
            //Act
            _sut.AddUser(user);
            _sut.AddUser(user);
            //Assert
            Assert.That(user.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void UserService_Should_Add_Nsext_Id_For_User()
        {
            //Arange
            var user = new User { Name = "Very test" };
            //Act
            _sut.AddUser(user);
            //Assert
            Assert.That(user.Id, Is.Not.EqualTo(0));
        }
    }
}
