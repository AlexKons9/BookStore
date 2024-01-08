using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }
        IBookService BookService { get; }
        ICustomerService CustomerService { get; }
        ILineItemService LineItemService { get; }
        IOrderService OrderService { get; }
    }
}
