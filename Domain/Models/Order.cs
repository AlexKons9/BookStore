using Domain.Abstractions;

namespace Domain.Models
{
    public class Order : ΤEntity
    {
        public Guid CustomerId { get; set; }
        public HashSet<LineItem> LineItems {  get;  set; }
    }
}
