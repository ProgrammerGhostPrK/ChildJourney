using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.Models;
using Newtonsoft.Json;

namespace ChildJourney.Controllers
{
    public class BadgeController : Controller
    {
        private readonly Database _context;

        public BadgeController(Database context)
        {
            _context = context;
        }

        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        // GET: Badge
        public async Task<IActionResult> Index()
        {
              return _context.Badges != null ? 
                          View(await _context.Badges.ToListAsync()) :
                          Problem("Entity set 'Database.Badges'  is null.");
        }

        // GET: Badge/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Badges == null)
            {
                return NotFound();
            }

            var badge = await _context.Badges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // GET: Badge/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Badge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image")] Badge badge)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            _context.Add(badge);
            User_Badge user_Badge = new User_Badge()
            {
                User = user,
                Badge = badge
            };
            _context.UsersBadges.Add(user_Badge);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        // GET: Badge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Badges == null)
            {
                return NotFound();
            }

            var badge = await _context.Badges.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }

        // POST: Badge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image")] Badge badge)
        {
            if (id != badge.Id)
            {
                return NotFound();
            }

            _context.Update(badge);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        // GET: Badge/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Badges == null)
            {
                return NotFound();
            }

            var badge = await _context.Badges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // POST: Badge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Badges == null)
            {
                return Problem("Entity set 'Database.Badges'  is null.");
            }
            var badge = await _context.Badges.FindAsync(id);
            if (badge != null)
            {
                _context.Badges.Remove(badge);
            }
            
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        private bool BadgeExists(int id)
        {
          return (_context.Badges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
