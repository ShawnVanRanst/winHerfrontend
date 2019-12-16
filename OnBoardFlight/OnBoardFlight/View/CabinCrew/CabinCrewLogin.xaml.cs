﻿using OnBoardFlight.Model;
using OnBoardFlight.View.CabinCrew;
using OnBoardFlight.ViewModel;
using OnBoardFlight.ViewModel.CabinCrew;
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

namespace OnBoardFlight.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CabinCrewLogin : Page
    {
        public CabinCrewLogin()
        {
            this.InitializeComponent();
            this.DataContext = new LoginViewModel();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void LoginCabinCrew(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NavigationCabinCrew), (this.DataContext as LoginViewModel).CabinCrewLogin);
        }
    }
}
