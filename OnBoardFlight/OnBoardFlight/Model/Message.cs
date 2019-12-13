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

        private string _sender;

        public string Sender
        {
            get { return _sender; }
            set { _sender = value; RaisePropertyChanged("Sender"); }
        }

        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChanged("Content"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
