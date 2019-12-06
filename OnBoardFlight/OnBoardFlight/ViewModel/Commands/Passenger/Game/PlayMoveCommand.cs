using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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
            string content = button.Content.ToString();
            if (content == "?")
            {
                button.IsEnabled = false;
                button.Content = GameViewModel.Play(button.Name);
                bool winner = GameViewModel.CheckWinner();
                if (winner)
                {
                    UIElement board = VisualTreeHelper.GetParent(button) as UIElement;
                    Grid grid = (Grid)board;
                    ICollection<UIElement> gameFields = grid.Children;
                    foreach (var btn in gameFields)
                    {
                        Button bt = (Button)btn;
                        bt.Content = "?";
                        bt.IsEnabled = true;
                    }
                    button.IsEnabled = true;
                }
            }
        }
    }
}
