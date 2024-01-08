using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ILineItemRepository LineItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task SaveChangesAsync();
    }
}
