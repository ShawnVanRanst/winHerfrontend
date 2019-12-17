using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface INotificationRepository
    {
        void DeleteNotificationById(int id);
        void SaveChanges();
    }
}
