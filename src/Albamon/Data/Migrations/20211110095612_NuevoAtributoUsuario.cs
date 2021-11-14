using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class NuevoAtributoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Saldo",
                table: "AspNetUsers",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "AspNetUsers");
        }
    }
}
