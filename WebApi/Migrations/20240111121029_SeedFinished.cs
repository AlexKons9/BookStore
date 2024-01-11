using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedFinished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("79c16101-1408-4155-8869-54abe18a1734"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "ISBN", "Price", "QuantityInStock", "Title" },
                values: new object[,]
                {
                    { new Guid("1cbb57f1-18fe-4a4e-940a-46ee74446cfd"), new Guid("ac5c720d-bd21-4f2d-9dae-c1c79e1914ae"), "The elegant train of the 1930s, the Orient Express, is stopped by heavy snowfall. A murder is discovered, and Poirot's trip home to London from the Middle East is interrupted to solve the case.", "Crime", "9780007119318", 14m, 1, "Murder on the Orient Express" },
                    { new Guid("368d434f-e257-44d1-900a-2cf0400a305e"), new Guid("ac5c720d-bd21-4f2d-9dae-c1c79e1914ae"), "The novel concerns the murder of an American heiress on Le Train Bleu, the titular \"Blue Train\".", "Mystery", "9789605170684", 20m, 0, "The Mystery of the Blue Train" },
                    { new Guid("c7b732dd-385e-4218-9799-873d82d1de12"), new Guid("a42a1678-8578-495d-b475-cff6c99443bb"), "The novel concerns the murder of an American heiress on Le Train Bleu, the titular \"Blue Train\".", "Mystery", "9789605170684", 20m, 0, "The Mystery of the Blue Train " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1cbb57f1-18fe-4a4e-940a-46ee74446cfd"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("368d434f-e257-44d1-900a-2cf0400a305e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c7b732dd-385e-4218-9799-873d82d1de12"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "ISBN", "Price", "QuantityInStock", "Title" },
                values: new object[] { new Guid("79c16101-1408-4155-8869-54abe18a1734"), new Guid("a42a1678-8578-495d-b475-cff6c99443bb"), null, null, null, 0m, 0, "Book Christie" });
        }
    }
}
