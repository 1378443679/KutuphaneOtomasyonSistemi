using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KutuphaneOtomasyonSistemi.Controllers
{
    public class IzinController : Controller
    {
        private readonly KitapContext _context;

        public IzinController(KitapContext context)
        {
            _context = context;
        }

        // GET: İzin
        public async Task<IActionResult> Index()
        {
            var izinler = await _context.Izinler
                                         .Include(k => k.Rol)
                                         .ToListAsync();
            return View(izinler);
        }

        // GET: İzin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var izin = await _context.Izinler.FindAsync(id);
            if (izin == null)
                return NotFound();

            // Kategorileri dropdown'da göstermek için

            ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
            ViewBag.ErisimTurleri = Enum.GetValues(typeof(ErisimTuru))
       .Cast<ErisimTuru>()
       .Select(e => new SelectListItem
       {
           Value = ((int)e).ToString(),
           Text = e.ToString()
       }).ToList();


            return View(izin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Izin izin)
        {
            if (id != izin.IzinID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
                return View(izin);
            }

            try
            {
                _context.Update(izin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Loglama yapabilirsin
                ModelState.AddModelError("", "Rol bilgisi geçerli değil.");
                ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
                return View(izin);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
            ViewBag.ErisimTurleri = new SelectList(Enum.GetValues(typeof(ErisimTuru)));


            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Izin izin)
        {
            if (ModelState.IsValid)
            {
                _context.Izinler.Add(izin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Model geçersizse sayfa tekrar gösterileceğinden ViewBag tekrar doldurulmalı
            ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
            return View(izin);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var izin = await _context.Izinler
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.IzinID == id);

            if (izin == null)
                return NotFound();

            return View(izin);
        }

        // GET: İzinler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Izinler == null)
            {
                return NotFound();
            }

            var izin = await _context.Izinler
                .Include(k => k.Rol) // Rolü dahil etmek istersen
                .FirstOrDefaultAsync(m => m.IzinID == id);

            if (izin == null)
            {
                return NotFound();
            }

            return View(izin);
        }

        // POST: İzinler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var izin = await _context.Izinler.FindAsync(id);
            if (izin != null)
            {
                _context.Izinler.Remove(izin);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
