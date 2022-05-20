using MangoRead.Domain.ViewModels.Account.Manage.ContentManagement;
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

        [BindProperty]
        public IList<ContentManagementViewModel> Contents { get; set; }

        public void OnGet()
        {
            var manuscripts = _manuscriptService.GetManuscripts();

            if (manuscripts.Status != Domain.Enums.ResponseStatus.OK && manuscripts.Status != Domain.Enums.ResponseStatus.EmptyEntity)
            {
                throw new ArgumentException("Get rejected data fails.");
            }

            Contents = manuscripts.Data
                .Where(x => x.Content != null && x.Content.ApprovalStatus != Domain.Enums.ApprovalStatus.Approved)
                .Select(x => new ContentManagementViewModel(x.Content))
                .ToList();
        }
    }
}
