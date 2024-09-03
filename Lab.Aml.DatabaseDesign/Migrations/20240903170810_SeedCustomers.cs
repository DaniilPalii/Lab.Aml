using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab.Aml.DatabaseDesign.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomers : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
