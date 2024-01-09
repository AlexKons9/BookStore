using Domain.Models;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book GetBookByCondition(Expression<Func<Book, bool>> expression, bool trackChanges);
        void CreateBook(Book author);
        void UpdateBook(Book author);
        void DeleteBook(Book author);
    }
}
