using Domain.Models;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface ILineItemRepository
    {
        IEnumerable<LineItem> GetAllLineItems(bool trackChanges);
        LineItem GetLineItemByCondition(Expression<Func<LineItem, bool>> expression, bool trackChanges);
        void CreateLineItem(LineItem author);
        void UpdateLineItem(LineItem author);
        void DeleteLineItem(LineItem author);
    }
}
