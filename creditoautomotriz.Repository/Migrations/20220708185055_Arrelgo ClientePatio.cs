using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace creditoautomotriz.Repository.Migrations
{
    public partial class ArrelgoClientePatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientePatio",
                columns: table => new
                {
                    PatioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePatio", x => new { x.ClienteId, x.PatioId });
                    table.ForeignKey(
                        name: "FK_ClientePatio_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientePatio_Patio_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patio",
                        principalColumn: "PuntoVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientePatio_PatioId",
                table: "ClientePatio",
                column: "PatioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientePatio");
        }
    }
}
