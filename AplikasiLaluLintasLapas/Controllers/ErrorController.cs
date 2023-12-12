using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiLaluLintasLapas.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            //var statusCodeResult = HttpContext.Features.Get<IStatusCodeHttpResult>();

            //switch (statusCode)
            //{
            //    case 404:
            //        ViewBag.ErrorMessage = "";
            //        ViewBag.Path = statusCode.OriginalPath;
            //        ViewBag.QS = statusCodeResult.;
            //        break;
            //}

            return View();
        }
    }
}