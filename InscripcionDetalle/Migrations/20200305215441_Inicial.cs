using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InscripcionDetalle.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    PreRequisito = table.Column<string>(nullable: false),
                    Creditos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstudianteId = table.Column<int>(nullable: false),
                    Semestre = table.Column<string>(nullable: false),
                    Limite = table.Column<int>(nullable: false),
                    Tomados = table.Column<int>(nullable: false),
                    Disponible = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.InscripcionId);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    Monto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionDetalles",
                columns: table => new
                {
                    InscripcionDetallesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InscripcionId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false),
                    DescripcionAsignatura = table.Column<string>(nullable: false),
                    Creditos = table.Column<int>(nullable: false),
                    Subtotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionDetalles", x => x.InscripcionDetallesId);
                    table.ForeignKey(
                        name: "FK_InscripcionDetalles_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionDetalles_InscripcionId",
                table: "InscripcionDetalles",
                column: "InscripcionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "InscripcionDetalles");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Inscripcion");
        }
    }
}
