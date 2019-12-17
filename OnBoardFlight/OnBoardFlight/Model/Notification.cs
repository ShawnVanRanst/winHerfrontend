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

        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChanged("Content"); }
        }

        private bool _singlePerson;

        public bool SinglePerson
        {
            get { return _singlePerson; }
            set { _singlePerson = value; RaisePropertyChanged("SinglePerson"); }
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