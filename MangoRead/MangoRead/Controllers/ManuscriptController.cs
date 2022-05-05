using MangoRead.Domain.Enums;
using MangoRead.Domain.ViewModels;
using MangoRead.Domain.ViewModels.Manuscript;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ManuscriptCreateViewModel());
        }

        [Authorize]
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

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this.manuscriptService.DeleteManuscript(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToPage("/Account/Manage/ManuscriptManagementAdvanced", new { area = "Identity" });
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await this.manuscriptService.GetManuscriptForEditById(id);
            var manuscript = response.Data;

            if (manuscript == null)
            {
                return NotFound();
            }

            return View(manuscript);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManuscriptEditViewModel model)
        {
            var response = await this.manuscriptService.Edit(id, model);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var response = await this.manuscriptService.SetApprovalStatus(id, ApprovalStatus.Approved);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new {id = id});
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var response = await this.manuscriptService.SetApprovalStatus(id, ApprovalStatus.Rejected);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return RedirectToAction("Error");
        }

        /*[HttpPost]
        public IActionResult Upload(List<IFormFile> postedFiles)
        {
            List<string> uploadedFiles = new List<string>();
            int count = 0;
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                count++;
                *//*using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }*//*
            }

            ViewBag.Message = $"uploaded {count} time(s).";

            return RedirectToAction("Create");
        }*/
    }
}
