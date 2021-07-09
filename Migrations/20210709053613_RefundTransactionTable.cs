using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class RefundTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTransactionId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentStatus",
                table: "PaymentTransaction",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentTransactionId",
                table: "PaymentTransaction",
                column: "PaymentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransaction_PaymentTransaction_PaymentTransactionId",
                table: "PaymentTransaction",
                column: "PaymentTransactionId",
                principalTable: "PaymentTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentTransaction_PaymentTransactionId",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentStatus",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentTransactionId",
                table: "PaymentTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "PaymentTransaction");
        }
    }
}
