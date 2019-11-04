using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShootTracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShootTracker.Controllers
{
    public class ShootController : Controller
    {
        // GET: /<controller>/
        public IActionResult ShotList()
        {
            ShotListRepository repo = new ShotListRepository();
            List<Shoot> shots = repo.GetAllShots();
            return View(shots);
        }

        public IActionResult Project()
        {
            ProjectRepository repo = new ProjectRepository();
            List<Project> projects = repo.GetProjects();
            return View(projects);
        }
    }
}