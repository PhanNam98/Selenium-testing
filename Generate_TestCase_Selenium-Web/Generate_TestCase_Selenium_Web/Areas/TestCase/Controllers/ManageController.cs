using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Routing;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class ManageController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }
        public ManageController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }
        #region Project
        //Get list project
        [Route("/Manage/Projects")]
        public async Task<IActionResult> Projects()
        {
            var user = await _userManager.GetUserAsync(User);
            var elementDBContext = await _context.Project.Include(p => p.Id_UserNavigation).Where(p => p.Id_User == user.Id).ToListAsync();
            if (StatusMessage == null)
            {
                if (elementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No projects yet, create a new one";
                }
                else
                if (elementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("Found {0} projects", elementDBContext.Count());
                }
                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            else
            {
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
            }
            return View(elementDBContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(string projectName, string description)
        {
            Project project = new Project();
            if (ModelState.IsValid)
            {
                try
                {
                    project.description = description;
                    var user = await _userManager.GetUserAsync(User);
                    project.Id_User = user.Id;
                    project.name = projectName;
                    project.CreatedDate = DateTime.Now.Date;
                    project.ModifiedDate = DateTime.Now.Date;
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Add successfully";
                }
                catch
                {

                    StatusMessage = "Add project failed";
                }
                //return RedirectToAction("AddNewUrl", "Urls", new RouteValueDictionary(new { project_id = project.id }));
            }
            return RedirectToAction(nameof(Projects));

        }
        #endregion

        #region Url
        //Get list url
        [Route("/Manage/Urls/")]
        public async Task<IActionResult> Urls(int project_id)
        {
            var user = await _userManager.GetUserAsync(User);
            var elementDBContext = await _context.Url.Include(p => p.project_).Include(p=>p.Test_case).Include(p=>p.Element).Where(p => p.project_.Id_User == user.Id && p.project_id == project_id).OrderByDescending(p=>p.ModifiedDate).ToListAsync();
            if (StatusMessage == null)
            {
                if (elementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No url yet, create a new one";
                }
                else
                if (elementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("Found {0} url", elementDBContext.Count());
                }
                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            else
            {
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
            }
            ViewData["project_id"] = project_id;
            return View(elementDBContext);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUrl(string name, string url1, int project_id, bool IsOnlyDislayed)
        {
            Url url = new Url();
            try
            {
                url.name = name;
                url.project_id = project_id;
                url.url1 = url1;
                url.CreatedDate = DateTime.Now.Date;
                url.ModifiedDate = DateTime.Now.Date;
                _context.Add(url);
                await _context.SaveChangesAsync();
                StatusMessage = "Add successful url";

                // return RedirectToAction("CrawlElt", "CrawlElements", new RouteValueDictionary(new { id_url = url.id_url, IsOnlyDislayed = IsOnlyDislayed }));
            }
            catch
            {

            }

            StatusMessage = "Add failed";
            return RedirectToAction(nameof(Urls), new { project_id = project_id });


            //return RedirectToAction("CrawlElt", "CrawlElements", new RouteValueDictionary(new { id_url = 1, IsOnlyDislayed = IsOnlyDislayed }));
        }
        #endregion

        #region
        [Route("/Manage/Elements/")]
        public async Task<IActionResult> Elements(int id_url)
        {
            var user = await _userManager.GetUserAsync(User);
            var listelt =await _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == user.Id).ToListAsync();
            if (listelt.Count > 0)
            {
                //var listelt = await _context.Element.Where(p => p.id_url == id_url).ToListAsync();
                if (StatusMessage == null)
                {
                    if (listelt.Count() == 0)
                    {
                        ViewData["Message"] = "No elements yet";
                    }
                    else
                    if (listelt.Count() > 0)
                    {
                        ViewData["Message"] = String.Format("Found {0} elements", listelt.Count());
                    }
                    else
                    {
                        ViewData["Message"] = "Error load data";
                    }
                }
                else
                {
                    ViewData["Message"] = StatusMessage;
                    TempData.Remove(StatusMessage);
                }
                ViewData["id_url"] = id_url;
                ViewData["project_id"] = listelt.FirstOrDefault().id_urlNavigation.project_.id;
                return View(listelt);
            }
            return NotFound();
            
        }
        public async Task<IActionResult> DeleteElts(int id_url, IEnumerable<string> eltId_Delete)
        {
            if (eltId_Delete == null)
            {
                return NotFound();
            }
            try
            {
                foreach (var id in eltId_Delete)
                {
                    var element = await _context.Element.Where(p => p.id_element == id && p.id_url == id_url).FirstOrDefaultAsync();
                    _context.Element.RemoveRange(element);
                }
                await _context.SaveChangesAsync();
                StatusMessage = "Delete successfully";
            }
            catch
            {
                StatusMessage = "Delete fail";
            }
            return RedirectToAction(nameof(Elements), new RouteValueDictionary(new
            {
                id_url = id_url

            }));
        }

        #endregion
    }
}