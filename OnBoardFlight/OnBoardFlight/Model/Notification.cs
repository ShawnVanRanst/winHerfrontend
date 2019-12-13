using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Notification : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("Title"); }
        }

        private string _context;

        public string Context
        {
            get { return _context; }
            set { _context = value; RaisePropertyChanged("Content"); }
        }

        private bool _general;

        public bool General
        {
            get { return _general; }
            set { _general = value; RaisePropertyChanged("Content"); }
        }

        private string _passengerSeat;

        public string PassengerSeat
        {
            get { return _passengerSeat; }
            set { _passengerSeat = value; RaisePropertyChanged("PassengerSeat"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}