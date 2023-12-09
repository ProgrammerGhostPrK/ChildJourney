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
    public class BodyPartController : Controller
    {
        private readonly Database _context;

        public BodyPartController(Database context)
        {
            _context = context;
        }

        // GET: BodyPart
        public async Task<IActionResult> Index()
        {
              return _context.BodyParts != null ? 
                          View(await _context.BodyParts.ToListAsync()) :
                          Problem("Entity set 'Database.BodyParts'  is null.");
        }

        // GET: BodyPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BodyParts == null)
            {
                return NotFound();
            }

            var bodyPart = await _context.BodyParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyPart == null)
            {
                return NotFound();
            }

            return View(bodyPart);
        }

        // GET: BodyPart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price")] BodyPart bodyPart)
        {
                _context.Add(bodyPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: BodyPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BodyParts == null)
            {
                return NotFound();
            }

            var bodyPart = await _context.BodyParts.FindAsync(id);
            if (bodyPart == null)
            {
                return NotFound();
            }
            return View(bodyPart);
        }

        // POST: BodyPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price")] BodyPart bodyPart)
        {
            if (id != bodyPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyPartExists(bodyPart.Id))
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
            return View(bodyPart);
        }

        // GET: BodyPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BodyParts == null)
            {
                return NotFound();
            }

            var bodyPart = await _context.BodyParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyPart == null)
            {
                return NotFound();
            }

            return View(bodyPart);
        }

        // POST: BodyPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BodyParts == null)
            {
                return Problem("Entity set 'Database.BodyParts'  is null.");
            }
            var bodyPart = await _context.BodyParts.FindAsync(id);
            if (bodyPart != null)
            {
                _context.BodyParts.Remove(bodyPart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyPartExists(int id)
        {
          return (_context.BodyParts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
