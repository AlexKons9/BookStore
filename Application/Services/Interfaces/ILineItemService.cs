using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ILineItemService
    {
        IEnumerable<LineItem> GetAllLineItems(bool trackChanges);
        LineItem GetLineItemById(Guid Id, bool trackChanges);
        void CreateLineItem(LineItem lineItem);
        void UpdateLineItem(LineItem lineItem);
        void DeleteLineItem(LineItem lineItem);
    }
}
