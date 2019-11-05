using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    class Passenger : INotifyPropertyChanged
    {
        private int seatNumber;

        public int SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; RaisePropertyChanged("SeatNumber"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged("Password"); }
        }


        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;


        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
