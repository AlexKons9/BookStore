using Database;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Repositories
{
    public class AuthorRepositoryTests
    {
        private AuthorRepository _authorRepository;
        private AppDbContext _appDbContext;

        public AuthorRepositoryTests()
        {
            _appDbContext = GetDbContext().GetAwaiter().GetResult();
            _authorRepository = new AuthorRepository(_appDbContext);
        }

        private async Task<AppDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var dbContext = new AppDbContext(options);
            dbContext.Database.EnsureCreated();
            return await AddTestingSeed(dbContext);
        }

        // Note that we have extra Entities seedeed (through OnModelCreating method)
        // when the AppdbContext is being created. This is an example of adding seed
        private async Task<AppDbContext> AddTestingSeed(AppDbContext context)
        {
            await context.Authors.AddAsync
            (
                new Domain.Models.Author
                {
                    Id = Guid.Parse("2c9c3ac7-607a-4639-b9fc-e766250b93f1"),
                    FirstName = "John",
                    LastName = "Smith",
                    Biography = "some Bio",
                    Books = new List<Domain.Models.Book>
                    {
                        new Domain.Models.Book
                        {
                            Id = Guid.Parse("3bf54ed1-a536-4804-9cd4-190590ca01be"),
                            AuthorId = Guid.Parse("2c9c3ac7-607a-4639-b9fc-e766250b93f1"),
                            Title = "Title of Book",
                            Description = "Description",
                            Genre = "Drama",
                            Price = 20,
                            QuantityInStock = 57,
                            ISBN = "9781844252800"
                        },
                        new Domain.Models.Book
                        {
                            Id = Guid.Parse("9a0cea27-3708-4717-90fc-60031eb55880"),
                            AuthorId = Guid.Parse("2c9c3ac7-607a-4639-b9fc-e766250b93f1"),
                            Title = "Title of Book 2",
                            Description = "Description 2",
                            Genre = "Mystery",
                            Price = 17,
                            QuantityInStock = 40,
                            ISBN = "2370878742753"
                        }
                    }
                }
            );
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public void AuthorRepository_GetById_Success()
        {
            //Arrange
            Guid id = Guid.Parse("2c9c3ac7-607a-4639-b9fc-e766250b93f1");

            //Act
            var result = _authorRepository.GetByCondition(x => x.Id == id, true);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Fact]
        public void AuthorRepository_GetAll_Success()
        {
            //Arrange

            //Act
            var result = _authorRepository.GetAllAuthors(false);
          
            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Author>>();
            result.Should().BeOfType<List<Author>>();
        }
    }
}
