using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generate_TestCase_Selenium_Web.Models;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Generate_TestCase_Selenium_Web.Areas.Adminitrator.Controllers
{
    [Area("Adminitrator")]
    [Authorize(Roles = "Adminitrator")]
    public class AdminController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }
        #region Dashboard
        [Route("/Admin/Dashboard")]
        public async Task<IActionResult> Dashboard()
        { 
            var listProject = await _context.Project.ToListAsync();
            var listurl = await _context.Url.Include(p => p.project_).ThenInclude(p => p.Id_UserNavigation).ToListAsync();
            var listestcase = await _context.Test_case.Include(p => p.id_urlNavigation).ThenInclude(p => p.project_).ToListAsync();
            var listresult = await _context.Result_testcase.Include(i => i.id_resultNavigation).ToListAsync();
            var listschdule = await _context.Test_schedule.ToListAsync();
            var listUser = await _context.AspNetUsers.Where(p=>p.IsAdmin==false).ToListAsync();

            ViewData["CountProjects"] = listProject.Count();
            ViewData["CountUrls"] = listurl.Count();
            ViewData["CountTestcases"] = listestcase.Count();
            ViewData["CountResult"] = listresult.Count();
            ViewData["CountSchedule"] = listschdule.Count();
            ViewData["CountUser"] = listUser.Count();
            return View();
        }
        #endregion
        public async Task<IActionResult> Config()
        {

            var user = await _userManager.GetUserAsync(User);
            var SettingDBContext = await _context.ConfigWeb.FirstOrDefaultAsync();
            if (StatusMessage == null)
            {

            }
            else
            {
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
            }
            return View(SettingDBContext);
        }

        // POST: User/Setting_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Configweb([Bind("id,number_of_test_cases_running_concurrently,number_of_urls_per_user")] ConfigWeb config_)
        {

            if (ModelState.IsValid)
            {
               
                try
                {
                    _context.Update(config_);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Update successfully";
                    return RedirectToAction("Config");
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                    
                }
                //return RedirectToAction(nameof(Index));

            }
            StatusMessage = "Update failed";
            ViewData["Message"] = StatusMessage;
            TempData.Remove(StatusMessage);
            return RedirectToAction("Config");
        }
    }
}