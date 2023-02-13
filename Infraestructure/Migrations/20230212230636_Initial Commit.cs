using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChallengeTecnicoEngee.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorId = table.Column<long>(type: "bigint", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogsVisitas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresVisitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosVisitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumentoVisitante = table.Column<long>(type: "bigint", nullable: false),
                    FechaHoraIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroTarjetaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorId = table.Column<long>(type: "bigint", nullable: false),
                    EmpleadoVisitadoId = table.Column<long>(type: "bigint", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsVisitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsVisitas_Empleados_EmpleadoVisitadoId",
                        column: x => x.EmpleadoVisitadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsVisitas_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "Activo", "Codigo", "Descripcion", "FechaAlta", "FechaEliminacion", "FechaModificacion" },
                values: new object[,]
                {
                    { 1L, true, "QA", "Quality Assurance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2L, true, "RRHH", "Recursos Humanos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3L, true, "COMME", "Comercial", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 4L, true, "HQ", "Gerencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Activo", "Apellidos", "FechaAlta", "FechaEliminacion", "FechaModificacion", "Nombres", "SectorId" },
                values: new object[,]
                {
                    { 1L, true, "de Almeida", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Daniel", 2L },
                    { 2L, true, "Riva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Dario", 1L },
                    { 3L, true, "Pellegrini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Diego", 3L },
                    { 4L, true, "Musso", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Federico", 2L },
                    { 5L, true, "Rodriguez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Laura", 1L },
                    { 6L, true, "Basanta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lautaro Ariel", 3L },
                    { 7L, true, "Castello", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Manuel", 2L },
                    { 8L, true, "Barrios", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Paula", 1L },
                    { 9L, true, "Diaz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Rocio", 3L },
                    { 10L, true, "Parasis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sebastian", 2L },
                    { 11L, true, "Marcote", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Walter", 1L },
                    { 12L, true, "Balcarcel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Guillermo", 3L },
                    { 13L, true, "Gawron", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Esteban", 2L },
                    { 14L, true, "Peddini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Enzo", 2L },
                    { 15L, true, "Russo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Andrea", 3L },
                    { 16L, true, "Zarate", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Adrian", 2L },
                    { 17L, true, "Yune", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Melisa", 1L },
                    { 18L, true, "Russmann", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nicolas", 3L },
                    { 19L, true, "Trillo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Galo", 2L },
                    { 20L, true, "Pellegrini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Diego", 1L },
                    { 21L, true, "Lupercal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Horus, 'El Architraidor'", 4L },
                    { 22L, true, "Russ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Leman, 'El Rey Lobo'", 4L },
                    { 23L, true, "Guilliman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Robute, 'El Maestro de Ultramar'", 4L },
                    { 24L, true, "El'Jhonson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lion, 'La Bestia'", 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SectorId",
                table: "Empleados",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_LogsVisitas_EmpleadoVisitadoId",
                table: "LogsVisitas",
                column: "EmpleadoVisitadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LogsVisitas_SectorId",
                table: "LogsVisitas",
                column: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogsVisitas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Sectores");
        }
    }
}
