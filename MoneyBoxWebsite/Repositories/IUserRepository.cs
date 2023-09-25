using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public interface IUserRepository
    {
        /* On-going work, could be used later */
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientById(Guid id);

        Task ChangePasswordAsync(Guid id, string currentPassword, string newPassword);
        Task ChangeUsernameAsync(Guid id, string newUsername);
        Task ChangeAddressAsync(Guid id, string newAddress);

        Task ChangeUserActivationAsync(Guid id, bool activeState);
        Task SaveChangesAsync();
    }
}
