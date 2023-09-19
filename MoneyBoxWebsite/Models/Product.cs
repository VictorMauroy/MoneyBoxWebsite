namespace MoneyBoxWebsite.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Reference { get; set; }
        
        public required string Description { get; set; }
        
        public decimal Price { get; set; } = 0;

        public required string ImageFilePath { get; set; }

        public float Height { get; set; } = 0;
        
        public float Width { get; set; } = 0;

        public float Length { get; set; } = 0;

        public float Weigth { get; set; } = 0;

        public required string Color { get; set; }

        public required string Manufacturer { get; set; }

        public int MoneyCapacity { get; set; }

        public bool Visibility { get; set; } = true;


        /*      RELATIONS       */

        public List<Review> Reviews { get; set; } = new List<Review>();

        /// <summary>
        /// If the product has a group of similar products linked
        /// </summary>
        public List<ProductGroup> ProductGroups { get; set; } = new List<ProductGroup>();

        /// <summary>
        /// In which order of products the current product belong. 
        /// Moreover, for what quantity and for which selling price.
        /// </summary>
        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
