using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Passenger> _passengers;

        public PassengerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _passengers = _dbContext.Passengers;
        }

        public Passenger GetPassengerById(int id)
        {
            return _passengers.FirstOrDefault(p => p.UserId == id);
        }


        public Passenger GetPassengerBySeat(string seat)
        {
            return _passengers.Include(p => p.TravelCompany).Include(p => p.ChatList).Include(p => p.Orders).FirstOrDefault(p => p.Seat.Equals(seat));
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return _passengers.ToList();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _passengers.Update(passenger);
        }

        public void ChangeSeats(Passenger passenger1, Passenger passenger2)
        {
            string seatPassenger1 = passenger1.Seat;
            string seatPassenger2 = passenger2.Seat;
            passenger1.Seat = seatPassenger2;
            passenger2.Seat = seatPassenger1;
            _passengers.Update(passenger1);
            _passengers.Update(passenger2);

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
