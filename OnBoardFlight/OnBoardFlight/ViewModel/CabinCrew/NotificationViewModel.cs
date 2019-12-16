using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Commands.CabinCrew;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using HttpClient = Windows.Web.Http.HttpClient;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class NotificationViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _seatnumber;

        public string Seatnumber
        {
            get { return _seatnumber; }
            set { _seatnumber = value; RaisePropertyChanged("Seatnumber"); }
        }

        public HttpClient Client { get; set; }

        public Notification Notification { get; set; }

        public SendNotificationCommand SendNotification { get; set; }


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
        #endregion

        public NotificationViewModel()
        {
            Notification = new Notification() { Content = "", SinglePerson = false, PassengerSeat = "", Title = ""};
            Client = new HttpClient();
            SendNotification = new SendNotificationCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task AddNotificationAsync()
        {

            try
            {
                var NotificationJson = JsonConvert.SerializeObject(Notification);
                var res = await Client.PostAsync(new Uri("http://localhost:5000/api/User/notification/add"), new HttpStringContent(NotificationJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                if (!res.IsSuccessStatusCode)
                {
                    ErrorMessage = "Something went wrong! Please try again later.";
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
        }
    }
}
