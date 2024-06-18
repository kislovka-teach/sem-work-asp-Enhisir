using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Different 1" },
                    { 2, "Different 2" },
                    { 3, "Different 3" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Разработка" },
                    { 2, "Администрирование" },
                    { 3, "Дизайн" },
                    { 4, "Менеждмент" },
                    { 5, "Маркетинг" },
                    { 6, "Разное" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarLink", "FirstName", "LastName", "PasswordHashed", "Role", "UserName" },
                values: new object[] { 1, "https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd", "Nikolay", "Rerich", "DefaultPassword", 0, "DeadWeight47" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Karma", "Text", "TimePosted", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, 1, 15, "example example example example example example example example example example example example example example example example example example example example example example example example example", new DateTime(2024, 5, 2, 16, 41, 28, 604, DateTimeKind.Utc).AddTicks(6418), "Text example", 1 },
                    { 2, 1, 15, "example example example example example example example example example example example example example example example example example example example example example example example example example", new DateTime(2024, 5, 2, 16, 41, 28, 604, DateTimeKind.Utc).AddTicks(6426), "Text example 2", 1 },
                    { 3, 1, 15, "example example example example example example example example example example example example example example example example example example example example example example example example example", new DateTime(2024, 5, 2, 16, 41, 28, 604, DateTimeKind.Utc).AddTicks(6428), "Text example 3", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
