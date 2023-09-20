using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBoxWebsite.Models
{
    public class Product
    {
        [Key]
        [Column("id")]
        public Guid ProductId { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("reference")]
        public required string Reference { get; set; }

        [Column("description")]
        public required string Description { get; set; }

        [Column("price")]
        public float Price { get; set; } = 0;

        [Column("image_file_path")]
        public required string ImageFilePath { get; set; }

        [Column("height")]
        public float Height { get; set; } = 0;

        [Column("width")]
        public float Width { get; set; } = 0;

        [Column("length")]
        public float Length { get; set; } = 0;

        [Column("weight")]
        public float Weigth { get; set; } = 0;

        [Column("color")]
        public required string Color { get; set; }

        [Column("manufacturer")]
        public required string Manufacturer { get; set; }

        [Column("money_capacity")]
        public int MoneyCapacity { get; set; }

        [Column("visibility")]
        public bool Visibility { get; set; } = true;


        /*      RELATIONS       */

        [Column("reviews")]
        public List<Review> Reviews { get; set; } = new List<Review>();

        /// <summary>
        /// If the product has a group of similar products linked
        /// </summary>
        [Column("product_groups")]
        public List<ProductGroup> ProductGroups { get; set; } = new List<ProductGroup>();

        /// <summary>
        /// In which order of products the current product belong. 
        /// Moreover, for what quantity and for which selling price.
        /// </summary>
        [Column("product_orders")] 
        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
