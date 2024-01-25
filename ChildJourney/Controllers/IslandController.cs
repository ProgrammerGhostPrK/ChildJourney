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
    public class IslandController : Controller
    {
        private readonly Database _context;

        public IslandController(Database context)
        {
            _context = context;
        }
        //Filling Viewmodels
        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        //Getting Views
        public IActionResult Create()
            {
                return View();
            }
        public IActionResult Edit(int? id)
        {
            var island = _context.Islands.Find(id);
            if (island == null)
            {
                return NotFound();
            }
            return View(island);
        }
        public IActionResult Delete(int? id)
        {
            var island = _context.Islands.Find(id);
            if (island == null)
            {
                return NotFound();
            }
            return View(island);
        }

        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Island island)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User User = _context.Users.Find(response.Id);
            _context.Add(island);
            User_Island user_Island = new User_Island()
            {
                User = User,
                Island = island
            };
            if (island.Price == 0)
            {
                foreach (var user in _context.Users.ToList())
                {
                    if (user != User)
                    {
                        User_Island User_Island = new User_Island()
                        {
                            User = user,
                            Island = island
                        };
                        _context.UserIslands.Add(User_Island);
                        _context.SaveChanges();
                    }
                }
            }
            _context.UserIslands.Add(user_Island);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Island island)
        {
            if (id != island.Id)
            {
                return NotFound();
            }
            _context.Update(island);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var island = _context.Islands.Find(id);
            if (island != null)
            {
                _context.Islands.Remove(island);
            }
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        public IActionResult DeleteAll()
        {
            foreach (var Island in _context.UserIslands.ToList())
            {
                _context.Remove(Island);
                _context.SaveChanges();
            }
            foreach (var Island in _context.Islands.ToList())
            {
                _context.Remove(Island);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
    }
}
