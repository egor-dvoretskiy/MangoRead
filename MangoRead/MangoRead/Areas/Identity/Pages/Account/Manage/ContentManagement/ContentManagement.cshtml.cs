using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangoRead.Areas.Identity.Pages.Account.Manage.ContentManagement
{
    public class ContentManagementModel : PageModel
    {
        private readonly IManuscriptService _manuscriptService;

        public ContentManagementModel(IManuscriptService manuscriptService)
        {
            _manuscriptService = manuscriptService;
        }

        public void OnGet()
        {


        }
    }
}
