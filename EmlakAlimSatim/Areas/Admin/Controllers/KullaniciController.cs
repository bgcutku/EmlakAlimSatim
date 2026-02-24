using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                _context.kullanicilars.Add(kullanici);
                _context.SaveChanges();
                return RedirectToAction("Index", "Kullanici", new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();

        }
    }
}
