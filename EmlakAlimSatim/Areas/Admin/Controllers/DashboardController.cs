using Microsoft.AspNetCore.Mvc;
using EmlakAlimSatim.Filters;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]  // Admin paneli koruma
    public class DashboardController : Controller
    {
        private readonly EmlakDbContext _context;
        public DashboardController(EmlakDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var mod = new DashboardViewModel
            {
                //Kart Verileri
                TotalPropertiesCount = await _context.Properties.CountAsync(),
                SaleCount = await _context.Properties.CountAsync(m => m.ListingType == "Satılık"),
                RentCount = await _context.Properties.CountAsync(m => m.ListingType == "Kiralık"),
                TotalMessagesCount = await _context.Messages.CountAsync(),

                //Son 5 Eklenen İlanlar
                RecentProperties = await _context.Properties
                    .OrderByDescending(m => m.Id)
                    .Take(5)
                    .ToListAsync(),

                //Son 5 Mesaj
                RecentMessages = await _context.Messages
                    .OrderByDescending(m => m.Id)
                    .Take(5)
                    .ToListAsync()


            };
            return View(mod);
        }
    }
}