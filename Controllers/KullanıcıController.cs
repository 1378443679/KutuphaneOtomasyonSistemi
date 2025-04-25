using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KutuphaneOtomasyonSistemi.Controllers
{
    public class KullanıcıController : Controller
    {
        private readonly KitapContext _context;

        public KullanıcıController(KitapContext context)
        {
            _context = context;
        }

        // GET: Kullanıcı
        public async Task<IActionResult> Index()
        {
            var kullanıcılar = await _context.Kullanıcılar
                                         .Include(k => k.Rol)
                                         .ToListAsync();
            return View(kullanıcılar);
        }

        // GET: Kullanıcı/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var kullanıcı = await _context.Kullanıcılar.FindAsync(id);
            if (kullanıcı == null)
                return NotFound();

            // Kategorileri dropdown'da göstermek için

            ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı", kullanıcı.RolID);


            return View(kullanıcı);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Kullanıcı kullanıcı)
        {
            if (id != kullanıcı.KullanıcıID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
                return View(kullanıcı);
            }

            try
            {
                _context.Update(kullanıcı);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Loglama yapabilirsin
                ModelState.AddModelError("", "Rol bilgisi geçerli değil.");
                ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
                return View(kullanıcı);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                _context.Kullanıcılar.Add(kullanıcı);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Model geçersizse sayfa tekrar gösterileceğinden ViewBag tekrar doldurulmalı
            ViewBag.RolListesi = new SelectList(_context.Roller.ToList(), "RolID", "RolAdı");
            return View(kullanıcı);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var kullanıcı = await _context.Kullanıcılar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.KullanıcıID == id);

            if (kullanıcı == null)
                return NotFound();

            return View(kullanıcı);
        }

        // GET: Kullanıcılar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanıcılar == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar
                .Include(k => k.Rol) // Rolü dahil etmek istersen
                .FirstOrDefaultAsync(m => m.KullanıcıID == id);

            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // POST: Kullanıcılar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullanıcı = await _context.Kullanıcılar.FindAsync(id);
            if (kullanıcı != null)
            {
                _context.Kullanıcılar.Remove(kullanıcı);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
