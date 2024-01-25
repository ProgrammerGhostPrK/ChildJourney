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
    public class BadgeController : Controller
    {
        private readonly Database _context;

        public BadgeController(Database context)
        {
            _context = context;
        }

        //Filling Viewmodels
        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        //Getting Viewsyy
        public IActionResult Edit(int? id)
        {
            var badge = _context.Badges.Find(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }
        public IActionResult DetailsInventory(int? id)
        {
            var badge = _context.Badges.Find(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }
        public IActionResult Delete(int? id)
        {
            var badge = _context.Badges.Find(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }


        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Badge badge)
        {
            if (id != badge.Id)
            {
                return NotFound();
            }
            _context.Update(badge);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var badge = _context.Badges.Find(id);
            if (badge != null)
            {
                _context.Badges.Remove(badge);
            }
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        public IActionResult DeleteAll()
        {
            foreach (var Badge in _context.UsersBadges.ToList())
            {
                _context.Remove(Badge);
                _context.SaveChanges();
            }
            foreach (var Badge in _context.Badges.ToList())
            {
                _context.Remove(Badge);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
        public IActionResult ClaimBoatBadge(int id)
        {
            User user = _context.Users.Find(id);
            Badge savedBadge = null;
            foreach (var item in _context.Badges.ToList())
            {
                if (item.Name == "Captain")
                {
                    savedBadge = item;
                }
            }
            if (savedBadge == null)
            {
                Badge BoatBadge = new Badge()
                {
                    Name = "Captain",
                    Description = "Succesfully drive the boat in the minigame Boatsteering!",
                    Image = "/images/boatimage.jpg"
                };
                _context.Badges.Add(BoatBadge);
                _context.SaveChanges();
                savedBadge = _context.Badges.Find(BoatBadge.Id);
            }
            if (savedBadge != null)
            {
                foreach (var item in _context.UsersBadges.ToList())
                {
                    if (item.UserId == user.Id && item.BadgeId == savedBadge.Id)
                    {
                        return Json(new { success = true, refreshPage = false });
                    }
                }
                User_Badge UserBoatBadge = new User_Badge()
                {
                    User = user,
                    Badge = savedBadge,
                    BadgeLevel = 1
                };
                _context.UsersBadges.Add(UserBoatBadge);
                _context.SaveChanges();
            }
            return Json(new { success = true });
        }
        public IActionResult ClaimBirdBadge(int id)
        {
            User user = _context.Users.Find(id);
            Badge savedBadge = null;
            foreach (var item in _context.Badges.ToList())
            {
                if (item.Name == "Free Bird")
                {
                    savedBadge = item;
                }
            }
            if (savedBadge == null)
            {
                Badge BirdBadge = new Badge()
                {
                    Name = "Free Bird",
                    Description = "Succesfully fly through all the pipes in the Birdflying minigame!",
                    Image = "/images/birdimage.jpg"
                };
                _context.Badges.Add(BirdBadge);
                _context.SaveChanges();
                savedBadge = _context.Badges.Find(BirdBadge.Id);
            }
            if (savedBadge != null)
            {
                foreach (var item in _context.UsersBadges.ToList())
                {
                    if (item.UserId == user.Id && item.BadgeId == savedBadge.Id)
                    {
                        return Json(new { success = true, refreshPage = false });
                    }
                }
                User_Badge UserBirdBadge = new User_Badge()
                {
                    User = user,
                    Badge = savedBadge,
                    BadgeLevel = 1
                };
                _context.UsersBadges.Add(UserBirdBadge);
                _context.SaveChanges();
            }
            return Json(new { success = true });
        }
    }
}
