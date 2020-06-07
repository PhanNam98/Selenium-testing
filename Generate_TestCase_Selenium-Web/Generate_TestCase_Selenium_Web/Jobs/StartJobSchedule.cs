using Coravel.Scheduling.Schedule.Interfaces;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Jobs
{
    public class StartJobSchedule:IJob
    {
        private readonly ILogger<StartJobSchedule> _logger;
        private readonly ElementDBContext _context;
        Quartz.IScheduler _scheduler;
        public StartJobSchedule(ILogger<StartJobSchedule> logger, Quartz.IScheduler scheduler)
        {
            _logger = logger;
            _context = new ElementDBContext();
            _scheduler = scheduler;

        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Start JobSchedule!");
            var listSchedule = _context.Test_schedule.Where(p => p.status.ToLower().Equals("running")).ToList();
            foreach (var schedule in listSchedule)
            {
                IJobDetail job = JobBuilder.Create<RunTestcaseJob>()
                                             .UsingJobData("scheduleid", schedule.id_schedule)
                                             .WithIdentity(schedule.id_schedule, schedule.id_user)
                                             .StoreDurably()
                                             .RequestRecovery()
                                             .Build();

                await _scheduler.AddJob(job, true);

                ITrigger trigger = TriggerBuilder.Create()
                                                 .ForJob(job)
                                                 .WithIdentity(schedule.id_schedule + "trigger", schedule.id_user)
                                                 .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(16, 32))
                                                 //.StartNow()
                                                 //.WithSimpleSchedule(z => z.WithIntervalInSeconds(10).RepeatForever())
                                                 .Build();

                await _scheduler.ScheduleJob(trigger);
            }

        }
    }
}
