using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.ManyToManies
{
    public class PassengerChat
    {

        #region Properties
        public int PassengerChatId { get; set; }

        public int PassengerId { get; set; }

        public int ChatId { get; set; }

        public string Name { get; set; }
        #endregion

        #region Navigational properties

        public Passenger Passenger { get; set; }

        public Chat Chat { get; set; }


        #endregion

        #region Constructors

        public PassengerChat()
        {

        }

        public PassengerChat(Passenger passenger, Chat chat, string name)
        {
            Passenger = passenger;
            PassengerId = Passenger.UserId;
            Chat = chat;
            ChatId = Chat.ChatId;
            Name = name;
        }
        #endregion
    }
}
