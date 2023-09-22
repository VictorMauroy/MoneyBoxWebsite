using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        public required string Username { get; set; }
        
        [DataType(DataType.Text)]
        public required string FirstName { get; set; }
        
        [DataType(DataType.Text)]
        public required string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)] //[EmailAddress] is an alternative.
        public required string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)] //Hide every character entered by the user.
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] //Allow to compare two field
        public required string ConfirmedPassword { get; set; }

        [DataType(DataType.Text)]
        public required string Address { get; set; }

        [DataType(DataType.PhoneNumber)] //It's pointless, doesn't check anything
        public required string PhoneNumber { get; set; }
    }
}
