using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class Avatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "AvatarUsers",
                newName: "RutaJson");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AvatarUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AvatarUsers");

            migrationBuilder.RenameColumn(
                name: "RutaJson",
                table: "AvatarUsers",
                newName: "ImageUrl");
        }
    }
}
