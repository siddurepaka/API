using OrderServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Repositories
{
   public interface IOrderRepository
    {
        List<Orders> GetAllOrders();
        Orders GetById(string id);
        void Addorders(Orders obj);
        void Deleteorders(string id);
        void Updateorders(Orders obj);
    }
}
