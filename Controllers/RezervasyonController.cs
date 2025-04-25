using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KutuphaneOtomasyonSistemi.Controllers
{
    public class RezervasyonController : Controller
    {
        private readonly KitapContext _context;

        public RezervasyonController(KitapContext context)
        {
            _context = context;
        }

        // GET: Rezervasyon
        public async Task<IActionResult> Index()
        {
            var rezervasyonlar = await _context.Rezervasyonlar
                                         .Include(k => k.Kullanıcı)
                                         .Include(k => k.Kitap)
                                         .ToListAsync();
            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var rezervasyon = await _context.Rezervasyonlar.FindAsync(id);
            if (rezervasyon == null)
                return NotFound();

            // Kullanıcıları ve Kitapları dropdown'da göstermek için

            ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
            ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");

            return View(rezervasyon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rezervasyon rezervasyon)
        {
            if (id != rezervasyon.RezervasyonID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
                ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
                return View(rezervasyon);
            }

            try
            {
                _context.Update(rezervasyon);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Loglama yapabilirsin
                ModelState.AddModelError("", "Kullanıcı ve Kitap bilgisi geçerli değil.");
                ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
                ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
                
                return View(rezervasyon);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
            ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID");
            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _context.Rezervasyonlar.Add(rezervasyon);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Model geçersizse sayfa tekrar gösterileceğinden ViewBag tekrar doldurulmalı
            ViewBag.KullanıcıListesi = new SelectList(_context.Kullanıcılar.ToList(), "KullanıcıID", "KullanıcıAdı");
            ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
            
            return View(rezervasyon);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var rezervasyon = await _context.Rezervasyonlar
                .Include(k => k.Kullanıcı)
                .Include(k => k.Kitap)
                .FirstOrDefaultAsync(m => m.RezervasyonID == id);

            if (rezervasyon == null)
                return NotFound();

            return View(rezervasyon);
        }

        // GET: Rezervasyonlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rezervasyonlar == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyonlar
                .Include(k => k.Kullanıcı) // Kullanıcıyı dahil etmek istersen
                .Include(k => k.Kitap) // Kitabı dahil etmek istersen
                .FirstOrDefaultAsync(m => m.RezervasyonID == id);

            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // POST: Rezervasyonlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyon = await _context.Rezervasyonlar.FindAsync(id);
            if (rezervasyon != null)
            {
                _context.Rezervasyonlar.Remove(rezervasyon);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
