using System.Diagnostics;
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
                .Take(8)
                .ToList();
            return View(properties);
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
