using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class CodigoVestimenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "CodigoVestimentas",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
