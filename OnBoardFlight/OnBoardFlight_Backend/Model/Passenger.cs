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

        public ICollection<Chat> Chats => ChatList.Select(cl => cl.Chat).ToList();
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

        public void AddChat(PassengerChat passengerChat)
        {
            ChatList.Add(passengerChat);
        }

        public void AddTravelCompanion(Passenger passenger)
        {
            Chat chat = new Chat();
            PassengerChat passengerChat1 = new PassengerChat(this, chat, passenger.FirstName + " " + passenger.LastName);
            AddChat(passengerChat1);
            chat.AddParticipants(passengerChat1);

            PassengerChat passengerChat2 = new PassengerChat(passenger, chat, FirstName + " " + LastName);
            passenger.AddChat(passengerChat2);
            chat.AddParticipants(passengerChat2);
        }

        /*
        // Adds a self made chat to his chat list existing of travel company members
        public void AddTravelCompanyChat(List<Passenger> chatMembers, string chatName)
        {
            Chat chat = new Chat()
            {
                Messages = new List<Message>(),
                Name = chatName,
                Participants = chatMembers.Select(cm => cm)
            };

            AddChat(chat);

            chatMembers.ForEach(m => m.AddChat(chat));
        }
        */
        #endregion
    }
}
