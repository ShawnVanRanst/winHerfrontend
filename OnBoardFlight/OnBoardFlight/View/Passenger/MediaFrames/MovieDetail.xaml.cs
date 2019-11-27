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
        private FFmpegInteropMSS FFmpegMSS;

        public MovieDetailsViewModel MovieDetailsViewModel { get; set; }

        public MovieDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Movie movie = (Movie)e.Parameter;
            MovieDetailsViewModel = new MovieDetailsViewModel(movie);
            this.DataContext = MovieDetailsViewModel;
        }

        private async void PlayMovie(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayer.Stop();
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            StorageFile file = await folder.GetFileAsync(MovieDetailsViewModel.Movie.Resource);

            IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read);
            FFmpegMSS = FFmpegInteropMSS.CreateFFmpegInteropMSSFromStream(readStream, true, true);
            MediaStreamSource mss = FFmpegMSS.GetMediaStreamSource();

            if(mss != null)
            {
                mediaPlayer.AreTransportControlsEnabled = true;

                mediaPlayer.TransportControls.IsFastForwardButtonVisible = true;
                mediaPlayer.TransportControls.IsFastForwardEnabled = true;

                mediaPlayer.TransportControls.IsFastRewindButtonVisible = true;
                mediaPlayer.TransportControls.IsFastRewindEnabled = true;

                mediaPlayer.TransportControls.IsSkipBackwardButtonVisible = true;
                mediaPlayer.TransportControls.IsSkipBackwardEnabled = true;

                mediaPlayer.TransportControls.IsSkipForwardButtonVisible = true;
                mediaPlayer.TransportControls.IsSkipForwardEnabled = true;

                mediaPlayer.TransportControls.IsStopButtonVisible = true;
                mediaPlayer.TransportControls.IsStopEnabled = true;

                mediaPlayer.TransportControls.IsRightTapEnabled = true;

                mediaPlayer.SetMediaStreamSource(mss);

                mediaPlayer.Play();
            }
            else
            {
                var msg = new MessageDialog("ERROR");
                await msg.ShowAsync();
            }
        }
    }
}
