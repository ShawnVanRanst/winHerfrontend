using OnBoardFlight.ViewModel.Commands.CabinCrew;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using OnBoardFlight.Model.Helper;
using Windows.Web.Http;
using HttpClient = Windows.Web.Http.HttpClient;
using OnBoardFlight.ViewModel.Commands;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class SeatViewModel: INotifyPropertyChanged
    {
        #region Properties
        private HttpClient Client { get; set; }
        private List<Model.Passenger> Passengers { get; set; }

        private Model.Passenger _passenger1;

        public Model.Passenger Passenger1
        {
            get { return _passenger1; }
            set
            {
                _passenger1 = value;
                RaisePropertyChanged("Passenger1");
            }
        }

        public string Seat1 { get; set; }

        private Model.Passenger _passenger2;

        public Model.Passenger Passenger2
        {
            get { return _passenger2; }
            set
            {
                _passenger2 = value;
                RaisePropertyChanged("Passenger2");
            }
        }

        public string Seat2 { get; set; }

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

        private string _errorMessage2;

        public string ErrorMessage2
        {
            get { return _errorMessage2; }
            set
            {
                _errorMessage2 = value;
                RaisePropertyChanged("ErrorMessage2");
            }
        }
        #endregion

        #region Commands
        public SearchPassengerToMoveCommand SearchPassengerToMoveCommand1 { get; set; }
        public SearchPassengerToMoveCommand SearchPassengerToMoveCommand2 { get; set; }
        public SwitchPlacesCommand SwitchPlacesCommand { get; set; } 
        #endregion

        public SeatViewModel()
        {
            Passenger1 = new Model.Passenger();
            Passenger2 = new Model.Passenger();
            Passengers = new List<Model.Passenger>();
            SwitchPlacesCommand = new SwitchPlacesCommand(this);
            SearchPassengerToMoveCommand1 = new SearchPassengerToMoveCommand(this, 1);
            SearchPassengerToMoveCommand2 = new SearchPassengerToMoveCommand(this, 2);
            Client = new HttpClient();
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadData()
        {
            try
            {
                var json = await Client.GetStringAsync(new Uri("http://localhost:5000/api/User/passengers"));
                var passengers = JsonConvert.DeserializeObject<IList<Model.Passenger>>(json);
                if(passengers.Count == 0)
                {
                    ErrorMessage = "There are no passengers available!";
                }
                foreach (var passenger in passengers)
                {
                    Passengers.Add(passenger);
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
        }

        public void SearchPassengerToMove(int pas)
        {
            try
            {
                if (pas == 1)
                {
                    Passenger1 = Passengers.FirstOrDefault(p => p.Seat == Seat1);
                    if(Passenger1 == null)
                    {
                        ErrorMessage = "There is no passenger on this seat!";
                    }
                    else
                    {
                        ErrorMessage = null;
                    }
                }
                else if (pas == 2)
                {
                    Model.Passenger ps = Passengers.FirstOrDefault(p => p.Seat == Seat2);
                    if (ps != null)
                    {
                        Passenger2 = ps;
                        ErrorMessage2 = null;
                    }
                    else
                    {
                        ErrorMessage2 = "There is no passenger on this seat! You can move the passenger to this seat.";
                    }
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
        }

        public async void SwitchSeats()
        {
            try
            {
                ChangeSeats changeSeats = new ChangeSeats() { Seat1 = Seat1, Seat2 = Seat2, TwoPassengers = CheckSeatPassengers() };
                var changeSeatsJson = JsonConvert.SerializeObject(changeSeats);
                var res = await Client.PostAsync(new Uri("http://localhost:5000/api/User/seats"), new HttpStringContent(changeSeatsJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    Switch();
                    ErrorMessage = null;
                }
                else
                {
                    ErrorMessage = res.StatusCode.ToString();
                }
            }
            catch(Exception)
            {
                ErrorMessage = "Something went wrong! Please try again later.";
            }
        }

        private bool CheckSeatPassengers()
        {
            if(Passenger1 == null || Passenger2 == null)
            {
                return false;
            }
            else{
                return true;
            }
        }

        private void Switch()
        {
            LoadData();
            Model.Passenger temp = Passenger1;
            Passenger1 = Passenger2;
            Passenger2 = temp;
        }
    }
}