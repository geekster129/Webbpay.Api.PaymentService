using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class CorrectRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentTransaction_PaymentTransactionId",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentTransactionId",
                table: "PaymentTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "PaymentTransaction");

            migrationBuilder.AddColumn<string>(
                name: "ExternalRefNo",
                table: "RefundTransactions",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalRefNo",
                table: "RefundTransactions");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTransactionId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

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
    }
}
