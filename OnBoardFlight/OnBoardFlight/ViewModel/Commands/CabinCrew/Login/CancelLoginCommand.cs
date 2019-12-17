using OnBoardFlight.ViewModel.CabinCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.CabinCrew.Login
{
    public class CancelLoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LoginViewModel LoginViewModel { get; set; }

        public CancelLoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoginViewModel.CancelLogin();
        }
    }
}
