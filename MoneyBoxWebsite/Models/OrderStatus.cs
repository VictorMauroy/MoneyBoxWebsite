using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class OrderStatus
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }


        /*      RELATIONS       */

        [Column("orders_using_status")]
        public List<Order> OrdersWithStatus { get; set; } = new List<Order>();
    }
}
