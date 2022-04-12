﻿using MangoRead.DAL;
using MangoRead.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MangoRead.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            this._context.Manuscripts.Add(new Domain.Entities.Manuscript { Title = "Test title", Publisher = "SomeGuy", Type = Domain.Enums.ManuscriptType.Manhwa });
            this._context.SaveChangesAsync();
            return View();
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