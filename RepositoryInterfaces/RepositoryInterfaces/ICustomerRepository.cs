using Domain.Models;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface ICustomerRepository 
    {
        IEnumerable<Customer> GetAllCustomers(bool trackChanges);
        Customer GetCustomerByCondition(Expression<Func<Customer, bool>> expression, bool trackChanges);
        void CreateCustomer(Customer author);
        void UpdateCustomer(Customer author);
        void DeleteCustomer(Customer author);
    }
}
