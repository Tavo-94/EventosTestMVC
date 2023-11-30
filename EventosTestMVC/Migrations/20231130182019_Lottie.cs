using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class Lottie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivoLottie",
                table: "AvatarUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArchivoLottie",
                table: "AvatarUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
