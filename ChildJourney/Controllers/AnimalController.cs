using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.Models;
using ChildJourney.ViewModels;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChildJourney.Controllers
{
    public class AnimalController : Controller
    {
        private readonly Database _context;

        public AnimalController(Database context)
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
            var animal = _context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }
        public IActionResult Delete(int? id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        //functions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal animal)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            _context.Add(animal);
            User_Animal user_Animal = new User_Animal()
            {
                User = user,
                Animal = animal
            };
            _context.UsersAnimals.Add(user_Animal);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }
            _context.Update(animal);
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
            }
            _context.SaveChanges();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }
        public IActionResult AddAnimal()
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            Animal animal;
            List<Animal> neededAnimals = new List<Animal>();
            foreach (var Animal in _context.Animals.ToList())
            {
                var useranimal = _context.UsersAnimals.FirstOrDefault(c => c.AnimalId == Animal.Id && c.UserId == user.Id);
                if (useranimal == null)
                {
                    neededAnimals.Add(Animal);
                }
            }
            if (neededAnimals.Count != 0)
            {
                animal = neededAnimals[0];
                User_Animal userAnimal = new User_Animal()
                {
                    Animal = animal,
                    User = user
                };
                _context.UsersAnimals.Add(userAnimal);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = true });
            }
        }
        public IActionResult DeleteAll()
        {
            foreach (var Animal in _context.UsersAnimals.ToList())
            {
                _context.Remove(Animal);
                _context.SaveChanges();
            }
            foreach (var Animal in _context.Animals.ToList())
            {
                _context.Remove(Animal);
                _context.SaveChanges();
            }
            return Json(new { success = true, refreshPage = true });
        }
    }
}
