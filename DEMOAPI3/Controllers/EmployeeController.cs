using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEMOAPI3.Models;
using DEMOAPI3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEMOAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository repository = new EmployeeRepository();
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }
        [HttpGet]
        [Route("GetbyId/{id}")]
        public IActionResult GetbyId(string id)
        {
            return Ok(repository.GetbyId(id));
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Employee item)
        {
            repository.add(item);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Employee item)
        {
            repository.Update(item);
            return Ok();

        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            repository.delete(id);
            return Ok("record Deleted");
        }
    }
}