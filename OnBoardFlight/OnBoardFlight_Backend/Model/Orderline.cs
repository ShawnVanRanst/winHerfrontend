using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Orderline
    {

        #region Properties

        public int OrderlineId { get; set; }

        public int Number { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
        #endregion

        #region Constructors

        public Orderline()
        {

        }

        public Orderline(int number, Product product, Order order)
        {
            Number = number;
            Product = product;
            Order = order;
        }


        #endregion

        #region Methods

        public double CalculateTotalPrice()
        {
            return Product.Price * Number;
        }
        #endregion
    }
}
