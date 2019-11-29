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

        public string Name { get; set; }

        public ICollection<PassengerChat> Participants { get; set; } = new List<PassengerChat>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();


        #region Constructors
        public Chat()
        {
        }

        public Chat(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods

        public void AddParticipants(Passenger passenger)
        {
            Participants.Add(new PassengerChat(passenger, this));
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
            #endregion
        }
}
