using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class VenderNFT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NFT_TypeNFT_TypenNFTId",
                table: "NFT");

            migrationBuilder.DropIndex(
                name: "IX_NFT_TypenNFTId",
                table: "NFT");

            migrationBuilder.DropColumn(
                name: "TypenNFTId",
                table: "NFT");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "NFT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<int>(
                name: "TypeNFTId",
                table: "NFT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeNFTId1",
                table: "NFT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Dirección = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Dirección);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Wallet_Signature = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletDirección = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK_Venta_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venta_Wallet_WalletDirección",
                        column: x => x.WalletDirección,
                        principalTable: "Wallet",
                        principalColumn: "Dirección",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentaItem",
                columns: table => new
                {
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    NFTID = table.Column<int>(type: "int", nullable: false),
                    VentaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_VentaItem_NFT_Cantidad",
                        column: x => x.Cantidad,
                        principalTable: "NFT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaItem_Venta_VentaID",
                        column: x => x.VentaID,
                        principalTable: "Venta",
                        principalColumn: "VentaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NFT_TypeNFTId",
                table: "NFT",
                column: "TypeNFTId");

            migrationBuilder.CreateIndex(
                name: "IX_NFT_TypeNFTId1",
                table: "NFT",
                column: "TypeNFTId1");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_WalletDirección",
                table: "Venta",
                column: "WalletDirección");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItem_Cantidad",
                table: "VentaItem",
                column: "Cantidad");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItem_VentaID",
                table: "VentaItem",
                column: "VentaID");

            migrationBuilder.AddForeignKey(
                name: "FK_NFT_TypeNFT_TypeNFTId",
                table: "NFT",
                column: "TypeNFTId",
                principalTable: "TypeNFT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NFT_TypeNFT_TypeNFTId1",
                table: "NFT",
                column: "TypeNFTId1",
                principalTable: "TypeNFT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NFT_TypeNFT_TypeNFTId",
                table: "NFT");

            migrationBuilder.DropForeignKey(
                name: "FK_NFT_TypeNFT_TypeNFTId1",
                table: "NFT");

            migrationBuilder.DropTable(
                name: "VentaItem");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_NFT_TypeNFTId",
                table: "NFT");

            migrationBuilder.DropIndex(
                name: "IX_NFT_TypeNFTId1",
                table: "NFT");

            migrationBuilder.DropColumn(
                name: "TypeNFTId",
                table: "NFT");

            migrationBuilder.DropColumn(
                name: "TypeNFTId1",
                table: "NFT");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "NFT",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypenNFTId",
                table: "NFT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NFT_TypenNFTId",
                table: "NFT",
                column: "TypenNFTId");

            migrationBuilder.AddForeignKey(
                name: "FK_NFT_TypeNFT_TypenNFTId",
                table: "NFT",
                column: "TypenNFTId",
                principalTable: "TypeNFT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
