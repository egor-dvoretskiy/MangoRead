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

        public async Task<IActionResult> GetManuscripts()
        {
            var response = await this.manuscriptService.GetManuscripts();

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
