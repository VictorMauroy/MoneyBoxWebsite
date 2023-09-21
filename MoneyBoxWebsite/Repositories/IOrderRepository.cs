using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(Guid id);
        Task CreateAsync(Order order);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
