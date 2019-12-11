using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IUserRepository
    {

        IEnumerable<User> GetPassengers();

        Passenger GetPassengerById(int id);

        Passenger GetPassengerBySeat(string seat);

        void UpdatePassenger(Passenger passenger);

        void ChangeSeats(Passenger passenger1, Passenger passenger2);

        User GetCabinCrewByCredentials(string login, string password);

        void SaveChanges();

        
    }
}
