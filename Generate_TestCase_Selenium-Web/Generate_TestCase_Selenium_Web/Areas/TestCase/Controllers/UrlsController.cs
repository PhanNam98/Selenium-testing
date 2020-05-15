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
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class UrlsController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UrlsController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }
       
        // GET: TestCase/Urls
        public async Task<IActionResult> Index()
        {
            var elementDBContext = _context.Url.Include(u => u.project_);
            //var a = elementDBContext.SingleOrDefaultAsync().Result.project_.Id_User;
            return View(await elementDBContext.ToListAsync());
        }
        // GET: TestCase/Urls/AddNewUrl
       
        public IActionResult AddNewUrl(int project_id)
        {

            ViewData["project_id"] = project_id;
            ViewData["LoadingTitle"] = "Crawling data, please wait.";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUrl(string name, string url1, int project_id, bool IsOnlyDislayed)
        {
            //Url url = new Url();
            //if (ModelState.IsValid)
            //{
            //    url.name = name;
            //    url.project_id = project_id;
            //    url.url1 = url1;
            //    url.CreatedDate = DateTime.Now.Date;
            //    url.ModifiedDate = DateTime.Now.Date;
            //    _context.Add(url);
            //    await _context.SaveChangesAsync();
            //    ViewData["LoadingTitle"] = "Crawling data, please wait.";

            //    return RedirectToAction("CrawlElt", "CrawlElements", new RouteValueDictionary(new { id_url = url.id_url, IsOnlyDislayed = IsOnlyDislayed }));

            //}
            //ViewData["Message"] = "Error";
            //return View(url);


            return RedirectToAction("CrawlElt", "CrawlElements", new RouteValueDictionary(new { id_url = 1, IsOnlyDislayed = IsOnlyDislayed }));
        }
      



        /*
        // GET: TestCase/Urls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = await _context.Url
                .Include(u => u.project_)
                .FirstOrDefaultAsync(m => m.id_url == id);
            if (url == null)
            {
                return NotFound();
            }

            return View(url);
        }

        // GET: TestCase/Urls/Create
        public IActionResult Create()
        {
            ViewData["project_id"] = new SelectList(_context.Project, "id", "Id_User");
            return View();
        }

        // POST: TestCase/Urls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_url,name,url1,project_id,CreatedDate,ModifiedDate")] Url url)
        {
            if (ModelState.IsValid)
            {
                _context.Add(url);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["project_id"] = new SelectList(_context.Project, "id", "Id_User", url.project_id);
            return View(url);
        }
       

       

        // GET: TestCase/Urls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = await _context.Url.FindAsync(id);
            if (url == null)
            {
                return NotFound();
            }
            ViewData["project_id"] = new SelectList(_context.Project, "id", "Id_User", url.project_id);
            return View(url);
        }

        // POST: TestCase/Urls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_url,name,url1,project_id,CreatedDate,ModifiedDate")] Url url)
        {
            if (id != url.id_url)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(url);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrlExists(url.id_url))
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
            ViewData["project_id"] = new SelectList(_context.Project, "id", "Id_User", url.project_id);
            return View(url);
        }

        // GET: TestCase/Urls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = await _context.Url
                .Include(u => u.project_)
                .FirstOrDefaultAsync(m => m.id_url == id);
            if (url == null)
            {
                return NotFound();
            }

            return View(url);
        }

        // POST: TestCase/Urls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = await _context.Url.FindAsync(id);
            _context.Url.Remove(url);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private bool UrlExists(int id)
        {
            return _context.Url.Any(e => e.id_url == id);
        }
    }
}
