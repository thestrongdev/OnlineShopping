using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingApplication.Data.Migrations
{
    public partial class otherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "ShopperCart",
                columns: table => new
                {
                    ShopperItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemQuantity = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopperCart", x => x.ShopperItemId);
                    table.ForeignKey(
                        name: "FK_ShopperCart_StoreItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StoreItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopperCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopperCart_ItemId",
                table: "ShopperCart",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopperCart_UserId",
                table: "ShopperCart",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopperCart");

            migrationBuilder.DropTable(
                name: "StoreItems");
        }
    }
}
