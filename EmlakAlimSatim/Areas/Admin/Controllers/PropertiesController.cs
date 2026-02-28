using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmlakAlimSatim.Data;
using EmlakAlimSatim.Models;

namespace EmlakAlimSatim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertiesController : Controller
    {
        private readonly EmlakDbContext _context;

        public PropertiesController(EmlakDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Properties
        public async Task<IActionResult> Index()
        {
            var emlakDbContext = _context.Properties.Include(p => p.Category).Include(p => p.City).Include(p => p.District).Include(p => p.Kullanici);
            return View(await emlakDbContext.ToListAsync());
        }

        // GET: Admin/Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilan = await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.City)
                .Include(p => p.District)
                .Include(p => p.Kullanici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilan == null)
            {
                return NotFound();
            }

            return View(ilan);
        }

        // GET: Admin/Properties/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Name");
            ViewData["KullaniciId"] = new SelectList(_context.kullanicilars, "KullaniciID", "Ad");
            return View();
        }

        // POST: Admin/Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,SquareMeters,RoomCount,BuildingAge,Floor,TotalFloors,HeatingType,ListingType,IsActive,CreatedAt,UpdatedAt,CoverImage,KullaniciId,CategoryId,CityId,DistrictId,Address")] Property @property, IFormFile ImageFile)
        {            
            if (ImageFile != null && ImageFile.Length > 0)
            {                
                string dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
               
                string klasorYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/properties");
                                
                if (!Directory.Exists(klasorYolu))
                {
                    Directory.CreateDirectory(klasorYolu);
                }
                
                string tamYol = Path.Combine(klasorYolu, dosyaAdi);
                using (var stream = new FileStream(tamYol, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                
                @property.CoverImage = "/img/properties/" + dosyaAdi;
            }

            // 2. Kullanıcı Atama (Mevcut kodum)
            if (@property.KullaniciId == 0)
            {
                var ilkKullanici = _context.kullanicilars.FirstOrDefault();
                if (ilkKullanici != null)
                {
                    @property.KullaniciId = ilkKullanici.KullaniciID;
                }
            }

            // 3. Tarihleri Doldur (Mevcut kodum)
            @property.CreatedAt = DateTime.Now;
            @property.UpdatedAt = DateTime.Now;

            // 4. Kayıt İşlemi
            if (ModelState.IsValid)
            {
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Hata varsa listeleri TEKRAR doldur
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", @property.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", @property.CityId);
            ViewData["DistrictId"] = new SelectList(_context.Districts.Where(d => d.CityId == @property.CityId), "Id", "Name", @property.DistrictId);
            ViewData["KullaniciId"] = new SelectList(_context.kullanicilars, "KullaniciID", "Ad", @property.KullaniciId);

            return View(@property);
        }

        // GET: Admin/Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", property.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", property.CityId);            
            ViewData["DistrictId"] = new SelectList(_context.Districts.Where(d => d.CityId == property.CityId), "Id", "Name", property.DistrictId);            
            ViewData["KullaniciId"] = new SelectList(_context.kullanicilars, "KullaniciID", "Ad", property.KullaniciId);
            return View(@property);
        }

        // POST: Admin/Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,SquareMeters,RoomCount,BuildingAge,Floor,TotalFloors,HeatingType,ListingType,IsActive,CreatedAt,UpdatedAt,CoverImage,KullaniciId,CategoryId,CityId,DistrictId,Address")] Property @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", @property.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", @property.CityId);
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", @property.DistrictId);
            ViewData["KullaniciId"] = new SelectList(_context.kullanicilars, "KullaniciID", "Ad", @property.KullaniciId);
            return View(@property);
        }

        // GET: Admin/Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilan = await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.City)
                .Include(p => p.District)
                .Include(p => p.Kullanici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilan == null)
            {
                return NotFound();
            }

            return View(ilan);
        }

        // POST: Admin/Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Properties.FindAsync(id);
            if (@property != null)
            {
                _context.Properties.Remove(@property);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
