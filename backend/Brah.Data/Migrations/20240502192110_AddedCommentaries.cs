using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentaries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_Commentaries_AuthorId",
                table: "Commentaries");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimePosted",
                value: new DateTime(2024, 5, 1, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Commentaries",
                columns: new[] { "Id", "ArticleId", "AuthorId", "ParentId", "Text", "TimePosted" },
                values: new object[,]
                {
                    { 1, 1, 1, null, "Как дела? Пока не родила", new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc) },
                    { 2, 1, 1, 1, "Как дела? Пока не родила", new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc) },
                    { 4, 1, 1, 1, "Как дела? Пока не родила", new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc) },
                    { 3, 1, 1, 2, "Как дела? Пока не родила", new DateTime(2024, 5, 2, 16, 42, 28, 0, DateTimeKind.Utc) },
                    { 5, 1, 1, 2, "Как дела? Пока не родила", new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaries_ParentId",
                table: "Commentaries",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_Commentaries_ParentId",
                table: "Commentaries",
                column: "ParentId",
                principalTable: "Commentaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_Commentaries_ParentId",
                table: "Commentaries");

            migrationBuilder.DropIndex(
                name: "IX_Commentaries_ParentId",
                table: "Commentaries");

            migrationBuilder.DeleteData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 604, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 604, DateTimeKind.Utc).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 604, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_Commentaries_AuthorId",
                table: "Commentaries",
                column: "AuthorId",
                principalTable: "Commentaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
