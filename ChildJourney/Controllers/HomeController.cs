using ChildJourney.Models;
using ChildJourney.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ChildJourney.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ChildJourney.Controllers
{
    public class HomeController : Controller
    {
        private readonly Database _context;

        public HomeController(Database context)
        {
            _context = context;
        }

        public AdminViewModel AdminViewModel()
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
                House_Decos = _context.HouseDecoration.ToList(),
                UserBodyPart = _context.UsersBodyParts.ToList(),
                UserClothing = _context.UsersClothing.ToList(),
                UserAnimals = _context.UsersAnimals.ToList(),
                UserDecoration = _context.UsersDecorations.ToList(),
                UserBadges = _context.UsersBadges.ToList(),
                UserRewards = _context.UsersRewards.ToList(),
                Islands = _context.Islands.ToList(),
                User_Island = _context.UserIslands.ToList(),
            };
            return viewModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Playgame()
        {
            return View(AdminViewModel());
        }

        public IActionResult AdminDashboard()
        {
            return View(AdminViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}