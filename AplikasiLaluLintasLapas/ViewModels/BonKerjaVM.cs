using System;
using AplikasiLaluLintasLapas.Models;

namespace AplikasiLaluLintasLapas.ViewModels
{
	public class BonKerjaVM
	{
		public BonKerja BonKerja { get; set; } 

		public DtBonKerja DtBonKerja { get; set; }

		public List<DtBonKerja> ListDetail { get; set; }

		public Pejabat Pejabat { get; set; }
	}
}

