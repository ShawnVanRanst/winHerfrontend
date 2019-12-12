using OnBoardFlight.View.CabinCrew;
using OnBoardFlight.View.General;
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
    public sealed partial class NavigationCabinCrew : Page
    {
        public NavigationCabinCrew()
        {
            this.InitializeComponent();
            NavView.SelectedItem = HomeBtn;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new NavigationCabinCrewViewModel((Model.Helper.CabinCrewLogin)e.Parameter);
            NavOptions("Home");
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
                    mainFrame.Navigate(typeof(Home), (this.DataContext as NavigationCabinCrewViewModel).CabinCrewLogin);
                    break;
                case "Seats":
                    mainFrame.Navigate(typeof(Seats));
                    break;
                case "Orders":
                    mainFrame.Navigate(typeof(OverviewOrders));
                    break;
                case "Advertisement":
                    mainFrame.Navigate(typeof(Advertisement));
                    break;
                case "Notification":
                    mainFrame.Navigate(typeof(Notification));
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
