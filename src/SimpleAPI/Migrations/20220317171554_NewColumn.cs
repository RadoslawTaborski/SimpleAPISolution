using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class NewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Statuses",
                newSchema: "public");

            migrationBuilder.AddColumn<bool>(
                name: "Old",
                schema: "public",
                table: "Statuses",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Old",
                schema: "public",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                schema: "public",
                newName: "Statuses");
        }
    }
}
