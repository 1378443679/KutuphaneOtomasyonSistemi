using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneOtomasyonSistemi.Models;
using KutuphaneOtomasyonSistemi.Repositories; // kendi namespace’ine göre düzenle

public class KategoriController : Controller
{
    private readonly KitapContext _context;

    public KategoriController(KitapContext context)
    {
        _context = context;
    }

    // GET: Kategori
    public async Task<IActionResult> Index()
    {
        var kategoriler = await _context.Kategoriler.ToListAsync();
        return View(kategoriler);
    }
    // GET: Kategori/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Kategoriler == null)
        {
            return NotFound();
        }

        var kategori = await _context.Kategoriler.FindAsync(id);
        if (kategori == null)
        {
            return NotFound();
        }
        return View(kategori);
    }

    // POST: Kategori/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("KategoriID,KategoriAdı")] Kategori kategori)
    {
        if (id != kategori.KategoriID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(kategori);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriExists(kategori.KategoriID))
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
        return View(kategori);
    }

    private bool KategoriExists(int id)
    {
        return _context.Kategoriler.Any(e => e.KategoriID == id);
    }

    // GET: Kategori/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Kategori/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("KategoriID,KategoriAdı")] Kategori kategori)
    {
        if (ModelState.IsValid)
        {
            _context.Add(kategori);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = "Yeni kategori başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }
        return View(kategori);
    }

    // GET: Kategori/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Kategoriler == null)
        {
            return NotFound();
        }

        var kategori = await _context.Kategoriler
            .FirstOrDefaultAsync(m => m.KategoriID == id);
        if (kategori == null)
        {
            return NotFound();
        }

        return View(kategori);
    }

    // POST: Kategori/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var kategori = await _context.Kategoriler.FindAsync(id);
        if (kategori != null)
        {
            _context.Kategoriler.Remove(kategori);
            await _context.SaveChangesAsync();
            TempData["SilmeMesaji"] = "Kategori başarıyla silindi.";
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Kategori/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Kategoriler == null)
        {
            return NotFound();
        }

        var kategori = await _context.Kategoriler
            .FirstOrDefaultAsync(m => m.KategoriID == id);
        if (kategori == null)
        {
            return NotFound();
        }

        return View(kategori);
    }

}
