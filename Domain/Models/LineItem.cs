using Domain.Abstractions;

namespace Domain.Models
{
    public class LineItem : ΤEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public decimal Price { get; set; }

    }
}
