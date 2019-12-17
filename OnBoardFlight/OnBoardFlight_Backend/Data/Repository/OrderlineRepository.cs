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
    public class OrderlineRepository : IOrderlineRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Orderline> _orderlines;

        public OrderlineRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _orderlines = _dbContext.Orderlines;
        }
        public void AddOrderline(Orderline orderline)
        {
            this._orderlines.Add(orderline);
        }

        public IEnumerable<Orderline> GetAllOrderlines()
        {
            return _orderlines.ToList();
        }

        public Orderline GetOrderlineById(int id)
        {
            return this._orderlines.FirstOrDefault(o => o.OrderlineId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
