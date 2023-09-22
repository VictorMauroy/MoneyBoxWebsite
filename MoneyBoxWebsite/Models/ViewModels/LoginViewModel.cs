using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models.ViewModels
{
    public class LoginViewModel
    {
        public required string Username { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }

        
        public bool IsPersistent { get; set; } = false;
    }
}
