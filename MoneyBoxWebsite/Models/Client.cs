using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MoneyBoxWebsite.Models
{
    public class Client : IdentityUser
    {
        [Column("name")]
        public required string Name { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("address")]
        public required string Address { get; set; }

        [Column("current_theme")]
        public required string CurrentTheme { get; set; } //Will use an enum.

        [Column("enabled")]
        public bool AccountEnabled { get; set; } = true;


        /*      RELATIONS       */

        [Column("reviews")]
        public List<Review> Reviews { get; set; } = new List<Review>();

        [Column("orders")]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
