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

        }
    }
}
