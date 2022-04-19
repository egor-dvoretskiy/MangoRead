using MangoRead.Domain.ViewModels;
using MangoRead.Domain.ViewModels.Manuscript;
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
            var response = await this.manuscriptService.GetManuscriptDetailsById(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManuscriptCreateViewModel manuscript)
        {
            if (ModelState.IsValid)
            {
                var response = await this.manuscriptService.AddManuscript(manuscript);

                if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(manuscript);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await this.manuscriptService.DeleteManuscript(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await this.manuscriptService.GetManuscriptViewModelForEditById(id);
            var manuscript = response.Data;

            if (manuscript == null)
            {
                return NotFound();
            }

            return View(manuscript);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManuscriptEditViewModel model)
        {
            var response = await this.manuscriptService.Edit(id, model);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
