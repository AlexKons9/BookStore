using Domain.Abstractions;

namespace Domain.Models
{
    public class LineItem : ΤEntity
    {
        public Order Order { get; private set; }
        public Book Book { get; private set; }
        public decimal Price { get; private set; }

    }
}
