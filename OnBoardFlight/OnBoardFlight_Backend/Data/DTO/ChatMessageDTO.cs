using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class ChatMessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public string Sender { get; set; }

        public ChatMessageDTO(Message message, string seat)
        {
            Id = message.MessageId;
            Content = message.Content;
            SendDate = message.SendDate;
            if(message.Sender.Seat == seat)
            {
                Sender = "You";
            }
            else
            {
                Sender = message.Sender.FirstName;
            }
        }
    }
}
