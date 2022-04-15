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

        public async Task<bool> Create(Manuscript entity)
        {
            try
            {
                await this._context.Manuscripts.AddAsync(entity);
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                _ = exception;
                return false;
            }
        }

        public Task<bool> Delete(Manuscript entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manuscript>> GetEntities()
        {
            return await this._context.Manuscripts.Include(x => x.Content).ThenInclude(x => x.Pages).ToListAsync();
        }

        public async Task<Manuscript?> GetEntityById(int id)
        {
            return await this._context.Manuscripts.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public Task<Manuscript> Update(Manuscript entity)
        {
            throw new NotImplementedException();
        }
    }
}
