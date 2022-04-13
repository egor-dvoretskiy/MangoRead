using MangoRead.DAL.Interfaces;
using MangoRead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.DAL.Repositories
{
    public class ManuscriptRepository : IManuscriptRepository
    {
        private readonly ApplicationDbContext _context;

        public ManuscriptRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Manuscript entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Manuscript entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manuscript>> GetEntities()
        {
            return await this._context.Manuscripts.Include(x => x.Content).ThenInclude(x => x.Pages).ToListAsync();
        }

        public Task<Manuscript> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Manuscript> Update(Manuscript entity)
        {
            throw new NotImplementedException();
        }
    }
}
