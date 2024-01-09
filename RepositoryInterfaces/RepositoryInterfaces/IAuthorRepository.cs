using Domain.Models;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
        Author GetAuthorByCondition(Expression<Func<Author, bool>> expression, bool trackChanges);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
