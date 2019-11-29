using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IChatRepository
    {

        Chat GetChat(int id);

        void UpdateChat(Chat chat);

        void SaveChanges();
    }
}
