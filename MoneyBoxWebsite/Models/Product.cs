namespace MoneyBoxWebsite.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; } = 0;

        public string ImageFilePath { get; set; }

        public float Height { get; set; } = 0;
        
        public float Width { get; set; } = 0;

        public float Length { get; set; } = 0;

        public float Weigth { get; set; } = 0;

        public string Color { get; set; }

        public string Manufacturer { get; set; }

        public int MoneyCapacity { get; set; }

        public bool Visibility { get; set; } = true;


        /*      RELATIONS       */


    }
}
