using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task CreateAsync(Product product);
        Task DisableAsync(Guid id);
        Task SaveChangesAsync();
    }
}
