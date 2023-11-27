using EventosTestMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoEventos : Migration
    {
        /// <inheritdoc />
       
           protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        }
    }
}
