using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.DTO
{
    public class AddOrderlineDTO
    {
        public int Number { get; set; }

        public int ProductId { get; set; }

        public AddOrderlineDTO(Orderline orderline)
        {
            Number = orderline.Number;
            ProductId = orderline.Product.ProductId;
        }
    }
}
