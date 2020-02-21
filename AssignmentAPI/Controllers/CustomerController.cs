using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       CustomerDB1Context db = new CustomerDB1Context();
        [HttpGet]
        public List<Customer> GetAll()
        {
            return db.Customer.ToList();
        }
        [HttpGet("{Cid}")]
        [Route("Getbyid/{id}")]
        public Customer GetById(string id)
        {
            return db.Customer.Find(id);
        }
        [HttpGet("{City}")]
        [Route("Getbycity/{id}")]
        public List<Customer> GetByName(string id)
        {
            return db.Customer.Where(p => p.City == id).ToList();
                }
        [HttpPost]
        [Route("Add")]
        public void add(Customer item)
        {
            db.Customer.Add(item);
            db.SaveChanges();
        }
        [HttpPost]
        [Route("Customer/{item}")]
        public void update(Customer item)
        {
            db.Customer.Find(item);
            db.Customer.Update(item);
            db.SaveChanges();
        }
    }
}