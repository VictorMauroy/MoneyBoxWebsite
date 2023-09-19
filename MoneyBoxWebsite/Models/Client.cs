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

        [Column("enabled")]
        public bool AccountEnabled { get; set; } = true;


        /*      RELATIONS       */

        public required Theme CurrentTheme { get; set; }

        public required Role CurrentRole { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
