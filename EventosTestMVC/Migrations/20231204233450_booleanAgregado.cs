using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class booleanAgregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaConfirmado",
                table: "UsuarioToEventos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaConfirmado",
                table: "UsuarioToEventos");
        }
    }
}
