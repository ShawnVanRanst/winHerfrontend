using Newtonsoft.Json;
using OnBoardFlight.DTO;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class OrderViewModel: INotifyPropertyChanged
    {

        #region Backend properties

        HttpClient client = new HttpClient();
        #endregion

        #region Properties
        private ObservableCollection<Model.Order> _orderlist;

        public ObservableCollection<Model.Order> OrderList
        {
            get { return _orderlist; }
            set
            {
                _orderlist = value;
                RaisePropertyChanged("OrderList");
            }
        }

        private string _seatNumber;

        public string SeatNumber
        {
            get { return _seatNumber; }
            set
            {
                _seatNumber = value;
                RaisePropertyChanged("SeatNumber");
            }
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
        #endregion

        public OrderViewModel(GeneralLogin generalLogin)
        {
            OrderList = new ObservableCollection<Model.Order>();
            SeatNumber = generalLogin.Login;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetOrders()
        {
            GetOrdersForPassenger();
        }


        private async void GetOrdersForPassenger()

        {
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Order/Seat?seat=" + SeatNumber));
                var orderlist = JsonConvert.DeserializeObject<IList<Order>>(json);
                ObservableCollection<Order> newOrderList = new ObservableCollection<Order>();
                if(newOrderList.Count == 0)
                {
                    throw new ArgumentNullException();
                }
                foreach (var Order in orderlist)
                {
                    newOrderList.Add(Order);
                }
                OrderList = newOrderList;
                ErrorMessage = null;
            }
            catch(ArgumentNullException)
            {
                ErrorMessage = "There are no orders at the moment. Go to the shop to place a new order.";
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Pleae try again later.";
            }
            
        }
    }
}
