using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _service;

        public BookController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                var books = _service.BookService.GetAllBooks(false);
                return Ok(books);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            try
            {
                var book = _service.BookService.GetBookById(id,true);
                return Ok(book);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest(new { Value = "Book data is null." });
                }

                _service.BookService.CreateBook(book);
                return CreatedAtAction("GetBookById", new { id = book.Id }, book);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(Guid id, [FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest(new { Value = "Book data is null." });
                }

                var existingBook = _service.BookService.GetBookById(id, true);

                if (existingBook == null)
                {
                    return NotFound(new { Value = $"Book with ID {id} not found." });
                }

                _service.BookService.UpdateBook(existingBook);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            try
            {
                var existingBook = _service.BookService.GetBookById(id, true);

                if (existingBook == null)
                {
                    return NotFound(new { Value = $"Book with ID {id} not found." });
                }

                // Replace the logic to delete the existing book using the service
                _service.BookService.DeleteBook(existingBook);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }
    }
}
