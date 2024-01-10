using Application.Services.Interfaces;
using Domain.Models;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class LineItemService : ILineItemService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public LineItemService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<LineItem> GetAllLineItems(bool trackChanges)
        {
            try
            {
                var lineItems = _repository.LineItemRepository.GetAllLineItems(trackChanges);
                _logger.LogInfo("Got all LineItems successfully!");
                return lineItems;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllLineItems)} service method." +
                                 $"Exception message: {ex.Message}");
                throw;
            }
        }

        public LineItem GetLineItemById(Guid id, bool trackChanges)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(LineItem), "x");
                var property = Expression.Property(parameter, "Id");
                var constant = Expression.Constant(id);
                var comparison = Expression.Equal(property, constant);
                var expresion = Expression.Lambda<Func<LineItem, bool>>(comparison, parameter);

                var lineItem = _repository.LineItemRepository.GetLineItemByCondition(expresion, trackChanges);
                _logger.LogInfo($"Got lineItem with Id: {id} successfully!");
                return lineItem;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetLineItemById)} service method." +
                                 $"Exception message: {ex.Message}");
                throw;
            }
        }

        public void CreateLineItem(LineItem lineItem)
        {
            try
            {
                _repository.LineItemRepository.CreateLineItem(lineItem);
                _repository.SaveChanges();
                _logger.LogInfo($"Created LineItem with id: {lineItem.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateLineItem)} service method." +
                                 $"Exception message: {ex.Message}");
                throw;
            }
        }

        public void UpdateLineItem(LineItem lineItem)
        {
            try
            {
                _repository.LineItemRepository.UpdateLineItem(lineItem);
                _repository.SaveChanges();
                _logger.LogInfo($"Updated LineItem with id: {lineItem.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateLineItem)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void DeleteLineItem(LineItem lineItem)
        {
            try
            {
                _repository.LineItemRepository.DeleteLineItem(lineItem);
                _repository.SaveChanges();
                _logger.LogInfo($"Deleted LineItem with id: {lineItem.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteLineItem)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }
    }
}
