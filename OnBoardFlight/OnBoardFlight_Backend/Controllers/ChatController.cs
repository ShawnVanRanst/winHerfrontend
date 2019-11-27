using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.IRepository;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;

        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Chat> GetChat(int id)
        {
            Chat chat = _chatRepository.GetChat(id);
            if(chat == null)
            {
                return NotFound();
            }
            return chat;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChat(int id, Chat chat)
        {
            if(id != chat.ChatId)
            {
                return BadRequest();
            }
            _chatRepository.UpdateChat(chat);
            _chatRepository.SaveChanges();
            return NoContent();
        }
    }
}