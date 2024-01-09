using Microsoft.AspNetCore.Mvc;

namespace ChildJourney.Controllers
{
    public class MiniGamesController : Controller
    {
        public IActionResult BoatSteering()
        {
            return View();
        }
        public IActionResult BirdFlying()
        {
            return View();
        }
    }
}
