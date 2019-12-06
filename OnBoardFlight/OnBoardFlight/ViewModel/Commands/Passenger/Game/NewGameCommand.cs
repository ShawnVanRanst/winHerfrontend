using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Game
{
    public class NewGameCommand : ICommand
    {
        public GameViewModel GameViewModel { get; set; }
        public NewGameCommand(GameViewModel gvm)
        {
            GameViewModel = gvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            GameViewModel.RandomFirstMoveNewGame();
        }
    }
}
