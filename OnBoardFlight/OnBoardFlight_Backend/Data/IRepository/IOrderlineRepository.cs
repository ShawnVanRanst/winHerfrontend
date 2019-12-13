using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IOrderlineRepository
    {
        IEnumerable<Orderline> GetAllOrderlines();
        Orderline GetOrderlineById(int id);
        void AddOrderline(Orderline orderline);
        void SaveChanges();
    }
}
