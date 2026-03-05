using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;
using Microsoft.AspNetCore.Mvc;
using EmlakAlimSatim.Filters;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]
    public class KullaniciController : Controller
    {
        private readonly EmlakDbContext _context;
        public KullaniciController(EmlakDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var veri = _context.kullanicilars.ToList();
            return View(veri);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kullanicilar kullanici)
        {
            if (ModelState.IsValid)
            {
                kullanici.KayitTarihi = DateTime.Now;
                _context.kullanicilars.Add(kullanici);
                _context.SaveChanges();
                return RedirectToAction("Index", "Kullanici", new {area="Admin"});
            }
            return View(kullanici);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var veri = _context.kullanicilars.Find(id);
            return View(veri);
        }
        [HttpPost]
        public IActionResult Edit(Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                _context.kullanicilars.Update(kullanicilar);
                _context.SaveChanges();
                return RedirectToAction("Index", "Kullanici", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var veri = _context.kullanicilars.Find(id);
            _context.kullanicilars.Remove(veri);
            _context.SaveChanges();
            return RedirectToAction("Index", "Kullanici", new { area = "Admin" });            

        }
    }
}
