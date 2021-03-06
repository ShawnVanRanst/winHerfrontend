﻿using Newtonsoft.Json;
using OnBoardFlight.DTO;
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
        #region Backend call properties
        private HttpClient client { get; }

        #endregion

        #region Properties
        public string SeatNumber { get; set; }

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged("Product");
            }
        }

        private Orderline _orderline;

        public Orderline Orderline
        {
            get { return _orderline; }
            set
            {
                _orderline = value;
                RaisePropertyChanged("Orderline");
            }
        }



        private Model.ShoppingCart _cart;
        public Model.ShoppingCart Cart
        {
            get
            {
                return _cart;
            }
            set
            {
                _cart = value;
                RaisePropertyChanged("Cart");
            }
        }

        public List<Product> ProductList { get; set; }

        public ObservableCollection<CategoryAndListProductHelper> CategoryListProductList { get; set; }


        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        private string _succesMessage;

        public string SuccesMessage
        {
            get { return _succesMessage; }
            set
            {
                _succesMessage = value;
                RaisePropertyChanged("SuccesMessage");
            }
        }

        #endregion

        public ShopViewModel(GeneralLogin generalLogin)
        {
            SeatNumber = generalLogin.Login;
            CategoryListProductList = new ObservableCollection<CategoryAndListProductHelper>();
            ProductList = new List<Product>();
            Cart = new ShoppingCart(SeatNumber);
            client = new HttpClient();
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
            ShoppingCart cart;
            //Check if cart already exists for passenger
            if (Cart == null)
            {
                //No cart => Add new Cart 
                cart = new ShoppingCart(SeatNumber);
                cart.AddOrderline(new Orderline(Product));
            }
            else
            {
                //Cart exists => assign Cart to local variable
                cart = this.Cart;
                //Check if orderline exists
                if (OrderlineExists())
                {
                    //Yes => +1 for number, change total price of orderline and order
                    cart = UpdateOrderLine(cart);
                }
                else
                {
                    //No => Add new orderline to the order
                    cart.AddOrderline(new Orderline(Product));
                    cart.Order.TotalPrice++;
                }
            }
            
            //Assign local cart variable to Cart, triggering setter and PropertyChanged
            Cart = cart;
        }

        public void AddOrder()
        {
            //Post the order to the backend and clear Cart if succesfull
            PostOrder();
        }

        public void DeleteOrderline()
        {
            if(Orderline == null)
            {
                ErrorMessage = "Please select an item to delete and then click the button.";
            }
            else
            {
                Order order = Cart.Order;
                ObservableCollection<Orderline> orderlines = order.Orderlines;
                orderlines.Remove(Orderline);
                Cart.Order.Orderlines = orderlines;
                Cart.Order = order;
                Cart.Order.TotalPrice--;
                Orderline = null;
                ErrorMessage = null;
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

        private Boolean OrderlineExists()
        {
            Orderline orderline = Cart.Order.Orderlines.FirstOrDefault(o => o.Product.ProductId == this.Product.ProductId);
            if(orderline == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private ShoppingCart UpdateOrderLine(ShoppingCart cartToUpdate)
        {
            cartToUpdate.Order.Orderlines.SingleOrDefault(o => o.Product.ProductId == this.Product.ProductId).Number++;
            cartToUpdate.Order.Orderlines.SingleOrDefault(o => o.Product.ProductId == this.Product.ProductId).TotalPrice++;
            cartToUpdate.Order.TotalPrice++;
            return cartToUpdate;
        }

        private async void LoadData()
        {
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Product"));
                var productslist = JsonConvert.DeserializeObject<IList<Product>>(json);
                if(productslist.Count == 0)
                {
                    ErrorMessage = "There are no products available.";
                }
                else
                {
                    foreach (var Product in productslist)
                    {
                        ProductList.Add(Product);
                    }
                    FillCategoryListProductList();
                    ErrorMessage = null;
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
           
        }

        private async void PostOrder()
        {
            try
            {
                AddOrderDTO dto = new AddOrderDTO(Cart.Order);
                HttpContent content = new StringContent(DTOToJson(dto), Encoding.UTF8,
                                        "application/json");
                HttpResponseMessage result = await client.PostAsync(new Uri("http://localhost:5000/api/Order"), content);
                if (result.IsSuccessStatusCode)
                {
                    ClearCart();
                    ErrorMessage = null;
                    SuccesMessage = "Order was created, we will bring you order asap!";
                }
                else
                {
                    ErrorMessage = "Something went wrong! Order was not created!";
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
        }


        private string DTOToJson(AddOrderDTO dto)
        {
            return JsonConvert.SerializeObject(dto);
        }


        //Reset cart to null so that the cart is ready for a new order
        private void ClearCart()
        {

            Cart.Order = null;
            Cart = null;
        }
    }
}
