using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class ProductGroup
    {
        [Key]
        [Column("id")]
        public Guid ProductGroupId { get; set; }

        [Column("name")]
        public required string Name { get; set; }


        /*      RELATIONS       */
        
        [Column("grouped_products")]
        public List<Product> GroupedProducts { get; set; } = new List<Product>();
    }
}
