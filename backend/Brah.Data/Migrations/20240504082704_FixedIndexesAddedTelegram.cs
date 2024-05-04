using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedIndexesAddedTelegram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Resumes",
                type: "character varying(320)",
                maxLength: 320,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telegram",
                table: "Resumes",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "unique_resume_tag_constraint",
                table: "ResumeTags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_article_tag_constraint",
                table: "ArticleTags",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "unique_resume_tag_constraint",
                table: "ResumeTags");

            migrationBuilder.DropIndex(
                name: "unique_article_tag_constraint",
                table: "ArticleTags");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Telegram",
                table: "Resumes");
        }
    }
}
