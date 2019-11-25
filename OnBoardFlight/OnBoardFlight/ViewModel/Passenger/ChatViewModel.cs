using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Chat> ChatList { get; set; }

        public ChatViewModel(List<Chat> chatList)
        {
            ChatList = new ObservableCollection<Chat>(chatList);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
