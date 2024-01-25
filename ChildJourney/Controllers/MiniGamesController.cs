using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.Models;
using Newtonsoft.Json;

namespace ChildJourney.Controllers
{
    public class MiniGamesController : Controller
    {
        private readonly Database _context;

        public MiniGamesController(Database context)
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
        public IActionResult AnimalCatch()
        {
            return View(HomeController().AdminViewModel());
        }
        public IActionResult BoatSteering()
        {
            return View(HomeController().AdminViewModel());
        }
        public IActionResult BirdFlying()
        {
            return View(HomeController().AdminViewModel());
        }
    }
}
