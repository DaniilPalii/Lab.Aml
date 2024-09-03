using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab.Aml.DatabaseDesign.Migrations
{
    /// <inheritdoc />
    public partial class SeedLimits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Limits",
                columns: new[] { "Id", "Amount", "Count", "CreationDate", "Currency", "Range" },
                values: new object[,]
                {
                    { 1L, 11000m, 11, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 0, 5, 0, 0) },
                    { 2L, 12000m, 12, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 0, 5, 0, 0) },
                    { 3L, 13000m, 13, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 4L, 21000m, 21, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 0, 5, 0, 0) },
                    { 5L, 22000m, 22, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 0, 6, 0, 0) },
                    { 6L, 23000m, 23, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 0, 7, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Limits",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Limits",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Limits",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Limits",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Limits",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Limits",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
