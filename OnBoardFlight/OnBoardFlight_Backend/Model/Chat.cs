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

        public ICollection<Passenger> Participants { get; set; }

        public ICollection<Message> Messages{ get; set; }


        #region Constructors
        public Chat()
        {
            Participants = new List<Passenger>();
            Messages = new List<Message>();
        }

        public Chat(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods

        public void AddParticipants(Passenger passenger)
        {
            Participants.Add(passenger);
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
        #endregion
    }
}
