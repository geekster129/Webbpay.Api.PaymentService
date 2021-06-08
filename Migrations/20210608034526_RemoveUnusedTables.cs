using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbpay.Api.PaymentService.Migrations
{
    public partial class RemoveUnusedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentGatewayConfigSettings");

            migrationBuilder.DropTable(
                name: "PaymentGatewayConfigValue");

            migrationBuilder.DropTable(
                name: "PaymentGatewayConfig");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentGatewayConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GatewayType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGatewayConfig", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentGatewayConfigSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGatewayConfigSettings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentGatewayConfigValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ConfigType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConfigValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentGatewayConfigId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGatewayConfigValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentGatewayConfigValue_PaymentGatewayConfig_PaymentGatewa~",
                        column: x => x.PaymentGatewayConfigId,
                        principalTable: "PaymentGatewayConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGatewayConfigValue_PaymentGatewayConfigId",
                table: "PaymentGatewayConfigValue",
                column: "PaymentGatewayConfigId");
        }
    }
}
