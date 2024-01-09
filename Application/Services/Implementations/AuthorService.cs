using Application.Services.Interfaces;
using Domain.Models;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System.Linq.Expressions;

namespace Application.Services.Implementations
{
    public sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public AuthorService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Author> GetAllAuthors(bool trackChanges)
        {
            try
            {
                var authors = _repository.AuthorRepository.GetAllAuthors(trackChanges);
                _logger.LogInfo("Got all authors successfully!");
                return authors;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public Author GetAuthorById(Guid id, bool trackChanges)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(Author), "x");
                var property = Expression.Property(parameter, "Id");
                var constant = Expression.Constant(id);
                var comparison = Expression.Equal(property, constant);
                var expresion = Expression.Lambda<Func<Author, bool>>(comparison, parameter);

                var author = _repository.AuthorRepository.GetAuthorByCondition(expresion, trackChanges);
                _logger.LogInfo($"Got author with Id: {id} successfully!");
                return author;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAuthorById)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }
        public void CreateAuthor(Author author)
        {
            try
            {
                _repository.AuthorRepository.CreateAuthor(author);
                _repository.SaveChanges();
                _logger.LogInfo($"Created Author with id: {author.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateAuthor)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void UpdateAuthor(Author author)
        {
            try
            {
                _repository.AuthorRepository.UpdateAuthor(author);
                _repository.SaveChanges();
                _logger.LogInfo($"Updated Author with id: {author.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateAuthor)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void DeleteAuthor(Author author)
        {
            try
            {
                _repository.AuthorRepository.DeleteAuthor(author);
                _repository.SaveChanges();
                _logger.LogInfo($"Deleted Author with id: {author.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteAuthor)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }
    }
}
