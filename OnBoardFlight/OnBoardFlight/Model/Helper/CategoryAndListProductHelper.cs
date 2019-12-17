using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Helper
{
    public class CategoryAndListProductHelper
    {
        private ProductCategory _category;

        public ProductCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private List<Product> _productList;

        public List<Product> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }

    }
}
