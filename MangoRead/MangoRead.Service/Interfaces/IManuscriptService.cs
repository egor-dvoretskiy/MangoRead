using MangoRead.Domain.Models;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangoRead.Domain.ViewModels.Manuscript;

namespace MangoRead.Service.Interfaces
{
    public interface IManuscriptService
    {
        Task<IBaseResponse<IEnumerable<Manuscript>>> GetManuscripts();

        Task<IBaseResponse<ManuscriptEditViewModel>> GetManuscriptViewModelForEditById(int id);

        Task<IBaseResponse<ManuscriptDetailsViewModel>> GetManuscriptDetailsById(int id);

        Task<IBaseResponse<ManuscriptCreateViewModel>> AddManuscript(ManuscriptCreateViewModel model);

        Task<IBaseResponse<bool>> DeleteManuscript(int id);

        Task<IBaseResponse<ManuscriptEditViewModel>> Edit(int id, ManuscriptEditViewModel model);
    }
}
