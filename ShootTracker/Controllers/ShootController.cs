using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShootTracker.Models;

namespace ShootTracker.Controllers
{
    public class ShootController : Controller
    {
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

        public IActionResult InsertProjectToDatabase(Project projectToInsert)
        {
            var repo = new ProjectRepository();
            repo.CreateProject(projectToInsert);

            return RedirectToAction("Project");
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        public IActionResult DeleteProject(int projectToDelete)
        {
            var repo = new ProjectRepository();
            repo.DeleteProject(projectToDelete);

            return RedirectToAction("Project");
        }
    }
}