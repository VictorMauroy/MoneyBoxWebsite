using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IProductRepository
    {
        // PRODUCTS
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DisableAsync(Guid id);

        // PRODUCT GROUPS
        Task<IEnumerable<ProductGroup>> GetAllGroupsAsync();
        Task<ProductGroup?> GetGroupByIdAsync(Guid id);
        Task CreateGroupAsync(ProductGroup group);
        Task UpdateGroupAsync(ProductGroup group);
        Task RemoveGroupAsync(Guid id);

        // SAVE
        Task SaveChangesAsync();
    }
}
