using Newtonsoft.Json;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.ViewModel.Commands.CabinCrew.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Web.Http;
using HttpClient = Windows.Web.Http.HttpClient;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties

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

        private CabinCrewLogin _cabinCrewLogin;

        public CabinCrewLogin CabinCrewLogin
        {
            get { return _cabinCrewLogin; }
            set { _cabinCrewLogin = value; RaisePropertyChanged("CabinCrewLogin"); }
        }


        #endregion

        public LoginCommand LoginCommand { get; set; }
        public CancelLoginCommand CancelLoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
            CancelLoginCommand = new CancelLoginCommand(this);
            CabinCrewLogin = new CabinCrewLogin { Login = "", Password = ""};
            CancelLogin();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoginCabinCrew()
        {
            var cabinCrewJson = JsonConvert.SerializeObject(CabinCrewLogin);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri("http://localhost:5000/api/User/cabincrew/login"), new HttpStringContent(cabinCrewJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                Model.CabinCrew cr = JsonConvert.DeserializeObject<Model.CabinCrew>(res.Content.ToString());
                if(cr != null)
                {
                    VisibilityLogin = Visibility.Visible;
                    VisibilityCheck = Visibility.Collapsed;
                    Name = cr.FirstName + " " + cr.LastName;
                }
            }
        }

        public void CancelLogin()
        {
            VisibilityLogin = Visibility.Collapsed;
            VisibilityCheck = Visibility.Visible;
            Name = "Cabin member";
            CabinCrewLogin.Password = "";
        }
    }
}
