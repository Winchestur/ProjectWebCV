using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebCV.Migrations
{
    /// <inheritdoc />
    public partial class AddSocialAndLocationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Cv");
        }
    }
}
