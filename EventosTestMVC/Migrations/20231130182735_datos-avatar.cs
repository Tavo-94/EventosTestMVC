using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class datosavatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "AvatarUsers",
        columns: new[] { "Id", "Name", "RutaJson" },
        values: new object[,]
        {
            { 1, "Avatar1", "~/json/1.json" },
            { 2, "Avatar2", "~/json/2.json" },
            { 3, "Avatar3", "~/json/3.json" },
            { 4, "Avatar4", "~/json/4.json" },
            { 5, "Avatar5", "~/json/5.json" },
            { 6, "Avatar6", "~/json/6.json" },
            { 7, "Avatar7", "~/json/7.json" },
            { 8, "Avatar8", "~/json/8.json" },
            { 9, "Default", "~/json/Default.json" },
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
