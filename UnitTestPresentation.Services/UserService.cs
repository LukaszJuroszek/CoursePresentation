using UnitTestPresentation.Repository;
using UnitTestPresentation.Repository.Entities;

namespace UnitTestPresentation.Services
{
    public interface IUserService
    {
        User AddUser(User user);
    }

    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public User AddUser(User user)
        {
            _repository.Add(user);

            return user;
        }
    }
}
