using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Assets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetCode = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    SeriCode = table.Column<string>(nullable: true),
                    OriginalPrice = table.Column<int>(nullable: false),
                    DayImport = table.Column<DateTime>(nullable: false),
                    GroupAssetCode = table.Column<string>(nullable: true),
                    Provider = table.Column<string>(nullable: true),
                    WarrantyPeriod = table.Column<DateTime>(nullable: false),
                    DepreciationMonths = table.Column<int>(nullable: false),
                    DepreciationRateByYear = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetTypeCode = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupAssetCode = table.Column<string>(nullable: true),
                    GroupAssetName = table.Column<string>(nullable: true),
                    ParentGroupAssetCode = table.Column<string>(nullable: true),
                    DepreciationMonths = table.Column<int>(nullable: false),
                    DepreciationRateByYear = table.Column<float>(nullable: false),
                    AssetTypeCode = table.Column<string>(nullable: true),
                    AssetAcount = table.Column<string>(nullable: true),
                    DepreciationAccount = table.Column<string>(nullable: true),
                    CostsAccount = table.Column<string>(nullable: true),
                    IncomeAccount = table.Column<string>(nullable: true),
                    LiquidationCostAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAssets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "GroupAssets");
        }
    }
}
