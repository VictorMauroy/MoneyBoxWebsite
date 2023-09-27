using System.ComponentModel.DataAnnotations;

namespace MoneyBoxWebsite.Models.ViewModels
{
    public class ProductViewModel
    {
        public required string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required float Height { get; set; }
        public required float Width { get; set; }
        public required float Length { get; set; }
        public required float Weight { get; set; }
        public required string Manufacturer { get; set; }
        public required int MoneyCapacity { get; set; }

        [DataType(DataType.Upload)]
        public required IFormFile Image { get; set; }

        public List<Guid> GroupIds { get; set; } = new();
        public required string Color { get; set; }
    }
}
