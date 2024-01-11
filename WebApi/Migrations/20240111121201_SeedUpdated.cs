using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("a918a23b-0b73-41ea-9e2b-9b270bfb5a14"), "n.smith@gmail.com", "Nick Smith" },
                    { new Guid("e02d616f-2d1f-4aa4-9cb6-0c865eb29b49"), "j.wick@gmail.com", "John Wick" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId" },
                values: new object[] { new Guid("61f2320e-ef17-4d4a-aaee-9fc8c6489378"), new Guid("a918a23b-0b73-41ea-9e2b-9b270bfb5a14") });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "BookId", "OrderId", "Price" },
                values: new object[] { new Guid("0ae6ea82-63ad-4193-a9a3-ebb912482680"), new Guid("1cbb57f1-18fe-4a4e-940a-46ee74446cfd"), new Guid("61f2320e-ef17-4d4a-aaee-9fc8c6489378"), 14m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e02d616f-2d1f-4aa4-9cb6-0c865eb29b49"));

            migrationBuilder.DeleteData(
                table: "LineItems",
                keyColumn: "Id",
                keyValue: new Guid("0ae6ea82-63ad-4193-a9a3-ebb912482680"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("61f2320e-ef17-4d4a-aaee-9fc8c6489378"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a918a23b-0b73-41ea-9e2b-9b270bfb5a14"));
        }
    }
}
