namespace MoneyBoxWebsite.Models
{
    public class ProductGroup
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }


        /*      RELATIONS       */

        public List<Product> GroupedProducts { get; set; } = new List<Product>();
    }
}
