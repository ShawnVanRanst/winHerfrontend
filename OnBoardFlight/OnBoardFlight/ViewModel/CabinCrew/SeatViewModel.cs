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

        public SearchPassengerToMoveCommand SearchPassengerToMoveCommand1{ get; set; }
        public SearchPassengerToMoveCommand SearchPassengerToMoveCommand2 { get; set; }
        public SwitchPlacesCommand SwitchPlacesCommand { get; set; }

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
            var json = await Client.GetStringAsync(new Uri("http://localhost:5000/api/User/passengers"));
            var passengers = JsonConvert.DeserializeObject<IList<Model.Passenger>>(json);
            foreach (var passenger in passengers)
            {
                Passengers.Add(passenger);
            }
        }

        public void SearchPassengerToMove(int pas)
        {
            if(pas == 1)
            {
                Passenger1 = Passengers.Where(p => p.Seat == Passenger1.Seat).FirstOrDefault();
            }
            if(pas == 2)
            {
                Model.Passenger ps = Passengers.Where(p => p.Seat == Passenger2.Seat).FirstOrDefault();
                if(ps != null)
                {
                    Passenger2 = ps;
                }
                else
                {
                    Passenger2.FirstName = null;
                    Passenger2.LastName = null;
                    // Update Message
                }
            }
        }

        public async void SwitchSeats()
        {
            ChangeSeats changeSeats = new ChangeSeats() { Seat1 = Passenger1.Seat, Seat2 = Passenger2.Seat, TwoPassengers = CheckSeatPassengers() };
            var changeSeatsJson = JsonConvert.SerializeObject(changeSeats);
            var res = await Client.PostAsync(new Uri("http://localhost:5000/api/User/seats"), new HttpStringContent(changeSeatsJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            if (res.IsSuccessStatusCode)
            {
                Switch();
                // show error
            }
        }

        private bool CheckSeatPassengers()
        {
            if(string.IsNullOrEmpty(Passenger1.FirstName) || string.IsNullOrEmpty(Passenger2.FirstName))
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