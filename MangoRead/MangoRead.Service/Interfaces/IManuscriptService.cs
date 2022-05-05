using MangoRead.Domain.Models;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangoRead.Domain.ViewModels.Manuscript;
using MangoRead.Domain.ViewModels.Account.Manage;
using MangoRead.Domain.Enums;

namespace MangoRead.Service.Interfaces
{
    public interface IManuscriptService
    {
        Task<IBaseResponse<IEnumerable<Manuscript>>> GetManuscripts();

        Task<IBaseResponse<IList<ManuscriptManagementBasicViewModel>>> GetManuscriptsForBasicManagement(string publisher);

        Task<IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>>> GetRequestedManuscriptsForAdvancedManagement();

        Task<IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>>> GetApprovedManuscriptsForAdvancedManagement();

        Task<IBaseResponse<ManuscriptEditViewModel>> GetManuscriptForEditById(int id);

        Task<IBaseResponse<ManuscriptDetailsViewModel>> GetManuscriptDetailsById(int id);

        Task<IBaseResponse<ManuscriptCreateViewModel>> AddManuscript(ManuscriptCreateViewModel model);

        Task<IBaseResponse<bool>> DeleteManuscript(int id);

        Task<IBaseResponse<ManuscriptEditViewModel>> Edit(int id, ManuscriptEditViewModel model);

        Task<IBaseResponse<bool>> SetApprovalStatus(int id, ApprovalStatus status);
    }
}
