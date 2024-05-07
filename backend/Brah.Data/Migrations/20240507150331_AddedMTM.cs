using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMTM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_tag");

            migrationBuilder.DropTable(
                name: "resume_tag");

            migrationBuilder.CreateTable(
                name: "ArticleTagToArticle",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    ArticleTagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTagToArticle", x => new { x.ArticleId, x.ArticleTagId });
                    table.ForeignKey(
                        name: "FK_ArticleTagToArticle_ArticleTags_ArticleTagId",
                        column: x => x.ArticleTagId,
                        principalTable: "ArticleTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTagToArticle_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTagToResume",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "integer", nullable: false),
                    ResumeTagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTagToResume", x => new { x.ResumeId, x.ResumeTagId });
                    table.ForeignKey(
                        name: "FK_ResumeTagToResume_ResumeTags_ResumeTagId",
                        column: x => x.ResumeTagId,
                        principalTable: "ResumeTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeTagToResume_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTagToArticle_ArticleTagId",
                table: "ArticleTagToArticle",
                column: "ArticleTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTagToResume_ResumeTagId",
                table: "ResumeTagToResume",
                column: "ResumeTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTagToArticle");

            migrationBuilder.DropTable(
                name: "ResumeTagToResume");

            migrationBuilder.CreateTable(
                name: "article_tag",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_tag", x => new { x.ArticleId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_article_tag_ArticleTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ArticleTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_tag_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resume_tag",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resume_tag", x => new { x.ResumeId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_resume_tag_ResumeTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ResumeTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resume_tag_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_tag_TagsId",
                table: "article_tag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_resume_tag_TagsId",
                table: "resume_tag",
                column: "TagsId");
        }
    }
}
