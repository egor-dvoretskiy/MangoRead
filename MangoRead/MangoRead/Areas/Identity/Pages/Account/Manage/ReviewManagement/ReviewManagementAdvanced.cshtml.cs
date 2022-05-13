using MangoRead.Domain.Models.Account;
using MangoRead.Domain.ViewModels.Account.Manage.ReviewManagement;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRead.Areas.Identity.Pages.Account.Manage.ReviewManagement
{
    [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
    public class ReviewManagementAdvancedModel : PageModel
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewManagementAdvancedModel(IReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public IList<ReviewManagementAdvancedViewModel> ApprovedReviewManagementAdvancedViewModels { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<ReviewManagementAdvancedViewModel> RequestedReviewManagementAdvancedViewModels { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<ReviewManagementAdvancedViewModel> RejectedReviewManagementAdvancedViewModels { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                ApprovedReviewManagementAdvancedViewModels = this.GetApprovedData();
                RequestedReviewManagementAdvancedViewModels = this.GetRequestedData();
                RejectedReviewManagementAdvancedViewModels = this.GetRejectedData();
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        private IList<ReviewManagementAdvancedViewModel> GetRejectedData()
        {
            var responseApproved = _reviewService.GetRejectedReviewsForAdvancedManagement();

            if (responseApproved.Status != Domain.Enums.ResponseStatus.OK && responseApproved.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get rejected data fails.");
            }

            return responseApproved.Data;
        }

        private IList<ReviewManagementAdvancedViewModel> GetApprovedData()
        {
            var responseApproved = _reviewService.GetApprovedReviewsForAdvancedManagement();

            if (responseApproved.Status != Domain.Enums.ResponseStatus.OK && responseApproved.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get approved data fails.");
            }

            return responseApproved.Data;
        }

        private IList<ReviewManagementAdvancedViewModel> GetRequestedData()
        {
            var responseRequested = _reviewService.GetRequestedReviewsForAdvancedManagement();

            if (responseRequested.Status != Domain.Enums.ResponseStatus.OK && responseRequested.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get requested data fails.");
            }

            return responseRequested.Data;
        }
    }
}
