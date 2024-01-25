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
        Outfit outfit;

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
        public IActionResult BuyClothing(int? Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var Clothingpiece = _context.Clothing.Find(Id);
            if (user.Coins >= Clothingpiece.Price)
            {
                foreach (var item in _context.UsersClothing)
                {
                    if (item.UserId == user.Id && item.ClothingId == Clothingpiece.Id)
                    {
                        return Json(new { success = true, refreshPage = false });
                    }
                }
                User_Clothing user_Clothing = new User_Clothing()
                {
                    User = user,
                    Type = Clothingpiece.Type,
                    Clothing = Clothingpiece
                };
                user.Coins -= Clothingpiece.Price;
                _context.UsersClothing.Add(user_Clothing);
                _context.SaveChanges();
                return Json(new { success = true, refreshPage = true });
            }
            else
            {
                return Json(new { success = true, refreshPage = false });
            }
        }
        public IActionResult AddToOutfit(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var UserClothingpiece = _context.UsersClothing.Find(Id);
            var Clothingpiece = _context.Clothing.Find(UserClothingpiece.ClothingId);
            if (user.OutfitId == null)
            {
                outfit = new Outfit()
                {
                    User = user,
                };
                user.Outfit = outfit;
                Outfit_Clothing OutfitC = new Outfit_Clothing()
                {
                    Outfit = user.Outfit,
                    Clothing = Clothingpiece
                };
                _context.OutfitClothing.Add(OutfitC);
                _context.SaveChanges();
                user.OutfitId = _context.Outfits.FirstOrDefault(m => m.UserId == user.Id).Id;
                _context.SaveChanges();
            }
            else
            {
                outfit = _context.Outfits.Find(user.OutfitId);
                Outfit_Clothing OutfitC = new Outfit_Clothing()
                {
                    Outfit = outfit,
                    Clothing = Clothingpiece
                };
                _context.OutfitClothing.Add(OutfitC);
                _context.SaveChanges();
                foreach (var item in _context.OutfitClothing.ToList())
                {
                    Clothing FoundClothing = _context.Clothing.Find(item.ClothingId);
                    if (FoundClothing.Type == Clothingpiece.Type && user.OutfitId == item.OutfitId)
                    {
                        _context.OutfitClothing.Remove(OutfitC);
                        Outfit_Clothing OutfitClothes = _context.OutfitClothing.Find(item.Id);
                        OutfitClothes.ClothingId = OutfitC.ClothingId;
                        _context.OutfitClothing.Update(OutfitClothes);
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
