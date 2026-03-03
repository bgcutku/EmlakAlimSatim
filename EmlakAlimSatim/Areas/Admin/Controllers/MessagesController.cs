using System;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Filters;
using EmlakAlimSatim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmlakAlimSatim.Filters;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthFilter]
    public class MessagesController : Controller
    {
        private readonly EmlakDbContext _context;

        public MessagesController(EmlakDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var messages = _context.Messages
                .Include(m => m.Property) 
                .OrderByDescending(m => m.SendDate)
                .ToList();

            return View(messages);
        }

        
        public IActionResult Delete(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}