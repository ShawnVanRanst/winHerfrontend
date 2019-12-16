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
using System.Threading;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class OrdersNotCompletedViewModel: INotifyPropertyChanged
    {

        #region Backend properties

        HttpClient client = new HttpClient();
        #endregion

        #region Properties
        private Order _order;

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                RaisePropertyChanged("Order");
            }
        }

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


        public OrdersNotCompletedViewModel()
        {
            OrderList = new ObservableCollection<Model.Order>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       

        public void GetOrders()
        {
            GetOrdersNotCompleted();
        }

        public void Complete()
        {
            CompleteOrderBackend();
        }
        private async void CompleteOrderBackend()
        {
            try
            {
                CompleteOrderDTO dto = new CompleteOrderDTO(_order);
                HttpContent content = new StringContent(DTOToJson(dto), Encoding.UTF8,
                                        "application/json");
                HttpResponseMessage result = await client.PostAsync(new Uri("http://localhost:5000/api/Order/Complete"), content);
                if(!result.IsSuccessStatusCode)
                {
                    ErrorMessage = "Something went wrong! Order is not completed.";
                }
                else
                {
                    ErrorMessage = null;
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
        }


        private async void GetOrdersNotCompleted()

        {
            try
            {
                var json1 = await client.GetStringAsync(new Uri("http://localhost:5000/api/Order/NotCompleted"));
                var orderlist = JsonConvert.DeserializeObject<IList<Order>>(json1);
                ObservableCollection<Order> newOrderList = new ObservableCollection<Order>();
                orderlist.OrderBy(o => o.Time);
                foreach (var Order in orderlist)
                {
                    newOrderList.Add(Order);
                }
                OrderList = newOrderList;
                int x = 0;
                var chatlist = new List<Order>();
                while (true)
                {
                    bool update = false;
                    var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Order/NotCompleted"));
                    var orderlistFromApi = JsonConvert.DeserializeObject<IList<Order>>(json);
                    orderlistFromApi.OrderBy(o => o.Time);

                    int lenght = orderlist.Count();
                    if (orderlistFromApi.Count() != lenght)
                    {
                        if (orderlistFromApi.Count() != 0)
                        {
                            update = true;
                        }
                    }

                    if (update)
                    {
                        orderlist = orderlistFromApi;
                        ObservableCollection<Order> newOrderList1 = new ObservableCollection<Order>();
                        foreach (var Order in orderlist)
                        {
                            newOrderList1.Add(Order);
                        }
                        OrderList = newOrderList1;
                    }
                    ErrorMessage = null;
                    Thread.SpinWait(5000);
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong fetching the orders. Please try again later.";
            }
            
        }
        private string DTOToJson(CompleteOrderDTO dto)
        {
            return JsonConvert.SerializeObject(dto);
        }
    }
}
