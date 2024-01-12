using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Syncfusion.JavaScript.Models;

namespace AplikasiLaluLintasLapas.Models
{
	public class ApplicationUser:IdentityUser
	{
        [Required]
        public string Nip { get; set; }
        [Required]
        public string Nama { get; set; }
        [Required]
        public string? Kontak { get; set; }
        [Required]
        public string? UrlTTd { get; set; }

    }
}

