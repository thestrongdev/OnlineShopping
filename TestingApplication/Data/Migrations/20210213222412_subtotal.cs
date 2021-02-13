using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingApplication.Data.Migrations
{
    public partial class subtotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "ShopperCart",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "ShopperCart");
        }
    }
}
