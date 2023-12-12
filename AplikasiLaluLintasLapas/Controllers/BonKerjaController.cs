using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikasiLaluLintasLapas.Data;
using AplikasiLaluLintasLapas.Models;
using Microsoft.AspNetCore.Mvc;
using AplikasiLaluLintasLapas.SD;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AplikasiLaluLintasLapas.ViewModels;

namespace AplikasiLaluLintasLapas.Controllers
{
    public class BonKerjaController : Controller
    {
        private readonly ApplicationDbContext _db;

        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;

        public BonKerjaController(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {

            if (_signInManager.IsSignedIn(User))
            {
                var user = _userManager.GetUserId(User);
                var role = _db.ApplicationUsers.Where(x => x.Id == user).ToList();

                return View();
            }

            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }

        public IActionResult UpsertDetail(int? Id)
        {
            DtBonKerja dtBonKerja = new DtBonKerja();

            if (Id != null)
            {
                if (dtBonKerja == null)
                {
                    return NotFound();
                }

                return View(dtBonKerja);
            }
            else
            {
                StaticData.TtdKaKpr = "Disapprove";
                StaticData.TtdKaRupam = "Disapprove";
                StaticData.TtdKaRutan = "Disapprove";
                StaticData.TtdKaYantah = "Disapprove";
            }
            return View(dtBonKerja);
        }

        [HttpPost]
        public IActionResult BonKerjaPage(BonKerja bonKerjax)
        {
            BonKerja bonKerja = new BonKerja();

            var data = _db.BonKerjas.Where(x => x.Id == bonKerjax.Id).FirstOrDefault();

            if (data != null)
            {
                bonKerja.Id = data.Id;
                bonKerja.Jumlah = data.Jumlah;
                bonKerja.Petugas = data.Petugas;
                bonKerja.Tanggal = data.Tanggal;

                var userId = _userManager.GetUserId(User);
                var roleId = _db.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
                var roleName = _db.Roles.Where(x => x.Id == roleId.RoleId).FirstOrDefault();

                bonKerja.TtdKaKpr = data.TtdKaKpr;
                bonKerja.TtdKaRupam = data.TtdKaRupam;
                bonKerja.TtdKaRutan = data.TtdKaRutan;
                bonKerja.TtdKaYantah = data.TtdKaYantah;

                bonKerja.UrlTtdKaKpr = data.UrlTtdKaKpr;
                bonKerja.UrlTtdKaRupam = data.UrlTtdKaRupam;
                bonKerja.UrlTtdKaRutan = data.UrlTtdKaRutan;
                bonKerja.UrlTtdKasiYantah = data.UrlTtdKasiYantah;

                var dataUser = _db.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

                if (dataUser != null)
                {
                    if (dataUser.UrlTTd != null || dataUser.UrlTTd != "")
                    {
                        if (roleName.Name == ("KASI YANTAH") && bonKerjax.TtdKaYantah.Equals("Approve"))
                        {
                            bonKerja.UrlTtdKasiYantah = dataUser.UrlTTd;
                            bonKerja.TtdKaYantah = bonKerjax.TtdKaYantah;
                        }
                        else if (roleName.Name == ("KA KPR") && bonKerjax.TtdKaKpr.Equals("Approve"))
                        {
                            bonKerja.UrlTtdKaKpr = dataUser.UrlTTd;
                            bonKerja.TtdKaKpr = bonKerjax.TtdKaKpr;
                        }
                        else if (roleName.Name == ("KA RUPAM") && bonKerjax.TtdKaRupam.Equals("Approve"))
                        {
                            bonKerja.UrlTtdKaRupam = dataUser.UrlTTd;
                            bonKerja.TtdKaRupam = bonKerjax.TtdKaRupam;
                        }
                        else if (roleName.Name == ("KA RUTAN") && bonKerjax.TtdKaRutan.Equals("Approve"))
                        {
                            bonKerja.UrlTtdKaRutan = dataUser.UrlTTd;
                            bonKerja.TtdKaRutan = bonKerjax.TtdKaRutan;
                        }

                        else if (roleName.Name == ("KASI YANTAH") && bonKerjax.TtdKaYantah.Equals("Disapprove"))
                        {
                            bonKerja.UrlTtdKasiYantah = "";
                            bonKerja.TtdKaYantah = bonKerjax.TtdKaYantah;
                        }
                        else if (roleName.Name == ("KA KPR") && bonKerjax.TtdKaKpr.Equals("Disapprove"))
                        {
                            bonKerja.UrlTtdKaKpr = "";
                            bonKerja.TtdKaKpr = bonKerjax.TtdKaKpr;
                        }
                        else if (roleName.Name == ("KA RUPAM") && bonKerjax.TtdKaRupam.Equals("Disapprove"))
                        {
                            bonKerja.UrlTtdKaRupam = "";
                            bonKerja.TtdKaRupam = bonKerjax.TtdKaRupam;
                        }
                        else if (roleName.Name == ("KA RUTAN") && bonKerjax.TtdKaRutan.Equals("Disapprove"))
                        {
                            bonKerja.UrlTtdKaRutan = "";
                            bonKerja.TtdKaRutan = bonKerjax.TtdKaRutan;
                        }

                        _db.Update(bonKerja);
                        _db.SaveChanges();

                        TempData["Success"] = "Data berhasil di update";

                        return RedirectToAction("Index", "BonKerja");

                        // return View(bonKerja);
                    }
                }

                TempData["Error"] = "Data gagal di update";

                return RedirectToAction("Index", "BonKerja");
            }

            if (bonKerja == null)
            {
                return NotFound();
            }

            return Redirect("/BonKerja/Index");

        }
 
        public IActionResult BonKerjaPage(string? Id)
        {
            BonKerja bonKerja = new BonKerja();

            var userId = _userManager.GetUserId(User);
            var roleId = _db.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            var roleName = _db.Roles.Where(x => x.Id == roleId.RoleId).FirstOrDefault();

            var dataUser = _db.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

            if (dataUser != null)
            {
                if (dataUser.UrlTTd == null)
                {
                    TempData["Error"] = "Silahkan upload tanda tangan terlebih dahulu sebelum melakukan approval";
                    return RedirectToAction("Index", "BonKerja");
                } 
            }

            if (Id != null)
            {
                var dataBonKerja = _db.BonKerjas.Where(x => x.Id == Id).FirstOrDefault();

                if (dataBonKerja != null)
                {
                    bonKerja.Id = Id;
                    bonKerja.Jumlah = dataBonKerja.Jumlah;
                    bonKerja.Petugas = dataBonKerja.Petugas;
                    bonKerja.Tanggal = dataBonKerja.Tanggal;

                    bonKerja.TtdKaKpr = dataBonKerja.TtdKaKpr;
                    bonKerja.TtdKaRupam = dataBonKerja.TtdKaRupam;
                    bonKerja.TtdKaRutan = dataBonKerja.TtdKaRutan;
                    bonKerja.TtdKaYantah = dataBonKerja.TtdKaYantah;

                    bonKerja.UrlTtdKaKpr = dataBonKerja.UrlTtdKaKpr;
                    bonKerja.UrlTtdKaRupam = dataBonKerja.UrlTtdKaRupam;
                    bonKerja.UrlTtdKaRutan = dataBonKerja.UrlTtdKaRutan;
                    bonKerja.UrlTtdKasiYantah = dataBonKerja.UrlTtdKasiYantah;

                    StaticData.IdBonKerja = Id;
                    StaticData.TtdKaKpr = bonKerja.TtdKaKpr;
                    StaticData.TtdKaRupam = bonKerja.TtdKaRupam;
                    StaticData.TtdKaRutan = bonKerja.TtdKaRutan;
                    StaticData.TtdKaYantah = bonKerja.TtdKaYantah;

                    ApplicationUser applicationUser = new ApplicationUser();

                    var dataUserx = _db.ApplicationUsers.ToList();

                    //var userId = _userManager.GetUserId(User);
                    //var email = _db.Users.Where(x => x.Id == userId).FirstOrDefault();

                    //var user = _userManager.GetUserId(User);
                    //var role = _db.Roles.Where(x => x.Id == user).ToList();

                    //foreach(var item in )


                    if (bonKerja.TtdKaKpr == "Approve")
                    {
                        var ttd = dataUserx.Where(x => x.Email == "kakpr@gmail.com").FirstOrDefault();

                        if (ttd != null)
                        {
                            StaticData.UrlTtdKaKpr = ttd.UrlTTd;
                        }
                    }

                    if (bonKerja.TtdKaRupam == "Approve")
                    {
                        StaticData.UrlTtdKaRupam = bonKerja.TtdKaRupam;
                    }

                    if (bonKerja.TtdKaRutan == "Approve")
                    {
                        StaticData.UrlTtdKaRutan = bonKerja.TtdKaRutan;
                    }

                    if (bonKerja.TtdKaKpr == "Approve")
                    {
                        StaticData.UrlTtdKaYantah = bonKerja.TtdKaKpr;
                    }

                    if (bonKerja.TtdKaKpr.Equals("Approve"))
                    {
                        StaticData.Aksi = bonKerja.TtdKaKpr;
                    }

                    if (bonKerja.TtdKaRupam.Equals("Approve"))
                    {
                        StaticData.Aksi = bonKerja.TtdKaRupam;
                    }

                    if (bonKerja.TtdKaRutan.Equals("Approve"))
                    {
                        StaticData.Aksi = bonKerja.TtdKaRutan;
                    }

                    if (bonKerja.TtdKaYantah.Equals("Approve"))
                    {
                        StaticData.Aksi = bonKerja.TtdKaYantah;
                    }

                    return View(bonKerja);
                }
            }

            if (bonKerja == null)
            {
                return NotFound();
            }

            return View(bonKerja);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult UpsertDetail(DtBonKerja bonKerja)
        {
            if (bonKerja.IdDetail == 0)
            {
                //bonKerja.NamaWBP = bonKerja.NamaWBP;
                //bonKerja.Blok = bonKerja.Blok;

                var data = _db.Configs.Where(x => x.config_key == "bonkerja").FirstOrDefault();
                int id = data.config_value;
                id++;
                string idBonKerja = "";
                idBonKerja = $"BON-{id.ToString("D5")}";

                bonKerja.IdBonKerja = idBonKerja;


                _db.DtBonKerjas.Add(bonKerja);
                _db.SaveChanges();
            }
            
            _db.SaveChanges();

            TempData["success"] = " Data detail bonkerja berhasil di tambahkan";

            bonKerja.IdDetail = 0;
            bonKerja.JenisKelamin = "";
            bonKerja.Blok = "";
            bonKerja.Keterangan = "";

            return View(bonKerja);

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BonKerja> bonKerjaList = _db.BonKerjas.ToList();

            return Json(new { data = bonKerjaList });
        }

        [HttpGet]
        public IActionResult GetAllDetail()
        {
            var data = _db.Configs.Where(x => x.config_key == "bonkerja").FirstOrDefault();
            int id = data.config_value;
            id++;
            string idBonKerja = "";
            idBonKerja = $"BON-{id.ToString("D5")}";

            List<DtBonKerja> dtBonKerjaList = _db.DtBonKerjas.ToList();

            //int id = 0;

            var allData = dtBonKerjaList.Where(x => x.IdBonKerja == idBonKerja).ToList();

            return Json(new { data = allData });
        }

        [HttpGet]
        public IActionResult GetDetail()
        {
            string id = StaticData.IdBonKerja;

            List<DtBonKerja> dtBonKerjaList = _db.DtBonKerjas.ToList();

            var allData = dtBonKerjaList.Where(x => x.IdBonKerja == id).ToList();

            return Json(new { data = allData });
        }

       // [HttpPost]
        //[ValidateAntiForgeryToken]
        public void SaveAll()
        {
            BonKerja bonKerja = new BonKerja();
            Config config = new Config();
           
            var data = _db.Configs.Where(x => x.config_key == "bonkerja").FirstOrDefault();
            int id = data.config_value;
            id++;
            string idBonKerja = "";
            idBonKerja = $"BON-{id.ToString("D5")}";

            var checkData = _db.DtBonKerjas.Where(x => x.IdBonKerja == idBonKerja).ToList();

            var user = _userManager.GetUserName(User);

            if (checkData != null || checkData.Count !=0)
            {
                bonKerja.Id = idBonKerja;
                bonKerja.Jumlah = checkData.Count;
                bonKerja.Tanggal = DateTime.Now;
                bonKerja.Petugas = user;
                bonKerja.TtdKaKpr = "Disapprove";
                bonKerja.TtdKaRupam = "Disapprove";
                bonKerja.TtdKaRutan = "Disapprove";
                bonKerja.TtdKaYantah = "Disapprove";

                bonKerja.UrlTtdKaKpr = "";
                bonKerja.UrlTtdKaRupam = "";
                bonKerja.UrlTtdKaRutan = "";
                bonKerja.UrlTtdKasiYantah = "";

                config.config_key = "bonkerja";
                config.config_value = id++;
                config.Id = data.Id; 

                _db.Configs.Update(config);
                _db.BonKerjas.Add(bonKerja);


                _db.SaveChanges();

                TempData["Success"] = "Bon Kerja Berhasil di Tambahkan";
 
            }

            else
            {
                TempData["Error"] = "Bon Kerja Gagal di Tambahkan";
            }
        }

        [HttpDelete]
        public IActionResult DeleteDetail(int Id)
        {
            //var objFromDb = _db.DtBonKerjas.Where(Id);
            var dataDt = _db.DtBonKerjas.Where(x => x.IdDetail == Id).FirstOrDefault();

            if (dataDt == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            //for(int a=0; a<dataDt.Count;a++)
            //{
            //    _db.DtBonKerjas.Remove(dataDt[a]);
            //}

            _db.DtBonKerjas.Remove(dataDt);
            _db.SaveChanges();

            return Json(new { success = true, message = "Delete Successful" });

            //TempData["Success"] = "Hapus Data Berhasil";

            //return RedirectToAction("Index", "BonKerja");
        }

        [HttpDelete]
        public IActionResult Delete(string Id)
        {
            var objFromDb = _db.BonKerjas.Find(Id);
            var dataDt = _db.DtBonKerjas.Where(x => x.IdBonKerja == Id).ToList();

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            for (int a = 0; a < dataDt.Count; a++)
            {
                _db.DtBonKerjas.Remove(dataDt[a]);
            }

            _db.BonKerjas.Remove(objFromDb);
            _db.SaveChanges();

            return Json(new { success = true, message = "Delete Successful" });
        }

        //[HttpGet]
        public IActionResult Print(string Id)
        {
            //Id = StaticData.IdBonKerja;

            BonKerjaVM bonKerja = new BonKerjaVM()
            {
                BonKerja = new BonKerja(),
                ListDetail = new List<DtBonKerja>()

            };

            var data = _db.BonKerjas.Where(x => x.Id == Id).FirstOrDefault();
            var checkData = _db.DtBonKerjas.Where(x => x.IdBonKerja == Id).ToList();

            List<DtBonKerja> listDetail = new List<DtBonKerja>();

            var user = _userManager.GetUserName(User);

            if (checkData != null)
            {
                bonKerja.BonKerja.Id = Id;
                bonKerja.BonKerja.Jumlah = checkData.Count;
                bonKerja.BonKerja.Tanggal = DateTime.Now;
                bonKerja.BonKerja.Petugas = user;
                bonKerja.BonKerja.TtdKaKpr = data.TtdKaKpr;
                bonKerja.BonKerja.TtdKaRupam = data.TtdKaRupam;
                bonKerja.BonKerja.TtdKaRutan = data.TtdKaRutan;
                bonKerja.BonKerja.TtdKaYantah = data.TtdKaYantah;

                bonKerja.BonKerja.UrlTtdKaKpr = data.UrlTtdKaKpr;
                bonKerja.BonKerja.UrlTtdKaRupam = data.UrlTtdKaRupam;
                bonKerja.BonKerja.UrlTtdKaRutan = data.UrlTtdKaRutan;
                bonKerja.BonKerja.UrlTtdKasiYantah = data.UrlTtdKasiYantah;

                bonKerja = new BonKerjaVM
                {
                    BonKerja = bonKerja.BonKerja,
                    ListDetail = checkData
                };

            }

            else
            {
                TempData["Error"] = "Bon Kerja Gagal di Tambahkan";
            }

            return View(bonKerja);
        }

        #endregion
    }
}