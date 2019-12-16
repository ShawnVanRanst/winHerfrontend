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
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ChatMessageDTO> Messages { get; set; }

        public int MyProperty { get; set; }

        public ChatDTO(Chat chat, string name, string seat)
        {
            Id = chat.ChatId;
            Name = name;
            Messages = chat.Messages.Select(m => new ChatMessageDTO(m, seat)).OrderBy(m => m.SendDate).ToList();
        }
    }
}
