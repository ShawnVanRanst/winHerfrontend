using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Commands.CabinCrew;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class NotificationViewModel : INotifyPropertyChanged
    {
        private string _seatnumber;

        public string Seatnumber
        {
            get { return _seatnumber; }
            set { _seatnumber = value; RaisePropertyChanged("Seatnumber"); }
        }

        public Notification Notification { get; set; }

        public SendNotificationCommand SendNotification { get; set; }

        public NotificationViewModel()
        {
            Notification = new Notification();
            SendNotification = new SendNotificationCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void GetPassenger(string seatnumber)
        {

        }

        public async Task AddNotificationAsync()
        {
            if (string.IsNullOrEmpty(Seatnumber))
            {
                // Add notification to every passenger
            }
            else
            {
                // Add notification to chosen user
            }
        }
    }
}
