using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generate_TestCase_Selenium_Web.Jobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class ScheduleController : Controller
    {
        IScheduler _scheduler;
        public ScheduleController(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create_schedule()
        {
            IJobDetail job = JobBuilder.Create<RunTestcaseJob>()
                                       .UsingJobData("username", "Nam")
                                       .UsingJobData("password", "Security!!")
                                       .WithIdentity("simplejob", "quartzexamples")
                                       .StoreDurably()
                                       .RequestRecovery()
                                       .Build();
            //job.JobDataMap.Put("user", new JobUserParameter { Username = "Joker", Password = "Ha Ha Ha!!" });
            //            JobDetail jobDetail = JobBuilder.newJob(YourJob.class)
            //        .withIdentity("your-job-name", "your-job-group")
            //        .build();
            //        Trigger trigger = TriggerBuilder.newTrigger()
            //                .withIdentity("your-trigger-name", "your-trigger-group")
            //                .withSchedule(CronScheduleBuilder.cronSchedule("0 0 * * ? *"))
            //                .startNow()
            //                .build();
            //        scheduler.scheduleJob(jobDetail, trigger);
            //scheduler.start();
            //save the job
            await _scheduler.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                                             .ForJob(job)
                                             .UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                                             .WithIdentity("testtrigger", "quartzexamples")
                                             .StartNow()
                                             .WithSimpleSchedule(z => z.WithIntervalInSeconds(5).RepeatForever())
                                             .Build();
            //ITrigger trigger2 = TriggerBuilder.Create()
            //                                .ForJob(job)
            //                                .UsingJobData("triggerparam", "Simple trigger 2 Parameter")
            //                                .WithIdentity("testtrigger2", "quartzexamples")
            //                                .StartNow()
            //                                .WithSimpleSchedule(z => z.WithIntervalInSeconds(5).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires())
            //                                .Build();
            //ITrigger trigger3 = TriggerBuilder.Create()
            //                                .ForJob(job)
            //                                .UsingJobData("triggerparam", "Simple trigger 3 Parameter")
            //                                .WithIdentity("testtrigger3", "quartzexamples")
            //                                .StartNow()
            //                                .WithSimpleSchedule(z => z.WithIntervalInSeconds(5).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires())
            //                                .Build();

            await _scheduler.ScheduleJob(trigger);
            //await _scheduler.ScheduleJob(trigger2);
            //await _scheduler.ScheduleJob(trigger3);
            //await _scheduler.DeleteJob(new JobKey("simplejob", "quartzexamples"));
            //TriggerKey triggerKey = new TriggerKey("testtrigger", "quartzexamples");
            //await _scheduler.UnscheduleJob(triggerKey);
            return RedirectToAction("Index");
        }
        
            public async Task<IActionResult> Pause_schedule()
        {
            await _scheduler.DeleteJob(new JobKey("simplejob", "quartzexamples"));
            TriggerKey triggerKey = new TriggerKey("testtrigger", "quartzexamples");
            await _scheduler.UnscheduleJob(triggerKey);
            return RedirectToAction("Index");
        }
    }
}