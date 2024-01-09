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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetAllOrders(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(x => x.Id).ToList();
        }

        public Order GetOrderByCondition(Expression<Func<Order, bool>> expression, bool trackChanges)
        {
            return GetByCondition(expression, trackChanges).FirstOrDefault();
        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }
    }
}
