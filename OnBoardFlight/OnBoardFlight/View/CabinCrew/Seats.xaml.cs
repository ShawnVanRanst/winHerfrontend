﻿using OnBoardFlight.ViewModel.CabinCrew;
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

namespace OnBoardFlight.View.CabinCrew
{

    public sealed partial class Seats : Page
    {

        private SeatViewModel SeatViewModel { get; set; }


        public Seats()
        {
            this.InitializeComponent();
            SeatViewModel = new SeatViewModel();
            this.DataContext = SeatViewModel;
        }

        private void SetSeat1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SeatViewModel.Seat1 = textBox.Text;
            SeatViewModel.Passenger1 = null;
            SeatViewModel.ErrorMessage = null;
        }

        private void SetSeat2(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SeatViewModel.Seat2 = textBox.Text;
            SeatViewModel.Passenger2 = null;
            SeatViewModel.ErrorMessage2 = null;
        }
    }
}
