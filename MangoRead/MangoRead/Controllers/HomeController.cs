using MangoRead.DAL;
using MangoRead.Models;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MangoRead.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService _reviewService;

        public HomeController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            var response = this._reviewService.GetPosingReviews();

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
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