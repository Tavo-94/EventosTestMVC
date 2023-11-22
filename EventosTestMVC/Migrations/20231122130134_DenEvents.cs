using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class DenEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListaCosas",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lugar",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoEvento",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vestimenta",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListaCosas",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Lugar",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TipoEvento",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Vestimenta",
                table: "Events");
        }
    }
}
