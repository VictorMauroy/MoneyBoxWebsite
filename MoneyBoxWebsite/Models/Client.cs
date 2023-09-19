using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class Client
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("enabled")]
        public bool AccountEnabled { get; set; }


        /*      RELATIONS       */
    
        
    }
}
