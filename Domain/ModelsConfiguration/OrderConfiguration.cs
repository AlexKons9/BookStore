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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData
            (
                new Order
                {
                    Id = Guid.Parse("61f2320e-ef17-4d4a-aaee-9fc8c6489378"),
                    CustomerId = Guid.Parse("a918a23b-0b73-41ea-9e2b-9b270bfb5a14"),
                }
            );
        }
    }
}
