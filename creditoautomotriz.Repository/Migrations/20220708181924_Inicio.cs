using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace creditoautomotriz.Repository.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCredito",
                columns: table => new
                {
                    EstadoCreditoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCredito", x => x.EstadoCreditoId);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Patio",
                columns: table => new
                {
                    PuntoVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patio", x => x.PuntoVenta);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false),
                    IdentificacionConyugue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreConyugue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SujetoCredito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Cliente_EstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCivil",
                        principalColumn: "EstadoCivilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumChasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cilindraje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Avaluo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.Placa);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ejecutivo",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    TelefonoCon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejecutivo", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Ejecutivo_Patio_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patio",
                        principalColumn: "PuntoVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credito",
                columns: table => new
                {
                    CreditoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaElaboracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PuntoVenta = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MesesPlazo = table.Column<int>(type: "int", nullable: false),
                    Cuotas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Entrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoCreditoId = table.Column<int>(type: "int", nullable: false),
                    EjecutivoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.CreditoId);
                    table.ForeignKey(
                        name: "FK_Credito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credito_Ejecutivo_EjecutivoId",
                        column: x => x.EjecutivoId,
                        principalTable: "Ejecutivo",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credito_EstadoCredito_EstadoCreditoId",
                        column: x => x.EstadoCreditoId,
                        principalTable: "EstadoCredito",
                        principalColumn: "EstadoCreditoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credito_Patio_PuntoVenta",
                        column: x => x.PuntoVenta,
                        principalTable: "Patio",
                        principalColumn: "PuntoVenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credito_Vehiculo_Placa",
                        column: x => x.Placa,
                        principalTable: "Vehiculo",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EstadoCivilId",
                table: "Cliente",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_ClienteId",
                table: "Credito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_EjecutivoId",
                table: "Credito",
                column: "EjecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_EstadoCreditoId",
                table: "Credito",
                column: "EstadoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_Placa",
                table: "Credito",
                column: "Placa");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_PuntoVenta",
                table: "Credito",
                column: "PuntoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Ejecutivo_PatioId",
                table: "Ejecutivo",
                column: "PatioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_MarcaId",
                table: "Vehiculo",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credito");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Ejecutivo");

            migrationBuilder.DropTable(
                name: "EstadoCredito");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Patio");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
