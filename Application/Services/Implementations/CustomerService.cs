using Application.Services.Interfaces;
using Domain.Models;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System.Linq.Expressions;

namespace Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomerService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges)
        {
            try
            {
                var customers = _repository.CustomerRepository.GetAllCustomers(trackChanges);
                _logger.LogInfo("Got all customers successfully!");
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllCustomers)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public Customer GetCustomerById(Guid id, bool trackChanges)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(Customer), "x");
                var property = Expression.Property(parameter, "Id");
                var constant = Expression.Constant(id);
                var comparison = Expression.Equal(property, constant);
                var expresion = Expression.Lambda<Func<Customer, bool>>(comparison, parameter);

                var book = _repository.CustomerRepository.GetCustomerByCondition(expresion, trackChanges);
                _logger.LogInfo($"Got customer with Id: {id} successfully!");
                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetCustomerById)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void CreateCustomer(Customer customer)
        {
            try
            {
                _repository.CustomerRepository.CreateCustomer(customer);
                _repository.SaveChanges();
                _logger.LogInfo($"Created Customer with id: {customer.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateCustomer)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _repository.CustomerRepository.UpdateCustomer(customer);
                _repository.SaveChanges();
                _logger.LogInfo($"Updated Customer with id: {customer.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateCustomer)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            try
            {
                _repository.CustomerRepository.DeleteCustomer(customer);
                _repository.SaveChanges();
                _logger.LogInfo($"Deleted Book with id: {customer.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteCustomer)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }
    }
}
