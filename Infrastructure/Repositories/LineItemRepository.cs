using Database;
using Domain.Models;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LineItemRepository : RepositoryBase<LineItem>, ILineItemRepository
    {
        public LineItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
