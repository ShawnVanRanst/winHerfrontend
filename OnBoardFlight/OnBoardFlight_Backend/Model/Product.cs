using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Product
    {

        #region Properties

        public int ProductId{ get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public double Price { get; set; }

        public Category Category{ get; set; }

        #endregion

        #region Constructors

        public Product()
        {

        }

        public Product(string description, string imageLink, double price, Category category)
        {
            Description = description;
            ImageLink = imageLink;
            Price = price;
            Category = category;
        }


        #endregion
    }
}
