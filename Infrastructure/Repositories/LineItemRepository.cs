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
    public class LineItemRepository : RepositoryBase<LineItem>, ILineItemRepository
    {
        public LineItemRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<LineItem> GetAllLineItems(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(x => x.Id).ToList();
        }

        public LineItem GetLineItemByCondition(Expression<Func<LineItem, bool>> expression, bool trackChanges)
        {
            return GetByCondition(expression, trackChanges).FirstOrDefault();
        }

        public void CreateLineItem(LineItem lineItem)
        {
            Create(lineItem);
        }

        public void UpdateLineItem(LineItem lineItem)
        {
            Update(lineItem);
        }

        public void DeleteLineItem(LineItem lineItem)
        {
            Delete(lineItem);
        }
    }
}
