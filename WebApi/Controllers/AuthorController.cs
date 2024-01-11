using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthorController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            try
            {
                var authors = _service.AuthorService.GetAllAuthors(false);
                return Ok(authors);
            }
            catch 
            {
                return StatusCode(500, new { Value = "Internal server error."});
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            try
            {
                var author = _service.AuthorService.GetAuthorById(id,false);
                return Ok(author);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpPost]
        public IActionResult PostAuthor([FromBody] Author author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest(new { Value = "Author data is null." });
                }

                _service.AuthorService.CreateAuthor(author);
                return CreatedAtAction("GetAuthorById", new { id = author.Id }, author);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutAuthor(Guid id, [FromBody] Author author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest(new { Value = "Author data is null." });
                }

                var existingAuthor = _service.AuthorService.GetAuthorById(id, trackChanges: true);

                if (existingAuthor == null)
                {
                    return NotFound(new { Value = $"Author with ID {id} not found." });
                }

                _service.AuthorService.UpdateAuthor(existingAuthor);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            try
            {
                var existingAuthor = _service.AuthorService.GetAuthorById(id, trackChanges: true);

                if (existingAuthor == null)
                {
                    return NotFound(new { Value = $"Author with ID {id} not found." });
                }

                _service.AuthorService.DeleteAuthor(existingAuthor);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }
    }
}
