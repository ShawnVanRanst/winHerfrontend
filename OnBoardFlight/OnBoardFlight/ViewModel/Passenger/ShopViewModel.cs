using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.Model.Media;
using OnBoardFlight.ViewModel.Commands.Passenger.Shop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class ShopViewModel
    {
        public Model.Passenger Passenger { get; set; }

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                AddProductToCart();
                RaisePropertyChanged("Product");
            }
        }


        private Model.ShoppingCart _cart;
        public Model.ShoppingCart Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                RaisePropertyChanged("Cart");
            }
        }

        public List<Product> ProductList { get; set; }

        public ObservableCollection<CategoryAndListProductHelper> CategoryListProductList { get; set; }


        #region Command
        public ICommand AddToCartCommand { get; set; }
        #endregion

        public ShopViewModel(Model.Passenger passenger)
        {
            CategoryListProductList = new ObservableCollection<CategoryAndListProductHelper>();
            ProductList = new List<Product>();
            Passenger = passenger;
            AddToCartCommand = new AddToCartCommand<object>(this);
            
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Product GetProductById(int id)
        {
            return ProductList.FirstOrDefault(p => p.ProductId == id);
        }

        public void AddProductToCart()
        {
            if (Cart == null)
            {
                Cart = new ShoppingCart(Passenger);
            }
            if (Cart.Order == null)
            {
                Cart.Order = new Order(Passenger);
            }
            Orderline orderline = GetOrderline(Product);
            if(orderline == null)
            {
                Cart.Order.Orderlines.Add(new Orderline(Product));
            }
            else
            {
                orderline.Number ++;
            }
            
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

        private Orderline GetOrderline(Product product)
        {
            return Cart.Order.Orderlines.FirstOrDefault(o => o.Product.ProductId == product.ProductId);
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
