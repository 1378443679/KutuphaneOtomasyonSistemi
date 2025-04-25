using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KutuphaneOtomasyonSistemi.Controllers
{
    public class ÜyeController : Controller
    {
        private readonly KitapContext _context;

        public ÜyeController(KitapContext context)
        {
            _context = context;
        }

        // GET: Üye
        public async Task<IActionResult> Index()
        {
            var üyeler = await _context.Üyeler.ToListAsync();
            return View(üyeler);
        }

        // GET: Üye/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var üye = await _context.Üyeler.FindAsync(id);
            if (üye == null)
                return NotFound();

            return View(üye);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Üye üye)
        {
            if (id != üye.ÜyeID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(üye);
            }

            try
            {
                _context.Update(üye);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return View(üye);
            }

            return RedirectToAction(nameof(Index));
        }

        // Create (Get)
        public IActionResult Create()
        {
            ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
            return View();
        }

        // Create (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Üye üye)
        {
            if (ModelState.IsValid)
            {
                _context.Üyeler.Add(üye);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Model geçersizse sayfa tekrar gösterileceğinden ViewBag tekrar doldurulmalı
            ViewBag.ÜyeListesi = new SelectList(_context.Üyeler.ToList(), "ÜyeID", "TCKimlikNo");
            return View(üye);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var üye = await _context.Üyeler
                .FirstOrDefaultAsync(m => m.ÜyeID == id);

            if (üye == null)
                return NotFound();

            return View(üye);
        }

        // GET: Kitaplar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Üyeler == null)
            {
                return NotFound();
            }

            var üye = await _context.Üyeler
                .FirstOrDefaultAsync(m => m.ÜyeID == id);

            if (üye == null)
            {
                return NotFound();
            }

            return View(üye);
        }

        // POST: Üyeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var üye = await _context.Üyeler.FindAsync(id);
            if (üye != null)
            {
                _context.Üyeler.Remove(üye);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
