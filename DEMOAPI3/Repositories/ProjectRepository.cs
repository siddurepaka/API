using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEMOAPI3.Models;

namespace DEMOAPI3.Repositories
{
    public class ProjectRepository
    {
        public List<Project>GetAll()
        {
            using (AssignmentDBContext db = new AssignmentDBContext())
            {
                return db.Project.ToList();
            }
        }
        public Project GetbyId(string pid)
        {
            using (AssignmentDBContext db = new AssignmentDBContext())
            {
                return db.Project.Find(pid);
            }

        }
        public void add(Project item)
        {
            using (AssignmentDBContext db = new AssignmentDBContext())
            {
                db.Project.Add(item);
                db.SaveChanges();
            }
        }
        public void delete(int pid)
        {
            using (AssignmentDBContext db = new AssignmentDBContext())
            {
                Project p = db.Project.Find(pid);
                db.Project.Remove(p);
                db.SaveChanges();
            }
        }
        public void Update(Project item)
        {
            using (AssignmentDBContext db = new AssignmentDBContext())
            {
                db.Project.Update(item);
                db.SaveChanges();
            }

        }
    }
}
