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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _ctx.Products.FirstAsync(p => p.ProductId == id);
        }
        
        public async void CreateAsync(Product product)
        {
            await _ctx.Products.AddAsync(product);
            SaveChangesAsync();
        }

        public async void DisableAsync(Guid id)
        {
            Product productToDisable = await GetByIdAsync(id);
            productToDisable.Visibility = false;
            SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
