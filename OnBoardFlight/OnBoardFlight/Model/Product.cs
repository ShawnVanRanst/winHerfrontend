using OnBoardFlight.ViewModel.Commands.Passenger.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public double Price { get; set; }

        public ProductCategory Category { get; set; }

         #region Commands
        public AddToCartCommand AddToCartCommand{ get; set; }
        #endregion
    }
}
