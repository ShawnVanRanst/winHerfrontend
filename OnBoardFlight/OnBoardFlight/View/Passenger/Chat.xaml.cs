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

namespace OnBoardFlight.View.Passenger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Chat : Page
    {
        public Chat()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new ChatViewModel((GeneralLogin)e.Parameter);

            MessageInputField.Width = ((Frame)Window.Current.Content).ActualWidth /100 * 60;
        }

        private void SelectChat(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Model.Chat chat = (Model.Chat)lv.SelectedItem;
            (this.DataContext as ChatViewModel).ShowMessages(chat);
        }
    }
}