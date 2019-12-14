using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Data.IRepository;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            try
            {
                _notificationRepository.DeleteNotificationById(id);
                _notificationRepository.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}