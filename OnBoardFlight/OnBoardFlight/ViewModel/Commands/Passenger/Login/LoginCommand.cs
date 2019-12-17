using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Login
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public PassengerLoginViewModel PassengerLoginViewModel { get; set; }

        public LoginCommand(PassengerLoginViewModel plvm)
        {
            PassengerLoginViewModel = plvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Login();
        }

        private async void Login()
        {
            await PassengerLoginViewModel.Login();
        }
    }
}
