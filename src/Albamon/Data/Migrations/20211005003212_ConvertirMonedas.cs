using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class ConvertirMonedas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFT");

            migrationBuilder.DropTable(
                name: "TypeNFT");

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
                name: "Wallet",
                columns: table => new
                {
                    Dirección = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    IdTransaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Dirección);
                });

            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    ConversionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaConversion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WalletDirección = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Conversion_Wallet_WalletDirección",
                        column: x => x.WalletDirección,
                        principalTable: "Wallet",
                        principalColumn: "Dirección",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonedaConvertida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonedaId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    monedaId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_ClienteId",
                table: "Conversion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_WalletDirección",
                table: "Conversion",
                column: "WalletDirección");

            migrationBuilder.CreateIndex(
                name: "IX_MonedaConvertida_ConversionId",
                table: "MonedaConvertida",
                column: "ConversionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonedaConvertida_MonedaId",
                table: "MonedaConvertida",
                column: "MonedaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonedaConvertida");

            migrationBuilder.DropTable(
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.DropTable(
                name: "Wallet");

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
                    TypenNFTId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
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
    }
}
