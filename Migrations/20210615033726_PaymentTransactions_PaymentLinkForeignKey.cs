using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class PaymentTransactions_PaymentLinkForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId_PaymentLinkStor~",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentLinkId_PaymentLinkStoreId",
                table: "PaymentTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentLink",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "PaymentLinkRef",
                table: "PaymentTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentLinkStoreId",
                table: "PaymentTransaction");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentLink",
                table: "PaymentLink",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentLinkId",
                table: "PaymentTransaction",
                column: "PaymentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLink_Id_StoreId",
                table: "PaymentLink",
                columns: new[] { "Id", "StoreId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId",
                table: "PaymentTransaction",
                column: "PaymentLinkId",
                principalTable: "PaymentLink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentLink_PaymentLinkId",
                table: "PaymentTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransaction_PaymentLinkId",
                table: "PaymentTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentLink",
                table: "PaymentLink");

            migrationBuilder.DropIndex(
                name: "IX_PaymentLink_Id_StoreId",
                table: "PaymentLink");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentLinkId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "PaymentLinkRef",
                table: "PaymentTransaction",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentLinkStoreId",
                table: "PaymentTransaction",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentLink",
                table: "PaymentLink",
                columns: new[] { "Id", "StoreId" });

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
    }
}
