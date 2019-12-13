using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }
        [HttpGet]
        [Route("Order/{seat}")]
        public IEnumerable<Order> GetAllOrdersBySeat(string seat)
        {
            return _orderRepo.GetAllOrdersBySeat(seat);
        }
        //[HttpGet]
        //[Route("Order/{id}")]
        //public ActionResult<Order> GetOrderById(int id)
        //{
        //    return _orderRepo.GetOrderById(id);
        //}
    }
}