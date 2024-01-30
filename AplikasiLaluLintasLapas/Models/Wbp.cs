using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.Models
{
	public class Wbp
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nama WBP")]
        public string Nama { get; set; }
        [Required]
        [Display(Name = "Nomor Registrasi")]
        public string Nomor { get; set; }
        [Required]
        [Display(Name = "Perkara")]
        public string Perkara { get; set; }
        [Required]
        [Display(Name = "Jenis Kelamin")]
        public string JenisKelamin { get; set; }
        [Required]
        [Display(Name = "Masa Tahanan")]
        public string MasaTahanan { get; set; }
        [Required]
        [Display(Name = "Blok/ Kamar")]
        public string BlokTahanan { get; set; }
    }
}

