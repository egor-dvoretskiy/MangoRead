using MangoRead.Domain.Enums;
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

        // GET: ManuscriptReviewController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var response = this._reviewService.GetReviewDetailsById(id);

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

        [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var response = this._reviewService.GetReviewForEditById(id);
            var review = response.Data;

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewEditViewModel model)
        {
            var response = await this._reviewService.Edit(id, model);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._reviewService.DeleteReview(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToPage("/Account/Manage/ReviewManagement/ReviewManagementAdvanced", new { area = "Identity" });
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var response = await this._reviewService.SetApprovalStatus(id, ApprovalStatus.Approved);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var response = await this._reviewService.SetApprovalStatus(id, ApprovalStatus.Rejected);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return RedirectToAction("Error");
        }
    }
}
