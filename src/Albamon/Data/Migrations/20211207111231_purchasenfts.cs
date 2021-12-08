using Microsoft.EntityFrameworkCore.Migrations;

namespace Albamon.Data.Migrations
{
    public partial class purchasenfts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseNFTS_NFT_NftId",
                table: "PurchaseNFTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseNFTS_Purchase_PurchaseId",
                table: "PurchaseNFTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseNFTS",
                table: "PurchaseNFTS");

            migrationBuilder.RenameTable(
                name: "PurchaseNFTS",
                newName: "PurchaseNFT");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseNFTS_PurchaseId",
                table: "PurchaseNFT",
                newName: "IX_PurchaseNFT_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseNFT",
                table: "PurchaseNFT",
                columns: new[] { "NftId", "PurchaseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseNFT_NFT_NftId",
                table: "PurchaseNFT",
                column: "NftId",
                principalTable: "NFT",
                principalColumn: "NftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseNFT_Purchase_PurchaseId",
                table: "PurchaseNFT",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseNFT_NFT_NftId",
                table: "PurchaseNFT");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseNFT_Purchase_PurchaseId",
                table: "PurchaseNFT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseNFT",
                table: "PurchaseNFT");

            migrationBuilder.RenameTable(
                name: "PurchaseNFT",
                newName: "PurchaseNFTS");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseNFT_PurchaseId",
                table: "PurchaseNFTS",
                newName: "IX_PurchaseNFTS_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseNFTS",
                table: "PurchaseNFTS",
                columns: new[] { "NftId", "PurchaseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseNFTS_NFT_NftId",
                table: "PurchaseNFTS",
                column: "NftId",
                principalTable: "NFT",
                principalColumn: "NftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseNFTS_Purchase_PurchaseId",
                table: "PurchaseNFTS",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
