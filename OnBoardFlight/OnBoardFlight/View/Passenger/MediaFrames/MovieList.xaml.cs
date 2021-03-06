﻿using OnBoardFlight.Model;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlight.View.Passenger.MediaFrames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieList : Page
    {
        public MovieList()
        {
            this.InitializeComponent();
            this.DataContext = new MovieListViewModel();
        }

        private void VideoDetails(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MovieDetail), ((sender as ListView).SelectedItem as Movie).Id);
        }
    }
}
