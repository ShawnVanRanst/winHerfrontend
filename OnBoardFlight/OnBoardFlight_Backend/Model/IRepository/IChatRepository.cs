using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.IRepository
{
    public interface IChatRepository
    {

        Chat GetChat(int id);

        void SaveChanges();
    }
}
