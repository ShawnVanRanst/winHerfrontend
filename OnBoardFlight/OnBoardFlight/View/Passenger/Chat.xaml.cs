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
        private ChatViewModel _chatViewModel { get; set; }

        public Chat()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _chatViewModel = new ChatViewModel((Model.Passenger) e.Parameter);
            this.DataContext = _chatViewModel;
        }

        private void SelectChat(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Model.Chat chat = (Model.Chat)lv.SelectedItem;
            ChatConversationHelper chatConversationHelper = new ChatConversationHelper()
            {
                Chat = chat,
                Passenger = _chatViewModel.Passenger
            };
            Conversation.Navigate(typeof(ChatConversation), chatConversationHelper);
        }
    }
}
