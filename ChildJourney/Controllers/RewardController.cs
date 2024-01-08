using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildJourney.Data;
using ChildJourney.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ChildJourney.Controllers
{
    public class RewardController : Controller
    {
        private readonly Database _context;

        public RewardController(Database context)
        {
            _context = context;
        }

        public HomeController HomeController()
        {
            var Hc = new HomeController(_context);
            return Hc;
        }

        // GET: Reward
        public async Task<IActionResult> Index()
        {
            return _context.Rewards != null ?
                        View(await _context.Rewards.ToListAsync()) :
                        Problem("Entity set 'Database.Rewards'  is null.");
        }

        // GET: Reward/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rewards == null)
            {
                return NotFound();
            }

            var reward = await _context.Rewards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reward == null)
            {
                return NotFound();
            }

            return View(reward);
        }

        // GET: Reward/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reward/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,CurrencyType,Worth,Price,Image")] Reward reward)
        {
            int rewardcounter = 0;
            if (reward.Type == "Weekly")
            {
                foreach (var item in _context.Rewards.ToList())
                {
                    if (item.Type == "Weekly")
                    {
                        rewardcounter += 1;
                    }
                }
            }
            if (rewardcounter >= 7 || (reward.Type == "Seasonal" && reward.Price == 0)) 
            {
                return View();
            }
            else { 
                _context.Add(reward);
                foreach (var user in _context.Users.ToList())
                {
                    User_Reward User_Reward = new User_Reward()
                    {
                        User = user,
                        Type = reward.Type,
                        Reward = reward
                    };
                    _context.UsersRewards.Add(User_Reward);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                return View("../Home/AdminDashboard", HomeController().AdminViewModel());
            }
        }

        // GET: Reward/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rewards == null)
            {
                return NotFound();
            }

            var reward = await _context.Rewards.FindAsync(id);
            if (reward == null)
            {
                return NotFound();
            }
            return View(reward);
        }

        // POST: Reward/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,CurrencyType,Worth,Image")] Reward reward)
        {
            if (id != reward.Id)
            {
                return NotFound();
            }
            if (reward.Type == "Seasonal" && reward.Price == 0)
            {
                return View();
            }
            else
            {
                _context.Update(reward);
                await _context.SaveChangesAsync();
                return View("../Home/AdminDashboard", HomeController().AdminViewModel());
            }
        }

        // GET: Reward/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rewards == null)
            {
                return NotFound();
            }

            var reward = await _context.Rewards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reward == null)
            {
                return NotFound();
            }

            return View(reward);
        }

        // POST: Reward/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rewards == null)
            {
                return Problem("Entity set 'Database.Rewards'  is null.");
            }
            var reward = await _context.Rewards.FindAsync(id);
            if (reward != null)
            {
                _context.Rewards.Remove(reward);
            }

            await _context.SaveChangesAsync();
            return View("../Home/AdminDashboard", HomeController().AdminViewModel());
        }

        private bool RewardExists(int id)
        {
            return (_context.Rewards?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult DeleteSeasonal()
        {
            foreach (var Reward in _context.UsersRewards.ToList())
            {
                if (Reward.Type == "Seasonal" || Reward.Type == "SeasonalClaimed")
                {
                    _context.Remove(Reward);
                    _context.SaveChanges();
                }
            }
            foreach (var Reward in _context.Rewards.ToList())
            {
                if (Reward.Type == "Seasonal")
                {
                    _context.Remove(Reward);
                    _context.SaveChanges();
                }
            }
            return Json(new { success = true, refreshPage = true });
        }
        public IActionResult DeleteWeeklies()
        {
            foreach (var Reward in _context.UsersRewards.ToList())
            {
                if (Reward.Type == "Weekly" || Reward.Type == "WeeklyClaimed")
                {
                    _context.Remove(Reward);
                    _context.SaveChanges();
                }
            }
            foreach (var Reward in _context.Rewards.ToList())
            {
                if (Reward.Type == "Weekly")
                {
                    _context.Remove(Reward);
                    _context.SaveChanges();
                }
            }
            return Json(new { success = true, refreshPage = true });
        }
    }
}