using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnAtBonkerja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTtdKaKpr",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlTtdKaRupam",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlTtdKaRutan",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlTtdKasiYantah",
                table: "BonKerjas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTtdKaKpr",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "UrlTtdKaRupam",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "UrlTtdKaRutan",
                table: "BonKerjas");

            migrationBuilder.DropColumn(
                name: "UrlTtdKasiYantah",
                table: "BonKerjas");
        }
    }
}
