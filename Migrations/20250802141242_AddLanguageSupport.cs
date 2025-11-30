using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebCV.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Cv",
                newName: "SummaryEn");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Cv",
                newName: "SummaryBg");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Cv",
                newName: "SkillsEn");

            migrationBuilder.RenameColumn(
                name: "Education",
                table: "Cv",
                newName: "SkillsBg");

            migrationBuilder.AddColumn<string>(
                name: "EducationBg",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceBg",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationBg",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "EducationEn",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ExperienceBg",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ExperienceEn",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Cv");

            migrationBuilder.RenameColumn(
                name: "SummaryEn",
                table: "Cv",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "SummaryBg",
                table: "Cv",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillsEn",
                table: "Cv",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "SkillsBg",
                table: "Cv",
                newName: "Education");
        }
    }
}
