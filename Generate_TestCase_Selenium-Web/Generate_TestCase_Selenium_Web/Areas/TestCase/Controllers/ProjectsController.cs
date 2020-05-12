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
    public class ProjectsController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProjectsController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }
        
        // GET: TestCase/Projects
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var elementDBContext =await _context.Project.Include(p => p.Id_UserNavigation).Where(p=>p.Id_User== user.Id).ToListAsync();
            if (elementDBContext.Count() == 0)
            {
                ViewData["Message"] = "No projects yet, create a new one";
            }
            else
            if (elementDBContext.Count() > 0)
            {
                
            }
            
            else
            {
                ViewData["Message"] = "Error load data";
            }
            return View(elementDBContext);
        }

        // GET: TestCase/Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Id_UserNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: TestCase/Projects/Create
        public IActionResult Create()
        {
            ViewData["Id_User"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: TestCase/Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Id_User,name,description,CreatedDate,ModifiedDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatedDate = DateTime.Now.Date;
                project.ModifiedDate = DateTime.Now.Date;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_User"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.Id_User);
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(string projectName, string description)
        {
            Project project = new Project();
            if (ModelState.IsValid)
            {

                project.description = description;
                var user = await _userManager.GetUserAsync(User);
                project.Id_User = user.Id;
                project.name = projectName;
                project.CreatedDate = DateTime.Now.Date;
                project.ModifiedDate = DateTime.Now.Date;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddNewUrl", "Urls", new RouteValueDictionary(new { project_id = project.id }));
            }
            return RedirectToAction(nameof(Index));
            
        }

        // GET: TestCase/Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["Id_User"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.Id_User);
            return View(project);
        }

        // POST: TestCase/Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Id_User,name,description,CreatedDate,ModifiedDate")] Project project)
        {
            if (id != project.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_User"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.Id_User);
            return View(project);
        }

        // GET: TestCase/Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Id_UserNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: TestCase/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.id == id);
        }
    }
}
