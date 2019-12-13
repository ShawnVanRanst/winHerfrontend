using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
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
    public class ChatConversationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Message> Messages { get; set; }

        public Chat Chat { get; set; }

        public Model.Passenger Passenger { get; set; }

        public ChatConversationViewModel(ChatConversationHelper chatConversationHelper)
        {
            Chat = chatConversationHelper.Chat;
            Passenger = chatConversationHelper.Passenger;
            Messages = new ObservableCollection<Message>(Chat.Messages);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Message msg = new Message()
                {
                    Content = message,
                    SendDate = new DateTime(),
                    Sender = "temp sender name"
                };
                Chat.AddMessage(msg);
                Messages.Add(msg);
            }
        }
    }
}
