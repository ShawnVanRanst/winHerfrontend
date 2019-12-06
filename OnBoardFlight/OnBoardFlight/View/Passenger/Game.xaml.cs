using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlight.View.Passenger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        private GameViewModel GameViewModel { get; set; }

        public Game()
        {
            this.InitializeComponent();
            GameViewModel = new GameViewModel();
            this.DataContext = GameViewModel;
        }

        private void PlayMove(object sender, TappedRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            if (GameViewModel.CheckWinner()) ClearBoard();
        }

        private void ClearBoard()
        {

            ICollection<UIElement> gameFields = Board.Children;
            foreach(var btn in gameFields)
            {
                Button button = (Button)btn;
                button.Content = "?";
                button.IsEnabled = true;
            }
        }

        private void Reset(object sender, TappedRoutedEventArgs e)
        {
            ClearBoard();
        }

        private void NewGame(object sender, TappedRoutedEventArgs e)
        {
            ClearBoard();
        }
    }
}
