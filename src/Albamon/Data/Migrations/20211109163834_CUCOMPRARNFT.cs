using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class CUCOMPRARNFT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NftId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wallet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Moneda",
                columns: table => new
                {
                    MonedaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CantidadCompra = table.Column<int>(type: "int", nullable: false),
                    CantidadVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneda", x => x.MonedaId);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchase_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeNFT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNFT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Direccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    IdTransaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Direccion);
                });

            migrationBuilder.CreateTable(
                name: "NFT",
                columns: table => new
                {
                    NftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Health = table.Column<double>(type: "float", nullable: false),
                    Attack = table.Column<double>(type: "float", nullable: false),
                    Rarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeNFTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFT", x => x.NftId);
                    table.ForeignKey(
                        name: "FK_NFT_TypeNFT_TypeNFTId",
                        column: x => x.TypeNFTId,
                        principalTable: "TypeNFT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    ConversionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaConversion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WalletDireccion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversion", x => x.ConversionId);
                    table.ForeignKey(
                        name: "FK_Conversion_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversion_Wallet_WalletDireccion",
                        column: x => x.WalletDireccion,
                        principalTable: "Wallet",
                        principalColumn: "Direccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    WalletDireccion = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK_Ventas_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Wallet_WalletDireccion",
                        column: x => x.WalletDireccion,
                        principalTable: "Wallet",
                        principalColumn: "Direccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseNFTS",
                columns: table => new
                {
                    NftId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    Pid = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseNFTS", x => new { x.NftId, x.PurchaseId });
                    table.ForeignKey(
                        name: "FK_PurchaseNFTS_NFT_NftId",
                        column: x => x.NftId,
                        principalTable: "NFT",
                        principalColumn: "NftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseNFTS_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonedaConvertida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonedaId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ConversionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonedaConvertida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonedaConvertida_Conversion_ConversionId",
                        column: x => x.ConversionId,
                        principalTable: "Conversion",
                        principalColumn: "ConversionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonedaConvertida_Moneda_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Moneda",
                        principalColumn: "MonedaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaItems",
                columns: table => new
                {
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    NFTID = table.Column<int>(type: "int", nullable: false),
                    VentaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_VentaItems_NFT_NFTID",
                        column: x => x.NFTID,
                        principalTable: "NFT",
                        principalColumn: "NftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaItems_Ventas_VentaID",
                        column: x => x.VentaID,
                        principalTable: "Ventas",
                        principalColumn: "VentaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NftId",
                table: "AspNetUsers",
                column: "NftId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_ClienteId",
                table: "Conversion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_WalletDireccion",
                table: "Conversion",
                column: "WalletDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_MonedaConvertida_ConversionId",
                table: "MonedaConvertida",
                column: "ConversionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonedaConvertida_MonedaId",
                table: "MonedaConvertida",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_NFT_TypeNFTId",
                table: "NFT",
                column: "TypeNFTId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseNFTS_PurchaseId",
                table: "PurchaseNFTS",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_NFTID",
                table: "VentaItems",
                column: "NFTID");

            migrationBuilder.CreateIndex(
                name: "IX_VentaItems_VentaID",
                table: "VentaItems",
                column: "VentaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_WalletDireccion",
                table: "Ventas",
                column: "WalletDireccion");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_NFT_NftId",
                table: "AspNetUsers",
                column: "NftId",
                principalTable: "NFT",
                principalColumn: "NftId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_NFT_NftId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MonedaConvertida");

            migrationBuilder.DropTable(
                name: "PurchaseNFTS");

            migrationBuilder.DropTable(
                name: "VentaItems");

            migrationBuilder.DropTable(
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "NFT");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "TypeNFT");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NftId",
                table: "AspNetUsers");

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
                name: "NftId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "AspNetUsers");
        }
    }
}
