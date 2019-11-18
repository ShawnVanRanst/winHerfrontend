using System;
using System.Collections.Generic;
using OnBoardFlight.Model.orders;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel
{
    public class ProductViewModel
    {
        public ObservableCollection<Model.orders.Product> ProductList { get; set; }

        public ProductViewModel()
        {
            ProductList = new ObservableCollection<Model.orders.Product>();
            GetProductData();
        }
        private async void GetProductData()
        {
           // backendcall
        }
        private void FillProductList( productData)
        {

        }
    }
}
