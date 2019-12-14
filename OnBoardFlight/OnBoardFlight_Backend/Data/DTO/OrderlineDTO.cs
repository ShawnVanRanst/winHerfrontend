using OnBoardFlight_Backend.Model;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class OrderlineDTO
    {

        public int OrderlineId { get; set; }

        public int Number { get; set; }

        public ProductDTO ProductDTO { get; set; }

        public double TotalPrice { get; set; }


        public OrderlineDTO(Orderline orderline)
        {
            OrderlineId = orderline.OrderlineId;
            Number = orderline.Number;
            ProductDTO = new ProductDTO(orderline.Product);
            TotalPrice = orderline.GetTotalPrice();
        }
    }
}