using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class UpdatePaymentTransactiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentLinkStoreId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentLinkId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentLinkId_PaymentLinkStoreId",
                table: "PaymentTransaction",
                columns: new[] { "PaymentLinkId", "PaymentLinkStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId_PaymentLinkStor~",
                table: "PaymentTransaction",
                columns: new[] { "PaymentLinkId", "PaymentLinkStoreId" },
                principalTable: "PaymentLink",
                principalColumns: new[] { "Id", "StoreId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId_PaymentLinkStor~",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentLinkId_PaymentLinkStoreId",
                table: "PaymentTransaction");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentLinkStoreId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentLinkId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentLinkId1",
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
    }
}
