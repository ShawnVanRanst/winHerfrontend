using OnBoardFlight_Backend.Model;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public double Price { get; set; }

        public ProductCategory Category { get; set; }


        public ProductDTO(Product product)
        {
            ProductId = product.ProductId;
            Description = product.Description;
            ImageLink = product.ImageLink;
            Price = product.Price;
            Category = product.Category;
        }
    }
}