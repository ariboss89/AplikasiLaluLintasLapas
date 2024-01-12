using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.Models
{
	public class Aplusan
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Jumlah Warga Binaan")]
        public int JumlahWBP { get; set; }
        [Required]
        [Display(Name = "Jumlah Tahanan")]
        public int Tahanan { get; set; }
        [Required]
        [Display(Name = "Tahanan Pria")]
        public int TahananPria { get; set; }
        [Required]
        [Display(Name = "Tahanan Wanita")]
        public int TahananWanita { get; set; }
        [Required]
        [Display(Name = "Jumlah Narapidana")]
        public int Narapidana { get; set; }
        [Required]
        [Display(Name = "Narapidana Pria")]
        public int NarapidanaPria { get; set; }
        [Required]
        [Display(Name = "Narapidana Wanita")]
        public int NarapidanaWanita { get; set; }
        [Required]
        [Display(Name = "Jumlah Keseluruhan")]
        public int JumlahKeseluruhan { get; set; }
        [Required]
        [Display(Name = "Dari Rupam")]
        public string DariRupam { get; set; }
        [Required]
        [Display(Name = "Ke Rupam")]
        public string KeRupam { get; set; }
        [Required]
        [Display(Name = "Jumlah Personil")]
        public int Personil { get; set; }
        [Required]
        public int Hadir { get; set; }
        [Required]
        public int Tidak { get; set; }
        [Required]
        public int Cuti { get; set; }
        [Required]
        public int Sakit { get; set; }
        [Required]
        public int Izin { get; set; }
        [Required]
        [Display(Name = "Dinas Luar")]
        public int DinasLuar { get; set; }
        [Required]
		public int Pengawalan { get; set; }
        [Required]
        [Display(Name = "Sidang Tahanan")]
        public int SidangTahanan { get; set; }
        [Required]
        [Display(Name = "Sidang Narapidana")]
        public int SidangNarapidana { get; set; }
        [Required]
        public int RSUD { get; set; }
        [Required]
        public int Asimilasi { get; set; }
        [Required]
        [Display(Name ="Bon Kejaksaan")]
        public int BonKejaksaan { get; set; }
        [Required]
        [Display(Name = "Bon Polisi")]
        public int BonPolisi { get; set; }
        [Required]
        [Display(Name = "Bon Kerja")]
        public int BonKerja { get; set; }
        [Required]
        [Display(Name = "Bon Lain-Lain")]
        public int BonLain { get; set; }
        [Required]
        public DateTime Tanggal { get; set; }
        
        [Display(Name = "Link Gambar")]
        public string ImgUrl { get; set; }
	}
}

