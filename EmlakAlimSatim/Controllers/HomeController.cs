using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmlakAlimSatim.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmlakDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(EmlakDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var properties = _context.Properties
                .Include(p => p.City)
                .Include(p => p.District)
                .OrderByDescending(p => p.Id)
                .Take(6)
                .ToList();
            return View(properties);
        }

        public IActionResult Search(string search)
        {
            var ilan = _context.Properties
                .Include(p => p.City)
                .Include(p => p.District)
                .Where(p => p.Title.Contains(search) || p.District.Name.Contains(search) || p.City.Name.Contains(search)).ToList();
            return View(ilan);
        }
        public IActionResult Satilik()
        {
            var sati = _context.Properties
                .Include(p => p.City)
                .Include(p => p.District)
                .Where(p => p.ListingType == "Satýlýk" && p.IsActive)
                .OrderByDescending(p => p.Id).ToList();
            return View(sati);

        }
        public IActionResult Kiralik()
        {
            var kira = _context.Properties
                .Include(p => p.City)
                .Include(p => p.District)
                .Where(p => p.ListingType == "Kiralýk" && p.IsActive)
                .OrderByDescending(p => p.Id).ToList();
            return View(kira);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
