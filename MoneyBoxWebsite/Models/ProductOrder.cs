namespace MoneyBoxWebsite.Models
{
    public class ProductOrder
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public float SellPrice { get; set; }


        /*      RELATIONS       */

        public required Product LinkedProduct { get; set; }

        public required Order LinkedOrder { get; set; }
    }
}
