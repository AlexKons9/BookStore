using Domain.Abstractions;

namespace Domain.Models
{
    public class Order : Entity
    {
        public Guid CustomerId { get; set; }
        public HashSet<LineItem> LineItems {  get;  set; }
    }
}
