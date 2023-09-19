using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class Role
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }


        /*      RELATIONS       */

        [Column("users")]
        public List<Client> Users { get; set; } = new List<Client>();
    }
}
