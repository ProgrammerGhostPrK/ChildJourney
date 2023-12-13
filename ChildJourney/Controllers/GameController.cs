using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.ViewModels;
using Newtonsoft.Json;
using System.Numerics;
using ChildJourney.Models;

namespace ChildJourney.Controllers
{
    public class GameController : Controller
    {
        private readonly Database _context;
        Outfit outfit;
        Body body;

        public GameController(Database context)
        {
            _context = context;
        }
        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        public IActionResult Introduction()
        {
            return View(HomeController().AdminViewModel());
        }

        public IActionResult AddToOutfit(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var Clothingpiece = _context.Clothing.Find(Id);
            if (user.OutfitId == null)
            {
                outfit  = new Outfit()
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
            }
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
        }

        public IActionResult AddToBody(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var Bodypart = _context.BodyParts.Find(Id);
            if (user.BodyId == null)
            {
                body = new Body()
                {
                    User = user,
                };
                Body_Bodypartcs BodyB = new Body_Bodypartcs()
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
                Body_Bodypartcs BodyB = new Body_Bodypartcs()
                {
                    Body = body,
                    BodyPart = Bodypart
                };
                _context.BodyBodyParts.Add(BodyB);
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
        }
    }
}
