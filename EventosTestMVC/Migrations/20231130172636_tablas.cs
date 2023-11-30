using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraEntity");

            migrationBuilder.DropTable(
                name: "MesaEntity");

            migrationBuilder.DropTable(
                name: "TareaEntity");
            migrationBuilder.InsertData(
table: "CodigoVestimenta",
columns: new[] { "Id", "Nombre" },
values: new object[,]
{
    { 1, "Casual" },
    { 2, "Formal" },
    { 3, "Elegante" },
    { 4, "Deportivo" },
    { 5, "Disfraz" },
    { 6, "Piyama" }
});

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
{ 1, "Cumpleaños" },
{ 2, "Boda" },
{ 3, "15 años" },
{ 4, "Baby Shower" },
{ 5, "Reunion con amigos" },
{ 6, "Reunion familiar" },
{ 7, "Despedida de soltera/o" },
{ 8, "Piyamada" },
{ 9, "Fiesta" }
   });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompraEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraEntity_EventoEntities_EventoId1",
                        column: x => x.EventoId1,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MesaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesaEntity_EventoEntities_EventoId1",
                        column: x => x.EventoId1,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TareaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareaEntity_EventoEntities_EventoId1",
                        column: x => x.EventoId1,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraEntity_EventoId1",
                table: "CompraEntity",
                column: "EventoId1");

            migrationBuilder.CreateIndex(
                name: "IX_MesaEntity_EventoId1",
                table: "MesaEntity",
                column: "EventoId1");

            migrationBuilder.CreateIndex(
                name: "IX_TareaEntity_EventoId1",
                table: "TareaEntity",
                column: "EventoId1");
        }
    }
}
