using MangoRead.DAL.Interfaces;
using MangoRead.Domain.Enums;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.Models;
using MangoRead.Domain.Responses;
using MangoRead.Domain.ViewModels.Account.Manage.ReviewManagement;
using MangoRead.Domain.ViewModels.Review;
using MangoRead.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Service.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IBaseResponse<ReviewCreateViewModel>> AddReview(ReviewCreateViewModel model)
        {
            var response = new BaseResponse<ReviewCreateViewModel>();

            try
            {
                var review = new ManuscriptReview()
                {
                    AuthorUserName = model.AuthorUserName,
                    Content = model.Content,
                    CouplingGuid = model.CouplingGuid,
                    UploadDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Rating = model.Rating,
                };

                bool isValid = await this._reviewRepository.Create(review);

                if (!isValid)
                {
                    throw new ArgumentException(nameof(review) + ", There is an error with review CREATE.");
                }

                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ReviewCreateViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteReview(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                bool isValid = await this._reviewRepository.Delete(id);

                if (!isValid)
                {
                    throw new ArgumentException("There is no such review to DELETE in db.");
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

        public async Task<IBaseResponse<ReviewEditViewModel>> Edit(int id, ReviewEditViewModel model)
        {
            var response = new BaseResponse<ReviewEditViewModel>();

            try
            {
                var review = await this._reviewRepository.GetEntityById(id);

                if (review == null)
                {
                    throw new ArgumentNullException(nameof(review), "There is no review with such id.");
                }

                review.Content = model.Content;
                review.UpdateDate = DateTime.Now;
                review.Rating = model.Rating;

                bool isValid = await this._reviewRepository.Update(review);

                if (!isValid)
                {
                    throw new ArgumentException("There is a problem with UPDATE review.");
                }

                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ReviewEditViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ReviewDetailsViewModel>> GetReviewDetailsById(int id)
        {
            var response = new BaseResponse<ReviewDetailsViewModel>();

            try
            {
                var review = await this._reviewRepository.GetEntityById(id);

                if (review == null)
                {
                    throw new ArgumentNullException(nameof(review), "There is no review with such id to display DETAILS.");
                }

                var model = new ReviewDetailsViewModel()
                {
                    Id = review.Id,
                    Rating = review.Rating,
                    Content = review.Content,
                    CouplingGuid = review.CouplingGuid,
                    AuthorUserName = review.AuthorUserName,
                    UpdateDate = review.UpdateDate,
                    UploadDate = review.UploadDate,
                };

                response.Data = model;
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ReviewDetailsViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ReviewEditViewModel>> GetReviewForEditById(int id)
        {
            var response = new BaseResponse<ReviewEditViewModel>();

            try
            {
                var review = await this._reviewRepository.GetEntityById(id);

                if (review == null)
                {
                    throw new ArgumentNullException(nameof(review), "There is no review with such id.");
                }

                ReviewEditViewModel model = new ReviewEditViewModel()
                {
                    Rating = review.Rating,
                    Content = review.Content,
                };

                response.Data = model;
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<ReviewEditViewModel>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<ReviewIndexViewModel>>> GetReviews()
        {
            var response = new BaseResponse<IEnumerable<ReviewIndexViewModel>>();

            try
            {
                var reviewsDb = await this._reviewRepository
                    .GetEntities();

                var reviewsIndex = reviewsDb
                    .Select(x => new ReviewIndexViewModel()
                    {
                        Id = x.Id,
                        Rating = x.Rating,
                        Content = x.Content,
                        CouplingGuid = x.CouplingGuid,
                        AuthorUserName = x.AuthorUserName,
                        UpdateDate = x.UpdateDate,
                        UploadDate = x.UploadDate,
                    })
                    .ToList();

                response.Data = reviewsIndex;
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<ReviewIndexViewModel>>()
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
                var review = await this._reviewRepository.GetEntityById(id);

                if (review == null)
                {
                    throw new ArgumentNullException(nameof(review), "There is no review with such id.");
                }

                if (status == ApprovalStatus.Approved)
                {
                    review.ApprovalDate = DateTime.Now;
                }
                else if (status == ApprovalStatus.Rejected)
                {
                    review.ApprovalDate = null;
                }

                review.ApprovalStatus = status;

                bool isValid = await this._reviewRepository.Update(review);

                if (!isValid)
                {
                    throw new ArgumentException("There is an error with UPDATE review after setting ApprovalStatus.");
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

        public async Task<IBaseResponse<IList<ReviewManagementBasicViewModel>>> GetManuscriptsForBasicManagement(string publisher)
        {
            var response = new BaseResponse<IList<ReviewManagementBasicViewModel>>();

            try
            {
                var manuscripts = await this._reviewRepository.GetEntities();

                List<ReviewManagementBasicViewModel> managementViewModels = manuscripts
                    .Where(x => x.AuthorUserName == publisher)
                    .Select(x => new ReviewManagementBasicViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ApprovalStatus = x.ApprovalStatus,
                        Rating = x.Rating,
                        UpdateDate = x.UpdateDate
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ReviewManagementBasicViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ReviewManagementBasicViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IList<ReviewManagementAdvancedViewModel>>> GetRequestedReviewsForAdvancedManagement()
        {
            var response = new BaseResponse<IList<ReviewManagementAdvancedViewModel>>();

            try
            {
                var reviews = await this._reviewRepository.GetEntities();

                List<ReviewManagementAdvancedViewModel> managementViewModels = reviews
                    .Where(x => x.ApprovalStatus == ApprovalStatus.InProgress)
                    .Select(x => new ReviewManagementAdvancedViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        UploadDate = x.UploadDate,
                        UpdateDate = x.UpdateDate,
                        ApprovalDate = x.ApprovalDate,
                        AuthorUserName = x.AuthorUserName,
                        Rating = x.Rating
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ReviewManagementAdvancedViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ReviewManagementAdvancedViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IList<ReviewManagementAdvancedViewModel>>> GetApprovedReviewsForAdvancedManagement()
        {
            var response = new BaseResponse<IList<ReviewManagementAdvancedViewModel>>();

            try
            {
                var reviews = await this._reviewRepository.GetEntities();

                List<ReviewManagementAdvancedViewModel> managementViewModels = reviews
                    .Where(x => x.ApprovalStatus == ApprovalStatus.Approved)
                    .Select(x => new ReviewManagementAdvancedViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        UploadDate = x.UploadDate,
                        UpdateDate = x.UpdateDate,
                        ApprovalDate = x.ApprovalDate,
                        AuthorUserName = x.AuthorUserName,
                        Rating = x.Rating
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ReviewManagementAdvancedViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ReviewManagementAdvancedViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IList<ReviewManagementAdvancedViewModel>>> GetRejectedReviewsForAdvancedManagement()
        {
            var response = new BaseResponse<IList<ReviewManagementAdvancedViewModel>>();

            try
            {
                var reviews = await this._reviewRepository.GetEntities();

                List<ReviewManagementAdvancedViewModel> managementViewModels = reviews
                    .Where(x => x.ApprovalStatus == ApprovalStatus.Rejected)
                    .Select(x => new ReviewManagementAdvancedViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        UploadDate = x.UploadDate,
                        UpdateDate = x.UpdateDate,
                        ApprovalDate = x.ApprovalDate,
                        AuthorUserName = x.AuthorUserName,
                        Rating = x.Rating
                    })
                    .ToList();

                response.Data = managementViewModels ?? new List<ReviewManagementAdvancedViewModel>();
                response.Status = Domain.Enums.ResponseStatus.OK;
                return response;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IList<ReviewManagementAdvancedViewModel>>()
                {
                    Descripton = exception.Message,
                    Status = Domain.Enums.ResponseStatus.InternalServerError
                };
            }
        }
    }
}
