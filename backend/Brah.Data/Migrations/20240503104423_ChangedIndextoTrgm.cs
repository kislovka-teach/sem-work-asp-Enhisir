using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIndextoTrgm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResumeTags_Name",
                table: "ResumeTags");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_Profession",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTags_Name",
                table: "ArticleTags");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Title",
                table: "Articles");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTags_Name",
                table: "ResumeTags",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:IndexOperators", new[] { "gin_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_Profession",
                table: "Resumes",
                column: "Profession")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:IndexOperators", new[] { "gin_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_Name",
                table: "ArticleTags",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:IndexOperators", new[] { "gin_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Title",
                table: "Articles",
                column: "Title")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:IndexOperators", new[] { "gin_trgm_ops" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResumeTags_Name",
                table: "ResumeTags");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_Profession",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTags_Name",
                table: "ArticleTags");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Title",
                table: "Articles");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:pg_trgm", ",,");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTags_Name",
                table: "ResumeTags",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "GiST")
                .Annotation("Npgsql:TsVectorConfig", "russian");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_Profession",
                table: "Resumes",
                column: "Profession")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "russian");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_Name",
                table: "ArticleTags",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "GiST")
                .Annotation("Npgsql:TsVectorConfig", "russian");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Title",
                table: "Articles",
                column: "Title")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "russian");
        }
    }
}
