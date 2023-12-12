using Microsoft.AspNetCore.Mvc;

namespace ChildJourney.Controllers
{
    public class GameController : Controller
    {

        public GameController()
        {
        }

        public ActionResult Introduction() 
        { 
            return View();
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
