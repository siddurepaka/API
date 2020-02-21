using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDEMO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        PracticeDBContext db = new PracticeDBContext();
        [HttpGet]
        public List<Project2> GetAll()
        {
            return db.Project2.ToList();
        }
        [HttpGet("{ProjectNo}")]
        [Route("Getbyid/{id}")]
        public Project2 GetById(string id)
        {
            return db.Project2.SingleOrDefault(p=>p.ProjectNo==id);
        }
        [HttpGet("{ProjectName}")]
        [Route("Getbyname/{name}")]
        public Project2 GetByName(string name)
        {
            return db.Project2.SingleOrDefault(p=>p.ProjectName==name);
        }
        [HttpPost]
        [Route("AddProduct")]
        public void add(Project2 item)
        {
            db.Project2.Add(item);
            db.SaveChanges();
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(string id)
        {
            Project2 p = db.Project2.SingleOrDefault(p=>p.ProjectNo==id);
            db.Remove(p);
            db.SaveChanges();
        }
        [HttpPut]
        [Route("Update/{id}")]
        public void update(string id)
        {
            Project2 p = db.Project2.SingleOrDefault(p=>p.ProjectNo==id);
            db.Project2.Update(p);
            db.SaveChanges();

        }
    }
}