using OnBoardFlight.ViewModel.CabinCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.CabinCrew
{
    public class SendNotificationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public NotificationViewModel NotificationViewModel { get; set; }

        public SendNotificationCommand(NotificationViewModel nvm)
        {
            NotificationViewModel = nvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddNotification(parameter);
        }

        private async void AddNotification(object parameter)
        {
            await NotificationViewModel.AddNotificationAsync();
        }
    }
}
