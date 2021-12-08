using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class atributoquantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PurchaseNFTS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PurchaseNFTS");
        }
    }
}
