using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Helper
{
    public class SendMessage : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string Seat { get; set; }
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChanged("Content"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
