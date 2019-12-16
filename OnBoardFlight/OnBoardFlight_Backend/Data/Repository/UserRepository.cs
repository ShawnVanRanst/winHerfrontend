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
            return (Passenger)_users.Where(u => u.GetType() == typeof(Passenger)).Include(p => (p as Passenger).TravelCompany).Include(p => (p as Passenger).ChatList).Include(p => (p as Passenger).Orders).Include(p => (p as Passenger).Notifications).Include(p => p.Flight).ThenInclude(f => f.Origin).Include(p => p.Flight).ThenInclude(f => f.Destination).FirstOrDefault(p => (p as Passenger).Seat.Equals(seat));
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
            return _users.Include(u => u.Flight).ThenInclude(f => f.Origin).Include(u => u.Flight).ThenInclude(f => f.Destination).FirstOrDefault(u => u.Login == login && u.Pass == pass);
        }

        public User GetCabinCrewByLogin(string login)
        {
            return _users.Include(u => u.Flight).ThenInclude(f => f.Origin).Include(u => u.Flight).ThenInclude(f => f.Destination).FirstOrDefault(u => u.Login == login);
        }

        public IEnumerable<Notification> GetNotificationByPassengerSeat(string seat)
        {
            return (_users.Where(u => u.GetType() == typeof(Passenger)).Include(u => (u as Passenger).Notifications).FirstOrDefault(u => (u as Passenger).Seat == seat) as Passenger).Notifications.ToList();
        }

        public Passenger GetPassengerChatBySeat(string seat)
        {
            return (Passenger)
                    _users.Where(u => u.GetType() == typeof(Passenger))
                    .Include(u => (u as Passenger).ChatList).ThenInclude(cl => cl.Chat).ThenInclude(c => c.Participants).ThenInclude(p => p.Passenger)
                    .Include(u => (u as Passenger).ChatList).ThenInclude(cl => cl.Chat).ThenInclude(c => c.Messages).ThenInclude(m => m.Sender)
                    .FirstOrDefault(u => (u as Passenger).Seat == seat);
        }
    }
}
