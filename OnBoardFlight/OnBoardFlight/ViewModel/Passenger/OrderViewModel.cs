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
                HttpContent content = new StringContent(SeatNumber, Encoding.UTF8, "application/json");
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Order/Seat/"));
                var orderlist = JsonConvert.DeserializeObject<IList<Order>>(json);
                ObservableCollection<Order> newOrderList = new ObservableCollection<Order>();
                foreach (var Order in orderlist)
                {
                    newOrderList.Add(Order);
                }
                OrderList = newOrderList;
            }
            catch(Exception)
            {
                //Geef gebruiker melding dat het niet gelukt is de orders op te halen
            }
            
        }
    }
}
