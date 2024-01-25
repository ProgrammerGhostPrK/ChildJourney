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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChildJourney.Controllers
{
    public class BodyPartController : Controller
    {
        private readonly Database _context;

        public BodyPartController(Database context)
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
            var bodyPart = _context.BodyParts.Find(id);
            if (bodyPart == null)
            {
                return NotFound();
            }
            return View(bodyPart);
        }
        public IActionResult Delete(int? id)
        {
            var bodyPart = _context.BodyParts.Find(id);
            if (bodyPart == null)
            {
                return NotFound();
            }
            return View(bodyPart);
        }

        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BodyPart bodyPart)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User User = _context.Users.Find(response.Id);
            _context.Add(bodyPart);
            User_BodyPart user_Bodypart = new User_BodyPart()
            {
                User = User,
                Type = bodyPart.Type,
                BodyPart = bodyPart
            };
            if (bodyPart.Price == 0)
            {
                foreach (var user in _context.Users.ToList())
                {
                    if (user != User)
                    {
                        User_BodyPart User_bodyPart = new User_BodyPart()
                        {
                            User = user,
                            Type = bodyPart.Type,
                            BodyPart = bodyPart
                        };
                        _context.UsersBodyParts.Add(User_bodyPart);
                        _context.SaveChanges();
                    }
                }
            }
            _context.UsersBodyParts.Add(user_Bodypart);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BodyPart bodyPart)
        {
            if (id != bodyPart.Id)
            {
                return NotFound();
            }
            _context.Update(bodyPart);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bodyPart = _context.BodyParts.Find(id);
            if (bodyPart != null)
            {
                _context.BodyParts.Remove(bodyPart);
            }
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        public IActionResult DeleteAll()
        {
            foreach (var UserBodyPart in _context.UsersBodyParts.ToList())
            {
                _context.Remove(UserBodyPart);
                _context.SaveChanges();
            }
            foreach (var BodyPart in _context.BodyParts.ToList())
            {
                _context.Remove(BodyPart);
                _context.SaveChanges();
            }
            foreach (var BodyBodyPart in _context.BodyBodyParts.ToList())
            {
                _context.Remove(BodyBodyPart);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
    }
}
