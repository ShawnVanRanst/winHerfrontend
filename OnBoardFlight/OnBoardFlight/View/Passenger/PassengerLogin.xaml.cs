using OnBoardFlight.ViewModel;
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

namespace OnBoardFlight.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PassengerLogin : Page
    {
        public PassengerLogin()
        {
            this.InitializeComponent();
            this.DataContext = new PassengerLoginViewModel();
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
                return true;
            }
            return false;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            //Backend call + get user from backend
            Model.Passenger Passenger = DummyDataSource.getPassenger();
            if(LoginBtn.Text == Passenger.Login)
            {
                Frame.Navigate(typeof(NavigationPassenger), Passenger);
            }
            else
            {
                LoginError.Text = "Seat number is not correct!";
            }
        }
    }
}
