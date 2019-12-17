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
    public class OrderRepository : IOrderRepository
    { 

    private readonly ApplicationDbContext _dbContext;

    private readonly DbSet<Order> _orders;

    public OrderRepository(ApplicationDbContext context)
    {
        _dbContext = context;
        _orders = _dbContext.Orders;
    }
        public void AddOrder(Order order)
        {
            this._orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this._orders.ToList();
        }

        public IEnumerable<Order> GetAllOrdersBySeat(string seat)
        {
            IEnumerable<Order> orders = _orders.Where(o => o.SeatNumber == seat).Include(o => o.Orderlines).ThenInclude(o => o.Product).ToList();
            return orders;
        }
        public IEnumerable<Order> GetAllNotCompletedOrders()
        {
            IEnumerable<Order> orders = _orders.Where(o => o.IsCompleted == false).Include(o => o.Orderlines).ThenInclude(o => o.Product).ToList();
            return orders;
        }
        public void CompleteOrder(Order order)
        {
            _orders.Update(order);
        }


        public Order GetOrderById(int id)
        {
            return this._orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
