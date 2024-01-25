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
        House House;

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
        public IActionResult BuyDecoration(int? Id)
        {
            {
                var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                User user = _context.Users.Find(response.Id);
                var Decoration = _context.Decoration.Find(Id);
                if (user.Coins >= Decoration.Price)
                {
                    foreach (var item in _context.UsersDecorations)
                    {
                        if (item.UserId == user.Id && item.DecorationId == Decoration.Id)
                        {
                            return Json(new { success = true, refreshPage = false });
                        }
                    }
                    User_Decoration user_Decoration = new User_Decoration()
                    {
                        User = user,
                        Type = Decoration.Type,
                        Decoration = Decoration
                    };
                    user.Coins -= Decoration.Price;
                    _context.UsersDecorations.Add(user_Decoration);
                    _context.SaveChanges();
                    return Json(new { success = true, refreshPage = true });
                }
                else
                {
                    return Json(new { success = true, refreshPage = false });
                }
            }
        }
        public IActionResult AddToHouse(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var UserDecorationpiece = _context.UsersDecorations.Find(Id);
            var Decorationpiece = _context.Decoration.Find(UserDecorationpiece.DecorationId);
            if (user.HouseId == null)
            {
                House = new House()
                {
                    User = user,
                };
                user.House = House;
                HouseDeco HouseD = new HouseDeco()
                {
                    House = user.House,
                    Decoration = Decorationpiece
                };
                _context.HouseDecoration.Add(HouseD);
                _context.SaveChanges();
                user.HouseId = _context.Houses.FirstOrDefault(m => m.UserId == user.Id).Id;
                _context.SaveChanges();
            }
            else
            {
                House = _context.Houses.Find(user.HouseId);
                HouseDeco HouseD = new HouseDeco()
                {
                    House = House,
                    Decoration = Decorationpiece
                };
                _context.HouseDecoration.Add(HouseD);
                _context.SaveChanges();
                foreach (var item in _context.HouseDecoration.ToList())
                {
                    Decoration FoundDecoration = _context.Decoration.Find(item.DecorationId);
                    if (FoundDecoration.Type == Decorationpiece.Type && user.HouseId == item.HouseId)
                    {
                        _context.HouseDecoration.Remove(HouseD);
                        HouseDeco HouseClothes = _context.HouseDecoration.Find(item.Id);
                        HouseClothes.DecorationId = HouseD.DecorationId;
                        _context.HouseDecoration.Update(HouseClothes);
                        _context.SaveChanges();
                        return Json(new { success = true, refreshPage = true });
                    }
                }
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
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
