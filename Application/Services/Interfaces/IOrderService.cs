using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders(bool trackChanges);
        Order GetOrderById(Guid Id, bool trackChanges);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
