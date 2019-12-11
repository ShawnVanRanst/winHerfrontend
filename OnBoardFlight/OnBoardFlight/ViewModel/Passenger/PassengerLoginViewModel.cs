using Newtonsoft.Json;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.ViewModel.Commands.Passenger.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class PassengerLoginViewModel : INotifyPropertyChanged
    {
        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; RaisePropertyChanged("Number"); }
        }

        public LoginCommand LoginCommand { get; set; }

        public PassengerLoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void Login()
        {
            string x = Number;
            HttpClient client = new HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/User/passenger/" + Number));
                var passenger = JsonConvert.DeserializeObject<Model.Passenger>(json);
            }
            catch (Exception e)
            {
            };
            
        }

    }
}
