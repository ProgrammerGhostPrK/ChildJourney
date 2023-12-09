using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.Models;

namespace ChildJourney.Controllers
{
    public class ClothingController : Controller
    {
        private readonly Database _context;

        public ClothingController(Database context)
        {
            _context = context;
        }

        // GET: Clothing
        public async Task<IActionResult> Index()
        {
              return _context.Clothing != null ? 
                          View(await _context.Clothing.ToListAsync()) :
                          Problem("Entity set 'Database.Clothing'  is null.");
        }

        // GET: Clothing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clothing == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // GET: Clothing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clothing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price")] Clothing clothing)
        {
                _context.Add(clothing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Clothing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clothing == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }
            return View(clothing);
        }

        // POST: Clothing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price")] Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingExists(clothing.Id))
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
            return View(clothing);
        }

        // GET: Clothing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clothing == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // POST: Clothing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clothing == null)
            {
                return Problem("Entity set 'Database.Clothing'  is null.");
            }
            var clothing = await _context.Clothing.FindAsync(id);
            if (clothing != null)
            {
                _context.Clothing.Remove(clothing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingExists(int id)
        {
          return (_context.Clothing?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
