﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    /// <inheritdoc />
    public partial class AddBonKerjaToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonKerjas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaWBP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Blok = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonKerjas");
        }
    }
}
