using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class UpdateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentLink_PaymentTransaction_PaymentTransactionId",
                table: "PaymentLink");

            migrationBuilder.DropIndex(
                name: "IX_PaymentLink_PaymentTransactionId",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "PaymentTransactionId",
                table: "PaymentLink");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentLinkId1",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentLinkStoreId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentLinkId1_PaymentLinkStoreId",
                table: "PaymentTransaction",
                columns: new[] { "PaymentLinkId1", "PaymentLinkStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId1_PaymentLinkSto~",
                table: "PaymentTransaction",
                columns: new[] { "PaymentLinkId1", "PaymentLinkStoreId" },
                principalTable: "PaymentLink",
                principalColumns: new[] { "Id", "StoreId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId1_PaymentLinkSto~",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentLinkId1_PaymentLinkStoreId",
                table: "PaymentTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentLinkId1",
                table: "PaymentTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentLinkStoreId",
                table: "PaymentTransaction");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTransactionId",
                table: "PaymentLink",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLink_PaymentTransactionId",
                table: "PaymentLink",
                column: "PaymentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentLink_PaymentTransaction_PaymentTransactionId",
                table: "PaymentLink",
                column: "PaymentTransactionId",
                principalTable: "PaymentTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
