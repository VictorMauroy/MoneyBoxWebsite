using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class Client
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("address")]
        public required string Address { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("current_theme")]
        public required string CurrentTheme { get; set; } //Will use an enum.

        [Column("enabled")]
        public bool AccountEnabled { get; set; } = true;


        /*      RELATIONS       */
        
        [Column("current_role")]
        public required Role CurrentRole { get; set; }

        [Column("reviews")]
        public List<Review> Reviews { get; set; } = new List<Review>();

        [Column("orders")]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
