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
    public class IslandController : Controller
    {
        private readonly Database _context;

        public IslandController(Database context)
        {
            _context = context;
        }
        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        // GET: Island
        public async Task<IActionResult> Index()
        {
              return _context.Islands != null ? 
                          View(await _context.Islands.ToListAsync()) :
                          Problem("Entity set 'Database.Islands'  is null.");
        }

        // GET: Island/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Islands == null)
            {
                return NotFound();
            }

            var island = await _context.Islands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (island == null)
            {
                return NotFound();
            }

            return View(island);
        }

        // GET: Island/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Island/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,PrimaryColor,SecondaryColor")] Island island)
        {
                _context.Add(island);
                await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        // GET: Island/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Islands == null)
            {
                return NotFound();
            }

            var island = await _context.Islands.FindAsync(id);
            if (island == null)
            {
                return NotFound();
            }
            return View(island);
        }

        // POST: Island/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,PrimaryColor,SecondaryColor")] Island island)
        {

            _context.Update(island);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        // GET: Island/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Islands == null)
            {
                return NotFound();
            }

            var island = await _context.Islands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (island == null)
            {
                return NotFound();
            }

            return View(island);
        }

        // POST: Island/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Islands == null)
            {
                return Problem("Entity set 'Database.Islands'  is null.");
            }
            var island = await _context.Islands.FindAsync(id);
            if (island != null)
            {
                _context.Islands.Remove(island);
            }
            
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        private bool IslandExists(int id)
        {
          return (_context.Islands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
