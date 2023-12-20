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
    public class BodyPartController : Controller
    {
        private readonly Database _context;

        public BodyPartController(Database context)
        {
            _context = context;
        }

        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
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
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Image")] BodyPart bodyPart)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            _context.Add(bodyPart);
            User_BodyPart user_Bodypart = new User_BodyPart()
            {
                User = user,
                Type = bodyPart.Type,
                BodyPart = bodyPart
            };
            _context.UsersBodyParts.Add(user_Bodypart);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Image")] BodyPart bodyPart)
        {
            if (id != bodyPart.Id)
            {
                return NotFound();
            }

            _context.Update(bodyPart);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());

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
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        private bool BodyPartExists(int id)
        {
          return (_context.BodyParts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
