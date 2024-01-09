using Database;
using Domain.Models;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(x => x.Name).ToList();
        }

        public Customer GetCustomerByCondition(Expression<Func<Customer, bool>> expression, bool trackChanges)
        {
            return GetByCondition(expression, trackChanges).FirstOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }
    }
}
