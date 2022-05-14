using Ionic.Zip;
using MangoRead.Domain.Enums;
using MangoRead.Domain.ViewModels;
using MangoRead.Domain.ViewModels.Manuscript;
using MangoRead.Service.Extensions;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;
using System.Web;

namespace MangoRead.Controllers
{
    public class ManuscriptController : Controller
    {
        private readonly IManuscriptService _manuscriptService;
        private readonly IConfiguration _configuration;

        public ManuscriptController(IManuscriptService manuscriptService, IConfiguration configuration)
        {
            _manuscriptService = manuscriptService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var response = this._manuscriptService.GetManuscripts();

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }

        public IActionResult Details(int id)
        {
            var response = this._manuscriptService.GetManuscriptDetailsById(id);

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
                var response = await this._manuscriptService.AddManuscript(manuscript);

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
            var response = await this._manuscriptService.DeleteManuscript(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToPage("/Account/Manage/ManuscriptManagement/ManuscriptManagementAdvanced", new { area = "Identity" });
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var response = this._manuscriptService.GetManuscriptForEditById(id);
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
            var response = await this._manuscriptService.Edit(id, model);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var response = await this._manuscriptService.SetApprovalStatus(id, ApprovalStatus.Approved);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new {id = id});
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var response = await this._manuscriptService.SetApprovalStatus(id, ApprovalStatus.Rejected);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return RedirectToAction("Error");
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddContent(int id)
        {
            var response = this._manuscriptService.GetManuscriptContent(id);

            if (response.Status == Domain.Enums.ResponseStatus.OK || response.Status == Domain.Enums.ResponseStatus.EmptyEntity)
            {
                var content = response.Data;

                return View(content);
            }

            return RedirectToAction("Error");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddContent(int id, ManuscriptContentViewModel model)
        {
            var response = this._manuscriptService.GetManuscriptContent(id);
            var content = response.Data;
            string title = content.Manuscript.Title;
            var file = model.File;

            if (!file.FileName.Contains(title))
            {
                ViewBag.Message = $"Wrong archive name: {file.Name}. The name of title you choosed is {title}";
                return View(content);
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            string contentPath = _configuration.GetValue<string>("StaticFilesConfiguration:RequestedFolderPath");
            string type = content.Manuscript.Type.ToString();

            string extractPath = string.Concat(currentDirectory, contentPath, type, @"\", file.FileName);

            using (Stream fileStream = new FileStream(extractPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }

            return RedirectToAction("Details", new { id = id });
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
