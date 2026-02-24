using Microsoft.AspNetCore.Mvc;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
