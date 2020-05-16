using UnitTestPresentation.Repository;

namespace UnitTestPresentation.Services
{
    public class BookService
    {
        private readonly IRepository _repository;

        public BookService(IRepository repository)
        {
            _repository = repository;
        }

    }
}
