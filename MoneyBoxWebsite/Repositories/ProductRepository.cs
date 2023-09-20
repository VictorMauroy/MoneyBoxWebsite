using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _ctx;

        public ProductRepository(ApplicationDbContext ctx) 
        {
            this._ctx = ctx;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _ctx.Products.FirstAsync(p => p.ProductId == id);
        }
        
        public async void CreateProductAsync(Product product)
        {
            await _ctx.Products.AddAsync(product);
            SaveChangesAsync();
        }

        public async void DisableProductAsync(Guid id)
        {
            Product productToDisable = await GetProductByIdAsync(id);
            productToDisable.Visibility = false;
            SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
