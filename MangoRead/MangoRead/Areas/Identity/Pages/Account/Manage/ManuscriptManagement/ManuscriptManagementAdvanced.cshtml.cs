using MangoRead.Domain.Models.Account;
using MangoRead.Domain.ViewModels.Account.Manage;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRead.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
    public class ManuscriptManagementAdvancedModel : PageModel
    {
        private readonly IManuscriptService _manuscriptService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManuscriptManagementAdvancedModel(IManuscriptService manuscriptService, UserManager<ApplicationUser> userManager)
        {
            _manuscriptService = manuscriptService;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public IList<ManuscriptManagementAdvancedViewModel> ApprovedManuscriptManagementAdvancedViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<ManuscriptManagementAdvancedViewModel> RequestedManuscriptManagementAdvancedViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<ManuscriptManagementAdvancedViewModel> RejectedManuscriptManagementAdvancedViewModel { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                ApprovedManuscriptManagementAdvancedViewModel = await this.GetApprovedData();
                RequestedManuscriptManagementAdvancedViewModel = await this.GetRequestedData();
                RejectedManuscriptManagementAdvancedViewModel = await this.GetRejectedData();
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        private async Task<IList<ManuscriptManagementAdvancedViewModel>> GetRejectedData()
        {
            var responseApproved = await _manuscriptService.GetRejectedManuscriptsForAdvancedManagement();

            if (responseApproved.Status != Domain.Enums.ResponseStatus.OK && responseApproved.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get rejected data fails.");
            }

            return responseApproved.Data;
        }

        private async Task<IList<ManuscriptManagementAdvancedViewModel>> GetApprovedData()
        {
            var responseApproved = await _manuscriptService.GetApprovedManuscriptsForAdvancedManagement();

            if (responseApproved.Status != Domain.Enums.ResponseStatus.OK && responseApproved.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get approved data fails.");
            }

            return responseApproved.Data;
        }

        private async Task<IList<ManuscriptManagementAdvancedViewModel>> GetRequestedData()
        {
            var responseRequested = await _manuscriptService.GetRequestedManuscriptsForAdvancedManagement();

            if (responseRequested.Status != Domain.Enums.ResponseStatus.OK && responseRequested.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get requested data fails.");
            }

            return responseRequested.Data;
        }
    }
}
