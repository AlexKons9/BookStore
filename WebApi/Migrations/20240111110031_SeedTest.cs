using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("69e29edb-eab1-442d-8946-dc091f8cb456"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d35775ab-577a-461c-bc5f-2b26c1b2ff6c"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("a42a1678-8578-495d-b475-cff6c99443bb"), "William Shakespeare (bapt.Tooltip baptised 26[a] April 1564 – 23 April 1616)[b] was an English playwright, poet and actor. He is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist.[3][4][5] He is often called England's national poet and the \"Bard of Avon\" (or simply \"the Bard\"). His extant works, including collaborations, consist of some 39 plays, 154 sonnets, three long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright.[6] Shakespeare remains arguably the most influential writer in the English language, and his works continue to be studied and reinterpreted.", "William", "Shakespeare" },
                    { new Guid("ac5c720d-bd21-4f2d-9dae-c1c79e1914ae"), "Dame Agatha Mary Clarissa Christie, Lady Mallowan, DBE (née Miller; 15 September 1890 – 12 January 1976) was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple. She also wrote the world's longest-running play, the murder mystery The Mousetrap, which has been performed in the West End since 1952. A writer during the \"Golden Age of Detective Fiction\", Christie has been called the \"Queen of Crime\". She also wrote six novels under the pseudonym Mary Westmacott. In 1971, she was made a Dame (DBE) by Queen Elizabeth II for her contributions to literature. Guinness World Records lists Christie as the best-selling fiction writer of all time, her novels having sold more than two billion copies.", "Agatha", "Cristie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a42a1678-8578-495d-b475-cff6c99443bb"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("ac5c720d-bd21-4f2d-9dae-c1c79e1914ae"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("69e29edb-eab1-442d-8946-dc091f8cb456"), "William Shakespeare (bapt.Tooltip baptised 26[a] April 1564 – 23 April 1616)[b] was an English playwright, poet and actor. He is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist.[3][4][5] He is often called England's national poet and the \"Bard of Avon\" (or simply \"the Bard\"). His extant works, including collaborations, consist of some 39 plays, 154 sonnets, three long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright.[6] Shakespeare remains arguably the most influential writer in the English language, and his works continue to be studied and reinterpreted.", "William", "Shakespeare" },
                    { new Guid("d35775ab-577a-461c-bc5f-2b26c1b2ff6c"), "Dame Agatha Mary Clarissa Christie, Lady Mallowan, DBE (née Miller; 15 September 1890 – 12 January 1976) was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple. She also wrote the world's longest-running play, the murder mystery The Mousetrap, which has been performed in the West End since 1952. A writer during the \"Golden Age of Detective Fiction\", Christie has been called the \"Queen of Crime\". She also wrote six novels under the pseudonym Mary Westmacott. In 1971, she was made a Dame (DBE) by Queen Elizabeth II for her contributions to literature. Guinness World Records lists Christie as the best-selling fiction writer of all time, her novels having sold more than two billion copies.", "Agatha", "Cristie" }
                });
        }
    }
}
