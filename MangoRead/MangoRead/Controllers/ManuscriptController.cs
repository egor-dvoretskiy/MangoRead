using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MangoRead.Controllers
{
    public class ManuscriptController : Controller
    {
        private readonly IManuscriptService manuscriptService;

        public ManuscriptController(IManuscriptService manuscriptService)
        {
            this.manuscriptService = manuscriptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Archive()
        {
            var response = await this.manuscriptService.GetManuscripts();

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }
    }
}
