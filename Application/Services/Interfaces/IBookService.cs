using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book GetBookById(Guid Id, bool trackChanges);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
