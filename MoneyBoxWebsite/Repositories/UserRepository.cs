using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Data;
using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _ctx;
        private UserManager<Client> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserRepository(ApplicationDbContext ctx, UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _ctx.Clients.FirstAsync(c => c.Id == id.ToString());
        }

        public async Task ChangeAddressAsync(Guid id, string newAddress)
        {
            Client client = await GetClientById(id);
            client.Address = newAddress;
            await SaveChangesAsync();
        }

        public async Task ChangePasswordAsync(Guid id, string currentPassword, string newPassword)
        {
            Client client = await GetClientById(id);
            await _userManager.ChangePasswordAsync(client, currentPassword, newPassword);
        }

        public async Task ChangeUsernameAsync(Guid id, string newUsername)
        {
            Client client = await GetClientById(id);
            client.UserName = newUsername;
            await SaveChangesAsync();
        }

        public async Task ChangeUserActivationAsync(Guid id, bool activeState)
        {
            Client clientToDisable = await GetClientById(id);
            clientToDisable.AccountEnabled = activeState;
            await SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
