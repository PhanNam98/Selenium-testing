using Generate_TestCase_Selenium_Web.Models.Contexts;
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
        public RunTestcaseJob(ILogger<RunTestcaseJob> logger )
        {
            _logger = logger;
            _context = new ElementDBContext();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string scheduleid = dataMap.GetString("scheduleid");
            _logger.LogInformation("Hello Job is running!-" + DateTime.Now.ToString()+ dataMap.GetString("scheduleid"));
            var list_testcase_id = _context.Testcase_scheduled.Where(t => t.id_schedule == scheduleid).Select(p => p.id_testcase).ToList();
            int a = list_testcase_id.Count();
        }
      
        
    }
}
