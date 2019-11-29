using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.ManyToManies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class PassengerDTO
    {

        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Seat { get; set; }

        public ICollection<Passenger> TravelCompany { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<int> ChatIds { get; set; }
        #endregion

        #region Constructor

        public PassengerDTO(Passenger passenger)
        {
            FirstName = passenger.FirstName;
            LastName = passenger.LastName;
            Seat = passenger.Seat;
            TravelCompany = passenger.TravelCompany;
            Orders = passenger.Orders;
            ChatIds = GetChatIds(passenger.ChatList);
        }
        #endregion

        #region Methods

        private ICollection<int> GetChatIds(ICollection<PassengerChat> passengerChats)
        {
            ICollection<int> idList = new List<int>();
            foreach(PassengerChat p in passengerChats)
            {
                idList.Add(p.ChatId);
            }
            return idList;
        }
        #endregion
    }
}
