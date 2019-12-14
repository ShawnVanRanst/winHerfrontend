using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Data.DTO;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public ChatController(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }
        /*
        [HttpGet("{id}")]
        public IActionResult GetChat(int id)
        {
            Chat chat = _chatRepository.GetChat(id);
            if(chat == null)
            {
                return NotFound();
            }
            return Ok(new ChatDTO(chat));
        }

    */
        [HttpPost()]
        public IActionResult UpdateChat(UpdateChatDTO updateChatDTO)
        {
            try
            {
                Passenger passenger = _userRepository.GetPassengerBySeat(updateChatDTO.Seat);
                Chat chat = _chatRepository.GetChat(updateChatDTO.Id);
                Message message = new Message(passenger, updateChatDTO.Content);
                chat.AddMessage(message);
                _chatRepository.UpdateChat(chat);
                _chatRepository.SaveChanges();
            }
            catch (Exception) { return NotFound(); };
            return Ok();
        }
    }
}