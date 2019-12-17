using OnBoardFlight.Model.Helper;
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

namespace OnBoardFlight.View.CabinCrew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverviewOrders : Page
    {
        private OrderViewModel OrderViewModel { get; set; }

        public OverviewOrders()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.DataContext.GetType() != typeof(OrdersNotCompletedViewModel))
            {
                this.DataContext = new OrdersNotCompletedViewModel();
            }
            (this.DataContext as OrdersNotCompletedViewModel).GetOrders();
        }

        private void Complete(object sender, TappedRoutedEventArgs e)
        {
            (this.DataContext as OrdersNotCompletedViewModel).Complete();
        }

        private void SelectOrder(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Model.Order o = (Model.Order)lv.SelectedItem;
            (this.DataContext as OrdersNotCompletedViewModel).Order = o;
        }
    }
}
