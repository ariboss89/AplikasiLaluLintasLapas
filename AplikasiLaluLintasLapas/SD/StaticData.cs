using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.SD
{
	public class StaticData
	{
        public const string Role_KARutan = "KA RUTAN";
        public const string Role_KasiYantah = "KASI YANTAH";
        public const string Role_KAKPR = "KA KPR";
        public const string Role_KARUPAM = "KA RUPAM";
        public const string Role_Petugas = "PETUGAS";

        public static string TtdKaRutan { get; set; }
        public static string TtdKaYantah { get; set; }
        public static string TtdKaKpr { get; set; }
        public static string TtdKaRupam { get; set; }
        public static string Petugas { get; set; }
        public static string Keterangan { get; set; }

        public static string UrlTtdKaRutan { get; set; }
        public static string UrlTtdKaYantah { get; set; }
        public static string UrlTtdKaKpr { get; set; }
        public static string UrlTtdKaRupam { get; set; }

        public static string IdBonKerja { get; set; }
        public static string Aksi { get; set; }
        public static string UrlTTd { get; set; }
    }
}

