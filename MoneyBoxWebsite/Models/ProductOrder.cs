using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    [Serializable]
    public class ProductOrder
    {
        [Key]
        [Column("id")]
        public Guid ProductOrderId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("sell_price")]
        public float SellPrice { get; set; }


        /*      RELATIONS       */

        [Column("linked_product")]
        public required Product LinkedProduct { get; set; }

        [Column("linked_order")]
        public Order LinkedOrder { get; set; }
    }
}
