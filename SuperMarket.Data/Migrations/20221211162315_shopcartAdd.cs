using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class shopcartAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCarts_SalesInformations_SalesInformationId",
                table: "ShopCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopCarts_SalesInformationId",
                table: "ShopCarts");

            migrationBuilder.DropColumn(
                name: "SalesInformationId",
                table: "ShopCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShopCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesInformationId",
                table: "ShopCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShopCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCarts_SalesInformationId",
                table: "ShopCarts",
                column: "SalesInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCarts_SalesInformations_SalesInformationId",
                table: "ShopCarts",
                column: "SalesInformationId",
                principalTable: "SalesInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
