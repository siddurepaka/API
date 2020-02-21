using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEMOAPI3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEMOAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ProjectRepository repository = new ProjectRepository();
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
    }
}