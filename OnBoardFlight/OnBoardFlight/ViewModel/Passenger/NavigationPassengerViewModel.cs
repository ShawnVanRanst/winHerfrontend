using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class NavigationPassengerViewModel: INotifyPropertyChanged
    {
        public GeneralLogin GeneralLogin { get; set; }
        public bool CheckForNotifications { get; set; }


        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        public NavigationPassengerViewModel(GeneralLogin login, bool checkForNotifications)
        {
            CheckForNotifications = checkForNotifications;
            GeneralLogin = login;
            LoadNotifications();
        }


        //Notify UI if property is changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private async void LoadNotifications()
        {
            HttpClient client = new HttpClient();
            while (CheckForNotifications)
            {
                try
                { 
                    var notificationsList = await client.GetStringAsync(new Uri("http://localhost:5000/api/User/notifications/" + GeneralLogin.Login));
                    IList<Notification> notifications = JsonConvert.DeserializeObject<IList<Notification>>(notificationsList);
                    foreach (var notification in notifications)
                    {
                        ContentDialog dialog = new ContentDialog()
                        {
                            Title = notification.Title,
                            Content = notification.Content,
                            PrimaryButtonText = "OK"
                        };
                        ContentDialogResult result = await dialog.ShowAsync();
                        if (result == ContentDialogResult.Primary)
                        {
                            var resD = await client.DeleteAsync(new Uri("http://localhost:5000/api/Notification/" + notification.Id));
                        }
                    }
                }
                catch(Exception)
                {
                    ErrorMessage = "Er ging iets mis bij het checken van messages. Probeer later opnieuw";
                }
            }
        }
    }
}
