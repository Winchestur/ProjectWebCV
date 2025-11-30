using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebCV.Migrations
{
    /// <inheritdoc />
    public partial class AddStudiedLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudiedLanguagesBg",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudiedLanguagesEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudiedLanguagesBg",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "StudiedLanguagesEn",
                table: "Cv");
        }
    }
}
