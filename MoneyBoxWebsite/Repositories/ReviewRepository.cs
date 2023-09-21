using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext _ctx;
        public ReviewRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _ctx.Reviews.FirstAsync(r => r.ReviewId == id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _ctx.Reviews.ToListAsync();
        }

        public async Task CreateAsync(Review review)
        {
            await _ctx.Reviews.AddAsync(review);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Review reviewToRemove = await GetByIdAsync(id);
            _ctx.Reviews.Remove(reviewToRemove);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
