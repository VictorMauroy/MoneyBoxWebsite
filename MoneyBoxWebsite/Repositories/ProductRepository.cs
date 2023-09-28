using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Data;
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

        #region Products
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _ctx.Products.FirstAsync(p => p.ProductId == id);
        }
        
        public async Task CreateAsync(Product product)
        {
            await _ctx.Products.AddAsync(product);
            await SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            _ctx.Products.Update(product);
            await SaveChangesAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            Product productToDisable = await GetByIdAsync(id);
            productToDisable.Visibility = false;
            await SaveChangesAsync();
        }

        public async Task EnableAsync(Guid id)
        {
            Product productToDisable = await GetByIdAsync(id);
            productToDisable.Visibility = true;
            await SaveChangesAsync();
        }
        #endregion

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        #region Product Groups
        public async Task<ProductGroup?> GetGroupByIdAsync(Guid id)
        {
            return await _ctx.ProductGroups.FirstOrDefaultAsync(g => g.ProductGroupId == id);
        }

        public async Task<IEnumerable<ProductGroup>> GetAllGroupsAsync()
        {
            return await _ctx.ProductGroups.ToListAsync();
        }

        public async Task CreateGroupAsync(ProductGroup group)
        {
            await _ctx.ProductGroups.AddAsync(group);
            await SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(ProductGroup group)
        {
            _ctx.ProductGroups.Update(group);
            await SaveChangesAsync();
        }

        public async Task RemoveGroupAsync(Guid id)
        {
            ProductGroup? groupToRemove = await GetGroupByIdAsync(id);

            if (groupToRemove != null)
            {
                // Break links
                foreach (Product product in groupToRemove.GroupedProducts)
                {
                    product.ProductGroups.Remove(groupToRemove);
                }

                _ctx.Remove(groupToRemove);
                await SaveChangesAsync();
            }
        }
        #endregion
    }
}
