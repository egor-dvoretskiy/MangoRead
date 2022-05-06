using MangoRead.Domain.Enums;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.Models;
using MangoRead.Domain.ViewModels.Account.Manage.ReviewManagement;
using MangoRead.Domain.ViewModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Service.Interfaces
{
    public interface IReviewService
    {
        Task<IBaseResponse<IEnumerable<ReviewIndexViewModel>>> GetReviews();

        Task<IBaseResponse<IList<ReviewManagementBasicViewModel>>> GetManuscriptsForBasicManagement(string publisher);

        Task<IBaseResponse<IList<ReviewManagementAdvancedViewModel>>> GetRequestedReviewsForAdvancedManagement();

        Task<IBaseResponse<IList<ReviewManagementAdvancedViewModel>>> GetApprovedReviewsForAdvancedManagement();

        Task<IBaseResponse<IList<ReviewManagementAdvancedViewModel>>> GetRejectedReviewsForAdvancedManagement();

        Task<IBaseResponse<ReviewEditViewModel>> GetReviewForEditById(int id);

        Task<IBaseResponse<ReviewDetailsViewModel>> GetReviewDetailsById(int id);

        Task<IBaseResponse<ReviewCreateViewModel>> AddReview(ReviewCreateViewModel model);

        Task<IBaseResponse<bool>> DeleteReview(int id);

        Task<IBaseResponse<ReviewEditViewModel>> Edit(int id, ReviewEditViewModel model);

        Task<IBaseResponse<bool>> SetApprovalStatus(int id, ApprovalStatus status);
    }
}
