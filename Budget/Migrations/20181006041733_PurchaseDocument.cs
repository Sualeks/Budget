using Microsoft.EntityFrameworkCore.Migrations;

namespace Budget.Migrations
{
    public partial class PurchaseDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "PurchaseDocuments");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseDocumentID",
                table: "Purchases",
                column: "PurchaseDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDocuments_BuyerID",
                table: "PurchaseDocuments",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDocuments_SellerID",
                table: "PurchaseDocuments",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseID",
                table: "Products",
                column: "PurchaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchases_PurchaseID",
                table: "Products",
                column: "PurchaseID",
                principalTable: "Purchases",
                principalColumn: "PurchaseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDocuments_Buyers_BuyerID",
                table: "PurchaseDocuments",
                column: "BuyerID",
                principalTable: "Buyers",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDocuments_Sellers_SellerID",
                table: "PurchaseDocuments",
                column: "SellerID",
                principalTable: "Sellers",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseDocuments_PurchaseDocumentID",
                table: "Purchases",
                column: "PurchaseDocumentID",
                principalTable: "PurchaseDocuments",
                principalColumn: "PurchaseDocumentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_PurchaseID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDocuments_Buyers_BuyerID",
                table: "PurchaseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDocuments_Sellers_SellerID",
                table: "PurchaseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseDocuments_PurchaseDocumentID",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseDocumentID",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDocuments_BuyerID",
                table: "PurchaseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDocuments_SellerID",
                table: "PurchaseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "PurchaseDocuments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
