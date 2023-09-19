using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public string Reference { get; set; }
       
        public string DeliveringAddress { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly ReservationDate { get; set; }

        public float OrderTotalSum { get; set; }


        /*      RELATIONS       */


    }
}
