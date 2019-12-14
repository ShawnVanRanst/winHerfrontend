using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class NavigationPassengerViewModel
    {
        public GeneralLogin GeneralLogin { get; set; }

        public NavigationPassengerViewModel(GeneralLogin login)
        {
            GeneralLogin = login;
            LoadNotifications();
        }

        private async void LoadNotifications()
        {
            HttpClient client = new HttpClient();
            while (true)
            {
                var notificationsList = await client.GetStringAsync(new Uri("http://localhost:5000/api/User/notifications/" + GeneralLogin.Login));
                IList<Notification> notifications = JsonConvert.DeserializeObject<IList<Notification>>(notificationsList);
                foreach(var notification in notifications)
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = notification.Title,
                        Content = notification.Content,
                        PrimaryButtonText = "OK"
                    };
                    ContentDialogResult result = await dialog.ShowAsync();
                    if(result == ContentDialogResult.Primary)
                    {
                        var resD = await client.DeleteAsync(new Uri("http://localhost:5000/api/Notification/" + notification.Id));
                    }
                }
            }
        }
    }
}
