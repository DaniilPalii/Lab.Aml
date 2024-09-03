using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab.Aml.DatabaseDesign.Migrations
{
    /// <inheritdoc />
    public partial class SeedOptionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Birthdate", "Name", "Surname" },
                values: new object[,]
                {
                    { 1L, "ul. Kwiatowa 5, 00-001 Warszawa", new DateOnly(1990, 6, 15), "Anna", "Kowalska" },
                    { 2L, "ul. Słoneczna 12, 31-234 Kraków", new DateOnly(1985, 3, 22), "Jan", "Nowak" },
                    { 3L, "ul. Ogrodowa 8, 40-600 Katowice", new DateOnly(1995, 10, 11), "Katarzyna", "Zielińska" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreationDate", "Currency", "CustomerId", "Description", "IsSuspicious", "TransactionType" },
                values: new object[,]
                {
                    { 1L, 150.00m, new DateTime(2023, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 3, 1L, "Initial deposit", null, 1 },
                    { 2L, 75.50m, new DateTime(2023, 1, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 3, 1L, "ATM withdrawal", null, 2 },
                    { 3L, 300.00m, new DateTime(2023, 1, 3, 11, 45, 0, 0, DateTimeKind.Unspecified), 2, 2L, "Online transfer", null, 2 },
                    { 4L, 1000.00m, new DateTime(2023, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 3L, "Salary deposit", null, 1 },
                    { 5L, 50.00m, new DateTime(2023, 1, 5, 16, 20, 0, 0, DateTimeKind.Unspecified), 3, 1L, "Grocery payment", null, 2 },
                    { 6L, 120.00m, new DateTime(2023, 1, 6, 13, 10, 0, 0, DateTimeKind.Unspecified), 3, 2L, "Gift deposit", null, 1 },
                    { 7L, 45.00m, new DateTime(2023, 2, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 8L, 45.00m, new DateTime(2023, 3, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 9L, 45.00m, new DateTime(2023, 4, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 10L, 45.00m, new DateTime(2023, 4, 15, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 11L, 45.00m, new DateTime(2023, 4, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 12L, 45.00m, new DateTime(2023, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 13L, 45.00m, new DateTime(2023, 4, 15, 21, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 14L, 45.00m, new DateTime(2023, 4, 15, 22, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 15L, 45.00m, new DateTime(2023, 4, 15, 23, 30, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 16L, 45.00m, new DateTime(2023, 4, 15, 23, 31, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 17L, 45.00m, new DateTime(2023, 4, 15, 23, 32, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 18L, 45.00m, new DateTime(2023, 4, 15, 23, 33, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 19L, 45.00m, new DateTime(2023, 4, 15, 23, 34, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 20L, 45.00m, new DateTime(2023, 4, 15, 23, 35, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 21L, 45.00m, new DateTime(2023, 4, 15, 23, 36, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 22L, 45.00m, new DateTime(2023, 4, 15, 23, 37, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 23L, 45.00m, new DateTime(2023, 4, 15, 23, 38, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 24L, 45.00m, new DateTime(2023, 4, 15, 23, 39, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 25L, 45.00m, new DateTime(2023, 4, 15, 23, 40, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 26L, 45.00m, new DateTime(2023, 4, 15, 23, 41, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 27L, 45.00m, new DateTime(2023, 4, 15, 23, 42, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 28L, 45.00m, new DateTime(2023, 4, 15, 23, 43, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 29L, 450.00m, new DateTime(2023, 4, 15, 23, 44, 0, 0, DateTimeKind.Unspecified), 3, 3L, "Online shopping", null, 1 },
                    { 30L, 45.00m, new DateTime(2023, 4, 15, 23, 45, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 31L, 100.00m, new DateTime(2024, 1, 1, 1, 1, 0, 0, DateTimeKind.Unspecified), 2, 3L, "Online shopping", null, 1 },
                    { 32L, 100000.00m, new DateTime(2024, 2, 1, 1, 1, 0, 0, DateTimeKind.Unspecified), 2, 1L, "Online shopping", null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
