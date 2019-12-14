using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetAllNotCompletedOrders();
        IEnumerable<Order> GetAllOrdersBySeat(string seat);
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void SaveChanges();
    }
}
