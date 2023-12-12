using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAplusanModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sidang",
                table: "Aplusans",
                newName: "Tahanan");

            migrationBuilder.RenameColumn(
                name: "Pilihan",
                table: "Aplusans",
                newName: "RSUD");

            migrationBuilder.AddColumn<string>(
                name: "Asimilasi",
                table: "Aplusans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BonKejaksaan",
                table: "Aplusans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BonKerja",
                table: "Aplusans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BonLain",
                table: "Aplusans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BonPolisi",
                table: "Aplusans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Narapidana",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SidangNarapidana",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SidangTahanan",
                table: "Aplusans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Tanggal",
                table: "Aplusans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asimilasi",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "BonKejaksaan",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "BonKerja",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "BonLain",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "BonPolisi",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "Narapidana",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "SidangNarapidana",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "SidangTahanan",
                table: "Aplusans");

            migrationBuilder.DropColumn(
                name: "Tanggal",
                table: "Aplusans");

            migrationBuilder.RenameColumn(
                name: "Tahanan",
                table: "Aplusans",
                newName: "Sidang");

            migrationBuilder.RenameColumn(
                name: "RSUD",
                table: "Aplusans",
                newName: "Pilihan");
        }
    }
}
