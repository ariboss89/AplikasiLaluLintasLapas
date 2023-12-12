using System;
using System.ComponentModel.DataAnnotations;

namespace AplikasiLaluLintasLapas.Models
{
	public class Config
	{
		[Key]
		public int Id { get; set; }

        public string config_key { get; set; }
        public int config_value { get; set; }
    }
}

