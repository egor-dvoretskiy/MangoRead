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
                    response.Descripton = "There is an error with creation.";
                    response.Status = Domain.Enums.ResponseStatus.EmptyEntity;
                    return response;
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
                    response.Descripton = "There is nothing to delete.";
                    response.Status = Domain.Enums.ResponseStatus.EmptyEntity;
                    return response;
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
                var manuscript = await this.manuscriptRepository.GetEntityById(id);

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


                bool isValid = await this.manuscriptRepository.Update(manuscript);

                if (!isValid)
                {
                    response.Descripton = "There is no manuscript with such id.";
                    response.Status = Domain.Enums.ResponseStatus.EmptyEntity;
                    return response;
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

        public async Task<IBaseResponse<ManuscriptDetailsViewModel>> GetManuscriptDetailsById(int id)
        {
            var response = new BaseResponse<ManuscriptDetailsViewModel>();

            try
            {
                var manuscript = await this.manuscriptRepository.GetEntityById(id);

                if (manuscript == null)
                {
                    response.Descripton = "There is no manuscript with such id to display details.";
                    response.Status = Domain.Enums.ResponseStatus.EmptyEntity;
                    return response;
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

        public async Task<IBaseResponse<ManuscriptEditViewModel>> GetManuscriptForEditById(int id)
        {
            var response = new BaseResponse<ManuscriptEditViewModel>();

            try
            {
                var manuscript = await this.manuscriptRepository.GetEntityById(id);

                if (manuscript == null)
                {
                    response.Descripton = "There is no manuscript with such id.";
                    response.Status = Domain.Enums.ResponseStatus.EmptyEntity;
                    return response;
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

        public async Task<IBaseResponse<IEnumerable<Manuscript>>> GetManuscripts()
        {
            var response = new BaseResponse<IEnumerable<Manuscript>>();

            try
            {
                var manuscripts = await this.manuscriptRepository.GetEntities();

                if (manuscripts.Count == 0)
                {
                    response.Descripton = "Found 0 elements.";
                    response.Status = Domain.Enums.ResponseStatus.EmptyEntity;
                    return response;
                }

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
    }
}
