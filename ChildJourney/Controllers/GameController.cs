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
        public AdminViewModel AdminViewModel(Island island)
        {
            var viewModel = new AdminViewModel()
            {
                Users = _context.Users.ToList(),
                Animals = _context.Animals.ToList(),
                Badges = _context.Badges.ToList(),
                bodyParts = _context.BodyParts.ToList(),
                clothing = _context.Clothing.ToList(),
                decorations = _context.Decoration.ToList(),
                rewards = _context.Rewards.ToList(),
                Outfit_Clothings = _context.OutfitClothing.ToList(),
                Body_BodyParts = _context.BodyBodyParts.ToList(),
                Islands = _context.Islands.ToList(),
                CurrentIsland = island
            };
            return viewModel;
        }
        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        public IActionResult Character()
        {
            return View(HomeController().AdminViewModel());
        }
        public IActionResult Islandpicking()
        {
            return View(HomeController().AdminViewModel());
        }
        public IActionResult HomeIsland(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island response = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = response as Island;
            }
            else {island = _context.Islands.Find(Id); }
            
            return View(AdminViewModel(island));
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
                foreach (var item in _context.OutfitClothing.ToList())
                {
                    Clothing FoundClothing = _context.Clothing.Find(item.ClothingId);
                    if (FoundClothing.Type == Clothingpiece.Type && user.OutfitId == item.OutfitId)
                    {
                        _context.OutfitClothing.Remove(OutfitC);
                        Outfit_Clothing OutfitClothes =_context.OutfitClothing.Find(item.Id);
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
    }
}
