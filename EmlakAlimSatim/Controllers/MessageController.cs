using System;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmlakAlimSatim.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmlakDbContext _context;

        public MessageController(EmlakDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Send(Message message)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen tüm alanları doldurun.";
                return RedirectToAction("Details", "Property", new { id = message.PropertyId });
            }

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesajınız başarıyla gönderildi!";
            return RedirectToAction("Details", "Property", new { id = message.PropertyId });
        }
    }
}