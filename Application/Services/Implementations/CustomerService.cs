using Application.Services.Interfaces;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;

namespace Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomerService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
