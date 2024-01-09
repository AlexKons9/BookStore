using Database;
using Domain.Models;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(x => x.Title).ToList();
        }

        public Book GetBookByCondition(Expression<Func<Book, bool>> expression, bool trackChanges)
        {
            return GetByCondition(expression, trackChanges).FirstOrDefault();
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
        }
    }
}
