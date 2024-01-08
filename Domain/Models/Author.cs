using Domain.Abstractions;

namespace Domain.Models
{
    public class Author : ΤEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Biography { get; set; }
        public List<Book> Books { get; set; }

    }
}
