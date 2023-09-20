using Microsoft.EntityFrameworkCore;
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

        public async void CreateAsync(Order order)
        {
            await _ctx.Orders.AddAsync(order);
            SaveChangesAsync();
        }

        public async void DeleteAsync(Guid id)
        {
            Order orderToRemove = await _ctx.Orders.FirstAsync(o => o.OrderId == id);
            _ctx.Orders.Remove(orderToRemove);
            SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
