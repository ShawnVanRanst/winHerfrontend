using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace OnBoardFlight_Backend.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _users = _dbContext.Users;
        }

        public Passenger GetPassengerById(int id)
        {
            return (Passenger)_users.FirstOrDefault(p => p.UserId == id);
        }


        public Passenger GetPassengerBySeat(string seat)
        {
            return (Passenger)_users.Include(p => (p as Passenger).TravelCompany).Include(p => (p as Passenger).ChatList).Include(p => (p as Passenger).Orders).FirstOrDefault(p => (p as Passenger).Seat.Equals(seat));
        }

        public IEnumerable<User> GetPassengers()
        {
            return _users.Where(u => u.GetType() == typeof(Passenger)).ToList();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _users.Update(passenger);
        }

        public void ChangeSeats(Passenger passenger1, Passenger passenger2)
        {
            string seatPassenger1 = passenger1.Seat;
            string seatPassenger2 = passenger2.Seat;
            passenger1.Seat = seatPassenger2;
            passenger2.Seat = seatPassenger1;
            _users.Update(passenger1);
            _users.Update(passenger2);

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public User GetCabinCrewByCredentials(string login, string pass)
        {

            return _users.FirstOrDefault(u => u.Login == login && u.Pass == pass);
        }
    }
}
