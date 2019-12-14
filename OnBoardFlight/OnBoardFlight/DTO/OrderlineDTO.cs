namespace OnBoardFlight.DTO
{
    public class OrderlineDTO
    {

        public int OrderlineId { get; set; }

        public int Number { get; set; }

        public ProductDTO ProductDTO{ get; set; }

        public double TotalPrice { get; set; }
    }
}