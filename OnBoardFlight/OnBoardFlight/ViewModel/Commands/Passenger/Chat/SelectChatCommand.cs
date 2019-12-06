using OnBoardFlight.Model.Helper;
using OnBoardFlight.View.Passenger;
using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlight.ViewModel.Commands.Passenger
{
    public class SelectChatCommand : ICommand
    {
        public ChatViewModel ChatViewModel { get; set; }

        public SelectChatCommand(ChatViewModel cvm)
        {
            ChatViewModel = cvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*
            ListView lv = (ListView)parameter;
            Model.Chat chat = (Model.Chat)lv.SelectedItem;
            ChatConversationHelper chatConversationHelper = new ChatConversationHelper()
            {
                Chat = chat,
                Passenger = ChatViewModel.Passenger
            };
            Conversation.Navigate(typeof(ChatConversation), chatConversationHelper);
            */
        }
    }
}
