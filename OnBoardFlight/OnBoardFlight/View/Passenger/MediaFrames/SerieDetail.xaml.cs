using FFmpegInterop;
using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlight.View.Passenger.MediaFrames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SerieDetail : Page
    {
        private FFmpegInteropMSS FFmpegMSS;

        public SerieDetailViewModel SerieDetailViewModel { get; set; }

        public SerieDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Serie serie = (Serie)e.Parameter;
            SerieDetailViewModel = new SerieDetailViewModel(serie);
            this.DataContext = SerieDetailViewModel;
        }

        private async void PlayEpisode(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            SerieEpisode se = (SerieEpisode)lv.SelectedItem;


            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            StorageFile file = await folder.GetFileAsync(se.Resource);

            IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read);
            FFmpegMSS = FFmpegInteropMSS.CreateFFmpegInteropMSSFromStream(readStream, true, true);
            MediaStreamSource mss = FFmpegMSS.GetMediaStreamSource();

            if (mss != null)
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
