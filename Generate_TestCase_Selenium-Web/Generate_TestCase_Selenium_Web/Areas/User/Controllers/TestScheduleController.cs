using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generate_TestCase_Selenium_Web.Jobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Identity;
namespace Generate_TestCase_Selenium_Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class TestScheduleController : Controller
    {
        IScheduler _scheduler;
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }
        public TestScheduleController(IScheduler scheduler, UserManager<ApplicationUser> userManager)
        {
            _scheduler = scheduler;
            _context = new ElementDBContext();
            _userManager = userManager;
        }
        [Route("/Schedule/")]
        public async Task<IActionResult> Index()
        {
            var id_user = _userManager.GetUserId(User);
            var listSchedule = _context.Test_schedule.Where(s => s.id_user == id_user && s.status!="delete");
            ViewData["Message"] = StatusMessage;
            if(StatusMessage!=null)
            TempData.Remove(StatusMessage);
            return View(await listSchedule.ToListAsync());
        }

        public async Task<IActionResult> Create_schedule(string time, string timem, List<string> list_Idtestcase, int id_url)
        {
            Test_schedule test_Schedule = new Test_schedule();
            test_Schedule.CreatedDate = DateTime.Now;
            string scheduleId = Guid.NewGuid().ToString("N");
            test_Schedule.id_schedule = scheduleId;
            var id_user = _userManager.GetUserId(User);
            test_Schedule.id_user = id_user;
            test_Schedule.job_repeat_time = time+":"+timem;
            test_Schedule.status = "running";
            _context.Test_schedule.Add(test_Schedule);
            await _context.SaveChangesAsync();
            foreach (var id in list_Idtestcase)
            {
                Testcase_scheduled testcase_Scheduled = new Testcase_scheduled();
                testcase_Scheduled.id_schedule = scheduleId;
                testcase_Scheduled.id_url = id_url;
                testcase_Scheduled.id_testcase = id;

                _context.Testcase_scheduled.Add(testcase_Scheduled);
            }
            _context.SaveChanges();
            IJobDetail job = JobBuilder.Create<RunTestcaseJob>()
                                         .UsingJobData("scheduleid", scheduleId)
                                         .WithIdentity(scheduleId, id_user)
                                         .StoreDurably()
                                         .RequestRecovery()
                                         .Build();

            await _scheduler.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                                             .ForJob(job)
                                             //.UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                                             .WithIdentity(scheduleId + "trigger", id_user)
                                               .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(int.Parse(time), int.Parse(timem)))
            //                                 .StartNow()
            //                                 .WithSimpleSchedule(z => z.WithIntervalInSeconds(600).RepeatForever())
                                             .Build();


            await _scheduler.ScheduleJob(trigger);
            StatusMessage = "Create schedule successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Stop_schedule(string scheduleId)
        {
            var id_user = _userManager.GetUserId(User);
            await _scheduler.DeleteJob(new JobKey(scheduleId, id_user));
            TriggerKey triggerKey = new TriggerKey("trigger" + scheduleId, id_user);
            await _scheduler.UnscheduleJob(triggerKey);
            var schedule = _context.Test_schedule.Find(scheduleId);
            schedule.status = "stop";
            await _context.SaveChangesAsync();
            StatusMessage = "Stop schedule successfully";
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> Delete_schedule(string scheduleId)
        {
            var id_user = _userManager.GetUserId(User);
            await _scheduler.DeleteJob(new JobKey(scheduleId, id_user));
            TriggerKey triggerKey = new TriggerKey("trigger" + scheduleId, id_user);
            await _scheduler.UnscheduleJob(triggerKey);
            var schedule = _context.Test_schedule.Find(scheduleId);
            schedule.status = "delete";
            await _context.SaveChangesAsync();
            StatusMessage = "Delete schedule successfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Start_schedule(string scheduleId)
        {
            var id_user = _userManager.GetUserId(User);
            Test_schedule test_Schedule = _context.Test_schedule.Find(scheduleId);
            test_Schedule.status = "running";
            _context.Test_schedule.Update(test_Schedule);
            await _context.SaveChangesAsync();
            IJobDetail job = JobBuilder.Create<RunTestcaseJob>()
                                          .UsingJobData("scheduleid", scheduleId)
                                          .WithIdentity(scheduleId, id_user)
                                          .StoreDurably()
                                          .RequestRecovery()
                                          .Build();

            await _scheduler.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                                             .ForJob(job)
                                             //.UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                                             .WithIdentity(scheduleId + "trigger", id_user)
                                             .StartNow()
                                             .WithSimpleSchedule(z => z.WithIntervalInSeconds(600).RepeatForever())
                                             .Build();


            await _scheduler.ScheduleJob(trigger);
            StatusMessage = "Start schedule successfully";
            return RedirectToAction("Index");
        }
        [Route("/Schedule/Detail")]
        public async Task<IActionResult> DetailSchedule(string scheduleId)
        {
            var listTestcase = await _context.Testcase_scheduled.Include(p => p.id_).ThenInclude(r=>r.id_urlNavigation).ThenInclude(p=>p.project_).Where(p => p.id_schedule == scheduleId).ToListAsync();
            ViewData["scheduleId"] = scheduleId;
            string[] time = _context.Test_schedule.Find(scheduleId).job_repeat_time.Split(':');
            ViewData["TimeSchedule"] = time[0];
            ViewData["TimeSchedulem"] = time[1];
            ViewData["id_url"] = listTestcase.FirstOrDefault().id_url;
            ViewData["Message"] = StatusMessage;
            ViewData["project"] = listTestcase.FirstOrDefault().id_.id_urlNavigation.url1;
            ViewData["site"] = listTestcase.FirstOrDefault().id_.id_urlNavigation.project_.name;
            if (StatusMessage != null)
                TempData.Remove(StatusMessage);
            return View(listTestcase);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTestcasesSchedule(string scheduleId, List<string> list_Idtestcase)
        {

            var id = _userManager.GetUserId(User);
            var testcase = await _context.Testcase_scheduled.Include(p => p.id_).Where(p => list_Idtestcase.Contains(p.id_testcase) && p.id_schedule == scheduleId).ToListAsync();
            if (testcase == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Testcase_scheduled.RemoveRange(testcase);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Delete successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    StatusMessage = "Delete fail";
                    return RedirectToAction(nameof(DetailSchedule), new { scheduleId = scheduleId });
                }
                //return Json(new { Result = "OK", Message = "Success" });
                return RedirectToAction(nameof(DetailSchedule), new { scheduleId = scheduleId });
                //return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
            }
            StatusMessage = "Delete fail";
            return RedirectToAction(nameof(DetailSchedule), new { scheduleId = scheduleId });


        }
        [Route("/Schedule/ChooseProject")]
        public async Task<IActionResult> LoadProject()
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
        [Route("/Schedule/Project/ChooseUrl")]
        public async Task<IActionResult> LoadUrl(int project_id)
        {
            var user = await _userManager.GetUserAsync(User);
            var elementDBContext = await _context.Url.Include(p => p.project_).Include(p => p.Test_case).Include(p => p.Element).Where(p => p.project_.Id_User == user.Id && p.project_id == project_id).OrderByDescending(p => p.ModifiedDate).ToListAsync();
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
            ViewData["project_name"] = _context.Project.Find(project_id).name;
            return View(elementDBContext);
        }
        [Route("/Schedule/Project/Url/ChooseTestcase")]
        public async Task<IActionResult> LoadTestase(int id_url)
        {
            var user = await _userManager.GetUserAsync(User);
            var listtestcase = await _context.Test_case.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == user.Id).ToListAsync();
            if (listtestcase.Count > 0)
            {
                //var listelt = await _context.Element.Where(p => p.id_url == id_url).ToListAsync();
                if (StatusMessage == null)
                {
                    if (listtestcase.Count() == 0)
                    {
                        ViewData["Message"] = "No test cases yet";
                    }
                    else
                    if (listtestcase.Count() > 0)
                    {
                        ViewData["Message"] = String.Format("Found {0} test cases", listtestcase.Count());
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
                ViewData["project_id"] = listtestcase.FirstOrDefault().id_urlNavigation.project_.id;
                ViewData["url_name"] = listtestcase.FirstOrDefault().id_urlNavigation.name;
                ViewData["LoadingTitle"] = "Please wait.";
                return View(listtestcase);
            }
            return View(listtestcase);
        }
        [Route("/Schedule/Project/Url/AddMoreTestcase")]
        [HttpGet]
        public async Task<IActionResult> AddMoreTestCase(int id_url, string scheduleId)
        {
            var user = await _userManager.GetUserAsync(User);
            var list_Idtestcase = _context.Testcase_scheduled.Where(p => p.id_schedule == scheduleId).Select(t => t.id_testcase).ToList();
            var listtestcase = await _context.Test_case.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == user.Id && !list_Idtestcase.Contains(p.id_testcase)).ToListAsync();
            if (listtestcase.Count > 0)
            {
                //var listelt = await _context.Element.Where(p => p.id_url == id_url).ToListAsync();
                if (StatusMessage == null)
                {
                    if (listtestcase.Count() == 0)
                    {
                        ViewData["Message"] = "No test cases yet";
                    }
                    else
                    if (listtestcase.Count() > 0)
                    {
                        ViewData["Message"] = String.Format("Found {0} test cases", listtestcase.Count());
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
                ViewData["project_id"] = listtestcase.FirstOrDefault().id_urlNavigation.project_.id;
                ViewData["url_name"] = listtestcase.FirstOrDefault().id_urlNavigation.name;
                ViewData["scheduleId"] = scheduleId;

                return View(listtestcase);
            }
            return View(listtestcase);
        }
        [HttpPost]
        public async Task<IActionResult> AddMoreTestCases(int id_url, string scheduleId, List<string> list_Idtestcase)
        {
            var user = await _userManager.GetUserAsync(User);
            foreach (var id in list_Idtestcase)
            {
                Testcase_scheduled testcase_Scheduled = new Testcase_scheduled();
                testcase_Scheduled.id_schedule = scheduleId;
                testcase_Scheduled.id_url = id_url;
                testcase_Scheduled.id_testcase = id;

                _context.Testcase_scheduled.Add(testcase_Scheduled);
            }
            _context.SaveChanges();
            ViewData["id_url"] = id_url;

            ViewData["scheduleId"] = scheduleId;

            return RedirectToAction(nameof(DetailSchedule), new { scheduleId = scheduleId });
        }
        [HttpPost]
        public async Task<IActionResult> ChangeTimeSchedule(int time,int timem, string scheduleId)
        {
            try
            {
                var schedule = _context.Test_schedule.Find(scheduleId);
                schedule.job_repeat_time = time.ToString()+":"+timem;
                _context.Test_schedule.Update(schedule);
                _context.SaveChanges();
                StatusMessage = "Update successfully";
               
            }
            catch
            {
                StatusMessage = "Update fail";
            }
            return RedirectToAction(nameof(DetailSchedule), new { scheduleId = scheduleId });
        }
        

    }
}