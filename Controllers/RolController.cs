using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonSistemi.Controllers
{
        public class RolController : Controller
        {
            private readonly KitapContext _context;

            public RolController(KitapContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index()
            {
                var roller = await _context.Roller.Include(i => i.Kullanıcılar).ToListAsync();
                return View(roller);
            }
        // GET: Rol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var rol = await _context.Roller.FindAsync(id);
            if (rol == null)
                return NotFound();

            // Kategorileri dropdown'da göstermek için

            ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");


            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rol rol)
        {
            if (id != rol.RolID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
                return View(rol);
            }

            try
            {
                _context.Update(rol);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Loglama yapabilirsin
                ModelState.AddModelError("", "Kullanıcı bilgisi geçerli değil.");
                ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
                return View(rol);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Roller.Add(rol);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Model geçersizse sayfa tekrar gösterileceğinden ViewBag tekrar doldurulmalı
            ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
            return View(rol);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var rol = await _context.Roller
                .Include(k => k.Kullanıcılar)
                .FirstOrDefaultAsync(m => m.RolID == id);

            if (rol == null)
                return NotFound();

            return View(rol);
        }

        // GET: Roller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Roller == null)
            {
                return NotFound();
            }

            var rol = await _context.Roller
                .Include(k => k.Kullanıcılar) // Kullanıcıları dahil etmek istersen
                .FirstOrDefaultAsync(m => m.RolID == id);

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Roller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _context.Roller.FindAsync(id);
            if (rol != null)
            {
                _context.Roller.Remove(rol);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }

}

