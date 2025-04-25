using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KutuphaneOtomasyonSistemi.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapContext _context;

        public KitapController(KitapContext context)
        {
            _context = context;
        }

        // GET: Kitap
        public async Task<IActionResult> Index()
        {
            var kitaplar = await _context.Kitaplar
                                         .Include(k => k.Kategori)
                                         .ToListAsync();
            return View(kitaplar);
        }

        // GET: Kitap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
                return NotFound();

            // Kategorileri dropdown'da göstermek için
            
            ViewBag.KategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdı");


            return View(kitap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Kitap kitap)
        {
            if (id != kitap.KitapID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.KategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdı");
                return View(kitap);
            }

            try
            {
                _context.Update(kitap);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Loglama yapabilirsin
                ModelState.AddModelError("", "Kategori bilgisi geçerli değil.");
                ViewBag.KategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdı");
                return View(kitap);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.KategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdı");
            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _context.Kitaplar.Add(kitap);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Model geçersizse sayfa tekrar gösterileceğinden ViewBag tekrar doldurulmalı
            ViewBag.KategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdı");
            return View(kitap);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .FirstOrDefaultAsync(m => m.KitapID == id);

            if (kitap == null)
                return NotFound();

            return View(kitap);
        }

        // GET: Kitaplar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori) // Kategoriyi dahil etmek istersen
                .FirstOrDefaultAsync(m => m.KitapID == id);

            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitaplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                await _context.SaveChangesAsync();
            }
           
            return RedirectToAction(nameof(Index));
        }
            

    }
}
