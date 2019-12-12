using OnBoardFlight_Backend.Model.ManyToManies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Passenger : User
    {

        #region Properties

        public string Seat { get; set; }

        #endregion

        #region Collections
        public ICollection<Passenger> TravelCompany { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<PassengerChat> ChatList{ get; set; }

        public ICollection<Notification> Notifications { get; set; }
        #endregion

        #region Constructors

        public Passenger()
        {
            TravelCompany = new List<Passenger>();
            Orders = new List<Order>();
            ChatList = new List<PassengerChat>();
            Notifications = new List<Notification>();
        }

        public Passenger(string firstName, string lastName, string seat)
        {
            TravelCompany = new List<Passenger>();
            Orders = new List<Order>();
            ChatList = new List<PassengerChat>();
            Notifications = new List<Notification>();
            FirstName = firstName;
            LastName = lastName;
            Seat = seat;
        }


        #endregion

        #region Methods
        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
        #endregion
    }
}
