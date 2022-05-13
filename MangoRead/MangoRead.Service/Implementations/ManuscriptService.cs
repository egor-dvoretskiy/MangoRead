#nullable disable

using MangoRead.DAL.Interfaces;
using MangoRead.Domain.Models;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.Responses;
using MangoRead.Domain.ViewModels;
using MangoRead.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangoRead.Domain.ViewModels.Manuscript;
using MangoRead.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MangoRead.Service.Extensions;
using MangoRead.Domain.ViewModels.Account.Manage;

namespace MangoRead.Service.Implementations
{
    public class ManuscriptService : IManuscriptService
    {
        private readonly IManuscriptRepository manuscriptRepository;

        public ManuscriptService(DAL.Interfaces.IManuscriptRepository manuscriptRepository)
        {
            this.manuscriptRepository = manuscriptRepository;
        }

        public async Task<IBaseResponse<ManuscriptCreateViewModel>> AddManuscript(ManuscriptCreateViewModel model)
        {
            var response = new BaseResponse<ManuscriptCreateViewModel>();

            try
            {
                var manuscript = new Manuscript()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Author = model.Author,
                    UpdateDate = DateTime.Now,
                    UploadDate = DateTime.Now,
                    Publisher = model.Publisher,
                    Translator = model.Translator,
                    OriginCountry = model.OriginCountry,
                    Type = model.Type,
                    Description = model.Description,
                    IsRequireLegalAge = model.IsRequireLegalAge,
                    Genres = model.Genres.Select(x => new GenreHolder() { Genre = x }).ToList(),
                    TitleImage = await model.TitlePicture.GetBytes(),
                };

                bool isValid = await this.manuscriptRepository.Create(manuscript);

                if (!isValid)
                {
                    throw new ArgumentException(nameof(manuscript), "There is an error with manuscript CREATE.");
                }

                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ManuscriptCreateViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteManuscript(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                bool isValid = await this.manuscriptRepository.Delete(id);

                if (!isValid)
                {
                    throw new ArgumentException("There is nothing to DELETE.");
                }

                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<bool>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ManuscriptEditViewModel>> Edit(int id, ManuscriptEditViewModel model)
        {
            var response = new BaseResponse<ManuscriptEditViewModel>();

            try
            {
                var manuscript = this.manuscriptRepository
                    .GetEntities()
                    .Where(x => x.Id ==  id)
                    .SingleOrDefault();

                if (manuscript == null)
                {
                    throw new ArgumentNullException(nameof(manuscript), "There is no manuscript with such id.");
                }

                manuscript.Title = model.Title;
                manuscript.TitleImage = await model.TitlePicture.GetBytes();
                manuscript.Author = model.Author;
                manuscript.Publisher = model.Publisher;
                manuscript.UpdateDate = DateTime.Now;
                manuscript.Translator = model.Translator;
                manuscript.OriginCountry = model.OriginCountry;
                manuscript.Type = model.Type;
                manuscript.Description = model.Description;
                manuscript.IsRequireLegalAge = model.IsRequireLegalAge;
                manuscript.Genres = model.Genres.Select(x => new GenreHolder() { Genre = x }).ToList();
                manuscript.Content = model.Content;
                manuscript.ApprovalStatus = ApprovalStatus.InProgress;
                manuscript.ApprovalDate = null;

                bool isValid = await this.manuscriptRepository.Update(manuscript);

                if (!isValid)
                {
                    throw new ArgumentException("There is an error with manuscript UPDATE.");
                }

                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ManuscriptEditViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<ManuscriptDetailsViewModel> GetManuscriptDetailsById(int id)
        {
            var response = new BaseResponse<ManuscriptDetailsViewModel>();

            try
            {
                var manuscript = this.manuscriptRepository
                    .GetEntities()
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                if (manuscript == null)
                {
                    throw new ArgumentNullException(nameof(manuscript), "There is no manuscript with such id.");
                }

                ManuscriptDetailsViewModel model = new ManuscriptDetailsViewModel()
                {
                    Id = id,
                    Title = manuscript.Title,
                    TitleImage = manuscript.TitleImage,
                    Author = manuscript.Author,
                    UpdateDate = manuscript.UpdateDate,
                    UploadDate = manuscript.UploadDate,
                    Publisher = manuscript.Publisher,
                    Translator = manuscript.Translator,
                    OriginCountry = manuscript.OriginCountry,
                    Type = manuscript.Type,
                    Description = manuscript.Description,
                    IsRequireLegalAge = manuscript.IsRequireLegalAge,
                    ApprovalStatus = manuscript.ApprovalStatus,
                    GenresString = string.Join(", ", manuscript.Genres.Select(x => x.Genre).ToArray()),
                    Content = manuscript.Content,
                };

                response.Data = model;
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ManuscriptDetailsViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<ManuscriptEditViewModel> GetManuscriptForEditById(int id)
        {
            var response = new BaseResponse<ManuscriptEditViewModel>();

            try
            {
                var manuscript = this.manuscriptRepository
                    .GetEntities()
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                if (manuscript == null)
                {
                    throw new ArgumentNullException(nameof(manuscript), "There is no manuscript with such id.");
                }

                ManuscriptEditViewModel model = new ManuscriptEditViewModel()
                {
                    Title = manuscript.Title,
                    TitleImage = manuscript.TitleImage,
                    Author = manuscript.Author,
                    Publisher = manuscript.Publisher,
                    Translator = manuscript.Translator,
                    OriginCountry = manuscript.OriginCountry,
                    Type = manuscript.Type,
                    Description = manuscript.Description,
                    IsRequireLegalAge = manuscript.IsRequireLegalAge,
                    Genres = manuscript.Genres.Select(x => x.Genre).ToArray(),
                    Content = manuscript.Content,
                };

                List<SelectListItem> genres = new List<SelectListItem>();
                foreach(var genre in Enum.GetValues<Genre>())
                {
                    SelectListItem item = new SelectListItem()
                    {
                        Text = genre.ToString(),
                        Value = genre.ToString(),
                        Selected = model.Genres.Contains(genre)
                    };

                    genres.Add(item);
                }

                model.GenresList = genres;

                response.Data = model;
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ManuscriptEditViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<IEnumerable<Manuscript>> GetManuscripts()
        {
            var response = new BaseResponse<IEnumerable<Manuscript>>();

            try
            {
                var manuscripts = this.manuscriptRepository.GetEntities();

                response.Data = manuscripts;
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<Manuscript>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<IList<ManuscriptManagementBasicViewModel>> GetManuscriptsForBasicManagement(string publisher)
        {
            var response = new BaseResponse<IList<ManuscriptManagementBasicViewModel>>();

            try
            {
                var manuscripts = this.manuscriptRepository.GetEntities();

                List<ManuscriptManagementBasicViewModel> managementViewModels = manuscripts
                    .Where(x => x.Publisher == publisher)
                    .Select(x => new ManuscriptManagementBasicViewModel 
                    { 
                        Id = x.Id,
                        ApprovalDate = x.ApprovalDate,
                        Title = x.Title,
                        ApprovalStatus = x.ApprovalStatus,
                        Type = x.Type,
                        UploadDate = x.UploadDate
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ManuscriptManagementBasicViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ManuscriptManagementBasicViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>> GetRequestedManuscriptsForAdvancedManagement()
        {
            var response = new BaseResponse<IList<ManuscriptManagementAdvancedViewModel>>();

            try
            {
                var manuscripts = this.manuscriptRepository.GetEntities();

                List<ManuscriptManagementAdvancedViewModel> managementViewModels = manuscripts
                    .Where(x => x.ApprovalStatus == ApprovalStatus.InProgress)
                    .Select(x => new ManuscriptManagementAdvancedViewModel
                    {
                        Id = x.Id,
                        Publisher = x.Publisher,
                        Title = x.Title,
                        Type = x.Type,
                        UploadDate = x.UploadDate
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ManuscriptManagementAdvancedViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ManuscriptManagementAdvancedViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>> GetApprovedManuscriptsForAdvancedManagement()
        {
            var response = new BaseResponse<IList<ManuscriptManagementAdvancedViewModel>>();

            try
            {
                var manuscripts = this.manuscriptRepository.GetEntities();

                List<ManuscriptManagementAdvancedViewModel> managementViewModels = manuscripts
                    .Where(x => x.ApprovalStatus == ApprovalStatus.Approved)
                    .Select(x => new ManuscriptManagementAdvancedViewModel
                    {
                        Id = x.Id,
                        ApprovalDate = x.ApprovalDate,
                        Publisher = x.Publisher,
                        Title = x.Title,
                        Type = x.Type,
                        UploadDate = x.UploadDate
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ManuscriptManagementAdvancedViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ManuscriptManagementAdvancedViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>> GetRejectedManuscriptsForAdvancedManagement()
        {
            var response = new BaseResponse<IList<ManuscriptManagementAdvancedViewModel>>();

            try
            {
                var manuscripts = this.manuscriptRepository.GetEntities();

                List<ManuscriptManagementAdvancedViewModel> managementViewModels = manuscripts
                    .Where(x => x.ApprovalStatus == ApprovalStatus.Rejected)
                    .Select(x => new ManuscriptManagementAdvancedViewModel
                    {
                        Id = x.Id,
                        ApprovalDate = x.ApprovalDate,
                        Publisher = x.Publisher,
                        Title = x.Title,
                        Type = x.Type,
                        UploadDate = x.UploadDate
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ManuscriptManagementAdvancedViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ManuscriptManagementAdvancedViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> SetApprovalStatus(int id, ApprovalStatus status)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var manuscript = this.manuscriptRepository
                    .GetEntities()
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                if (manuscript == null)
                {
                    throw new ArgumentNullException(nameof(manuscript), "There is no manuscript with such id.");
                }

                if (status == ApprovalStatus.Approved)
                {
                    manuscript.ApprovalDate = DateTime.Now;
                }
                else if (status == ApprovalStatus.Rejected)
                {
                    manuscript.ApprovalDate = null;
                }
                manuscript.ApprovalStatus = status;

                bool isValid = await this.manuscriptRepository.Update(manuscript);

                if (!isValid)
                {
                    throw new ArgumentException(nameof(manuscript), "There is an error with UPDATE review after setting ApprovalStatus.");
                }

                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<bool>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }
    }
}
