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
    public sealed partial class Advertisement : Page
    {
        private AdvertismentViewModel Vm { get; set; }

        public Advertisement()
        {
            this.InitializeComponent();
            Vm = new AdvertismentViewModel();
            this.DataContext = Vm;
        }

        private void Filter(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Vm.Filter = textBox.Text;
            Vm.FilterProducts();
        }
    }
}
