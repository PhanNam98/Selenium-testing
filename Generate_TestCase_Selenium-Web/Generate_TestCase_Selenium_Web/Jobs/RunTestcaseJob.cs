using Coravel.Queuing.Interfaces;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Jobs
{
    //[PersistJobDataAfterExecution]
    //[DisallowConcurrentExecution]
    public class RunTestcaseJob : IJob
    {
        
        private readonly ILogger<RunTestcaseJob> _logger;
        private readonly ElementDBContext _context;
        private readonly IQueue _queue;
        private readonly IHubContext<JobProgressHub> _hubContext;
        public RunTestcaseJob(ILogger<RunTestcaseJob> logger, IQueue queue, IHubContext<JobProgressHub> hubContext)
        {
            _logger = logger;
            _context = new ElementDBContext();
            _queue = queue;
            _hubContext = hubContext;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string scheduleid = dataMap.GetString("scheduleid");
            _logger.LogInformation($"Job: {scheduleid} is running!-" + DateTime.Now.ToString());
            var list_testcase_id = _context.Testcase_scheduled.Where(t => t.id_schedule == scheduleid).Select(p => p.id_testcase).ToList();
            var url_id = _context.Testcase_scheduled.Where(t => t.id_schedule == scheduleid).FirstOrDefault().id_url;
            var schedule = _context.Test_schedule.Where(s => s.id_schedule == scheduleid).SingleOrDefault();

            RunTestCaseBackGround runTestCaseBackGround = new RunTestCaseBackGround(_queue, _hubContext);
            await runTestCaseBackGround.RunTestCasesJob((int)url_id, list_testcase_id, schedule.id_user, scheduleid);
        }
      
        
    }
}
