using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Chat> _chats;

        public ChatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _chats = _dbContext.Chats;
        }

        public Chat GetChat(int id)
        {
            return _chats.Include(c => c.Participants).Include(c => c.Messages).FirstOrDefault(c => c.ChatId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
