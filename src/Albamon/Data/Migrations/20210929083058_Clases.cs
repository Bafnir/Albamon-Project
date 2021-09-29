using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class Clases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeNFT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNFT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NFT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    TypenNFTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NFT_TypeNFT_TypenNFTId",
                        column: x => x.TypenNFTId,
                        principalTable: "TypeNFT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NFT_TypenNFTId",
                table: "NFT",
                column: "TypenNFTId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFT");

            migrationBuilder.DropTable(
                name: "TypeNFT");
        }
    }
}
