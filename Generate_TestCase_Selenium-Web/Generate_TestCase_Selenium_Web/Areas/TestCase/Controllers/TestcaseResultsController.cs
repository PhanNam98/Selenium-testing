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

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class TestcaseResultsController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TestcaseResultsController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }

        // GET: TestCase/TestcaseResults
        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(User);
            var elementDBContext = _context.Result_testcase.Include(r => r.id_).Include(r => r.id_resultNavigation);
            return View(await elementDBContext.ToListAsync());
        }

        // GET: TestCase/TestcaseResults/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result_testcase = await _context.Result_testcase
                .Include(r => r.id_)
                .Include(r => r.id_resultNavigation)
                .FirstOrDefaultAsync(m => m.id_result == id);
            if (result_testcase == null)
            {
                return NotFound();
            }

            return View(result_testcase);
        }

        // GET: TestCase/TestcaseResults/Create
        public IActionResult Create()
        {
            ViewData["id_testcase"] = new SelectList(_context.Test_case, "id_testcase", "id_testcase");
            ViewData["id_result"] = new SelectList(_context.Running_process, "id_process", "id_process");
            return View();
        }

        // POST: TestCase/TestcaseResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_result,id_testcase,id_url,Result,TestDate")] Result_testcase result_testcase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result_testcase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_testcase"] = new SelectList(_context.Test_case, "id_testcase", "id_testcase", result_testcase.id_testcase);
            ViewData["id_result"] = new SelectList(_context.Running_process, "id_process", "id_process", result_testcase.id_result);
            return View(result_testcase);
        }

        // GET: TestCase/TestcaseResults/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result_testcase = await _context.Result_testcase.FindAsync(id);
            if (result_testcase == null)
            {
                return NotFound();
            }
            ViewData["id_testcase"] = new SelectList(_context.Test_case, "id_testcase", "id_testcase", result_testcase.id_testcase);
            ViewData["id_result"] = new SelectList(_context.Running_process, "id_process", "id_process", result_testcase.id_result);
            return View(result_testcase);
        }

        // POST: TestCase/TestcaseResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_result,id_testcase,id_url,Result,TestDate")] Result_testcase result_testcase)
        {
            if (id != result_testcase.id_result)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result_testcase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Result_testcaseExists(result_testcase.id_result))
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
            ViewData["id_testcase"] = new SelectList(_context.Test_case, "id_testcase", "id_testcase", result_testcase.id_testcase);
            ViewData["id_result"] = new SelectList(_context.Running_process, "id_process", "id_process", result_testcase.id_result);
            return View(result_testcase);
        }

        // GET: TestCase/TestcaseResults/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result_testcase = await _context.Result_testcase
                .Include(r => r.id_)
                .Include(r => r.id_resultNavigation)
                .FirstOrDefaultAsync(m => m.id_result == id);
            if (result_testcase == null)
            {
                return NotFound();
            }

            return View(result_testcase);
        }

        // POST: TestCase/TestcaseResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result_testcase = await _context.Result_testcase.FindAsync(id);
            _context.Result_testcase.Remove(result_testcase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Result_testcaseExists(string id)
        {
            return _context.Result_testcase.Any(e => e.id_result == id);
        }
    }
}
