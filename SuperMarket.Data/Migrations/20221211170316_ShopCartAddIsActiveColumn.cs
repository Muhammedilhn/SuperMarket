using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class ShopCartAddIsActiveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCarts_Products_ProductId",
                table: "ShopCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopCarts_ProductId",
                table: "ShopCarts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShopCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShopCarts");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCarts_ProductId",
                table: "ShopCarts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCarts_Products_ProductId",
                table: "ShopCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
