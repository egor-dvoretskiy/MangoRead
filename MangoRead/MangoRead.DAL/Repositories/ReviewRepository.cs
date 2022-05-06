using MangoRead.DAL.Interfaces;
using MangoRead.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ManuscriptReview entity)
        {
            try
            {
                await this._context.Reviews.AddAsync(entity);
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var review = await this._context.Reviews
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (review != null)
                {
                    this._context.Reviews.Remove(review);
                    await this._context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {
            }

            return false;
        }

        public async Task<List<ManuscriptReview>> GetEntities()
        {
            return await this._context.Reviews.ToListAsync();
        }

        public async Task<ManuscriptReview?> GetEntityById(int id)
        {
            return await this._context.Reviews
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Update(ManuscriptReview entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                this._context.Reviews.Update(entity);
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                _ = exception;
                return false;
            }
        }
    }
}
