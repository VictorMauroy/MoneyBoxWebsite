using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        void CreateOrderAsync(Order order);
        void DeleteOrderAsync(Guid id);
        void SaveChangesAsync();
    }
}
