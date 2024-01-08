using Application.Services.Interfaces;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;

namespace Application.Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<ILineItemService> _lineItemService;
        private readonly Lazy<IOrderService> _orderService;

        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public ICustomerService CustomerService => _customerService.Value;
        public ILineItemService LineItemService => _lineItemService.Value;
        public IOrderService OrderService => _orderService.Value;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager, logger));
            _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, logger));
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, logger));
            _lineItemService = new Lazy<ILineItemService>(() => new LineItemService(repositoryManager, logger));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, logger));
        }
    }
}
