using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Login
{
    public class CancelLoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public PassengerLoginViewModel PassengerLoginViewModel { get; set; }

        public CancelLoginCommand(PassengerLoginViewModel passengerLoginViewModel)
        {
            PassengerLoginViewModel = passengerLoginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PassengerLoginViewModel.CancelLogin();
        }
    }
}
