using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Update_Asset_FullAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "GroupAssets",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Depreciations",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AssetTypes",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Assets",
                newName: "IsDelete");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GroupAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "GroupAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AssetTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Assets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Assets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GroupAssets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "GroupAssets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GroupAssets");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "GroupAssets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "GroupAssets",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Depreciations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "AssetTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Assets",
                newName: "IsDeleted");
        }
    }
}
