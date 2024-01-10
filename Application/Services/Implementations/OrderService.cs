using Application.Services.Interfaces;
using Domain.Models;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System.Linq.Expressions;

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

        public IEnumerable<Order> GetAllOrders(bool trackChanges)
        {
            try
            {
                var orders = _repository.OrderRepository.GetAllOrders(trackChanges);
                _logger.LogInfo("Got all orders successfully!");
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllOrders)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public Order GetOrderById(Guid id, bool trackChanges)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(Order), "x");
                var property = Expression.Property(parameter, "Id");
                var constant = Expression.Constant(id);
                var comparison = Expression.Equal(property, constant);
                var expresion = Expression.Lambda<Func<Order, bool>>(comparison, parameter);

                var order = _repository.OrderRepository.GetOrderByCondition(expresion, trackChanges);
                _logger.LogInfo($"Got order with Id: {id} successfully!");
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetOrderById)} service method." +
                                 $"Exception message: {ex.Message}");
                throw;
            }
        }

        public void CreateOrder(Order order)
        {
            try
            {
                _repository.OrderRepository.CreateOrder(order);
                _repository.SaveChanges();
                _logger.LogInfo($"Created order with id: {order.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateOrder)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                _repository.OrderRepository.UpdateOrder(order);
                _repository.SaveChanges();
                _logger.LogInfo($"Updated order with id: {order.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateOrder)} service method." +
                                 $"Exception message: {ex.Message}");
                throw;
            }
        }

        public void DeleteOrder(Order order)
        {
            try
            {
                _repository.OrderRepository.DeleteOrder(order);
                _repository.SaveChanges();
                _logger.LogInfo($"Deleted order with id: {order.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteOrder)} service method." +
                                 $"Exception message: {ex.Message}");
                throw;
            }
        }
    }
}
