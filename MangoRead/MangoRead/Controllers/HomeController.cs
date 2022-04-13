using MangoRead.DAL;
using MangoRead.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var elements = _context.Manuscripts.Where(x => x.OriginCountry.Equals("Japanese")).ToList();

            if (elements.Any())
            {
                var test = _context.Manuscripts.Include(x => x.Content).ThenInclude(x => x.Pages).ToList();
                string foldername = elements[0].Content?.FolderName ?? "nothing";
                string pages = elements[0].Content?.Pages.First().Path;
            }

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