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
    public class SeatViewModel: INotifyPropertyChanged
    {

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
            get { return _passenger1; }
            set
            {
                _passenger1 = value;
                RaisePropertyChanged("Passenger2");
            }
        }

        private string _seatNumber1;

        public string SeatNumber1
        {
            get { return _seatNumber1; }
            set {
                _seatNumber1 = value;
                RaisePropertyChanged("SeatNumber1");
            }
        }


        private string _seatNumber2;

        public string SeatNumber2
        {
            get { return _seatNumber2; }
            set
            {
                _seatNumber2 = value;
                RaisePropertyChanged("SeatNumber2");
            }
        }



        public SearchPassengerToMoveCommand SearchPassengerToMoveCommand{ get; set; }

        public SearchPassengerToMoveCommand SearchPassengerToChangePlacesCommand { get; set; }



        public SeatViewModel()
        {
            SearchPassengerToMoveCommand = new SearchPassengerToMoveCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void SearchPassengerToMove()
        {
            //Backend call
        }

        public void SearchPassengerToChangePlaces()
        {
            //Backend call
            //Check if there is a passenger on this seat
        }

        public void SwitchSeats()
        {
            //Backend call
            //Check if there is a second passenger
                // NO => Passenger 1 gets new seat
                // YES => Passengers switch places
        }
    }
}
