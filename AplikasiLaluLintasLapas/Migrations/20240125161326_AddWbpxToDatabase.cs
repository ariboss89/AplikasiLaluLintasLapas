using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddWbpxToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wbps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasaTahanan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlokTahanan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wbps", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wbps");
        }
    }
}
