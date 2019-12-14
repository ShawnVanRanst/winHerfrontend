using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class UpdateChatDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Seat { get; set; }
    }
}
