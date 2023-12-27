﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ChildJourney.Controllers
{
    public class DecorationController : Controller
    {
        private readonly Database _context;

        public DecorationController(Database context)
        {
            _context = context;
        }

        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        // GET: Decoration
        public async Task<IActionResult> Index()
        {
              return _context.Decoration != null ? 
                          View(await _context.Decoration.ToListAsync()) :
                          Problem("Entity set 'Database.Decoration'  is null.");
        }

        // GET: Decoration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Decoration == null)
            {
                return NotFound();
            }

            var decoration = await _context.Decoration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decoration == null)
            {
                return NotFound();
            }

            return View(decoration);
        }

        // GET: Decoration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decoration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Type,Image")] Decoration decoration)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User User = _context.Users.Find(response.Id);
            _context.Add(decoration);
            User_Decoration user_Decoration = new User_Decoration()
            {
                User = User,
                Decoration = decoration
            };
            if (decoration.Price == 0)
            {
                foreach (var user in _context.Users.ToList())
                {
                    if (user != User)
                    {
                        User_Decoration User_Decoration = new User_Decoration()
                        {
                            User = user,
                            Decoration = decoration
                        };
                        _context.UsersDecorations.Add(User_Decoration);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            _context.UsersDecorations.Add(user_Decoration);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        // GET: Decoration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Decoration == null)
            {
                return NotFound();
            }

            var decoration = await _context.Decoration.FindAsync(id);
            if (decoration == null)
            {
                return NotFound();
            }
            return View(decoration);
        }

        // POST: Decoration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Type,Image")] Decoration decoration)
        {
            if (id != decoration.Id)
            {
                return NotFound();
            }

            _context.Update(decoration);
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        // GET: Decoration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Decoration == null)
            {
                return NotFound();
            }

            var decoration = await _context.Decoration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decoration == null)
            {
                return NotFound();
            }

            return View(decoration);
        }

        // POST: Decoration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Decoration == null)
            {
                return Problem("Entity set 'Database.Decoration'  is null.");
            }
            var decoration = await _context.Decoration.FindAsync(id);
            if (decoration != null)
            {
                _context.Decoration.Remove(decoration);
            }
            
            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        private bool DecorationExists(int id)
        {
          return (_context.Decoration?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
