using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalesInformationId",
                table: "ShopCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShopCartId",
                table: "SalesInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCarts_Products_ProductId",
                table: "ShopCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopCarts_ProductId",
                table: "ShopCarts");

            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "SalesInformations");

            migrationBuilder.AlterColumn<int>(
                name: "SalesInformationId",
                table: "ShopCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
