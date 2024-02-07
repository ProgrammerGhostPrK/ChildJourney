using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.ViewModels;
using Newtonsoft.Json;
using System.Numerics;
using ChildJourney.Models;
using System;
using System.Globalization;
using System.Net;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChildJourney.Controllers
{
    public class GameController : Controller
    {
        private readonly Database _context;

        public GameController(Database context)
        {
            _context = context;
        }

        //Fillings Viewmodels
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
                Moods = _context.Moods.ToList(),
                rewards = _context.Rewards.ToList(),
                Outfit_Clothings = _context.OutfitClothing.ToList(),
                Body_BodyParts = _context.BodyBodyParts.ToList(),
                UserBodyPart = _context.UsersBodyParts.ToList(),
                House_Decos = _context.HouseDecoration.ToList(),
                UserClothing = _context.UsersClothing.ToList(),
                UserAnimals = _context.UsersAnimals.ToList(),
                UserDecoration = _context.UsersDecorations.ToList(),
                UserBadges = _context.UsersBadges.ToList(),
                UserRewards = _context.UsersRewards.ToList(),
                Islands = _context.Islands.ToList(),
                CurrentIsland = island,
                User_Island = _context.UserIslands.ToList(),
                User = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"))
        };
            return viewModel;
        }
        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        //Getting Views
        public IActionResult TimedRewards()
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            int Rewardcount = 0;
            foreach (var Rewardpiece in _context.UsersRewards.ToList())
            {
                if (Rewardpiece.UserId == user.Id)
                {
                    Rewardcount += 1;
                }
            }
            if (Rewardcount == 0)
            {
                foreach (var Reward in _context.Rewards.ToList())
                {
                    AddReward(Reward, user);
                }
            }
            return View(HomeController().AdminViewModel());
        }
        public IActionResult Character()
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            int Clothingcount = 0;
            int Bodypartcount = 0;
            int Islandcount = 0;
            int Decorationcount = 0;
            foreach (var clothingpiece in _context.UsersClothing.ToList())
            {
                if (clothingpiece.UserId == user.Id) 
                {
                    Clothingcount += 1;
                }
            }
            foreach (var Bodypart in _context.UsersBodyParts.ToList())
            {
                if (Bodypart.UserId == user.Id)
                {
                    Bodypartcount += 1;
                }
            }
            foreach (var Island in _context.UserIslands.ToList())
            {
                if (Island.UserId == user.Id)
                {
                    Islandcount += 1;
                }
            }
            foreach (var Decorationpiece in _context.UsersDecorations.ToList())
            {
                if (Decorationpiece.UserId == user.Id)
                {
                    Decorationcount += 1;
                }
            }
            if (Clothingcount == 0)
            {
                foreach(var Clothing in _context.Clothing.ToList())
                {
                    if (Clothing.Price == 0) 
                    { 
                        AddClothing(Clothing, user);
                    }
                }
            }
            if (Bodypartcount == 0)
            {
                foreach (var Bodypart in _context.BodyParts.ToList())
                {
                    if (Bodypart.Price == 0)
                    {
                        AddBodyPart(Bodypart, user);
                    }
                }
            }
            if (Islandcount == 0)
            {
                foreach (var Island in _context.Islands.ToList())
                {
                    if (Island.Price == 0)
                    {
                        AddIsland(Island, user);
                    }
                }
            }
            if (Decorationcount == 0)
            {
                foreach (var Deco in _context.Decoration.ToList())
                {
                    if (Deco.Price == 0)
                    {
                        AddDecoration(Deco, user);
                    }
                }
            }
            return View(HomeController().AdminViewModel());
        }
        public IActionResult Islandpicking()
        {
            return View(HomeController().AdminViewModel());
        }
        public IActionResult Inventory(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island response = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = response as Island;
            }
            else { island = _context.Islands.Find(Id); }

            return View(AdminViewModel(island));
        }
        public IActionResult StoreBodyPart(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island response = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = response as Island;
            }
            else { island = _context.Islands.Find(Id); }

            return View(AdminViewModel(island));
        }
        public IActionResult StoreClothing(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island response = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = response as Island;
            }
            else { island = _context.Islands.Find(Id); }

            return View(AdminViewModel(island));
        }
        public IActionResult StoreIslands(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island response = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = response as Island;
            }
            else { island = _context.Islands.Find(Id); }

            return View(AdminViewModel(island));
        }
        public IActionResult StoreDecorations(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island response = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = response as Island;
            }
            else { island = _context.Islands.Find(Id); }

            return View(AdminViewModel(island));
        }
        public IActionResult HomeIsland(int? Id)
        {
            Island island;
            if (Id == null)
            {
                Island islandresponse = JsonConvert.DeserializeObject<Island>(HttpContext.Session.GetString("CurrentIsland"));
                island = islandresponse as Island;
            }
            else
            {
                island = _context.Islands.Find(Id);
                var islandJson = JsonConvert.SerializeObject(island);
                HttpContext.Session.SetString("CurrentIsland", islandJson);
            }

            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            int Day;

            using (var client = new HttpClient())
            {
                DayOfWeek Result;
                
                try
                {
                    var result = client.GetAsync("https://google.com", HttpCompletionOption.ResponseHeadersRead).Result;
                    Result = result.Headers.Date.Value.DayOfWeek;
                    Day = result.Headers.Date.Value.Day;
                }
                catch {
                    Result = DateTime.Today.DayOfWeek;
                    Day = DateTime.Today.Day;
                }
                if (user.lastMonthLogin != Day && user.Daystreak != (int)Result)
                {
                    user.DailyStreak = 0;
                    _context.SaveChanges();
                }                
                user.lastWeekLogin = user.Daystreak;
                user.Daystreak = (int)Result;
            }

            if (user.Daystreak != user.lastWeekLogin)
            {
                int counter = 0;
                foreach (var item in _context.UsersRewards.ToList())
                {
                    if (item.Type == "WeeklyClaimed" && item.UserId == user.Id)
                    {
                        counter += 1;
                    }
                    if (response.Daystreak < _context.Rewards.Find(item.RewardId).Day && item.Type == "WeeklyClaimed" && item.UserId == response.Id)
                    {
                        foreach (var Object in _context.UsersRewards.ToList())
                        {
                            if (Object.Type == "WeeklyClaimed" && Object.UserId == user.Id)
                            {
                                Object.Type = "Weekly";
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                foreach (var Mood in _context.Moods.ToList())
                {
                    if (Day < Mood.Day && Mood.UserId == response.Id)
                    {
                        _context.Remove(Mood);
                        _context.SaveChanges();
                    }
                }
                user.lastMonthLogin = Day;
                user.lastWeekLogin = user.Daystreak;
            }
            
            _context.SaveChanges();
            return View(AdminViewModel(island));
        }

        //game functions
        public IActionResult AddAnimal()
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            Animal animal;
            List<Animal> neededAnimals = new List<Animal>();
            foreach (var Animal in _context.Animals.ToList()) 
            {
                var useranimal = _context.UsersAnimals.FirstOrDefault(c => c.AnimalId == Animal.Id && c.UserId == user.Id);
                if (useranimal == null){
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
        public IActionResult AddReward(Reward piece, User user)
        {
            User_Reward user_Reward = new User_Reward()
            {
                User = user,
                Type = piece.Type,
                Reward = piece
            };
            _context.UsersRewards.Add(user_Reward);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddClothing(Clothing piece, User user)
        {
            User_Clothing user_Clothing = new User_Clothing()
            {
                User = user,
                Type = piece.Type,
                Clothing = piece
            };
            _context.UsersClothing.Add(user_Clothing);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddIsland(Island piece, User user)
        {
            User_Island user_Island = new User_Island()
            {
                User = user,
                Island = piece
            };
            _context.UserIslands.Add(user_Island);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddBodyPart(BodyPart piece, User user)
        {
            User_BodyPart user_Bodypart = new User_BodyPart()
            {
                User = user,
                Type = piece.Type,
                BodyPart = piece
            };
            _context.UsersBodyParts.Add(user_Bodypart);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddDecoration(Decoration piece, User user)
        {
            User_Decoration user_Decoration = new User_Decoration()
            {
                User = user,
                Type = piece.Type,
                Decoration = piece
            };
            _context.UsersDecorations.Add(user_Decoration);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddCoins(int Amount)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            user.Coins += Amount;
            _context.SaveChanges();
            return Json(new { success = true });
        }
        public IActionResult AddSeasonPoints(int Amount)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            user.SeasonPoints += Amount;
            user.DailyStreak += 1;
            _context.SaveChanges();
            return Json(new { success = true });
        }
        public IActionResult AddMood(string Grade, int userId, int Day)
        {
            Mood mood = new Mood()
            {
                User = _context.Users.Find(userId),
                Grade = Grade,
                Day = Day
            };
            _context.Moods.Add(mood);
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
        }
    }
}
