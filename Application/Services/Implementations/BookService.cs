using Application.Services.Interfaces;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;

namespace Application.Services.Implementations
{
    public sealed class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public BookService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
