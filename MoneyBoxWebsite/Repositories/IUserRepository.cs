namespace MoneyBoxWebsite.Repositories
{
    public interface IUserRepository
    {
        /* On-going work, could be used later */

        void ChangePasswordAsync(string newPassword);
        void ChangeUsernameAsync(string newUsername);
        void ChangeAddressAsync(string newAddress);

        void CreateUserAsync();
        void DisableUserAsync();
        void SaveChangesAsync();
    }
}
