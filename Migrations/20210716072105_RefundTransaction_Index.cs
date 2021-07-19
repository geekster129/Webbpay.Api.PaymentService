using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class RefundTransaction_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RefundTransactions_Created",
                table: "RefundTransactions",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_RefundTransactions_RefundStatus",
                table: "RefundTransactions",
                column: "RefundStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefundTransactions_Created",
                table: "RefundTransactions");

            migrationBuilder.DropIndex(
                name: "IX_RefundTransactions_RefundStatus",
                table: "RefundTransactions");
        }
    }
}
