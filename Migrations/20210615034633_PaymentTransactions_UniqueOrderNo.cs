using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class PaymentTransactions_UniqueOrderNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentOrderNo",
                table: "PaymentTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentOrderNo",
                table: "PaymentTransaction",
                column: "PaymentOrderNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentOrderNo",
                table: "PaymentTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentOrderNo",
                table: "PaymentTransaction",
                column: "PaymentOrderNo");
        }
    }
}
