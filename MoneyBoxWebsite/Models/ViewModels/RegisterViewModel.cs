﻿using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        public required string Username { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname must be between 2 and 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Firstname can only contain letters and spaces.")]
        public required string FirstName { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 and 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Lastname can only contain letters and spaces.")]
        public required string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)] //[EmailAddress] is an alternative.
        public required string Email { get; set; }

        [DataType(DataType.Password)] //Hide every character entered by the user.
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W).+$", 
            ErrorMessage = "The password must contains at least one number, one lowercase and one uppercase letter and lastly, one non-alphanumeric character.")] 
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] //Allow to compare two field
        public required string ConfirmedPassword { get; set; }

        // Numéro de rue
        public int StreetNumber { get; set; } = 0;

        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Street name must be between 2 and 100 characters.")]
        public required string StreetName { get; set; }
        
        public int PostalCode { get; set; } = 0;

        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 50 characters.")]
        public required string City { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Country name must be between 2 and 50 characters.")]
        public required string Country { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
