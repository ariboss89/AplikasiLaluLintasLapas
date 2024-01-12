using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddNipAndNamaToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamaKaRupam",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NipKaRupam",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamaKaRupam",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "NipKaRupam",
                table: "BonKerjas");
        }
    }
}
