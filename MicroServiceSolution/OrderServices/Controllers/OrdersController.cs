using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Models;
using OrderServices.Repositories;


namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        public OrdersController(IOrderRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Getorders")]
        public IActionResult Get()
        {
            try
            {

                return Ok(_repo.GetAllOrders());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(string id)
        {
            try
            {

                return Ok(_repo.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
        [HttpPost]
        [Route("Addorder")]
        public IActionResult POST(Orders id)
        {
            try
            {
                _repo.Addorders(id);
                return Ok();//veredhi pettali
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
        [HttpPut]
        [Route("Updateorder")]
        public IActionResult PUT(Orders item)
        {
            try
            {
                _repo.Updateorders(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                _repo.Deleteorders(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

    }
}