using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
        Author GetAuthorById(Guid Id, bool trackChanges);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
