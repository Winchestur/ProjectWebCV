using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebCV.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectsDescriptionBg",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectsDescriptionEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectsLinks",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectsTitleBg",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectsTitleEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectsDescriptionBg",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ProjectsDescriptionEn",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ProjectsLinks",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ProjectsTitleBg",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ProjectsTitleEn",
                table: "Cv");
        }
    }
}
