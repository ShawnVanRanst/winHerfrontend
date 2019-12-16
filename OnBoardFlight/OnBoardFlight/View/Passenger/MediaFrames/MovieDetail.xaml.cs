using OnBoardFlight.Model.Media;
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
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.UI.Popups;
using FFmpegInterop;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlight.View.Passenger.MediaFrames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieDetail : Page
    {
        public MovieDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = new MovieDetailsViewModel((int)e.Parameter);
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void Back_Click(object sender, TappedRoutedEventArgs e)
        {
            On_BackRequested();
        }

        private void PlayMov(object sender, TappedRoutedEventArgs e)
        {
            PlayBtn.Visibility = Visibility.Collapsed;
        }
    }
}
