﻿using Generate_TestCase_Selenium_Web.Models.Contexts;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Jobs
{
    public class HelloWorldJob : IJob
    {
        private readonly ILogger<HelloWorldJob> _logger;
        private readonly ElementDBContext _context;
        IScheduler _scheduler;
        public HelloWorldJob(ILogger<HelloWorldJob> logger, IScheduler scheduler)
        {
            _logger = logger;
            _context = new ElementDBContext();
            _scheduler = scheduler;

        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            //Console.WriteLine("Hello world!");
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
                                                 //.UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                                                 .WithIdentity(schedule.id_schedule + "trigger", schedule.id_user)
                                                 .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(16,25))
                                                 //.StartNow()
                                                 //.WithSimpleSchedule(z => z.WithIntervalInSeconds(10).RepeatForever())
                                                 .Build();


                await _scheduler.ScheduleJob(trigger);
            }
            
        }
    }
}
