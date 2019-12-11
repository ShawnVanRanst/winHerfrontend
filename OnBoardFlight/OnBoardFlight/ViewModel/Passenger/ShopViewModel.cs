using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class ShopViewModel
    {
        public Model.Passenger Passenger { get; set; }

        public List<Product> ProductList { get; set; }

        public ObservableCollection<CategoryAndListProductHelper> CategoryListProductList { get; set; }

        public ShopViewModel(Model.Passenger passenger)
        {
            CategoryListProductList = new ObservableCollection<CategoryAndListProductHelper>();
            ProductList = new List<Product>();
            Passenger = passenger;
            LoadData();
        }

        internal void AddToCart()
        {
            throw new NotImplementedException();
        }

        private void FillCategoryListProductList()
        {
            var categories = Enum.GetValues(typeof(ProductCategory));
            foreach (ProductCategory category in categories)
            {
                CategoryAndListProductHelper categoryAndListProductHelper = new CategoryAndListProductHelper()
                {
                    Category = category,
                    ProductList = new List<Product>()
                };
                foreach (Product p in ProductList)
                {
                    if (p.Category == category)
                    {
                        categoryAndListProductHelper.ProductList.Add(p);
                    }
                }
                CategoryListProductList.Add(categoryAndListProductHelper);
            }
        }

        private async void LoadData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Product"));
            var Productslist = JsonConvert.DeserializeObject<IList<Product>>(json);
            foreach (var Product in Productslist)
            {
                ProductList.Add(Product);
            }
            FillCategoryListProductList();
        }
    }
}
