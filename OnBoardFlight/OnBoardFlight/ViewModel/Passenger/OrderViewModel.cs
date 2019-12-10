using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class OrderViewModel: INotifyPropertyChanged
    {

        private ICollection<Model.Order> _orderlist;

        public ICollection<Model.Order> OrderList
        {
            get { return _orderlist; }
            set
            {
                _orderlist = value;
                RaisePropertyChanged("OrderList");
            }
        }

        private Model.Passenger _passenger;

        public Model.Passenger Passenger
        {
            get { return _passenger; }
            set
            {
                _passenger = value;
                RaisePropertyChanged("Passenger");
            }
        }


        public OrderViewModel()
        {
            OrderList = new List<Model.Order>();
            OrderList.Add(DummyDataSource.Order1);
            OrderList.Add(DummyDataSource.Order2);
            Passenger = OrderList.FirstOrDefault().Passenger;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
