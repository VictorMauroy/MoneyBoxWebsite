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

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _ctx.Orders.FirstAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _ctx.Orders.ToListAsync();
        }

        public async void CreateOrderAsync(Order order)
        {
            await _ctx.Orders.AddAsync(order);
            SaveChangesAsync();
        }

        public async void DeleteOrderAsync(Guid id)
        {
            Order orderToRemove = await _ctx.Orders.FirstAsync(o => o.OrderId == id);
            _ctx.Orders.Remove(orderToRemove);
            SaveChangesAsync();
        }

        public void UpdateOrderAsync(Order order)
        {
            _ctx.Orders.Update(order);
            SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
