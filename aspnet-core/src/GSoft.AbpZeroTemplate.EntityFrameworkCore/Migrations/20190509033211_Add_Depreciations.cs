using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Depreciations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {         

            migrationBuilder.CreateTable(
                name: "Depreciations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepreciationCode = table.Column<string>(nullable: true),
                    AssetCode = table.Column<string>(nullable: true),
                    DayBeginCalculateDepreciation = table.Column<DateTime>(nullable: false),
                    DepreciationMonths = table.Column<int>(nullable: false),
                    DepreciatedValue = table.Column<float>(nullable: false),
                    DepreciationRateByYear = table.Column<float>(nullable: false),
                    RemainingValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depreciations");          
        }
    }
}
