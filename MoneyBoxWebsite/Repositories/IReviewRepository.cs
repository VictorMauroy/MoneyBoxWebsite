using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(Guid id);
        void CreateAsync(Review review);
        void DeleteAsync(Guid id);
        void SaveChangesAsync();
    }
}
