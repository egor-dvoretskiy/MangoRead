using MangoRead.DAL.Interfaces;
using MangoRead.Domain.Entities;
using MangoRead.Domain.Interfaces;
using MangoRead.Domain.Responses;
using MangoRead.Domain.ViewModels;
using MangoRead.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Service.Implementations
{
    public class ManuscriptService : IManuscriptService
    {
        private readonly IManuscriptRepository manuscriptRepository;

        public ManuscriptService(DAL.Interfaces.IManuscriptRepository manuscriptRepository)
        {
            this.manuscriptRepository = manuscriptRepository;
        }

        public Task<IBaseResponse<ManuscriptViewModel>> AddManuscript(ManuscriptViewModel carViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> DeleteManuscript(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Manuscript>> Edit(int id, ManuscriptViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Manuscript>> GetManuscriptById(int id)
        {
            throw new NotImplementedException();
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
