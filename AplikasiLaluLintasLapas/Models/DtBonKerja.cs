using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.Models
{
	public class DtBonKerja
	{
        [Key]
        [Display(Name = "Id Detail")]
        public int IdDetail { get; set; }
        [Required]
        [Display(Name = "Id Bon Kerja")]
        public string IdBonKerja { get; set; }
        [Required]
        [Display(Name = "Nama Warga Binaan")]
        public string NamaWBP { get; set; }
        [Required]
        [Display(Name = "Jenis Kelamin")]
        public string JenisKelamin { get; set; }        
        [Required]
        [Display(Name = "Blok")]
        public string Blok { get; set; }

        [Display(Name = "Jenis Bon Kerja")]
        public string JenisBonKerja { get; set; }

        [Display(Name = "Keterangan")]
        public string Keterangan { get; set; }
    }
}

