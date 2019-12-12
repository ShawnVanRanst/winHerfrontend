using OnBoardFlight_Backend.Model.ManyToManies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Chat
    {

        public int ChatId { get; set; }

        public ICollection<PassengerChat> Participants { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<Passenger> ChatMembers => Participants.Select(p => p.Passenger).ToList();


        #region Constructors

        public Chat()
        {
            Messages = new List<Message>();
            Participants = new List<PassengerChat>();
        }
        #endregion

        #region Methods

        public void AddParticipants(PassengerChat passengerChat)
        {
            Participants.Add(passengerChat);
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
            #endregion
        }
}
