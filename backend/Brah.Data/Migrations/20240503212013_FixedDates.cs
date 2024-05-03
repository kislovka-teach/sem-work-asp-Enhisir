using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimePosted",
                value: new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 1, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkPlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 42, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Commentaries",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimePosted",
                value: new DateTime(2024, 5, 2, 16, 41, 28, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkPlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2023, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
