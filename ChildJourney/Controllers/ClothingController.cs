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
    public class ClothingController : Controller
    {
        private readonly Database _context;

        public ClothingController(Database context)
        {
            _context = context;
        }

        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
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
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Image")] Clothing clothing)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            _context.Add(clothing);
            User_Clothing user_Clothing = new User_Clothing()
            {
                User = user,
                Type = clothing.Type,
                Clothing = clothing
            };
            _context.UsersClothing.Add(user_Clothing);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Image")] Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return NotFound();
            }

           
            _context.Update(clothing);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
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
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        public IActionResult DeleteAll()
        {
            foreach (var UserClothing in _context.UsersClothing.ToList())
            {
                _context.Remove(UserClothing);
                _context.SaveChanges();
            }
            foreach (var Clothing in _context.Clothing.ToList())
            {
                _context.Remove(Clothing);
                _context.SaveChanges();
            }
            foreach (var OutfitClothing in _context.OutfitClothing.ToList())
            {
                _context.Remove(OutfitClothing);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
    }
}
