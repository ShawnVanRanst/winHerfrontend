using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Passenger : User
    {

        #region Properties

        #endregion

        #region Collections
        public ICollection<Passenger> TravelCompany { get; set; }

        public ICollection<Order> Orders { get; set; }
        #endregion

        #region Constructors

        public Passenger()
        {
            TravelCompany = new List<Passenger>();
        }

        public Passenger(string login)
        {
            Login = login;
        }
        #endregion
    }
}
