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
using Windows.UI.Xaml;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class PassengerLoginViewModel : INotifyPropertyChanged
    {
        #region Properties

        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; RaisePropertyChanged("Number"); }
        }

        private Model.Passenger _passenger;

        public Model.Passenger Passenger
        {
            get { return _passenger; }
            set { _passenger = value; RaisePropertyChanged("Passenger"); }
        }

        private Visibility _visibilityLogin;

        public Visibility VisibilityLogin
        {
            get { return _visibilityLogin; }
            set { _visibilityLogin = value; RaisePropertyChanged("VisibilityLogin"); }
        }

        private Visibility _visibilityCheck;

        public Visibility VisibilityCheck
        {
            get { return _visibilityCheck; }
            set { _visibilityCheck = value; RaisePropertyChanged("VisibilityCheck"); }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged("Name"); }
        }

        #endregion


        public LoginCommand LoginCommand { get; set; }

        public CancelLoginCommand CancelLoginCommand { get; set; }

        public PassengerLoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
            CancelLoginCommand = new CancelLoginCommand(this);
            CancelLogin();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Login()
        {
            string x = Number;
            HttpClient client = new HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/User/passenger/" + Number));
                var passenger = JsonConvert.DeserializeObject<Model.Passenger>(json);
                Passenger = passenger;
                if(passenger != null)
                {
                    VisibilityLogin = Visibility.Visible;
                    VisibilityCheck = Visibility.Collapsed;
                    Name = Passenger.FirstName + " " + Passenger.LastName;
                }
            }
            catch (Exception e)
            {
                CancelLogin();
            };
        }

        public void CancelLogin()
        {
            VisibilityLogin = Visibility.Collapsed;
            VisibilityCheck = Visibility.Visible;
            Name = "Passenger";
        }
    }
}