using Domain.Abstractions;

namespace Domain.Models
{
    public class Book : ΤEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }

        public Book()
        {
        }

        public Book(string title, string description, Author author, string isbn, string gengre, int quantityInStock, decimal price ) 
        {
            title = Title;
            Description = description;
            Author = author;
            ISBN = isbn;
            Genre = gengre;
            QuantityInStock = quantityInStock;
            Price = price;
        }
    }
}
