using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class RemoveDemoTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoTests");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProductID",
            //    table: "ProductTags");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProductId",
            //    table: "ProductQuantities");

            //migrationBuilder.DropIndex(
            //    name: "IX_PostID",
            //    table: "PostTags");

            //migrationBuilder.DropIndex(
            //    name: "IX_OrderID",
            //    table: "OrderDetails");

            //migrationBuilder.DropIndex(
            //    name: "IX_AnnouncementId",
            //    table: "AnnouncementUsers");

            //migrationBuilder.RenameIndex(
            //    name: "IX_VideoInstructionCategoryId",
            //    table: "VideoInstructions",
            //    newName: "IX_VideoInstructions_VideoInstructionCategoryId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_PriceId",
            //    table: "VideoInstructionCategories",
            //    newName: "IX_VideoInstructionCategories_PriceId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TagID",
            //    table: "ProductTags",
            //    newName: "IX_ProductTags_TagID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CategoryID",
            //    table: "Products",
            //    newName: "IX_Products_CategoryID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_SizeId",
            //    table: "ProductQuantities",
            //    newName: "IX_ProductQuantities_SizeId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ColorId",
            //    table: "ProductQuantities",
            //    newName: "IX_ProductQuantities_ColorId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductId",
            //    table: "ProductImages",
            //    newName: "IX_ProductImages_ProductId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TagID",
            //    table: "PostTags",
            //    newName: "IX_PostTags_TagID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CategoryID",
            //    table: "Posts",
            //    newName: "IX_Posts_CategoryID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CustomerId",
            //    table: "Orders",
            //    newName: "IX_Orders_CustomerId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_SizeId",
            //    table: "OrderDetails",
            //    newName: "IX_OrderDetails_SizeId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductID",
            //    table: "OrderDetails",
            //    newName: "IX_OrderDetails_ProductID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ColorId",
            //    table: "OrderDetails",
            //    newName: "IX_OrderDetails_ColorId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_RoleId",
            //    table: "GPermissions",
            //    newName: "IX_GPermissions_RoleId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_FunctionId",
            //    table: "GPermissions",
            //    newName: "IX_GPermissions_FunctionId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ParentId",
            //    table: "Functions",
            //    newName: "IX_Functions_ParentId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_IdentityRole_Id",
            //    table: "AppUserRoles",
            //    newName: "IX_AppUserRoles_IdentityRole_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUser_Id",
            //    table: "AppUserRoles",
            //    newName: "IX_AppUserRoles_AppUser_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUser_Id",
            //    table: "AppUserLogins",
            //    newName: "IX_AppUserLogins_AppUser_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUser_Id",
            //    table: "AppUserClaims",
            //    newName: "IX_AppUserClaims_AppUser_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserId",
            //    table: "AnnouncementUsers",
            //    newName: "IX_AnnouncementUsers_UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserId",
            //    table: "Announcements",
            //    newName: "IX_Announcements_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameIndex(
            //    name: "IX_VideoInstructions_VideoInstructionCategoryId",
            //    table: "VideoInstructions",
            //    newName: "IX_VideoInstructionCategoryId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_VideoInstructionCategories_PriceId",
            //    table: "VideoInstructionCategories",
            //    newName: "IX_PriceId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductTags_TagID",
            //    table: "ProductTags",
            //    newName: "IX_TagID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Products_CategoryID",
            //    table: "Products",
            //    newName: "IX_CategoryID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductQuantities_SizeId",
            //    table: "ProductQuantities",
            //    newName: "IX_SizeId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductQuantities_ColorId",
            //    table: "ProductQuantities",
            //    newName: "IX_ColorId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductImages_ProductId",
            //    table: "ProductImages",
            //    newName: "IX_ProductId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_PostTags_TagID",
            //    table: "PostTags",
            //    newName: "IX_TagID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Posts_CategoryID",
            //    table: "Posts",
            //    newName: "IX_CategoryID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Orders_CustomerId",
            //    table: "Orders",
            //    newName: "IX_CustomerId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_OrderDetails_SizeId",
            //    table: "OrderDetails",
            //    newName: "IX_SizeId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_OrderDetails_ProductID",
            //    table: "OrderDetails",
            //    newName: "IX_ProductID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_OrderDetails_ColorId",
            //    table: "OrderDetails",
            //    newName: "IX_ColorId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_GPermissions_RoleId",
            //    table: "GPermissions",
            //    newName: "IX_RoleId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_GPermissions_FunctionId",
            //    table: "GPermissions",
            //    newName: "IX_FunctionId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Functions_ParentId",
            //    table: "Functions",
            //    newName: "IX_ParentId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUserRoles_IdentityRole_Id",
            //    table: "AppUserRoles",
            //    newName: "IX_IdentityRole_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUserRoles_AppUser_Id",
            //    table: "AppUserRoles",
            //    newName: "IX_AppUser_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUserLogins_AppUser_Id",
            //    table: "AppUserLogins",
            //    newName: "IX_AppUser_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AppUserClaims_AppUser_Id",
            //    table: "AppUserClaims",
            //    newName: "IX_AppUser_Id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AnnouncementUsers_UserId",
            //    table: "AnnouncementUsers",
            //    newName: "IX_UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Announcements_UserId",
            //    table: "Announcements",
            //    newName: "IX_UserId");

            migrationBuilder.CreateTable(
                name: "DemoTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoTests", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductID",
            //    table: "ProductTags",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductId",
            //    table: "ProductQuantities",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostID",
            //    table: "PostTags",
            //    column: "PostID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderID",
            //    table: "OrderDetails",
            //    column: "OrderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AnnouncementId",
            //    table: "AnnouncementUsers",
            //    column: "AnnouncementId");
        }
    }
}
