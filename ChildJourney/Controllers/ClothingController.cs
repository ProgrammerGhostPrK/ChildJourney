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
            var clothing = _context.Clothing.Find(id);
            if (clothing == null)
            {
                return NotFound();
            }
            return View(clothing);
        }
        public IActionResult Delete(int? id)
        {
            var clothing = _context.Clothing.Find(id);
            if (clothing == null)
            {
                return NotFound();
            }
            return View(clothing);
        }

        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clothing clothing)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User User = _context.Users.Find(response.Id);
            _context.Add(clothing);
            User_Clothing user_Clothing = new User_Clothing()
            {
                User = User,
                Type = clothing.Type,
                Clothing = clothing
            };
            if (clothing.Price == 0)
            {
                foreach (var user in _context.Users.ToList())
                {
                    if (user != User)
                    {
                        User_Clothing User_Clothing = new User_Clothing()
                        {
                            User = user,
                            Type = clothing.Type,
                            Clothing = clothing
                        };
                        _context.UsersClothing.Add(User_Clothing);
                        _context.SaveChanges();
                    }
                }
            }
            _context.UsersClothing.Add(user_Clothing);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return NotFound();
            }
            _context.Update(clothing);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var clothing = _context.Clothing.Find(id);
            if (clothing != null)
            {
                _context.Clothing.Remove(clothing);
            }
            _context.SaveChanges();
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
