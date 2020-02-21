using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Repositories
{
    interface IOrderRepository
    {
        List<Orders> GetAllOrders();
        Orders GetById(string id);
        void AddItems(Orders obj);
        void DeleteItem(string id);
        void UpdateItem(Orders obj);

    }
}
