using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebCV.Migrations
{
    /// <inheritdoc />
    public partial class AddFullNameEn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullNameEn",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameEn",
                table: "Cv");
        }
    }
}
