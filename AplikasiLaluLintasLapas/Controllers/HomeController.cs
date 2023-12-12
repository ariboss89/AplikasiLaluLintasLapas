using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AplikasiLaluLintasLapas.Models;
using AplikasiLaluLintasLapas.Data;
using AplikasiLaluLintasLapas.SD;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;

namespace AplikasiLaluLintasLapas.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;

    UserManager<IdentityUser> _userManager;
    SignInManager<IdentityUser> _signInManager;


    public HomeController(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IWebHostEnvironment webHostEnvironment)
    {
        _db = db;
        _userManager = userManager;
        _signInManager = signInManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index(BonKerja br)
    {

        if (_signInManager.IsSignedIn(User))
        {
            var user = _userManager.GetUserId(User);

            return View(br);
        }

        else
        {
            // get user roles
            //var user = userManager.FindByEmailAsync(User.ToString());
            //// Get the roles for the user
            //var roles = await _userManager.GetRolesAsync(user);

            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

       
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Profil()
    {

        ApplicationUser applicationUser = new ApplicationUser();

        var userId = _userManager.GetUserId(User);
        var email = _db.Users.Where(x => x.Id == userId).FirstOrDefault();

        if (email != null)
        {
            var data = _db.ApplicationUsers.Where(x => x.Email == email.Email).FirstOrDefault();

            //var Items = _db.Users.Find(userId).Items.ToList();

            var aa = _db.UserLogins.ToList();

            if (data != null)
            {
                applicationUser.Email = data.Email;
                applicationUser.Nama = data.Nama;
                applicationUser.Kontak = data.Kontak;
                applicationUser.UrlTTd = data.UrlTTd;

                if (applicationUser.UrlTTd == null)
                {
                    StaticData.UrlTTd = "";
                }
                else
                {
                    StaticData.UrlTTd = applicationUser.UrlTTd;
                }

                return View(applicationUser);
            }
        }

        StaticData.UrlTTd = "";

        return View(applicationUser);
    }

    [HttpPost]
    public IActionResult Profil(ApplicationUser applicationUser, IFormFile? file)
    {
        if (applicationUser.UrlTTd == null)
        {
            StaticData.UrlTTd = "";
        }

        var userId = _userManager.GetUserId(User);
        var data = _db.Users.Where(x => x.Id == userId).FirstOrDefault();

        if (data != null)
        {

            applicationUser.Id = data.Id;
            applicationUser.UserName = data.UserName;
            applicationUser.NormalizedUserName = data.NormalizedUserName;
            applicationUser.Email = data.Email;
            applicationUser.NormalizedEmail = data.NormalizedEmail;
            applicationUser.EmailConfirmed = data.EmailConfirmed;
            applicationUser.PasswordHash = data.PasswordHash;
            applicationUser.SecurityStamp = data.SecurityStamp;
            applicationUser.ConcurrencyStamp = data.ConcurrencyStamp;
            applicationUser.PhoneNumber = data.PhoneNumber;
            applicationUser.LockoutEnabled = data.LockoutEnabled;

            string wwwWebRootPath = _webHostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwWebRootPath, @"images/signature");

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                applicationUser.UrlTTd = @"/images/signature/" + fileName;

                TempData["success"] = "Data berhasil di ubah";

                _db.Users.Update(applicationUser);
                _db.SaveChanges();
            }
        }

        return RedirectToAction("Index","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult GetData()
    {
        List<Aplusan> aplusanList = _db.Aplusans.ToList();

        var tgl = DateTime.Now.ToString("yyyy-MM-dd");

        //var tgl = ("2023-11-27");

        //var dataKu = aplusanList.Where(x => x.Tanggal == Convert.ToDateTime(tgl)).ToList();

        //var orderBy =  dataKu.OrderByDescending(x=>x.Id).ToList();

        //var dataKu = aplusanList.Where(x => x.Tanggal == Convert.ToDateTime(tgl)).ToList();

        var countBonKerja = _db.BonKerjas.Where(x => x.Tanggal >= DateTime.Now || x.Tanggal <= DateTime.Now).ToList().Count; 

        var orderBy = aplusanList.OrderByDescending(x => x.Id).ToList();

        if (aplusanList != null && orderBy.Count !=0)
        {
            //var dataBonKerja = _db.BonKerjas.Where(x => x.Tanggal == Convert.ToDateTime(tgl)).ToList();

            //int count = dataBonKerja.Count();

            //int count = 10;

            //dataKu.BonKerja = count;

            orderBy[0].BonKerja = countBonKerja;
            
            return Json(new { data = orderBy[0] });
        }
        else
        {
            TempData["error"] = "Data Aplusan Tidak Tersedia";

            return RedirectToAction("Index", "Home");
        }
    }

    [HttpGet]
    public IActionResult Print(int?Id)
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
        
        aplusan.Tanggal = DateTime.Now;

        return View(aplusan);
    }
}

