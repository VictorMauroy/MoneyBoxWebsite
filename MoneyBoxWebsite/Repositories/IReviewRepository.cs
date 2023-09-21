using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(Guid id);
        Task CreateAsync(Review review);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
