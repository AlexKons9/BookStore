using Domain.Abstractions;

namespace Domain.Models
{
    public class LineItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid BookId { get; private set; }
        public decimal Price { get; private set; }

        public LineItem(Guid id, Guid orderId, Guid productId, decimal price)
        {
            Id = id;
            OrderId = orderId;
            BookId = productId;
            Price = price;
        }
    }
}
