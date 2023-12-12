using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddAplusanToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplusans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JumlahWBP = table.Column<int>(type: "int", nullable: false),
                    JumlahKeseluruhan = table.Column<int>(type: "int", nullable: false),
                    DariRupam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeRupam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personil = table.Column<int>(type: "int", nullable: false),
                    Hadir = table.Column<int>(type: "int", nullable: false),
                    Tidak = table.Column<int>(type: "int", nullable: false),
                    Cuti = table.Column<int>(type: "int", nullable: false),
                    Sakit = table.Column<int>(type: "int", nullable: false),
                    Izin = table.Column<int>(type: "int", nullable: false),
                    DinasLuar = table.Column<int>(type: "int", nullable: false),
                    Pengawalan = table.Column<int>(type: "int", nullable: false),
                    Sidang = table.Column<int>(type: "int", nullable: false),
                    Pilihan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplusans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplusans");
        }
    }
}
