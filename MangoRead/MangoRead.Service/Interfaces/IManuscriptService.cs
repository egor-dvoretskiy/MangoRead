﻿using MangoRead.Domain.Models;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Service.Interfaces
{
    public interface IManuscriptService
    {
        Task<IBaseResponse<IEnumerable<Manuscript>>> GetManuscripts();

        Task<IBaseResponse<ManuscriptViewModel>> GetManuscriptViewModelById(int id);

        Task<IBaseResponse<ManuscriptViewModel>> AddManuscript(ManuscriptViewModel carViewModel);

        Task<IBaseResponse<bool>> DeleteManuscript(int id);

        Task<IBaseResponse<ManuscriptViewModel>> Edit(int id, ManuscriptViewModel model);
    }
}
