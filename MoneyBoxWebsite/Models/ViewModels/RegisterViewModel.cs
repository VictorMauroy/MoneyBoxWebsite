using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        public required string Username { get; set; }
        
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Enter only letters.")]
        public required string FirstName { get; set; }
        
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Enter only letters.")]
        public required string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)] //[EmailAddress] is an alternative.
        public required string Email { get; set; }

        [DataType(DataType.Password)] //Hide every character entered by the user.
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=(.*\d))(?=(.*[A-Z]))(?=(.*[a-z]))(?=(.*[^A-Za-z0-9]))(?=.*(.)(.*\1))", 
            ErrorMessage = "The password must contains at least one number, one lowercase and one uppercase letter and lastly, one non-alphanumeric character.")] 
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] //Allow to compare two field
        public required string ConfirmedPassword { get; set; }

        [DataType(DataType.Text)]
        public required string Address { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
