using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBonKerja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blok",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "JenisKelamin",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "Keterangan",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "NamaWBP",
                table: "BonKerjas");

            migrationBuilder.AddColumn<int>(
                name: "Jumlah",
                table: "BonKerjas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jumlah",
                table: "BonKerjas");

            migrationBuilder.AddColumn<string>(
                name: "Blok",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JenisKelamin",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Keterangan",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NamaWBP",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
