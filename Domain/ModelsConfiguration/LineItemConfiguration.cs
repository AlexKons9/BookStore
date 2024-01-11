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
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasData
            (
                new LineItem
                {
                    Id = Guid.Parse("0ae6ea82-63ad-4193-a9a3-ebb912482680"),
                    BookId = Guid.Parse("1cbb57f1-18fe-4a4e-940a-46ee74446cfd"),
                    OrderId = Guid.Parse("61f2320e-ef17-4d4a-aaee-9fc8c6489378"),
                    Price = 14
                }
            );
        }
    }
}
