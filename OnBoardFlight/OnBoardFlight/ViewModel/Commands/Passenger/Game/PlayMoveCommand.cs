using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Game
{
    public class PlayMoveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GameViewModel GameViewModel { get; set; }

        public PlayMoveCommand(GameViewModel gvm)
        {
            GameViewModel = gvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Button button = (Button)parameter;
            button.Content = GameViewModel.Play(button.Name);
        }
    }
}
