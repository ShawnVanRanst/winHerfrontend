using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.ManyToManies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class ChatDTO
    {

        public string Name { get; set; }

        public ICollection<int> PassengerIds { get; set; }

        public ICollection<Message> Messages { get; set; }


        public ChatDTO(Chat chat)
        {
            Name = chat.Name;
            PassengerIds = GetPassengerIds(chat.Participants);
            Messages = chat.Messages;
        }

        private ICollection<int> GetPassengerIds(ICollection<PassengerChat> passengerChats)
        {
            ICollection<int> idList = new List<int>();
            foreach(PassengerChat p in passengerChats)
            {
                idList.Add(p.PassengerId);
            }
            return idList;
        }
    }
}
