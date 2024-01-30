using System;
using AplikasiLaluLintasLapas.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikasiLaluLintasLapas.ViewModels
{
	public class DtBonKerjaVM
	{
        public DtBonKerja DtBonKerja { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListWBP { get; set; }
    }
}

