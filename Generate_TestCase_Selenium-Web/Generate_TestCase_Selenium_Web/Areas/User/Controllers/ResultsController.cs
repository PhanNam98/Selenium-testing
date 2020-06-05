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

namespace Generate_TestCase_Selenium_Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ResultsController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }
        public ResultsController( UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }

        [Route("/TestCase/Result")]
        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(User);
            var elementDBContext = _context.Running_process.Include(r => r.id_scheduleNavigation).Include(r => r.id_userNavigation).Where(p=>p.id_user==id && p.status.Equals("finished")).OrderByDescending(d=>d.end_time);
            return View(await elementDBContext.ToListAsync());
        }


        [Route("/TestCase/Result/Detail/{id?}")]
        public async Task<IActionResult> ResultDetail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Result_testcase
                .Include(r => r.id_resultNavigation)
                .Include(t=>t.id_)
                .Where(p=>p.id_result==id)
                .ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            ViewData["Pass"] = results.Where(p => p.Result.ToLower().Equals("pass")).Count();
            ViewData["Skip"] = results.Where(p => p.Result.ToLower().Equals("skip")).Count();
            ViewData["Failure"] = results.Where(p => p.Result.ToLower().Equals("failure")).Count();
            ViewData["id_result"] = id;
            return View(results);
        }

         [Route("/TestCase/Result/Detail/TestData")]
        public async Task<IActionResult> TestData(int id_url, string id_testcase,string id_result)
        {
            ViewData["Message"] = StatusMessage;
            TempData.Remove("StatusMessage");
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            ViewData["id_result"] = id_result;
            var testdataDBContext = await _context.Input_Result_test.Include(i => i.id_).Where(p => p.id_url == id_url && p.id_testcase == id_testcase && p.id_result== id_result).OrderBy(p => p.step).ToListAsync();
            if (ViewData["Message"] == null)
            {
                if (testdataDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No data yet, create a new one";
                }
                else
                if (testdataDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("{0} test data(s)", testdataDBContext.Count());
                }

                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            return View(testdataDBContext);
        }
        [Route("/TestCase/Result/Detail/TestElement")]
        public async Task<IActionResult> TestElement(string id_testcase, string id_result)
        {
            ViewData["Message"] = StatusMessage;
            TempData.Remove("StatusMessage");
            ViewData["id_testcase"] = id_testcase;
            ViewData["id_result"] = id_result;
            var testelementDBContext = await _context.Test_element_Result_test.Where(p => p.id_result == id_result && p.id_testcase == id_testcase).ToListAsync();
            //var urlRedirectDBContext = await _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefaultAsync();
            //if (urlRedirectDBContext != null)
            //{
            //    ViewData["urlRedirecttest"] = urlRedirectDBContext.redirect_url_test;
            //    ViewData["current_url"] = urlRedirectDBContext.current_url;
            //}
            //else
            //{
            //    ViewData["urlRedirecttest"] = "";
            //    ViewData["current_url"] = "";
            //}
            if (ViewData["Message"] == null)
            {
                if (testelementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No element yet, create a new one";
                }
                else
                if (testelementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("{0} test element(s)", testelementDBContext.Count());
                }

                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            return View(testelementDBContext);
        }
















        // GET: User/Results/Details/5

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var running_process = await _context.Running_process
                .Include(r => r.id_scheduleNavigation)
                .Include(r => r.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_process == id);
            if (running_process == null)
            {
                return NotFound();
            }

            return View(running_process);
        }

        // GET: User/Results/Create
        public IActionResult Create()
        {
            ViewData["id_schedule"] = new SelectList(_context.Test_schedule, "id_schedule", "id_schedule");
            ViewData["id_user"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: User/Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_process,id_schedule,id_user,status,start_time,end_time,message")] Running_process running_process)
        {
            if (ModelState.IsValid)
            {
                _context.Add(running_process);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_schedule"] = new SelectList(_context.Test_schedule, "id_schedule", "id_schedule", running_process.id_schedule);
            ViewData["id_user"] = new SelectList(_context.AspNetUsers, "Id", "Id", running_process.id_user);
            return View(running_process);
        }

        // GET: User/Results/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var running_process = await _context.Running_process.FindAsync(id);
            if (running_process == null)
            {
                return NotFound();
            }
            ViewData["id_schedule"] = new SelectList(_context.Test_schedule, "id_schedule", "id_schedule", running_process.id_schedule);
            ViewData["id_user"] = new SelectList(_context.AspNetUsers, "Id", "Id", running_process.id_user);
            return View(running_process);
        }

        // POST: User/Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_process,id_schedule,id_user,status,start_time,end_time,message")] Running_process running_process)
        {
            if (id != running_process.id_process)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(running_process);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Running_processExists(running_process.id_process))
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
            ViewData["id_schedule"] = new SelectList(_context.Test_schedule, "id_schedule", "id_schedule", running_process.id_schedule);
            ViewData["id_user"] = new SelectList(_context.AspNetUsers, "Id", "Id", running_process.id_user);
            return View(running_process);
        }

        // GET: User/Results/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var running_process = await _context.Running_process
                .Include(r => r.id_scheduleNavigation)
                .Include(r => r.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_process == id);
            if (running_process == null)
            {
                return NotFound();
            }

            return View(running_process);
        }

        // POST: User/Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var running_process = await _context.Running_process.FindAsync(id);
            _context.Running_process.Remove(running_process);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Running_processExists(string id)
        {
            return _context.Running_process.Any(e => e.id_process == id);
        }
    }
}
