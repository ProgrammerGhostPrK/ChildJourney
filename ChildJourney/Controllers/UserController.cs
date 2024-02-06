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
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ChildJourney.Controllers
{
    public class UserController : Controller
    {
        private readonly Database _context;

        public UserController(Database context)
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
        public IActionResult Edit(int? id)
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        public IActionResult Delete(int? id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public IActionResult Registreer()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (_context.Users.Count() == 0)
            {
                User user = new User()
                {
                    Id = 0,
                    Name = "Admin",
                    Email = "Admin@Admin.Admin",
                    Image = "a",
                    lastWeekLogin = 0,
                    lastMonthLogin = 0,
                    DailyStreak = 0,
                    Daystreak = 0,
                    Age = 0,
                    Coins = 0,
                    SeasonPoints = 0,
                    Admin = true,
                };
                _context.Add(user);
                _context.SaveChanges();
            }
            HttpContext.Session.SetString("CurrentUser", "");
            return View();
        }

        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registreer(User user)
        {
            user.Coins = 0;
            user.Daystreak = 0;
            user.DailyStreak = 0;
            user.SeasonPoints = 0;
            user.lastWeekLogin = 0;
            user.lastMonthLogin = 0;
            user.Admin = false;
            _context.Add(user);
            _context.SaveChanges();
            return View("../User/Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User userData)
        {
            User user = _context.Users.Find(id);
            user.Admin = userData.Admin;
            if (id != user.Id)
            {
                return NotFound();
            }
            _context.Update(user);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User User)
        {
            var user = _context.Users.FirstOrDefault(a => a.Email.Equals(User.Email) && a.Name.Equals(User.Name));
            if (user != null)
            {
                var userJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("CurrentUser", userJson);
                return View("../Home/Index");
            }
            else { return View(user); }
        }
        public IActionResult DeleteAll()
        {
            foreach (var User in _context.Users.ToList())
            {
                _context.Remove(User);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
    }

}
