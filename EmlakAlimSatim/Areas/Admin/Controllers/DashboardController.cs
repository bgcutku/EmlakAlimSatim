using Microsoft.AspNetCore.Mvc;
using EmlakAlimSatim.Filters;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]  // Admin paneli koruma
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}