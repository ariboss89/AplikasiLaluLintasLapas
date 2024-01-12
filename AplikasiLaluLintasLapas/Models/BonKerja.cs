using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.Models
{
	public class BonKerja
	{
        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Tanggal")]
        public DateTime Tanggal { get; set; }
        [Required]
        [Display(Name = "Jumlah")]
        public int Jumlah { get; set; }
        [Display(Name = "Kepala Rutan")]
        public string TtdKaRutan { get; set; }
        [Display(Name = "Kasi Yantah")]
        public string TtdKaYantah { get; set; }
        [Display(Name = "Kepala Kpr")]
        public string TtdKaKpr { get; set; }
        [Display(Name = "Kepala Rupam")]
        public string TtdKaRupam { get; set; }
        [Display(Name = "Petugas")]
        public string Petugas { get; set; }
        [Display(Name = "TTD Kepala Rutan")]
        public string UrlTtdKaRutan { get; set; }
        [Display(Name = "TTD Kasi Yantah")]
        public string UrlTtdKasiYantah { get; set; }
        [Display(Name = "TTD Kepala Kpr")]
        public string UrlTtdKaKpr { get; set; }
        [Display(Name = "TTD Kepala Rupam")]
        public string UrlTtdKaRupam { get; set; }
        [Required]
        [Display(Name = "NIP Kepala Rupam")]
        public string NipKaRupam { get; set; }
        [Required]
        [Display(Name = "Nama Kepala Rupam")]
        public string NamaKaRupam { get; set; }     
    }
}

