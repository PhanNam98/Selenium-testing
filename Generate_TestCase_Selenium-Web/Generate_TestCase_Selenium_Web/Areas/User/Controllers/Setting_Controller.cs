using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Generate_TestCase_Selenium_Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class Setting_Controller : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }

        public Setting_Controller(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }


        // GET: User/Setting_/Edit/5
        public async Task<IActionResult> Setting()
        {

            var user = await _userManager.GetUserAsync(User);
            var SettingDBContext = await _context.Setting_.Where(p => p.Id_User == user.Id).SingleOrDefaultAsync();
            if (StatusMessage == null)
            {

            }
            else
            {
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
            }
            ViewData["Browsers"] = new List<SelectListItem>
            {
                 new SelectListItem {Text = "Chrome", Value = "chrome"},
                new SelectListItem {Text = "FireFox", Value = "firefox"}
                };
            return View(SettingDBContext);
        }

        // POST: User/Setting_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Setting([Bind("Id_User,Browser,SendResultToMail")] Setting_ setting_)
        {

            if (ModelState.IsValid)
            {
                ViewData["Browsers"] = new List<SelectListItem>
            {
                 new SelectListItem {Text = "Chrome", Value = "chrome"},
                new SelectListItem {Text = "FireFox", Value = "firefox"}
                };
                try
                {
                    _context.Update(setting_);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Update successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Setting_Exists(setting_.Id_User))
                    {
                        return NotFound();
                    }
                    //else
                    //{
                    //    throw;
                    //}
                    StatusMessage = "Update failed";
                }
                //return RedirectToAction(nameof(Index));
                return View(setting_);
            }
            StatusMessage = "Update failed";
            ViewData["Message"] = StatusMessage;
            TempData.Remove(StatusMessage);
            return View(setting_);
        }


        private bool Setting_Exists(string id)
        {
            return _context.Setting_.Any(e => e.Id_User == id);
        }
    }
}
