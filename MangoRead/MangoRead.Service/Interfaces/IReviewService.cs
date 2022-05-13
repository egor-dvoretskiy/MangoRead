using MangoRead.Domain.Enums;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.Models;
using MangoRead.Domain.ViewModels.Account.Manage.ReviewManagement;
using MangoRead.Domain.ViewModels.Home;
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
        IBaseResponse<IEnumerable<ReviewIndexViewModel>> GetReviews();

        IBaseResponse<IList<IndexReviewViewModel>> GetPosingReviews();

        IBaseResponse<IList<ReviewManagementBasicViewModel>> GetManuscriptsForBasicManagement(string publisher);

        IBaseResponse<IList<ReviewManagementAdvancedViewModel>> GetRequestedReviewsForAdvancedManagement();

        IBaseResponse<IList<ReviewManagementAdvancedViewModel>> GetApprovedReviewsForAdvancedManagement();

        IBaseResponse<IList<ReviewManagementAdvancedViewModel>> GetRejectedReviewsForAdvancedManagement();

        IBaseResponse<ReviewEditViewModel> GetReviewForEditById(int id);

        IBaseResponse<ReviewDetailsViewModel> GetReviewDetailsById(int id);

        Task<IBaseResponse<ReviewCreateViewModel>> AddReview(ReviewCreateViewModel model);

        Task<IBaseResponse<bool>> DeleteReview(int id);

        Task<IBaseResponse<ReviewEditViewModel>> Edit(int id, ReviewEditViewModel model);

        Task<IBaseResponse<bool>> SetApprovalStatus(int id, ApprovalStatus status);
    }
}
