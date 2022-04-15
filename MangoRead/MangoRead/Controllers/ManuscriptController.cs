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

        public async Task<IActionResult> Index()
        {
            var response = await this.manuscriptService.GetManuscripts();

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await this.manuscriptService.GetManuscriptById(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }
    }
}
