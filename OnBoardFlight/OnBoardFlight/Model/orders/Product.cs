using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.orders
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product(string imageLink, string description, double price, Category category)
        {
            ImageLink = imageLink;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
