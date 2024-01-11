using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelsConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
               new Book
               {
                   Id = Guid.Parse("368d434f-e257-44d1-900a-2cf0400a305e"),
                   Title = "The Mystery of the Blue Train",
                   Description = "The novel concerns the murder of an American heiress on Le Train Bleu, the titular \"Blue Train\".",
                   Genre = "Mystery",
                   ISBN = "9789605170684",
                   Price = 20, 
                   QuantityInStock = 0,
                   AuthorId = Guid.Parse("ac5c720d-bd21-4f2d-9dae-c1c79e1914ae")
               },
               new Book
               {
                   Id = Guid.Parse("1cbb57f1-18fe-4a4e-940a-46ee74446cfd"),
                   Title = "Murder on the Orient Express",
                   Description = "The elegant train of the 1930s, the Orient Express, is stopped by heavy snowfall. A murder is " +
                   "discovered, and Poirot's trip home to London from the Middle East is interrupted to solve the case.",
                   Genre = "Crime",
                   ISBN = "9780007119318",
                   Price = 14,
                   QuantityInStock = 1,
                   AuthorId = Guid.Parse("ac5c720d-bd21-4f2d-9dae-c1c79e1914ae")
               },
               new Book
               {
                   Id = Guid.Parse("c7b732dd-385e-4218-9799-873d82d1de12"),
                   Title = "The Mystery of the Blue Train ",
                   Description = "The novel concerns the murder of an American heiress on Le Train Bleu, the titular \"Blue Train\".",
                   Genre = "Mystery",
                   ISBN = "9789605170684",
                   Price = 20,
                   QuantityInStock = 0,
                   AuthorId = Guid.Parse("a42a1678-8578-495d-b475-cff6c99443bb")
               }
            );
        }
    }
}
