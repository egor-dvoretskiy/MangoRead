using MangoRead.Domain.Models.Account;
using MangoRead.Domain.ViewModels.Account.Manage.ReviewManagement;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRead.Areas.Identity.Pages.Account.Manage.ReviewManagement
{
    [Authorize(Roles="Basic")]
    public class ReviewManagementBasicModel : PageModel
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewManagementBasicModel(IReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public IList<ReviewManagementBasicViewModel> ReviewManagementBasicViewModel { get; set; }

        public async Task OnGetAsync()
        {
            /*var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return;
            }

            var response = await _reviewService.GetManuscriptsForBasicManagement(user.UserName);

            if (response.Status != Domain.Enums.ResponseStatus.OK && response.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return;
            }

            ManuscriptManagementBasicViewModels = response.Data;*/
        }
    }
}
