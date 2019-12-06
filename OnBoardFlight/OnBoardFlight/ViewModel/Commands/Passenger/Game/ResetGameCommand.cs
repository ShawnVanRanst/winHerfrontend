using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Game
{
    public class ResetGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GameViewModel GameViewModel { get; set; }

        public ResetGameCommand(GameViewModel gvm)
        {
            GameViewModel = gvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            GameViewModel.ResetGameScore();
        }
    }
}
