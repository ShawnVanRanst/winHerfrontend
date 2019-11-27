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
            mediaContent.Navigate(typeof(VideoList), "movies");
        }


        private void LoadMedia(object sender, TappedRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string mediaToLoad = btn.Content.ToString();
            switch (mediaToLoad)
            {
                case "Movies":
                    mediaContent.Navigate(typeof(VideoList), "movies");
                    break;
                case "Series":
                    mediaContent.Navigate(typeof(VideoList), "series");
                    break;
                case "Music":
                    mediaContent.Navigate(typeof(MusicList));
                    break;
            }
        }
    }
}
