using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonSistemi.Controllers
{
    public class ÖdünçController : Controller
    {
        private readonly KitapContext _context;

        public ÖdünçController(KitapContext context)
        {
            _context = context;
        }

        // GET: Ödünç
        public async Task<IActionResult> Index()
        {
            var ödünçler = await _context.Ödünçler
                                         .Include(k => k.Üye)
                                         .Include(k => k.Kitap)
                                         .ToListAsync();
            return View(ödünçler);
        }

        // GET: Ödünç/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ödünç = await _context.Ödünçler.FindAsync(id);
            if (ödünç == null)
                return NotFound();

            // Üyeleri dropdown'da göstermek için

            ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
            ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");

            return View(ödünç);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ödünç ödünç)
        {
            if (id != ödünç.ÖdünçID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
                ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");

                return View(ödünç);
            }

            try
            {
                _context.Update(ödünç);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Loglama yapabilirsin
                ModelState.AddModelError("", "Üye ve Kitap bilgisi geçerli değil.");
                ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
                ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
                return View(ödünç);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
            ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ödünç ödünç)
        {
            if (ModelState.IsValid)
            {
                // Foreign key kontrolü: Kullanıcının seçtiği üye ve kitap gerçekten veritabanında var mı?
                if (!_context.Üyeler.Any(u => u.ÜyeID == ödünç.ÜyeID) || !_context.Kitaplar.Any(k => k.KitapID == ödünç.KitapID))
                {
                    ModelState.AddModelError("", "Seçilen Üye veya Kitap veritabanında bulunamadı.");
                    ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
                    ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
                    return View(ödünç);
                }

                _context.Ödünçler.Add(ödünç);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // ModelState geçerli değilse dropdown'ları yeniden doldur
            ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
            ViewBag.KitapListesi = new SelectList(_context.Kitaplar.ToList(), "KitapID", "Başlık");
            return View(ödünç);
        }


        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ödünç = await _context.Ödünçler
                .Include(k => k.Üye)
                .Include(k => k.Kitap)
                .FirstOrDefaultAsync(m => m.ÖdünçID == id);

            if (ödünç == null)
                return NotFound();

            return View(ödünç);
        }

        // GET: Ödünçler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ödünçler == null)
            {
                return NotFound();
            }

            var ödünç = await _context.Ödünçler
                .Include(k => k.Üye) // Üyeyi dahil etmek istersen
                .Include(k => k.Kitap) // Kitabı dahil etmek istersen
                .FirstOrDefaultAsync(m => m.ÖdünçID == id);

            if (ödünç == null)
            {
                return NotFound();
            }

            return View(ödünç);
        }

        // POST: Ödünçler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ödünç = await _context.Ödünçler.FindAsync(id);
            if (ödünç != null)
            {
                _context.Ödünçler.Remove(ödünç);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
