using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Notification> _notifications;

        public NotificationRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            _notifications = _dbContext.Notifications;
        }

        public void DeleteNotificationById(int id)
        {
            Notification notification = _notifications.FirstOrDefault(n => n.Id == id);
            _notifications.Remove(notification);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
