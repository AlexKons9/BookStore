using Application.Services.Interfaces;
using Domain.Models;
using LoggingService.Interfaces;
using RepositoryInterfaces.RepositoryInterfaces;
using System.Linq.Expressions;

namespace Application.Services.Implementations
{
    public sealed class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public BookService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            try
            {
                var books = _repository.BookRepository.GetAllBooks(trackChanges);
                _logger.LogInfo("Got all books successfully!");
                return books;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllBooks)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public Book GetBookById(Guid id, bool trackChanges)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(Book), "x");
                var property = Expression.Property(parameter, "Id");
                var constant = Expression.Constant(id);
                var comparison = Expression.Equal(property, constant);
                var expresion = Expression.Lambda<Func<Book, bool>>(comparison, parameter);

                var book = _repository.BookRepository.GetBookByCondition(expresion, trackChanges);
                _logger.LogInfo($"Got book with Id: {id} successfully!");
                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetBookById)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void CreateBook(Book book)
        {
            try
            {
                _repository.BookRepository.CreateBook(book);
                _repository.SaveChanges();
                _logger.LogInfo($"Created Book with id: {book.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateBook)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                _repository.BookRepository.UpdateBook(book);
                _repository.SaveChanges();
                _logger.LogInfo($"Updated Book with id: {book.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateBook)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }

        public void DeleteBook(Book book)
        {
            try
            {
                _repository.BookRepository.DeleteBook(book);
                _repository.SaveChanges();
                _logger.LogInfo($"Deleted Book with id: {book.Id} successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteBook)} service method." +
                                 $"Exeption message: {ex.Message}");
                throw;
            }
        }
    }
}
