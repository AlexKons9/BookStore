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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
            (
                new Customer
                {
                    Id = Guid.Parse("e02d616f-2d1f-4aa4-9cb6-0c865eb29b49"),
                    Name = "John Wick",
                    Email = "j.wick@gmail.com"
                },
                new Customer
                {
                    Id = Guid.Parse("a918a23b-0b73-41ea-9e2b-9b270bfb5a14"),
                    Name = "Nick Smith",
                    Email = "n.smith@gmail.com"
                }
            );
        }
    }
}
