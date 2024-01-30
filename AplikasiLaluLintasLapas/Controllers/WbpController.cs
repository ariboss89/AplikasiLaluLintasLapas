using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikasiLaluLintasLapas.Data;
using AplikasiLaluLintasLapas.Models;
using AplikasiLaluLintasLapas.SD;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiLaluLintasLapas.Controllers
{
    public class WbpController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WbpController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? Id)
        {
            Wbp wbp = new Wbp();

            if (Id != null)
            {
                if (wbp == null)
                {
                    return NotFound();
                }

                var data = _db.Wbps.Where(x => x.Id == Id).FirstOrDefault();

                wbp.Id = data.Id;
                wbp.Nama = data.Nama;
                wbp.Nomor = data.Nomor;
                wbp.Perkara = data.Perkara;
                wbp.JenisKelamin = data.JenisKelamin;
                wbp.MasaTahanan = data.MasaTahanan;
                wbp.BlokTahanan = data.BlokTahanan;

                return View(wbp);
            }
            
            return View(wbp);
        }

        [HttpPost]
        public IActionResult Upsert(Wbp wbp)
        {
            if (ModelState.IsValid)
            {
                if (wbp.Id == 0)
                {
                    _db.Wbps.Add(wbp);
                    _db.SaveChanges();

                    TempData["success"] = "Data WBP berhasil di tambahkan";
                }
                else
                {
                    _db.Wbps.Update(wbp);
                    _db.SaveChanges();

                    TempData["success"] = "Data WBP berhasil di ubah";
                }

                return RedirectToAction("Index");
            }

            TempData["error"] = "Data WBP gagal di tambahkan";

            return View(wbp);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Wbp> wbpList = _db.Wbps.OrderByDescending(x => x.Id).ToList();

            return Json(new { data = wbpList });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var objFromDb = _db.Wbps.Find(Id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _db.Wbps.Remove(objFromDb);
            _db.SaveChanges();

            TempData["Success"] = "Hapus Data Berhasil";

            return Json(new { success = true, message = "Delete Successful" });

            //return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}