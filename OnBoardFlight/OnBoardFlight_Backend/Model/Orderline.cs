using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Orderline
    {

        #region Properties

        public int OderlineId { get; set; }

        public int Number { get; set; }

        public Product Product { get; set; }
        #endregion

        #region Constructors

        public Orderline()
        {

        }

        public Orderline(int number, Product product)
        {
            Number = number;
            Product = product;
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
