using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddBonKerjaAndDtToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonKerjas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Jumlah = table.Column<int>(type: "int", nullable: false),
                    TtdKaRutan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TtdKaYantah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TtdKaKpr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TtdKaRupam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Petugas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonKerjas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DtBonKerjas",
                columns: table => new
                {
                    IdDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBonKerja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaWBP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blok = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtBonKerjas", x => x.IdDetail);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonKerjas");

            migrationBuilder.DropTable(
                name: "DtBonKerjas");
        }
    }
}
