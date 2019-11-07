using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Passenger : INotifyPropertyChanged
    {
        private int _seatNumber;

        public int SeatNumber
        {
            get { return _seatNumber; }
            set { _seatNumber = value; RaisePropertyChanged("SeatNumber"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
