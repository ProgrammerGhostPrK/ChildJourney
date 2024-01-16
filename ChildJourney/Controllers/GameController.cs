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

namespace ChildJourney.Controllers
{
    public class GameController : Controller
    {
        private readonly Database _context;
        Outfit outfit;
        Body body;
        House House;

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
                foreach (var Mood in _context.Moods)
                {
                    if (response.Daystreak < Mood.Day && Mood.UserId == response.Id)
                    {
                        _context.Remove(Mood);
                        _context.SaveChanges();
                    }
                }
                user.lastMonthLogin = Day;
            }
            
            _context.SaveChanges();
            return View(AdminViewModel(island));
        }
        public IActionResult ClaimReward(int id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            User_Reward user_Reward = _context.UsersRewards.Find(id);
            Reward reward = _context.Rewards.Find(user_Reward.RewardId);
            if (reward.CurrencyType == "Coins") 
            {
                user.Coins += reward.Worth;
            }
            if (reward.CurrencyType == "SeasonPoints")
            {
                user.SeasonPoints += reward.Worth;
            }
            user_Reward.Type = "WeeklyClaimed";
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
        }
        public IActionResult ClaimSeasonalReward(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            User_Reward user_Reward = _context.UsersRewards.Find(Id);
            Reward reward = _context.Rewards.Find(user_Reward.RewardId);
            if (reward.CurrencyType == "Coins")
            {
                user.Coins += reward.Worth;
            }
            if (reward.CurrencyType == "SeasonPoints")
            {
                user.SeasonPoints += reward.Worth;
            }
            user_Reward.Type = "SeasonalClaimed";
            _context.SaveChanges();
            return Json(new { success = true, refreshPage = true });
        }
        public IActionResult BuyClothing(int? Id)
        {
                var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                User user = _context.Users.Find(response.Id);
                var Clothingpiece = _context.Clothing.Find(Id);
                if (user.Coins >= Clothingpiece.Price)
                {
                    foreach (var item in _context.UsersClothing)
                    {
                        if (item.UserId == user.Id && item.ClothingId == Clothingpiece.Id)
                        {
                            return Json(new { success = true, refreshPage = false });
                        }
                    }
                    User_Clothing user_Clothing = new User_Clothing()
                    {
                        User = user,
                        Type = Clothingpiece.Type,
                        Clothing = Clothingpiece
                    };
                    user.Coins -= Clothingpiece.Price;
                    _context.UsersClothing.Add(user_Clothing);
                    _context.SaveChanges();
                    return Json(new { success = true, refreshPage = true });
                }
                else
                {
                    return Json(new { success = true, refreshPage = false });
                }
        }
        public IActionResult BuyBodyPart(int? Id)
        {
            {
                var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                User user = _context.Users.Find(response.Id);
                var BodyPart = _context.BodyParts.Find(Id);
                if (user.Coins >= BodyPart.Price)
                {
                    foreach (var item in _context.UsersBodyParts)
                    {
                        if (item.UserId == user.Id && item.BodyPartId == BodyPart.Id)
                        {
                            return Json(new { success = true, refreshPage = false });
                        }
                    }
                    User_BodyPart user_BodyPart = new User_BodyPart()
                    {
                        User = user,
                        Type = BodyPart.Type,
                        BodyPart = BodyPart
                    };
                    user.Coins -= BodyPart.Price;
                    _context.UsersBodyParts.Add(user_BodyPart);
                    _context.SaveChanges();
                    return Json(new { success = true, refreshPage = true });
                }
                else
                {
                    return Json(new { success = true, refreshPage = false });
                }
            }
        }
        public IActionResult BuyIsland(int? Id)
        {
            {
                var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                User user = _context.Users.Find(response.Id);
                var Island = _context.Islands.Find(Id);
                if (user.Coins >= Island.Price)
                {
                    foreach (var item in _context.UserIslands)
                    {
                        if (item.UserId == user.Id && item.IslandId == Island.Id)
                        {
                            return Json(new { success = true, refreshPage = false });
                        }
                    }
                    User_Island user_Island = new User_Island()
                    {
                        User = user,
                        Island = Island
                    };
                    user.Coins -= Island.Price;
                    _context.UserIslands.Add(user_Island);
                    _context.SaveChanges();
                    return Json(new { success = true, refreshPage = true });
                }
                else
                {
                    return Json(new { success = true, refreshPage = false });
                }
            }
        }
        public IActionResult BuyDecoration(int? Id)
        {
            {
                var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                User user = _context.Users.Find(response.Id);
                var Decoration = _context.Decoration.Find(Id);
                if (user.Coins >= Decoration.Price)
                {
                    foreach (var item in _context.UsersDecorations)
                    {
                        if (item.UserId == user.Id && item.DecorationId == Decoration.Id)
                        {
                            return Json(new { success = true, refreshPage = false });
                        }
                    }
                    User_Decoration user_Decoration = new User_Decoration()
                    {
                        User = user,
                        Type = Decoration.Type,
                        Decoration = Decoration
                    };
                    user.Coins -= Decoration.Price;
                    _context.UsersDecorations.Add(user_Decoration);
                    _context.SaveChanges();
                    return Json(new { success = true, refreshPage = true });
                }
                else
                {
                    return Json(new { success = true, refreshPage = false });
                }
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
        public IActionResult AddToOutfit(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var UserClothingpiece = _context.UsersClothing.Find(Id);
            var Clothingpiece = _context.Clothing.Find(UserClothingpiece.ClothingId);
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
        public IActionResult AddToHouse(int Id)
        {
            var response = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
            User user = _context.Users.Find(response.Id);
            var UserDecorationpiece = _context.UsersDecorations.Find(Id);
            var Decorationpiece = _context.Decoration.Find(UserDecorationpiece.DecorationId);
            if (user.HouseId == null)
            {
                House = new House()
                {
                    User = user,
                };
                user.House = House;
                HouseDeco HouseD = new HouseDeco()
                {
                    House = user.House,
                    Decoration = Decorationpiece
                };
                _context.HouseDecoration.Add(HouseD);
                _context.SaveChanges();
                user.HouseId = _context.Houses.FirstOrDefault(m => m.UserId == user.Id).Id;
                _context.SaveChanges();
            }
            else
            {
                House = _context.Houses.Find(user.HouseId);
                HouseDeco HouseD = new HouseDeco()
                {
                    House = House,
                    Decoration = Decorationpiece
                };
                _context.HouseDecoration.Add(HouseD);
                _context.SaveChanges();
                foreach (var item in _context.HouseDecoration.ToList())
                {
                    Decoration FoundDecoration = _context.Decoration.Find(item.DecorationId);
                    if (FoundDecoration.Type == Decorationpiece.Type && user.HouseId == item.HouseId)
                    {
                        _context.HouseDecoration.Remove(HouseD);
                        HouseDeco HouseClothes = _context.HouseDecoration.Find(item.Id);
                        HouseClothes.DecorationId = HouseD.DecorationId;
                        _context.HouseDecoration.Update(HouseClothes);
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
            var UserBodypart = _context.UsersBodyParts.Find(Id);
            var Bodypart = _context.BodyParts.Find(UserBodypart.BodyPartId);
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
