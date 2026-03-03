using System;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmlakAlimSatim.Controllers
{
    public class PropertyController : Controller
    {
        private readonly EmlakDbContext _context;

        public PropertyController(EmlakDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var properties = _context.Properties
                .Include(p => p.City)
                .Include(p => p.District)
                .OrderByDescending(p => p.Id)
                .ToList();

            return View(properties);
        }

        
        public IActionResult Details(int id)
        {
            var property = _context.Properties
                .Include(p => p.City)
                .Include(p => p.District)
                .FirstOrDefault(p => p.Id == id);

            if (property == null)
                return NotFound();

            return View(property);
        }
    }
}