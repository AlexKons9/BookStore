using Application.Services.Interfaces;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
