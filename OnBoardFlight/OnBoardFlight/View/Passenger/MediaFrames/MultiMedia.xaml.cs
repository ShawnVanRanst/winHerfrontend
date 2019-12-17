using OnBoardFlight.View.Passenger.MediaFrames;
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
    public sealed partial class MultiMedia : Page
    {
        public MultiMedia()
        {
            this.InitializeComponent();
            mediaContent.Navigate(typeof(MovieList));
            MediaNav.SelectedItem = MoviesBtn;
        }


        private void NavigateOptions(string tag)
        {
            switch (tag)
            {
                case "Movies":
                    mediaContent.Navigate(typeof(MovieList));
                    break;
                case "Series":
                    mediaContent.Navigate(typeof(SerieList));
                    break;
                case "Music":
                    mediaContent.Navigate(typeof(MusicList));
                    break;
            }
        }

        private void SelectMedia(object sender, TappedRoutedEventArgs e)
        {
            NavigationViewItem selectedItem = (NavigationViewItem)MediaNav.SelectedItem;
            string tag = selectedItem.Tag.ToString();
            NavigateOptions(tag);
        }
    }
}
