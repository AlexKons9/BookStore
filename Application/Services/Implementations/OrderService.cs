using Application.Services.Interfaces;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;

namespace Application.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public OrderService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
