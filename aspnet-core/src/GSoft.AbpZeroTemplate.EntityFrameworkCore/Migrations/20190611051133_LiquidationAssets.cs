using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class LiquidationAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvicitonAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    EvictionDate = table.Column<DateTime>(nullable: false),
                    AssetCode = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsReadonly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvicitonAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ExportDate = table.Column<DateTime>(nullable: false),
                    AssetCode = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    IsReadonly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiquidationAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    LiquidationDate = table.Column<DateTime>(nullable: false),
                    AssetCode = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    LiquidationForm = table.Column<string>(nullable: true),
                    LiquidationCost = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsReadonly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidationAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    AssetCode = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    IsReadonly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferAssets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvicitonAssets");

            migrationBuilder.DropTable(
                name: "ExportAssets");

            migrationBuilder.DropTable(
                name: "LiquidationAssets");

            migrationBuilder.DropTable(
                name: "TransferAssets");
        }
    }
}
