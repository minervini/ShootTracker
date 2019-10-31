using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShootTracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShootTracker.Controllers
{
    public class TestShootController : Controller
    {
        // GET: /<controller>/
        public IActionResult ShotList()
        {
            ShotListRepository repo = new ShotListRepository();
            List<TestShoot> shots = repo.GetAllShots();
            return View(shots);
        }
    }
}