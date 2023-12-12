using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.ViewModels;

namespace ChildJourney.Controllers
{
    public class GameController : Controller
    {
        private readonly Database _context;

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

        public List<string> AddDialogue(string Text, List<string> list)
        {
            list.Add(Text);
            return list;
        }

        public List<string> RemoveDialogue(List<string> list)
        {
            list.RemoveAt(0);
            return list;
        }
    }
}
