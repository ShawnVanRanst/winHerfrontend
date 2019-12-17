using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Chat
{
    public class SendMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ChatViewModel ChatViewModel { get; set; }

        public SendMessageCommand(ChatViewModel chatViewModel)
        {
            ChatViewModel = chatViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ChatViewModel.SendAMessage();
        }
    }
}
