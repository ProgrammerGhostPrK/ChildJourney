﻿using ChildJourney.Models;
using ChildJourney.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ChildJourney.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                rewards = _context.Rewards.ToList()
            };
            return viewModel;
        }

        public IActionResult Index()
        {
            return View();
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