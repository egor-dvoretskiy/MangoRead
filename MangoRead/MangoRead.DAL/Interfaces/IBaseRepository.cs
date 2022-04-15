using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<T?> GetEntityById(int id);

        Task<List<T>> GetEntities();

        Task<T> Update(T entity);

        Task<bool> Delete(T entity);
    }
}
