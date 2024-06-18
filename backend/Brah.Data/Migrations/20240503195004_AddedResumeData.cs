using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Brah.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedResumeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEnd",
                table: "WorkPlaces",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                table: "Resumes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Resumes",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Resumes",
                columns: new[] { "Id", "About", "Grade", "LeftSalaryBorder", "LookingForWork", "Profession", "RightSalaryBorder", "UserId" },
                values: new object[] { 1, "ddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsdddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsdddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsdddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsd", 0, 100000, true, "Малолетний дебил", 150000, 1 });

            migrationBuilder.InsertData(
                table: "WorkPlaces",
                columns: new[] { "Id", "CompanyName", "DateBegin", "DateEnd", "Description", "Grade", "Profession", "ResumeId" },
                values: new object[,]
                {
                    { 1, "Министрество не твоих собачьих дел", new DateTime(2023, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc), null, "См. название", 2, "Какой-то мужик", 1 },
                    { 2, "ИП Макима", new DateTime(2022, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc), "Кусал за ногу", 3, "Собачка", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkPlaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkPlaces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEnd",
                table: "WorkPlaces",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                table: "Resumes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Resumes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);
        }
    }
}
