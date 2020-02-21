using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDBContext _context;
        public void AddItems(Orders obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(string id)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Orders GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Orders obj)
        {
            throw new NotImplementedException();
        }
    }
}
