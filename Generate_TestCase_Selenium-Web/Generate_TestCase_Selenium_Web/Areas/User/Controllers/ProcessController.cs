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

namespace Generate_TestCase_Selenium_Web.Areas.User
{
    [Area("User")]
    [Authorize]
    public class ProcessController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProcessController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }

        // GET: User/Process
        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(User);
            var list_process = _context.Running_process.Include(r => r.id_scheduleNavigation).Include(r => r.id_userNavigation).Where(p=>p.id_user==id ).OrderByDescending(p=>p.start_time);
            return View(await list_process.ToListAsync());
        }

        // GET: User/Process/Details/5
        public async Task<IActionResult> Details(string id_process)
        {
            if (id_process == null)
            {
                return NotFound();
            }
            string id = _userManager.GetUserId(User);
            var running_process = await _context.Running_process
                .Include(r => r.id_scheduleNavigation)
                .Include(r => r.id_userNavigation)
                .FirstOrDefaultAsync(m => m.id_process == id_process && m.id_user==id);
            if (running_process == null)
            {
                return NotFound();
            }
            return RedirectToAction("Progress", "GenerateTestCases", new { jobId=id_process , area = "TestCase" });
            //return View(running_process);
        }

        // GET: User/Process/Create
        public IActionResult Create()
        {
            ViewData["id_schedule"] = new SelectList(_context.Test_schedule, "id_schedule", "id_schedule");
            ViewData["id_user"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: User/Process/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_process,id_schedule,id_user,status,start_time,end_time")] Running_process running_process)
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

        // GET: User/Process/Edit/5
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

        // POST: User/Process/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_process,id_schedule,id_user,status,start_time,end_time")] Running_process running_process)
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

        // GET: User/Process/Delete/5
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

        // POST: User/Process/Delete/5
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
