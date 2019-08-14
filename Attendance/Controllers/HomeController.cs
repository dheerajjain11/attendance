using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet("~/")]
        [Authorize(Roles = "User")]       
        public IActionResult Index()
        {
            Console.WriteLine("Inside Home Controller Index");
            return null;
        }
    }
}