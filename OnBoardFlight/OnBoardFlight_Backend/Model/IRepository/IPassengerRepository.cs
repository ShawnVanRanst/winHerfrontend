using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.IRepository
{
    interface IPassengerRepository
    {

        IEnumerable<Passenger> GetPassengers();

        Passenger GetPassengerBySeat(string seat);

        void UpdatePassenger(Passenger passenger);

        void SaveChanges();

        
    }
}
