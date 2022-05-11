using MangoRead.Domain.Models.Account;
using MangoRead.Domain.ViewModels.Review;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MangoRead.Controllers
{
    public class ManuscriptReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManuscriptReviewController(IReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }

        // GET: ManuscriptReviewController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManuscriptReviewController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await this._reviewService.GetReviewDetailsById(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(int id)
        {
            return View(new ReviewCreateViewModel() { IdCouple = id });
        }

        // POST: ManuscriptReviewController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(int id, ReviewCreateViewModel review)
        {
            review.IdCouple = id;
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                review.UserName = user.UserName;
            }

            if (ModelState.IsValid)
            {
                var response = await this._reviewService.AddReview(review);

                if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
                {
                    return RedirectToAction("Details", "Manuscript", new {id = review.IdCouple});
                }
            }

            return View(review);
        }

        // GET: ManuscriptReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManuscriptReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManuscriptReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManuscriptReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
