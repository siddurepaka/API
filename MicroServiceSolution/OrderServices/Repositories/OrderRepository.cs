using OrderServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDBContext _context;
        public OrderRepository(ShopDBContext context)
        {
            _context = context;
        }
        public void Addorders(Orders obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public void Deleteorders(string id)
        {
            _context.Remove(id);
            _context.SaveChanges();

        }

        public List<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Orders GetById(string id)
        {
            return _context.Orders.Find(id);
        }

        public void Updateorders(Orders obj)
        {
            _context.Orders.Update(obj);
            _context.SaveChanges();
        }
    }
}
