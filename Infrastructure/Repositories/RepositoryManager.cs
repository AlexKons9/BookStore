using Database;
using RepositoryInterfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<ILineItemRepository> _lineItemRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;

        public IAuthorRepository AuthorRepository => _authorRepository.Value;
        public IBookRepository BookRepository => _bookRepository.Value;
        public ICustomerRepository CustomerRepository => _customerRepository.Value;
        public ILineItemRepository LineItemRepository => _lineItemRepository.Value;
        public IOrderRepository OrderRepository => _orderRepository.Value;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
            _lineItemRepository = new Lazy<ILineItemRepository>(() => new LineItemRepository(_context));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_context));

        }

        public void SaveChanges() => _context.SaveChangesAsync();
    }
}
