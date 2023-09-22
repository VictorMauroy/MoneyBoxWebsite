using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Data;
using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _ctx;

        public OrderRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _ctx.Orders.FirstAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _ctx.Orders.ToListAsync();
        }

        public async Task CreateAsync(Order order)
        {
            await _ctx.Orders.AddAsync(order);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Order orderToRemove = await _ctx.Orders.FirstAsync(o => o.OrderId == id);
            _ctx.Orders.Remove(orderToRemove);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
