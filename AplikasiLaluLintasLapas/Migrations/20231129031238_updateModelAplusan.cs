using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class updateModelAplusan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NarapidanaPria",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NarapidanaWanita",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TahananPria",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TahananWanita",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NarapidanaPria",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "NarapidanaWanita",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "TahananPria",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "TahananWanita",
                table: "Aplusans");
        }
    }
}
