using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public required string Reference { get; set; }
       
        public required string DeliveringAddress { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly ReservationDate { get; set; }

        public float OrderTotalSum { get; set; }


        /*      RELATIONS       */

        public List<ProductOrder> ProductsOrdered { get; set; } = new List<ProductOrder>();

        public required OrderStatus OrderStatus { get; set; }

        public required Client Client { get; set; }
    }
}
