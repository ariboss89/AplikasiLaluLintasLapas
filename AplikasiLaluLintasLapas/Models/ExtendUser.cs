using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.Models
{
	public class ExtendUser
	{
        [Key]
        public int Id { get; set; }
        
        public string UserId { get; set; }
        
        public int Tahanan { get; set; }
    }
}

