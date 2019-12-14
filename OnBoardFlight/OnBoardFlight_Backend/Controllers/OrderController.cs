using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Data.DTO;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IPassengerRepository _passengerRepo;
        private readonly IProductRepository _productRepo;

        public OrderController(IOrderRepository orderRepository, IPassengerRepository passengerRepository, IProductRepository productRepository)
        {
            _orderRepo = orderRepository;
            _passengerRepo = passengerRepository;
            _productRepo = productRepository;
        }

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }
        [HttpGet]
        [Route("NotCompleted")]
        public IActionResult GetAllNotCompletedOrders()
        {
            IEnumerable<Order> orders = _orderRepo.GetAllNotCompletedOrders();
            return Ok(orders.Select(o => new OrderDTO(o)));
        }
        [HttpPost]
        [Route("Complete")]
        public IActionResult CompleteOrder(CompleteOrderDTO orderdto)
        {
            Order order = _orderRepo.GetOrderById(orderdto.OrderId);
            order.IsCompleted = true;
            _orderRepo.CompleteOrder(order);
            _orderRepo.SaveChanges();
            OrderDTO orderDTO = new OrderDTO(order);
            return Ok(orderDTO);
        }

        [Route("Seat")]
        [HttpGet]
        public IActionResult GetAllOrdersBySeat(string seat)
        {
            IEnumerable<Order> orders = _orderRepo.GetAllOrdersBySeat(seat);

            return Ok(orders.Select(o => new OrderDTO(o)));
        }
        [HttpPost]
        public IActionResult AddOrder(AddOrderDTO dto)
        {
            Passenger passenger = _passengerRepo.GetPassengerBySeat(dto.SeatNumber);
            if (passenger == null)
            {
                return BadRequest();
            }
            Order order = new Order(passenger, dto.Time);
            foreach (AddOrderlineDTO olDTO in dto.OrderlineDTOs)
            {
                Product product = _productRepo.GetProductById(olDTO.ProductId);
                if (product == null)
                {
                    return BadRequest();
                }
                Orderline ol = new Orderline(olDTO.Number, product, order);
                ol.CalculateTotalPrice();
                order.AddOrderline(ol);
            }
            order.CalculateTotalPrice();
            try
            {
                _orderRepo.AddOrder(order);
                _orderRepo.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(dto);
        }
    }
}