using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Generate_TestCase_Selenium_Web.Areas.Adminitrator.Controllers
{
    [Area("Adminitrator")]
    //[Authorize(Roles = "Adminitrator")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}