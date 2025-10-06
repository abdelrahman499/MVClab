using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVClab.Migrations
{
    /// <inheritdoc />
    public partial class degreeadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinDegree",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MinDegree",
                table: "Courses");
        }
    }
}
