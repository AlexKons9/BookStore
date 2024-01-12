using Application.Services.Interfaces;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace UnitTests.Controllers
{
    public class AuthorControllerTests
    {
        private AuthorController _authorController;
        private IServiceManager _serviceManager;
        public AuthorControllerTests()
        {
            _serviceManager = A.Fake<IServiceManager>();
            // SUT "System Under Test"
            _authorController = new AuthorController(_serviceManager);
        }

        

        [Fact]
        public void AuthorController_GetAllAuthors_ReturnSuccess()
        {
            //Arrange
            var authors = A.Fake<IEnumerable<Author>>();
            A.CallTo(() => _serviceManager.AuthorService.GetAllAuthors(false)).Returns(authors);

            //Act
            var result = _authorController.GetAuthors();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
        }

        [Fact]
        public void AuthorController_GetAllAuthorById_ReturnSuccess()
        {
            //Arrange
            var id = Guid.NewGuid();
            var author = new Author
            {
                Biography = ""
            };

            A.CallTo(() => _serviceManager.AuthorService.GetAuthorById(id, true)).Returns(author);

            //Act
            var result = _authorController.GetAuthors();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
        }

        [Fact]
        public void AuthorController_PostAuthor_ReturnSuccess()
        {
            //Arrange
            var author = A.Fake<Author>();
            A.CallTo(() => _serviceManager.AuthorService.CreateAuthor(author));

            //Act
            var result = _authorController.PostAuthor(author);

            //Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void AuthorController_PutAuthor_ReturnSuccess()
        {
            //Arrange
            var author = A.Fake<Author>();
            var id = Guid.NewGuid();
            A.CallTo(() => _serviceManager.AuthorService.GetAuthorById(id, true)).Returns(author);
            author.Biography = "Updated Bio";
            A.CallTo(() => _serviceManager.AuthorService.UpdateAuthor(author));

            //Act
            var result = _authorController.PutAuthor(id, author);

            //Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void AuthorController_DeleteAuthor_ReturnSuccess()
        {
            //Arrange
            var author = A.Fake<Author>();
            var id = Guid.NewGuid();
            A.CallTo(() => _serviceManager.AuthorService.GetAuthorById(id, true)).Returns(author);
            A.CallTo(() => _serviceManager.AuthorService.DeleteAuthor(author));

            //Act
            var result = _authorController.DeleteAuthor(id);

            //Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void AuthorController_DeleteAuthor_ReturnStatusCode500()
        {
            // Arrange
            var author = A.Fake<Author>();
            var id = Guid.NewGuid();
            A.CallTo(() => _serviceManager.AuthorService.GetAuthorById(id, true)).Throws(new Exception());
            A.CallTo(() => _serviceManager.AuthorService.DeleteAuthor(author));
            var expectedObject = new ObjectResult(new { Value = "Internal server error." });
            expectedObject.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Act
            var result = _authorController.DeleteAuthor(id);

            // Assert
            result.Should().BeOfType<ObjectResult>().Which
                  .Should().BeEquivalentTo(expectedObject);
        }
    }
}
