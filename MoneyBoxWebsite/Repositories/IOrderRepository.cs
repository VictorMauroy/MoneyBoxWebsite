using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(Guid id);
        void CreateAsync(Order order);
        void DeleteAsync(Guid id);
        void SaveChangesAsync();
    }
}
