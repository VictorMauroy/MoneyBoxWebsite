using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class Order
    {
        [Key]
        [Column("id")]
        public Guid OrderId { get; set; }

        [Column("reference")]
        public required string Reference { get; set; }

        [Column("delivering_address")]
        public required string DeliveringAddress { get; set; }

        [Column("reservation_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }

        [Column("order_total_sum")]
        public float OrderTotalSum { get; set; }


        /*      RELATIONS       */

        [Column("ordered_products")]
        public List<ProductOrder> OrderedProducts { get; set; } = new List<ProductOrder>();

        [Column("order_status")]
        public required OrderStatus OrderStatus { get; set; }

        [Column("client")]
        public required Client Client { get; set; }
    }
}
