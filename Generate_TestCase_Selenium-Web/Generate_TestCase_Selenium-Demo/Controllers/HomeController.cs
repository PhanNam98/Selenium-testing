using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Generate_TestCase_Selenium_Demo.Models;

namespace Generate_TestCase_Selenium_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Index2()
        {
            var watch = new Stopwatch();
            watch.Start();
            var a = GetAsync();
            var aq =  GetAsync1();
            var ar =  GetAsync2();
            var ae =  GetAsync3();
            var content = await a;
            var count = await aq;
            var name = await ar;
            var name1 = await ae;
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }
        
        public async Task<string> GetAsync()
        {
            await Task.Delay(30000); //Use - when you want a logical delay without blocking the current thread.  
            return "joker";
        } public async Task<string> GetAsync1()
        {
            await Task.Delay(60000); //Use - when you want a logical delay without blocking the current thread.  
            return "joker";
        } public async Task<string> GetAsync2()
        {
            await Task.Delay(40000); //Use - when you want a logical delay without blocking the current thread.  
            return "joker";
        } public async Task<string> GetAsync3()
        {
            await Task.Delay(50000); //Use - when you want a logical delay without blocking the current thread.  
            return "joker";
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
