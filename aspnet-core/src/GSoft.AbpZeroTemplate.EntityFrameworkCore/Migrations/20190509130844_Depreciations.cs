using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Depreciations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Depreciations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Depreciations");
        }
    }
}
