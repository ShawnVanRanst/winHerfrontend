using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Message : INotifyPropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _sendDate;

        public DateTime SendDate
        {
            get { return _sendDate; }
            set { _sendDate = value; }
        }

        private Passenger _sender;

        public Passenger Sender
        {
            get { return _sender; }
            set { _sender = value; RaisePropertyChanged("Sender"); }
        }

        private string _context;

        public string Context
        {
            get { return _context; }
            set { _context = value; RaisePropertyChanged("Context"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
