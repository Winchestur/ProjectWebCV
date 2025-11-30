using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebCV.Migrations
{
    /// <inheritdoc />
    public partial class AddInterests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterestsBg",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterestsEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestsBg",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "InterestsEn",
                table: "Cv");
        }
    }
}
