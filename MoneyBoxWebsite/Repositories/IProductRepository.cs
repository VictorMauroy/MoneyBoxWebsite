using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        void CreateProductAsync(Product product);
        void DisableProductAsync(Guid id);
        void SaveChangesAsync();
    }
}
