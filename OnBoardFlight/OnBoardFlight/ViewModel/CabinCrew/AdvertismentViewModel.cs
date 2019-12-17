using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Commands.CabinCrew.Promotion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.Web.Http;
using HttpClient = Windows.Web.Http.HttpClient;
using Windows.UI.Xaml;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class AdvertismentViewModel : INotifyPropertyChanged
    {
        #region Properties
        private HttpClient Client { get; set; }

        public AddPromotionCommand AddPromotionCommand { get; set; }


        public ObservableCollection<Product> ProductData { get; set; }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; RaisePropertyChanged("Products"); }
        }

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                if (value != null)
                {
                    Visibility = Visibility.Visible;
                }
                else
                {
                    Visibility = Visibility.Collapsed;
                }
                RaisePropertyChanged("Product");
            }
        }

        private string _oldPrice;

        public string OldPrice
        {
            get { return _oldPrice; }
            set { _oldPrice = value; RaisePropertyChanged("OldPrice"); }
        }


        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; RaisePropertyChanged("Filter"); }
        }

        private Visibility _visibility;

        public Visibility Visibility
        {
            get { return _visibility; }
            set { _visibility = value; RaisePropertyChanged("Visibility"); }
        }


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



        public AdvertismentViewModel()
        {
            Visibility = Visibility.Collapsed;
            Client = new HttpClient();
            AddPromotionCommand = new AddPromotionCommand(this);
            Products = new ObservableCollection<Product>();
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void LoadData()
        {
            try
            {
                var json = await Client.GetStringAsync(new Uri("http://localhost:5000/api/Product"));
                var products = JsonConvert.DeserializeObject<IList<Product>>(json);
                if(products.Count == 0)
                {
                    ErrorMessage = "No products available!";
                }
                else
                {
                    ProductData = new ObservableCollection<Product>();
                    foreach (var product in products)
                    {
                        ProductData.Add(product);
                    }
                    Products = ProductData;
                    ErrorMessage = null;
                }  
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
            
        }

        public async Task EditPromotion()
        {
            if (Product.Discount)
            {
                Product.OldPrice = double.Parse(OldPrice);
            }
            try
            {
                var ProductJson = JsonConvert.SerializeObject(Product);
                var res = await Client.PostAsync(new Uri("http://localhost:5000/api/Product/product/update"), new HttpStringContent(ProductJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    SuccesMessage = "Price of " + Product.Description + " succesfully updated!";
                    Product = null;
                    LoadData();
                }
                else
                {
                    ErrorMessage = "Creating promotion was not succesfull! Please try again later.";
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Promotion was not created.";
            }
           
        }

        public void FilterProducts()
        {
            Products = new ObservableCollection<Product>();
            foreach(var product in ProductData)
            {
                if (product.Description.ToLower().Contains(Filter.ToLower()))
                {
                    Products.Add(product);
                }
            }
        }
    }
}
