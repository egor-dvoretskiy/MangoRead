using MangoRead.Domain.Models.Account;
using MangoRead.Domain.ViewModels.Account.Manage;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRead.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Basic")]
    public class ManuscriptManagementBasicModel : PageModel
    {
        private readonly IManuscriptService _manuscriptService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManuscriptManagementBasicModel(IManuscriptService manuscriptService, UserManager<ApplicationUser> userManager)
        {
            _manuscriptService = manuscriptService;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public IList<ManuscriptManagementBasicViewModel> ManuscriptManagementBasicViewModels { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return;
            }

            var response = await _manuscriptService.GetManuscriptsForBasicManagement(user.UserName);

            if (response.Status != Domain.Enums.ResponseStatus.OK && response.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return;
            }

            ManuscriptManagementBasicViewModels = response.Data;
        }
    }
}
