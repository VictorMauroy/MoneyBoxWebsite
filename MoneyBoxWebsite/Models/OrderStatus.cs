namespace MoneyBoxWebsite.Models
{
    public class OrderStatus
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }


        /*      RELATIONS       */

        public List<Order> OrdersWithStatus { get; set; } = new List<Order>();
    }
}
