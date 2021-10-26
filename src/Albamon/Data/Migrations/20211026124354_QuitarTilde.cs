using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class QuitarTilde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_Wallet_WalletDirección",
                table: "Conversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Wallet_WalletDirección",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "Dirección",
                table: "Wallet",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "WalletDirección",
                table: "Ventas",
                newName: "WalletDireccion");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_WalletDirección",
                table: "Ventas",
                newName: "IX_Ventas_WalletDireccion");

            migrationBuilder.RenameColumn(
                name: "WalletDirección",
                table: "Conversion",
                newName: "WalletDireccion");

            migrationBuilder.RenameIndex(
                name: "IX_Conversion_WalletDirección",
                table: "Conversion",
                newName: "IX_Conversion_WalletDireccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_Wallet_WalletDireccion",
                table: "Conversion",
                column: "WalletDireccion",
                principalTable: "Wallet",
                principalColumn: "Direccion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Wallet_WalletDireccion",
                table: "Ventas",
                column: "WalletDireccion",
                principalTable: "Wallet",
                principalColumn: "Direccion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_Wallet_WalletDireccion",
                table: "Conversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Wallet_WalletDireccion",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Wallet",
                newName: "Dirección");

            migrationBuilder.RenameColumn(
                name: "WalletDireccion",
                table: "Ventas",
                newName: "WalletDirección");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_WalletDireccion",
                table: "Ventas",
                newName: "IX_Ventas_WalletDirección");

            migrationBuilder.RenameColumn(
                name: "WalletDireccion",
                table: "Conversion",
                newName: "WalletDirección");

            migrationBuilder.RenameIndex(
                name: "IX_Conversion_WalletDireccion",
                table: "Conversion",
                newName: "IX_Conversion_WalletDirección");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_Wallet_WalletDirección",
                table: "Conversion",
                column: "WalletDirección",
                principalTable: "Wallet",
                principalColumn: "Dirección",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Wallet_WalletDirección",
                table: "Ventas",
                column: "WalletDirección",
                principalTable: "Wallet",
                principalColumn: "Dirección",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
