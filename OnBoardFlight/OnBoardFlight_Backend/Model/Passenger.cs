using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Passenger : User
    {

        #region Properties

        public int PassengerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Seat { get; set; }

        #endregion

        #region Collections
        public ICollection<Passenger> TravelCompany { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Chat> ChatList{ get; set; }
        #endregion

        #region Constructors

        public Passenger()
        {
            TravelCompany = new List<Passenger>();
            Orders = new List<Order>();
            ChatList = new List<Chat>();
        }

        public Passenger(string firstName, string lastName, string seat)
        {
            FirstName = firstName;
            LastName = lastName;
            Seat = seat;
        }


        #endregion

        #region Methods
        #endregion
    }
}
