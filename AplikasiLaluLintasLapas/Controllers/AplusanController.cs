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
    public class AplusanController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AplusanController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Upsert(Aplusan aplusan, IFormFile? file)
        {
            //if (ModelState.IsValid)
            //{
            string wwwWebRootPath = _webHostEnvironment.WebRootPath;

            int jmlWBP = aplusan.JumlahWBP;

            int jmlTahanan = aplusan.Tahanan;
            int tahananPria = aplusan.TahananPria;
            int tahananWanita = aplusan.TahananWanita;

            int jmlNarapidana = aplusan.Narapidana;
            int narapidanaPria = aplusan.NarapidanaPria;
            int narapidanaWanita = aplusan.NarapidanaWanita;

            int jmlhKeseluruhan = aplusan.JumlahKeseluruhan;

            if (file != null && aplusan.Id == 0)
            {

                if (tahananPria + tahananWanita != jmlTahanan || narapidanaPria + narapidanaWanita != jmlNarapidana || jmlNarapidana + jmlTahanan != jmlWBP)
                {
                    TempData["Error"] = "Jumlah Tahanan dan Narapidana Tidak Sesuai !!";

                    return View(aplusan);
                }
                else
                {

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwWebRootPath, @"images/aplusan");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    aplusan.ImgUrl = @"/images/aplusan/" + fileName;

                    TempData["Success"] = "Aplusan berhasil di tambahkan";

                    _db.Aplusans.Add(aplusan);
                    _db.SaveChanges();
                }
            }
            else if(file != null && aplusan.Id != 0)
            {

                if (tahananPria + tahananWanita != jmlTahanan || narapidanaPria + narapidanaWanita != jmlNarapidana || jmlNarapidana + jmlTahanan != jmlWBP)
                {
                    TempData["Error"] = "Jumlah Tahanan dan Narapidana Tidak Sesuai !!";

                    return View(aplusan);
                }
                else
                {

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwWebRootPath, @"images/aplusan");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    aplusan.ImgUrl = @"/images/aplusan/" + fileName;

                    TempData["Success"] = "Aplusan berhasil di ubah";

                    _db.Aplusans.Update(aplusan);
                    _db.SaveChanges();
                }
            }

            else if(file == null && aplusan.Id != 0)
            {

                if (tahananPria+ tahananWanita != jmlTahanan || narapidanaPria + narapidanaWanita != jmlNarapidana || jmlNarapidana + jmlTahanan != jmlWBP)
                {
                    TempData["Error"] = "Jumlah Tahanan dan Narapidana Tidak Sesuai !!";

                    return View(aplusan);
                }
                else
                {
                    var data = _db.Aplusans.Where(x => x.Id == aplusan.Id).FirstOrDefault();

                    aplusan.ImgUrl = data.ImgUrl;
                    _db.Aplusans.Update(aplusan);
                    _db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Upsert(int? Id)
        {
            Aplusan aplusan = new Aplusan();

            var dataSaatIni = _db.Aplusans.OrderByDescending(x => x.Id).FirstOrDefault();

            if (Id != null)
            {

                var data = _db.Aplusans.Where(x => x.Id == Id).FirstOrDefault();

                if (data != null)
                {
                    aplusan.Id = data.Id;
                    aplusan.JumlahWBP = data.JumlahWBP;
                    aplusan.Tahanan = data.Tahanan;
                    aplusan.TahananPria = data.TahananPria;
                    aplusan.TahananWanita = data.TahananWanita;
                    aplusan.Narapidana = data.Narapidana;
                    aplusan.NarapidanaPria = data.NarapidanaPria;
                    aplusan.NarapidanaWanita = data.NarapidanaWanita;
                    aplusan.DariRupam = data.DariRupam;
                    aplusan.KeRupam = data.KeRupam;
                    aplusan.Personil = data.Personil;
                    aplusan.Hadir = data.Hadir;
                    aplusan.Tidak = data.Tidak;
                    aplusan.Cuti = data.Cuti;
                    aplusan.Sakit = data.Sakit;
                    aplusan.Izin = data.Izin;
                    aplusan.DinasLuar = data.DinasLuar;
                    aplusan.Pengawalan = data.Pengawalan;
                    aplusan.SidangTahanan = data.SidangTahanan;
                    aplusan.SidangNarapidana = data.SidangNarapidana;
                    aplusan.RSUD = data.RSUD;
                    aplusan.BonKerja = data.BonKerja;
                    aplusan.Asimilasi = data.Asimilasi;
                    aplusan.BonKejaksaan = data.BonKejaksaan;
                    aplusan.BonKerja = data.BonKerja;
                    aplusan.BonPolisi = data.BonPolisi;
                    aplusan.BonLain = data.BonLain;
                    aplusan.Tanggal = data.Tanggal;
                    aplusan.ImgUrl = data.ImgUrl;
                    
                    return View(aplusan);

                }
                
                TempData["error"] = "Data tidak ditemukan";
                return View(aplusan);
            }
            else
            {
                aplusan.JumlahWBP = dataSaatIni.JumlahWBP;
                aplusan.Tahanan = dataSaatIni.Tahanan;
                aplusan.TahananPria = dataSaatIni.TahananPria;
                aplusan.TahananWanita = dataSaatIni.TahananWanita;
                aplusan.Narapidana = dataSaatIni.Narapidana;
                aplusan.NarapidanaPria = dataSaatIni.NarapidanaPria;
                aplusan.NarapidanaWanita = dataSaatIni.NarapidanaWanita;
            }


            aplusan.Tanggal = DateTime.Now;

            return View(aplusan);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Aplusan> aplusanList = _db.Aplusans.OrderByDescending(x=>x.Id).ToList();

            return Json(new { data = aplusanList });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var objFromDb = _db.Aplusans.Find(Id);
           
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _db.Aplusans.Remove(objFromDb);
            _db.SaveChanges();

            TempData["Success"] = "Hapus Data Berhasil";

            return Json(new { success = true, message = "Delete Successful" });

            //return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}