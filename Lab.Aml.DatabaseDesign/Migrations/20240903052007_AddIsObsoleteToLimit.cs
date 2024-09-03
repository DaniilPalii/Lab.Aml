using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab.Aml.DatabaseDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddIsObsoleteToLimit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsObsolete",
                table: "Limits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsObsolete",
                table: "Limits");
        }
    }
}
