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
        Body body;

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
        public IActionResult BuyBodyPart(int? Id)
        {
            {
                var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                User user = _context.Users.Find(response.Id);
                var BodyPart = _context.BodyParts.Find(Id);
                if (user.Coins >= BodyPart.Price)
                {
                    foreach (var item in _context.UsersBodyParts)
                    {
                        if (item.UserId == user.Id && item.BodyPartId == BodyPart.Id)
                        {
                            return Json(new { success = true, refreshPage = false });
                        }
                    }
                    User_BodyPart user_BodyPart = new User_BodyPart()
                    {
                        User = user,
                        Type = BodyPart.Type,
                        BodyPart = BodyPart
                    };
                    user.Coins -= BodyPart.Price;
                    _context.UsersBodyParts.Add(user_BodyPart);
                    _context.SaveChanges();
                    return Json(new { success = true, refreshPage = true });
                }
                else
                {
                    return Json(new { success = true, refreshPage = false });
                }
            }
        }
        public IActionResult AddToBody(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var UserBodypart = _context.UsersBodyParts.Find(Id);
            var Bodypart = _context.BodyParts.Find(UserBodypart.BodyPartId);
            if (user.BodyId == null)
            {
                body = new Body()
                {
                    User = user,
                };
                BodyBodyParts BodyB = new BodyBodyParts()
                {
                    Body = body,
                    BodyPart = Bodypart
                };
                _context.BodyBodyParts.Add(BodyB);
                _context.SaveChanges();
                user.BodyId = _context.Bodies.FirstOrDefault(m => m.UserId == user.Id).Id;
                _context.SaveChanges();
            }
            else
            {
                body = _context.Bodies.Find(user.BodyId);
                BodyBodyParts BodyB = new BodyBodyParts()
                {
                    Body = body,
                    BodyPart = Bodypart
                };
                _context.BodyBodyParts.Add(BodyB);
                _context.SaveChanges();
                foreach (var item in _context.BodyBodyParts.ToList())
                {
                    if (_context.BodyParts.Find(item.BodyPartId).Type == Bodypart.Type && user.BodyId == item.BodyId)
                    {
                        _context.BodyBodyParts.Remove(BodyB);
                        BodyBodyParts BBP = _context.BodyBodyParts.Find(item.Id);
                        BBP.BodyPartId = BodyB.BodyPartId;
                        _context.BodyBodyParts.Update(BBP);
                        _context.SaveChanges();
                        return Json(new { success = true, refreshPage = true });
                    }
                }
                body = _context.Bodies.Find(user.BodyId);
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
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
