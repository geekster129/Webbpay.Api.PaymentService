using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class PaymentLink_ProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "PaymentLink",
                newName: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PaymentLink",
                newName: "InventoryId");
        }
    }
}
