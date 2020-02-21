using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItemService.Repositories;
using ItemService.Controllers;
using ItemService.Models;

namespace ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
         private readonly IItemRepository _repo;
            public ItemsController(IItemRepository repo)
            {
                _repo = repo;
            }
            [HttpGet]
            [Route("GetItems")]
            public IActionResult Get()
            {
                try
                {
                    
                    return Ok(_repo.GetAllItems());
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
            [Route("Additem")]
            public IActionResult POST(Items id)
            {
                try
                {
                    _repo.AddItems(id);
                    return Ok();//veredhi pettali
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);

                }
            }
            [HttpPut]
            [Route("UpdateItem")]
            public IActionResult PUT(Items item)
            {
                try
                {
                    _repo.UpdateItem(item);
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
                    _repo.DeleteItem(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);

                }
            }
        }
    }
