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
            var decoration = _context.Decoration.Find(id);
            if (decoration == null)
            {
                return NotFound();
            }
            return View(decoration);
        }
        public IActionResult Delete(int? id)
        {
            var decoration = _context.Decoration.Find(id);
            if (decoration == null)
            {
                return NotFound();
            }
            return View(decoration);
        }

        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Decoration decoration)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User User = _context.Users.Find(response.Id);
            _context.Add(decoration);
            User_Decoration user_Decoration = new User_Decoration()
            {
                User = User,
                Type = decoration.Type,
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
                            Type = decoration.Type,
                            Decoration = decoration
                        };
                        _context.UsersDecorations.Add(User_Decoration);
                        _context.SaveChanges();
                    }
                }
            }
            _context.UsersDecorations.Add(user_Decoration);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Decoration decoration)
        {
            if (id != decoration.Id)
            {
                return NotFound();
            }
            _context.Update(decoration);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var decoration = _context.Decoration.Find(id);
            if (decoration != null)
            {
                _context.Decoration.Remove(decoration);
            }
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        public IActionResult DeleteAll()
        {
            foreach (var UserDecoration in _context.UsersDecorations.ToList())
            {
                _context.Remove(UserDecoration);
                _context.SaveChanges();
            }
            foreach (var Decoration in _context.Decoration.ToList())
            {
                _context.Remove(Decoration);
                _context.SaveChanges();
            }
            foreach (var HouseDecoration in _context.HouseDecoration.ToList())
            {
                _context.Remove(HouseDecoration);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
    }
}
