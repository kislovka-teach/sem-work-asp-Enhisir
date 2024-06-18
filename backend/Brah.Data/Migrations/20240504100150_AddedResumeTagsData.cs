using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedResumeTagsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResumeTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Backend" },
                    { 2, "Frontend" },
                    { 3, "Full-Stack" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResumeTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResumeTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResumeTags",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
