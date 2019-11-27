using OnBoardFlight.Model;
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
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlight.View.Passenger.MediaFrames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicList : Page
    {
        private MediaPlayer player;

        public MusicList()
        {
            this.InitializeComponent();
            this.DataContext = new MusicListViewModel();
            player = new MediaPlayer();
        }

        private async void PlaySong(object sender, TappedRoutedEventArgs e)
        {
            player.Source = null;
            ListView lv = (ListView)sender;
            Music song = (Music)lv.SelectedItem;
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            StorageFile file = await folder.GetFileAsync(song.Resource);

            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            player.Dispose();
        }
    }
}
