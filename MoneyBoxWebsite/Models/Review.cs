using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class Review
    {
        [Key]
        [Column("id")]
        public Guid ReviewId { get; set; }

        [Column("message")]
        public required string Message { get; set; }

        [Column("validate")]
        public bool IsValidate { get; set; } = false;



        /*      RELATIONS       */

        [Column("creator")]
        public required Client Creator { get; set; }

        [Column("linked_product")]
        public required Product LinkedProduct { get; set; }
    }
}
