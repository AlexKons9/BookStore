using Database;
using Domain.Models;
using RepositoryInterfaces;
using System.Linq.Expressions;


namespace Infrastructure.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Author> GetAllAuthors(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(x => x.LastName).ToList();
        }

        public Author GetAuthorByCondition(Expression<Func<Author, bool>> expression, bool trackChanges)
        {
            return GetByCondition(expression, trackChanges).FirstOrDefault();
        }

        public void CreateAuthor(Author author)
        {
            Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            Delete(author);
        }
    }
}
