using Domain.Models;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(bool trackChanges);
        Order GetOrderByCondition(Expression<Func<Order, bool>> expression, bool trackChanges);
        void CreateOrder(Order author);
        void UpdateOrder(Order author);
        void DeleteOrder(Order author);
    }
}
