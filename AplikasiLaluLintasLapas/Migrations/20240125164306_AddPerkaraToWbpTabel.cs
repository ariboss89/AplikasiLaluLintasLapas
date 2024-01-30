using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddPerkaraToWbpTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Perkara",
                table: "Wbps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perkara",
                table: "Wbps");
        }
    }
}
