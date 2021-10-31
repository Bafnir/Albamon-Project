using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class MejorarUsuarioComprarNFT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_ApplicationUserId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "ApplicationUserNFT");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Purchase",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_ApplicationUserId",
                table: "Purchase",
                newName: "IX_Purchase_UserId");

            migrationBuilder.CreateTable(
                name: "NFTUsuario",
                columns: table => new
                {
                    NFTSNftId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFTUsuario", x => new { x.NFTSNftId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_NFTUsuario_AspNetUsers_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NFTUsuario_NFT_NFTSNftId",
                        column: x => x.NFTSNftId,
                        principalTable: "NFT",
                        principalColumn: "NftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NFTUsuario_UsuariosId",
                table: "NFTUsuario",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_UserId",
                table: "Purchase",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_UserId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "NFTUsuario");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Purchase",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                newName: "IX_Purchase_ApplicationUserId");

            migrationBuilder.CreateTable(
                name: "ApplicationUserNFT",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NFTSNftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserNFT", x => new { x.ApplicationUsersId, x.NFTSNftId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserNFT_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserNFT_NFT_NFTSNftId",
                        column: x => x.NFTSNftId,
                        principalTable: "NFT",
                        principalColumn: "NftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserNFT_NFTSNftId",
                table: "ApplicationUserNFT",
                column: "NFTSNftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_ApplicationUserId",
                table: "Purchase",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
