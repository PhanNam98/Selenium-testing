using Coravel.Queuing.Interfaces;
using Generate_TestCase_Selenium_Web.Areas.TestCase.Models;
using Generate_TestCase_Selenium_Web.Models.Constants;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.Mail;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Jobs
{
    public class RunTestCaseBackGround
    {
        private readonly ElementDBContext _context;
        private readonly IQueue _queue;
        private string browserRun;
        private List<string> listSpecialCharacter;
        private readonly IHubContext<JobProgressHub> _hubContext;
        public RunTestCaseBackGround(IQueue queue, IHubContext<JobProgressHub> hubContext) 
        {
            _context = new ElementDBContext();
            _queue = queue;
            _hubContext = hubContext;
            Setup();
        }
        private void Setup()
        {

            listSpecialCharacter = new List<string>();
            listSpecialCharacter.Add("!");
            listSpecialCharacter.Add("#");
            listSpecialCharacter.Add("$");
            listSpecialCharacter.Add("%");
            listSpecialCharacter.Add("&");
            listSpecialCharacter.Add("^");
            listSpecialCharacter.Add("|");
            listSpecialCharacter.Add(@"\");
            listSpecialCharacter.Add("/");
            listSpecialCharacter.Add("=");
            listSpecialCharacter.Add("?");
            listSpecialCharacter.Add(";");
            listSpecialCharacter.Add(">");
            listSpecialCharacter.Add("<");
            listSpecialCharacter.Add("-");
            listSpecialCharacter.Add("*");
            listSpecialCharacter.Add("+");
            listSpecialCharacter.Add("{");
            listSpecialCharacter.Add("}");
            listSpecialCharacter.Add("(");
            listSpecialCharacter.Add(")");

        }
        public async Task<string> RunTestCasesJob(int id_url, List<string> list_Idtestcase, string id_user,string id_schedule=null)
        {
            string jobId = Guid.NewGuid().ToString("N");
            string id = id_user;
            Running_process running_Process = new Running_process();
            running_Process.id_process = jobId;
            running_Process.id_user = id;
            running_Process.start_time = DateTime.Now;
            running_Process.end_time = null;
            running_Process.status = "waiting";
            running_Process.id_schedule = id_schedule;
            _context.Running_process.Add(running_Process);
            await _context.SaveChangesAsync();
            _queue.QueueAsyncTask(() => RunTestCaseJob(id, jobId, id_url, list_Idtestcase));

            return  jobId ;
        }
        private async Task RunTestCaseJob(string id_user, string jobId, int id_url, List<string> list_Idtestcase)
        {
            string id = id_user;
            //string id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var _context = new ElementDBContext();
                browserRun = _context.Setting_.Where(p => p.Id_User == id).SingleOrDefault().Browser;
                var url = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault().url1;
                //var list_Idtestcase1 = _context.Test_case.Where(p => p.id_url == id_url).ToList();
                IEnumerable<Task<string>> runTasksQuery =
                    from Id in list_Idtestcase select Run_ReturnResultJob(jobId, id_url, url, Id);
                await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Running test case");
                List<Task<string>> runTasks = runTasksQuery.ToList();
                //try
                //{
                while (runTasks.Count > 0)
                {
                    // Identify the first task that completes.

                    Task<string> firstFinishedTask = await Task.WhenAny(runTasks);

                    // ***Remove the selected task from the list so that you don't
                    // process it more than once.
                    runTasks.Remove(firstFinishedTask);
                    // Await the completed task.

                    string length = await firstFinishedTask;

                }

                if (_context.Setting_.Where(p => p.Id_User == id).SingleOrDefault().SendResultToMail == true)
                    await SendExcel(id_url, list_Idtestcase,id_user);
                //}
                //catch
                //{
                //    ViewData["Message"] = "Run failed";
                //}
                //ViewData["id_url"] = id_url;
                //var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();
                var running_Process = _context.Running_process.Find(jobId);
                running_Process.status = "finished";
                _context.Running_process.Update(running_Process);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Finished!");
            }
        }
        private async Task<string> Run_ReturnResultJob(string jobId, int id_url, string url, string id_testcase)
        {

            int isPass = 0;
            int isFailure = 0;
            int isSkip = 0;
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            var list_output = _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToList();
            await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Running test case " + id_testcase);
            var running_Process = _context.Running_process.Find(jobId);
            running_Process.status = "running";
            running_Process.message = "Running test case " + id_testcase;
            _context.Running_process.Update(running_Process);
            //try
            //{
            Result_testcase result_Testcase = new Result_testcase();
            result_Testcase.id_result = running_Process.id_process;
            result_Testcase.id_testcase = id_testcase;
            result_Testcase.id_url = id_url;
            result_Testcase.Result = "";
            result_Testcase.TestDate = DateTime.Now;
            _context.Result_testcase.Add(result_Testcase);
            await _context.SaveChangesAsync();
            if (browserRun.Equals("chrome"))
            {

                ChromeDriver chromedriver = SetUpDriver(url);

                //chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                //run test case
                foreach (var inputtest in list_inputtest)
                {
                    Input_Result_test input_Result_Test = new Input_Result_test();
                    input_Result_Test.id_element = inputtest.id_element;
                    input_Result_Test.id_result = jobId;
                    input_Result_Test.id_testcase = id_testcase;
                    input_Result_Test.id_url = id_url;
                    input_Result_Test.value = inputtest.value;
                    input_Result_Test.action = inputtest.action;
                    input_Result_Test.step = inputtest.test_step;
                    switch (inputtest.action)
                    {

                        case "fill":
                            {
                                try
                                {
                                    var fill = chromedriver.FindElementByXPath(inputtest.xpath);
                                    if (fill.Displayed)
                                    {
                                        fill.Click();
                                        fill.SendKeys(inputtest.value);
                                    }

                                }
                                catch (Exception e)
                                {
                                    //if (e.Message.Equals("element not interactable"))
                                    //{

                                    //}
                                }


                                break;
                            }
                        case "select":
                            {
                                try
                                {
                                    var select = chromedriver.FindElementByXPath(inputtest.xpath);
                                    var selectElement = new SelectElement(select);
                                    int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                    Random random = new Random();
                                    int index = random.Next(0, CountallSelectedOptions + 1);
                                    //selectElement.SelectByIndex(int.Parse(inputtest.value));
                                    selectElement.SelectByIndex(index);
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }
                                break;
                            }
                        case "click":
                            {
                                try
                                {
                                    var click = chromedriver.FindElementByXPath(inputtest.xpath);
                                    click.Click();
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                        case "submit":
                            {
                                try
                                {
                                    chromedriver.FindElementByXPath(inputtest.xpath).Click();

                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                    }
                    _context.Input_Result_test.Add(input_Result_Test);
                }
                await _context.SaveChangesAsync();
                //test
                if (list_output.Count > 0)
                {
                    foreach (var outputtest in list_output)
                    {
                        Test_element_Result_test test_Element_Result_Test = new Test_element_Result_test();
                        test_Element_Result_Test.id_result = jobId;
                        test_Element_Result_Test.id_test_elements = outputtest.id_element;
                        test_Element_Result_Test.id_testcase = id_testcase;
                        test_Element_Result_Test.value_test = outputtest.value_test;
                        bool WasTested = false;
                        IWebElement testelt;
                        string DataResult = "";
                        if (!outputtest.xpath.Equals(""))
                        {
                            if (chromedriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                            {
                                testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                test_Element_Result_Test.xpath = outputtest.xpath;
                                string vt;
                                try
                                {
                                    vt = testelt.Text;
                                }
                                catch
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;

                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {
                                    var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (chromedriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                        {

                                            testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                            test_Element_Result_Test.xpath = outputtest.xpath;
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;
                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }

                                }

                            }
                        }

                        if (!outputtest.xpath_full.Equals("") && !WasTested)
                        {

                            if (chromedriver.FindElementsByXPath(outputtest.xpath_full).Count() > 0)
                            {
                                testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                test_Element_Result_Test.xpath = outputtest.xpath_full;
                                string vt = null;
                                if (testelt.Text != null)
                                {
                                    vt = testelt.Text;
                                }
                                else if (testelt.GetAttribute("value") != null)
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {

                                    var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (chromedriver.FindElementsByXPath(outputtest.xpath_full).Count > 0)
                                        {
                                            testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                            test_Element_Result_Test.xpath = outputtest.xpath_full;
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;

                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }


                                }


                            }
                        }
                        if (!WasTested)// check skip case
                        {
                            isSkip++;
                        }
                        test_Element_Result_Test.value = DataResult;
                        _context.Test_element_Result_test.Add(test_Element_Result_Test);
                        outputtest.value_return = DataResult;
                        _context.Element_test.Update(outputtest);
                        await _context.SaveChangesAsync();




                    }
                }
                else
                {
                    isSkip++;
                }

                //BUL.RedirectUrlBUL.Update_RedirectUrl(Id_testcase, ID_URL, current_url);
                //QuitDriver(chromedriver);
                var RedirectUrl = _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                if (RedirectUrl != null)
                {
                    string current_url = chromedriver.Url;
                    if (!RedirectUrl.current_url.Equals(current_url))
                    {
                        isFailure++;
                    }
                    RedirectUrl.current_url = current_url;
                    _context.Update(RedirectUrl);
                }
                chromedriver.Quit();
                string result = "";
                await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Running finished test case: " + id_testcase);
                running_Process.status = "finished";
                running_Process.message = "Running finished test case " + id_testcase;
                running_Process.end_time = DateTime.Now;
                _context.Running_process.Update(running_Process);
                if (isFailure == 0 && isSkip == 0)
                {
                    result = "Pass";
                }
                else
                {
                    if (isFailure > 0)
                    {

                        result = "Failure";
                    }
                    else if (isSkip > 0)
                    {

                        result = "Skip";
                    }
                }
                Testcase.result = result;
                result_Testcase.Result = result;
                await _context.SaveChangesAsync();
                return result;
                //}
                //catch
                //{

                //}
            }
            else
            {

                FirefoxDriver firefoxdriver = SetUpDriverFireFox(url);
                //run test case
                foreach (var inputtest in list_inputtest)
                {
                    Input_Result_test input_Result_Test = new Input_Result_test();
                    input_Result_Test.id_element = inputtest.id_element;
                    input_Result_Test.id_result = jobId;
                    input_Result_Test.id_testcase = id_testcase;
                    input_Result_Test.id_url = id_url;
                    input_Result_Test.value = inputtest.value;
                    input_Result_Test.action = inputtest.action;
                    input_Result_Test.step = inputtest.test_step;
                    switch (inputtest.action)
                    {

                        case "fill":
                            {
                                try
                                {

                                    var fill = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    if (fill.Displayed)
                                    {
                                        fill.Click();
                                        fill.SendKeys(inputtest.value);


                                    }

                                }
                                catch (Exception e)
                                {
                                    //if (e.Message.Equals("element not interactable"))
                                    //{

                                    //}
                                }


                                break;
                            }
                        case "select":
                            {
                                try
                                {
                                    var select = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    var selectElement = new SelectElement(select);
                                    int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                    Random random = new Random();
                                    int index = random.Next(0, CountallSelectedOptions + 1);
                                    //selectElement.SelectByIndex(int.Parse(inputtest.value));
                                    selectElement.SelectByIndex(index);

                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }
                                break;
                            }
                        case "click":
                            {
                                try
                                {
                                    var click = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    click.Click();
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                        case "submit":
                            {
                                try
                                {
                                    firefoxdriver.FindElementByXPath(inputtest.xpath).Click();

                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                    }
                    _context.Input_Result_test.Add(input_Result_Test);
                }
                await _context.SaveChangesAsync();
                //test
                if (list_output.Count > 0)
                {
                    foreach (var outputtest in list_output)
                    {
                        Test_element_Result_test test_Element_Result_Test = new Test_element_Result_test();
                        test_Element_Result_Test.id_result = jobId;
                        test_Element_Result_Test.id_test_elements = outputtest.id_element;
                        test_Element_Result_Test.id_testcase = id_testcase;
                        test_Element_Result_Test.value_test = outputtest.value_test;

                        bool WasTested = false;
                        IWebElement testelt;
                        string DataResult = "";
                        if (!outputtest.xpath.Equals(""))
                        {
                            if (firefoxdriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                            {
                                testelt = firefoxdriver.FindElementByXPath(outputtest.xpath);
                                test_Element_Result_Test.xpath = outputtest.xpath;
                                string vt;
                                try
                                {
                                    vt = testelt.Text;
                                }
                                catch
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    test_Element_Result_Test.value = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {
                                    var testDisplayed = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        firefoxdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (firefoxdriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                        {

                                            testelt = firefoxdriver.FindElementByXPath(outputtest.xpath);
                                            test_Element_Result_Test.xpath = outputtest.xpath;
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                test_Element_Result_Test.value = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;
                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }

                                }

                            }
                        }

                        if (!outputtest.xpath_full.Equals("") && !WasTested)
                        {

                            if (firefoxdriver.FindElementsByXPath(outputtest.xpath_full).Count() > 0)
                            {
                                testelt = firefoxdriver.FindElementByXPath(outputtest.xpath_full);
                                test_Element_Result_Test.xpath = outputtest.xpath_full;
                                string vt = null;
                                if (testelt.Text != null)
                                {
                                    vt = testelt.Text;
                                }
                                else if (testelt.GetAttribute("value") != null)
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    test_Element_Result_Test.value = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {

                                    var testDisplayed = firefoxdriver.FindElementByXPath(inputtest.xpath);

                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        firefoxdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (firefoxdriver.FindElementsByXPath(outputtest.xpath_full).Count > 0)
                                        {
                                            testelt = firefoxdriver.FindElementByXPath(outputtest.xpath_full);
                                            test_Element_Result_Test.xpath = outputtest.xpath_full;
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                test_Element_Result_Test.value = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;

                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }


                                }


                            }
                        }
                        if (!WasTested)// check skip case
                        {
                            isSkip++;
                        }
                        _context.Test_element_Result_test.Add(test_Element_Result_Test);
                        outputtest.value_return = DataResult;
                        _context.Element_test.Update(outputtest);
                        await _context.SaveChangesAsync();




                    }
                }
                else
                {
                    isSkip++;
                }
                var RedirectUrl = _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                if (RedirectUrl != null)
                {
                    string current_url = firefoxdriver.Url;
                    current_url = current_url.Remove(current_url.Length - 1);
                    if (RedirectUrl.redirect_url_test != current_url)
                    {
                        isFailure++;
                    }
                    RedirectUrl.current_url = current_url;
                    _context.Update(RedirectUrl);
                }
                firefoxdriver.Quit();
                string result = "";
                running_Process.message = "Running finished test case " + id_testcase;
                running_Process.end_time = DateTime.Now;
                _context.Running_process.Update(running_Process);

                if (isFailure == 0 && isSkip == 0)
                {
                    result = "Pass";
                }
                else
                {
                    if (isFailure > 0)
                    {

                        result = "Failure";
                    }
                    else if (isSkip > 0)
                    {

                        result = "Skip";
                    }
                }
                Testcase.result = result;
                result_Testcase.Result = result;

                await _context.SaveChangesAsync();

                return result;
                //}
                //catch
                //{

                //}
            }

        }

        private ChromeDriver SetUpDriver(string url)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            //options.AddArgument("headless");
            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            //drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            ChromeDriver chromedriver = new ChromeDriver(service, options);
            chromedriver.Url = url;
            chromedriver.Navigate();
            //The HTTP request to the remote WebDriver server for URL 
            return chromedriver;
        }
        private FirefoxDriver SetUpDriverFireFox(string url)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new FirefoxOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            //options.AddArgument("headless");
            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            //drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            //options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            FirefoxDriver firefoxdriver = new FirefoxDriver(service, options);
            firefoxdriver.Url = url;
            firefoxdriver.Navigate();
            //The HTTP request to the remote WebDriver server for URL 
            return firefoxdriver;
        }

        private void QuitDriver(ChromeDriver chromedriver)
        {

            chromedriver.Quit();

        }
        private void CloseDriver(ChromeDriver chromedriver)
        {

            chromedriver.Close();

        }

        #region Excel
        // Send excel to mail
        private async Task SendExcel(int id_url, List<string> list_Idtestcase,string id_user)
        {
            var user = _context.AspNetUsers.Find(id_user);
            var url = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();
            var testcases = await _context.Test_case.Include(i => i.Input_testcase).Include(p => p.Element_test).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();
            TestcaseExcel testcaseExcel = new TestcaseExcel();
            var testcaseExcels = testcaseExcel.ConvertToTestcaseExcel(testcases);
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = new MemoryStream();
            string filename = "Testcase-" + DateTime.Now.ToString("MM-dd-yyyy") + "-" + Generate_RandomString(5) + ".xlsx";
            var path = Path.Combine(Directory.GetCurrentDirectory(), Constants.EXCEL_FILE, filename);
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Test case");
                package.Workbook.Properties.Author = "Genergate testcase web";
                //worksheet.Cells["A2"].LoadFromCollection<TestcaseExcel>(testcaseExcels, true);
                worksheet.Cells[1, 1].Value = "Url: " + url.url1;
                BindingFormatForExcel(worksheet, testcaseExcels);
                fileContents = package.GetAsByteArray();
                System.IO.File.WriteAllBytes(path, fileContents);// save to dissk

            }


            if (fileContents == null || fileContents.Length == 0)
            {
               
            }
            else
            {
                string emailcontent = "Thank you for using our service. " +
                           "The excel file has been attached below.";
                await SendMail.SendMailWithFile(emailcontent, user.Email, "Export Test case", path);
                //await SendMail.SendMailWithFile("file exel", user.Email, "Export Excel", path);
            }


        }
        
      
        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<TestcaseExcel> listItems)
        {
            // Set default width cho tất cả column
            //worksheet.DefaultColWidth = 10;
            worksheet.Cells["A1:C1"].Merge = true;
            worksheet.Cells[1, 1].Style.Font.SetFromFont(new Font("Arial", 14));
            worksheet.Column(1).Width = 50;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 30;
            worksheet.Column(4).Width = 30;
            worksheet.Column(5).Width = 150;
            worksheet.Column(6).Width = 150;
            worksheet.Column(7).Width = 150;
            worksheet.Cells[2, 1].Value = "No.";
            worksheet.Cells[2, 2].Value = "Test case";
            worksheet.Cells[2, 3].Value = "Description";
            worksheet.Cells[2, 4].Value = "Result";
            worksheet.Cells[2, 5].Value = "Test Data";
            worksheet.Cells[2, 6].Value = "Test Elements";
            worksheet.Cells[2, 7].Value = "Result Test Elements";
            // Tự động xuống hàng khi text quá dài
            worksheet.Cells.Style.WrapText = true;
            // Tạo header

            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A2:G2"])
            {
                // Set PatternType
                //range.Style.Fill.PatternType = ExcelFillStyle.;
                // Set Màu cho Background
                // range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                range.Style.Font.SetFromFont(new Font("Arial", 12));
                // Set Border
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                // Set màu ch Border
                range.Style.Border.Bottom.Color.SetColor(Color.Blue);
            }

            // Đỗ dữ liệu từ list vào 
            for (int i = 0; i < listItems.Count; i++)
            {
                var item = listItems[i];
                worksheet.Cells[i + 3, 1].Value = i + 1;
                worksheet.Cells[i + 3, 2].Value = item.Id_testcase;
                worksheet.Cells[i + 3, 3].Value = item.Description;
                worksheet.Cells[i + 3, 4].Value = item.Result;
                worksheet.Cells[i + 3, 5].Value = item.TestData;
                worksheet.Cells[i + 3, 6].Value = item.TestElement;
                worksheet.Cells[i + 3, 7].Value = item.ResultTestElement;

                worksheet.Cells[i + 3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[i + 3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[i + 3, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[i + 3, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                // Format lại color nếu như thỏa điều kiện
                // Ở đây chúng ta sẽ format lại theo dạng fromRow,fromCol,toRow,toCol
                using (var range = worksheet.Cells[i + 3, 4])
                {
                    // Format text đỏ và đậm
                    if (item.Result == "Pass")
                    {
                        range.Style.Font.Color.SetColor(Color.Green);
                    }
                    else if (item.Result == "Skip")
                    {
                        range.Style.Font.Color.SetColor(Color.Blue);
                    }
                    else
                    {
                        range.Style.Font.Color.SetColor(Color.Red);
                    }

                    range.Style.Font.Bold = true;
                }


            }
            
        }
        #endregion


        #region Helper Generate
       
        public string Generate_RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(4, true));
            builder.Append(Generate_RandomSpecialString(1));
            builder.Append(Generate_RandomNumber(1000, 9999));
            builder.Append(Generate_RandomString(2, false));
            return builder.ToString();
        }
        public string Generate_RandomEmail()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(8, true));
            builder.Append(Generate_RandomNumber(0, 99));
            builder.Append("@email.com");
            return builder.ToString();
        }
        public string Generate_RandomStringNumberSpecialString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(8, true));
            builder.Append(Generate_RandomNumber(0, 99));
            builder.Append(Generate_RandomSpecialString(2));
            return builder.ToString();
        }
        public string Generate_RandomStringNumberSpecialString(Random random)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(random, 8, true));
            builder.Append(Generate_RandomSpecialString(random, 2));
            builder.Append(Generate_RandomNumber(random, 0, 100));
            builder.Append(Generate_RandomString(random, 3, true));
            return builder.ToString();
        }
        public string Generate_RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Thread.Sleep(10);
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string Generate_RandomString(Random random, int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Thread.Sleep(10);

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string Generate_RandomSpecialString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 20)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public string Generate_RandomSpecialString(Random random, int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 20)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public int Generate_RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public int Generate_RandomNumber(Random random, int min, int max)
        {

            return random.Next(min, max);
        }

        #endregion
    }
}
