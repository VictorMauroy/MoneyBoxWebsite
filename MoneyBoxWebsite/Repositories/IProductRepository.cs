using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        void CreateAsync(Product product);
        void DisableAsync(Guid id);
        void SaveChangesAsync();
    }
}
