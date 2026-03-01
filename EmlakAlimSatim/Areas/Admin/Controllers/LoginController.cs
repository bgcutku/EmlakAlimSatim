using Microsoft.AspNetCore.Mvc;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;
using EmlakAlimSatim.Models.ViewModels;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly EmlakDbContext _context;

        public LoginController(EmlakDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            var admin = _context.kullanicilars.FirstOrDefault(x =>
                x.KullaniciAdi == model.KullaniciAdi &&
                x.SifreHash == model.Sifre &&
                x.Role == "Admin"
            );

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminUsername", admin.KullaniciAdi);
                HttpContext.Session.SetString("AdminName", admin.Ad);

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}