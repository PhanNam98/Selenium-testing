using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Jobs
{
    public class RunTestcaseJob : IJob
    {
        private readonly ILogger<RunTestcaseJob> _logger;
        public RunTestcaseJob(ILogger<RunTestcaseJob> logger)
        {
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello Job is running!-" + DateTime.Now.ToString());
        }
    }
}
