using FFmpegInterop;
using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlight.ViewModel.Commands.Media
{
    public class PlaySerieCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SerieEpisodeDetailViewModel SerieEpisodeDetailViewModel { get; set; }

        private FFmpegInteropMSS FFmpegMSS { get; set; }

        public PlaySerieCommand(SerieEpisodeDetailViewModel sedvm)
        {
            SerieEpisodeDetailViewModel = sedvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            MediaElement mediaPlayer = (MediaElement)parameter;
            mediaPlayer.Stop();
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            StorageFile file = await folder.GetFileAsync(SerieEpisodeDetailViewModel.SerieEpisode.Resource);

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

                mediaPlayer.TransportControls.IsStopButtonVisible = true;
                mediaPlayer.TransportControls.IsStopEnabled = true;

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
