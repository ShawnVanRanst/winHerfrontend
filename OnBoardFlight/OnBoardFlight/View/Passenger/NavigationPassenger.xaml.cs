using OnBoardFlight.View.General;
using OnBoardFlight.View.Passenger;
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
    public sealed partial class NavigationPassenger : Page
    {
        public NavigationPassenger()
        {
            this.InitializeComponent();
            NavView.SelectedItem = HometBtn;
            mainFrame.Navigate(typeof(Home));
        }

        private void NavigateTo(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem selectedItem = (NavigationViewItem)args.SelectedItem;

            string tag = selectedItem.Tag.ToString();

            NavOptions(tag);
        }

        private void NavOptions(string tag)
        {
            switch (tag)
            {
                case "Home":
                    mainFrame.Navigate(typeof(Home));
                    break;
                case "Shop":
                    mainFrame.Navigate(typeof(Shop));
                    break;
                case "Orders":
                    mainFrame.Navigate(typeof(MyOrders));
                    break;
                case "Media":
                    mainFrame.Navigate(typeof(MultiMedia));
                    break;
                case "Chat":
                    mainFrame.Navigate(typeof(Chat));
                    break;
                case "Logout":
                    //TODO logout the user
                    ConfirmLogout();
                    break;
            }
        }

        //Small error when pressing "No", Logout button can't be pressed again unless navigated to other frame
        private async void ConfirmLogout()
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Logout",
                Content = "Are you sure you want to logout?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
