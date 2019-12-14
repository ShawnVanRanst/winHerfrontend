using OnBoardFlight.Model;

namespace OnBoardFlight.DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public double Price { get; set; }

        public ProductCategory Category { get; set; }
    }
}