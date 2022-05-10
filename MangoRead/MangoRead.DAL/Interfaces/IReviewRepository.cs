using MangoRead.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.DAL.Interfaces
{
    public interface IReviewRepository : IBaseRepository<ManuscriptReview>
    {
        Task<bool> Update(Manuscript entity);
    }
}
