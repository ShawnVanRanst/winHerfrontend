using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IPassengerRepository
    {

        IEnumerable<Passenger> GetPassengers();

        Passenger GetPassengerById(int id);

        Passenger GetPassengerBySeat(string seat);

        void UpdatePassenger(Passenger passenger);

        void ChangeSeats(Passenger passenger1, Passenger passenger2);

        void SaveChanges();

        
    }
}
