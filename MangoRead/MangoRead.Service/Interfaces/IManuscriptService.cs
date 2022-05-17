﻿using MangoRead.Domain.Models;
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
        IBaseResponse<IEnumerable<Manuscript>> GetManuscripts();

        IBaseResponse<IList<ManuscriptManagementBasicViewModel>> GetManuscriptsForBasicManagement(string publisher);

        IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>> GetRequestedManuscriptsForAdvancedManagement();

        IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>> GetApprovedManuscriptsForAdvancedManagement();

        IBaseResponse<IList<ManuscriptManagementAdvancedViewModel>> GetRejectedManuscriptsForAdvancedManagement();

        IBaseResponse<ManuscriptEditViewModel> GetManuscriptForEditById(int id);

        IBaseResponse<ManuscriptDetailsViewModel> GetManuscriptDetailsById(int id);

        IBaseResponse<ManuscriptContentViewModel> GetManuscriptContent(int id);

        Task<IBaseResponse<bool>> UploadRequestedFile(ManuscriptContentViewModel model);

        Task<IBaseResponse<ManuscriptCreateViewModel>> AddManuscript(ManuscriptCreateViewModel model);

        Task<IBaseResponse<bool>> DeleteManuscript(int id);

        Task<IBaseResponse<ManuscriptEditViewModel>> Edit(int id, ManuscriptEditViewModel model);

        Task<IBaseResponse<bool>> SetApprovalStatus(int id, ApprovalStatus status);
    }
}
