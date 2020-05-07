﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Microsoft.AspNetCore.Routing;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class GenerateTestCasesController : Controller
    {
        private readonly ElementDBContext _context;
        private int Id_Url;
        private List<Test_case> ListTestCase;
        private List<List<Input_testcase>> List_ListInputTestcase;
        private List<string> listSpecialCharacter;
        //private ChromeDriver chromedriver;
        [TempData]
        public string StatusMessage { get; set; }
       
        private enum Actions
        {
            fill,
            click,
            select,
            submit
        }
        public GenerateTestCasesController()
        {
            _context = new ElementDBContext();
            Setup();
        }

        //GET: TestCase/GenerateTestCases
        public async Task<IActionResult> Index(int id_url,bool isload=false)
        {
            ViewData["id_url"] = id_url;
            var testcaseDBContext =await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url).ToListAsync();
            if (!isload)
            {
                if (testcaseDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No test case yet";
                }
                else
              if (testcaseDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("Success, {0} test case(s) were created", testcaseDBContext.Count());
                }

                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            else
                ViewData["Message"] = null;
            ViewData["LoadingTitle"] = "Running test case. Please wait.";
            return View(testcaseDBContext);
           

        }
        public async Task<IActionResult> Result(int id_url)
        {
            ViewData["id_url"] = id_url;
            var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url).ToListAsync();

            //  if (testcaseDBContext.Count() == 0)
            //  {
            //      ViewData["Message"] = "No testcase yet";
            //  }
            //  else
            //if (testcaseDBContext.Count() > 0)
            //  {
            //      ViewData["Message"] = String.Format("Success, {0} test case(s) were fo", testcaseDBContext.Count());
            //  }

            //  else
            //  {
            //      ViewData["Message"] = "Error load data";
            //  }

            ViewData["Pass"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("pass")).Count();
            ViewData["Skip"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("skip")).Count();
            ViewData["Failure"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("failure")).Count();
            return View(testcaseDBContext);


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

        public async Task<IActionResult> Generate_testcase(int id_url)
        {
            Id_Url = id_url;
            ListTestCase = new List<Test_case>();
            List_ListInputTestcase = new List<List<Input_testcase>>();
            List<Form_elements> forms = await _context.Form_elements.Where(p => p.id_url == Id_Url).ToListAsync();
            if (forms.Count > 0)
            {
                for (int i = 0; i < forms.Count; i++)
                {
                    var _context1 = new ElementDBContext();
                    List<Element> submit = await _context1.Element.Where(p => p.id_url == Id_Url && p.id_form == forms[i].id_form && p.type == "submit").ToListAsync();
                    for (int j = 0; j < submit.Count; j++)
                    {
                        //NotFill_ClickSubmit(forms[i].id_form, j, submit[j]);
                        await Input_Type_Text(forms[i].id_form, j, submit[j]);

                        //ClickAll_TypeRadio(forms[i].id_form, j, submit[j]);
                    }
                }
            }
            else
            {
                //not form
            }

            //_context.Test_case.AddRange(ListTestCase);
            //await _context.SaveChangesAsync();

            //foreach (var inputtest in List_ListInputTestcase)
            //{
            //    _context.Input_testcase.AddRange(inputtest);

            //}
            //if (await _context.SaveChangesAsync() > 0)
            //    return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index), new RouteValueDictionary(new { id_url = id_url }));


        }



        #region Input Type Text
        private async Task<bool> Input_Type_Text(string id_form, int index_submit, Element submit)
        {
            var a = Fill_1000_charter_TypeText(id_form, index_submit, submit);
            var a1 = Fill_Text_TypeText(id_form, index_submit, submit);
            //Fill_out_1_Field_Blank_TypeText(id_form, index_submit, submit);
            //Fill_Text_Two_Leading_Spaces_TypeText(id_form, index_submit, submit);
            //Fill_One_letter_characters_TypeText(id_form, index_submit, submit);
            //Fill_Text_Number_TypeText(id_form, index_submit, submit);
            //Fill_Text_Number_Special_TypeText(id_form, index_submit, submit);
            var result = await a;
            var result1 = await a1;
            return result && result1;
        }
        private async Task<bool> Fill_1000_charter_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_1000_charter_TypeText_" + id_form + "_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeText = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "text" && p.tag_name == "input").ToListAsync();
            if (listTypeText.Count > 0)
            {
                int step = 1;
                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 1000), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_Text_TypeText(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            string id_testCase = "Fill_Text_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "text" && p.tag_name == "input").ToListAsync();


            if (listTypeText.Count > 0)
            {
                int step = 1;
                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 8), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        //private void Fill_out_1_Field_Blank_TypeText(string id_form, int index_submit, Element submit)
        //{

        //    var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);
        //    int number_of_elements = listTypeText.Count;

        //    if (number_of_elements > 0)
        //    {

        //        for (int i = 0; i < number_of_elements; i++)
        //        {
        //            string id_testCase = "Fill_out_1_Field_Blank_TypeText_" + id_form + "_" + index_submit + "_" + i;
        //            Crate_Testcase(id_testCase);
        //            List<Input_testcase> listInputElt = new List<Input_testcase>();
        //            int step = 1;
        //            for (int j = 0; j < listTypeText.Count; j++)
        //            {
        //                if (i == j)
        //                {
        //                    listInputElt.Add(Crate_InputTestcase(listTypeText[j], id_testCase, "", Actions.fill.ToString(), step++));
        //                }
        //                else
        //                {
        //                    Random random = new Random();
        //                    listInputElt.Add(Crate_InputTestcase(listTypeText[j], id_testCase, Generate_RandomString(random, 8), Actions.fill.ToString(), step++));
        //                }


        //            }
        //            listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

        //            List_ListInputTestcase.Add(listInputElt);

        //        }

        //    }
        //}
        //private void Fill_Text_Two_Leading_Spaces_TypeText(string id_form, int index_submit, Element submit)
        //{
        //    string id_testCase = "Fill_Text_Two_Leading_Spaces_TypeText_" + id_form + "_" + index_submit;
        //    var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);


        //    if (listTypeText.Count > 0)
        //    {

        //        Crate_Testcase(id_testCase);
        //        List<Input_testcase> listInputElt = new List<Input_testcase>();
        //        int step = 1;
        //        for (int i = 0; i < listTypeText.Count; i++)
        //        {
        //            Random random = new Random();
        //            listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, " " + Generate_RandomString(random, 8) + " ", Actions.fill.ToString(), step++));

        //        }
        //        listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

        //        List_ListInputTestcase.Add(listInputElt);

        //    }
        //}
        //private void Fill_One_letter_characters_TypeText(string id_form, int index_submit, Element submit)
        //{
        //    string id_testCase = "Fill_One_letter_characters_TypeText_" + id_form + "_" + index_submit;
        //    var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);
        //    if (listTypeText.Count > 0)
        //    {

        //        Crate_Testcase(id_testCase);
        //        List<Input_testcase> listInputElt = new List<Input_testcase>();
        //        int step = 1;
        //        for (int i = 0; i < listTypeText.Count; i++)
        //        {
        //            Random random = new Random();
        //            listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 1), Actions.fill.ToString(), step++));

        //        }
        //        listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

        //        List_ListInputTestcase.Add(listInputElt);

        //    }

        //}
        //private void Fill_Text_Number_TypeText(string id_form, int index_submit, Element submit)
        //{
        //    string id_testCase = "Fill_Text_Number_TypeText_" + id_form + "_" + index_submit;
        //    var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

        //    if (listTypeText.Count > 0)
        //    {

        //        Crate_Testcase(id_testCase);
        //        List<Input_testcase> listInputElt = new List<Input_testcase>();
        //        int step = 1;
        //        for (int i = 0; i < listTypeText.Count; i++)
        //        {
        //            Random random = new Random();
        //            listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 6) + Generate_RandomNumber(random, 0, 100) + Generate_RandomString(random, 3), Actions.fill.ToString(), step++));

        //        }
        //        listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

        //        List_ListInputTestcase.Add(listInputElt);

        //    }
        //}
        //private void Fill_Text_Number_Special_TypeText(string id_form, int index_submit, Element submit)
        //{
        //    string id_testCase = "Fill_Text_Number_Special_TypeText_" + id_form + "_" + index_submit;
        //    var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);


        //    if (listTypeText.Count > 0)
        //    {

        //        Crate_Testcase(id_testCase);
        //        List<Input_testcase> listInputElt = new List<Input_testcase>();
        //        int step = 1;
        //        for (int i = 0; i < listTypeText.Count; i++)
        //        {
        //            Random random = new Random();
        //            listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomStringNumberSpecialString(random), Actions.fill.ToString(), step++));

        //        }
        //        listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

        //        List_ListInputTestcase.Add(listInputElt);

        //    }
        //}
        #endregion




        #region Helper Generate
        ///https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

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

        public bool Crate_Testcase(string id_testCase)
        {
            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            //return BUL.TestCaseBUL.InsertTestcase(newTestCase);
            return true;

        }
        public Input_testcase Crate_InputTestcase(Element testElt, string id_testCase, string value, string action, int step)
        {
            Input_testcase newinput = new Input_testcase();
            try
            {
                newinput.id_element = testElt.id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = value;
                newinput.action = action;
                newinput.xpath = testElt.xpath;
                newinput.test_step = step;
            }
            catch
            {
                return null;
            }
            return newinput;


        }
        #endregion


        #region Run test case
        [HttpPost]
        [Route("/TestCase/Result")]
        public async Task<IActionResult> RunTestCase(int id_url, List<string> list_Idtestcase)
        {
            var _context = new ElementDBContext();
            var url = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault().url1;
            //var list_Idtestcase1 = _context.Test_case.Where(p => p.id_url == id_url).ToList();
            IEnumerable<Task<string>> runTasksQuery =
                from Id in list_Idtestcase select Run_ReturnResult(id_url, url, Id);
            List<Task<string>> runTasks = runTasksQuery.ToList();
            try
            {
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
                ViewData["Message"] = "Run successfully";
            }
            catch
            {
                ViewData["Message"] = "Run failed";
            }
            ViewData["id_url"] = id_url;
            var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();

            ViewData["Pass"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("pass")).Count();
            ViewData["Skip"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("skip")).Count();
            ViewData["Failure"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("failure")).Count();
            //return RedirectToAction(nameof(Result), new RouteValueDictionary(new { id_url = id_url }));
            return View("Result", testcaseDBContext);
        }

        public async Task<string> Run_ReturnResult(int id_url, string url, string id_testcase)
        {

            int isPass = 0;
            int isFailure = 0;
            int isSkip = 0;
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            //try
            //{
            ChromeDriver chromedriver = SetUpDriver(url); ;

            chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            var list_output = _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToList();

            foreach (var inputtest in list_inputtest)
            {
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
            }


            if (list_output.Count > 0)
            {
                foreach (var outputtest in list_output)
                {
                    bool WasTested = false;
                    IWebElement testelt;
                    string DataResult = "";
                    if (!outputtest.xpath.Equals(""))
                    {
                        try
                        {

                            testelt = chromedriver.FindElementByXPath(outputtest.xpath);
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
                        catch
                        {
                            foreach (var inputtest in list_inputtest)
                            {
                                var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                if (testDisplayed.Displayed)
                                {
                                    testDisplayed.Click();
                                    try
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath);
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
                                        break;
                                    }
                                    catch
                                    {


                                    }


                                }

                            }
                          
                        }
                    }

                    if (!outputtest.xpath_full.Equals("") && !WasTested)
                    {

                        try
                        {
                            testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
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
                        catch
                        {
                            foreach (var inputtest in list_inputtest)
                            {

                                var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                if (testDisplayed.Displayed)
                                {
                                    testDisplayed.Click();
                                    try
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
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
                                        break;
                                    }
                                    catch
                                    {


                                    }
                                }


                            }


                        }
                    }
                    if (!WasTested)// check skip case
                    {
                        isSkip++;
                    }

                    outputtest.value_return = DataResult;
                    _context.Element_test.Update(outputtest);
                    await _context.SaveChangesAsync();

                    #region backup
                    //try
                    //{

                    //    testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                    //    string vt;
                    //    try
                    //    {
                    //        vt = testelt.Text;
                    //    }
                    //    catch
                    //    {
                    //        vt = testelt.GetAttribute("value");
                    //    }
                    //    if (vt != null)
                    //    {
                    //        outputtest.value_return = vt;
                    //        if (!vt.Equals(outputtest.value_test))
                    //        {
                    //            isPass = 0;
                    //        }
                    //        BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //    }



                    //}
                    //catch
                    //{
                    //    try
                    //    {
                    //        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                    //        string vt;
                    //        try
                    //        {
                    //            vt = testelt.Text;
                    //        }
                    //        catch
                    //        {
                    //            vt = testelt.GetAttribute("value");
                    //        }
                    //        if (vt != null)
                    //        {
                    //            outputtest.value_return = vt;
                    //            if (!vt.Equals(outputtest.value_test))
                    //            {
                    //                isPass = 0;
                    //            }
                    //            BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //        }

                    //    }
                    //    catch
                    //    {
                    //        foreach (var inputtest in list_inputtest)
                    //        {

                    //            var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                    //            if (testDisplayed.Displayed)
                    //            {
                    //                testDisplayed.Click();
                    //                try
                    //                {
                    //                    testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                    //                    string vt;
                    //                    try
                    //                    {
                    //                        vt = testelt.Text;
                    //                    }
                    //                    catch
                    //                    {
                    //                        vt = testelt.GetAttribute("value");
                    //                    }
                    //                    if (vt != null)
                    //                    {
                    //                        outputtest.value_return = vt;
                    //                        if (!vt.Equals(outputtest.value_test))
                    //                        {
                    //                            isPass = 0;
                    //                        }
                    //                        BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //                    }
                    //                    break;
                    //                }
                    //                catch
                    //                {
                    //                    try
                    //                    {
                    //                        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                    //                        string vt;
                    //                        try
                    //                        {
                    //                            vt = testelt.Text;
                    //                        }
                    //                        catch
                    //                        {
                    //                            vt = testelt.GetAttribute("value");
                    //                        }
                    //                        if (vt != null)
                    //                        {
                    //                            outputtest.value_return = vt;
                    //                            if (!vt.Equals(outputtest.value_test))
                    //                            {
                    //                                isPass = 0;
                    //                            }
                    //                            BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //                        }
                    //                        break;
                    //                    }
                    //                    catch
                    //                    {

                    //                    }

                    //                }


                    //            }

                    //        }
                    //    }
                    //}

                    #endregion


                }
            }
            else
            {
                isSkip++;
            }
            //string current_url = chromedriver.Url;
            //BUL.RedirectUrlBUL.Update_RedirectUrl(Id_testcase, ID_URL, current_url);
            QuitDriver(chromedriver);
            string result = "";

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
            await _context.SaveChangesAsync();
            return result;
            //}
            //catch
            //{

            //}
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

        private void QuitDriver(ChromeDriver chromedriver)
        {

            chromedriver.Quit();

        }
        private void CloseDriver(ChromeDriver chromedriver)
        {

            chromedriver.Close();

        }

        #endregion

        #region Output test case
        public async Task<IActionResult> TestElement(int id_url, string id_testcase)
        {
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            var testelementDBContext =await _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase==id_testcase).ToListAsync();
            if (testelementDBContext.Count() == 0)
            {
                ViewData["Message"] = "No element yet, create a new one";
            }
            else
           if (testelementDBContext.Count() > 0)
            {
                ViewData["Message"] = String.Format("{0} test element(s)", testelementDBContext.Count());
            }

            else
            {
                ViewData["Message"] = "Error load data";
            }
            return View(testelementDBContext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestElt(string xpath,string fullxpath, int id_url,string valuetest,string id_testcase)
        {
            var elttest = new Element_test();
            if (ModelState.IsValid)
            {
                if (xpath == null)
                    xpath = "";
                if (fullxpath == null)
                    fullxpath = "";
                if (valuetest == null)
                    valuetest = "";
                Random random = new Random();
                elttest.xpath = xpath;
                elttest.xpath_full = fullxpath;
                elttest.value_test = valuetest;
                elttest.id_url = id_url;
                elttest.id_testcase = id_testcase;
                elttest.id_element = id_testcase + Generate_RandomString(random,5);
                _context.Add(elttest);
                await _context.SaveChangesAsync();
                ViewData["Message"] = String.Format("Success");
                return RedirectToAction(nameof(TestElement), new RouteValueDictionary(new { id_url = id_url, id_testcase = id_testcase }));
            }

            return RedirectToAction(nameof(TestElement), new RouteValueDictionary(new { id_url = id_url, id_testcase = id_testcase }));
        }
        [HttpPost, ActionName("DeleteTestElt")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTestElt(string id_testcase, int id_url, string id_elementtest)
        {
            try
            {
                var test_elt = await _context.Element_test.Where(p => p.id_element == id_elementtest && p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
                _context.Element_test.Remove(test_elt);
                await _context.SaveChangesAsync();
                ViewData["Message"] = String.Format("Success");
                
            }
            catch
            {
                ViewData["Message"] = String.Format("Error");
            }
            return RedirectToAction(nameof(TestElement),new { id_testcase=id_testcase, id_url=id_url });
        }
        #endregion
        #region Input test case

        public async Task<IActionResult> TestData(int id_url, string id_testcase)
        {
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            var testdataDBContext = await _context.Input_testcase.Include(i=>i.id_).Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p=>p.test_step).ToListAsync();
            if (testdataDBContext.Count() == 0)
            {
                ViewData["Message"] = "No element yet, create a new one";
            }
            else
           if (testdataDBContext.Count() > 0)
            {
                ViewData["Message"] = String.Format("{0} test data(s)", testdataDBContext.Count());
            }

            else
            {
                ViewData["Message"] = "Error load data";
            }
            return View(testdataDBContext);
        }


        #endregion


        // GET: TestCase/GenerateTestCases/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test_case = await _context.Test_case
                .Include(t => t.id_urlNavigation)
                .FirstOrDefaultAsync(m => m.id_testcase == id);
            if (test_case == null)
            {
                return NotFound();
            }

            return View(test_case);
        }

        // GET: TestCase/GenerateTestCases/Create
        public IActionResult Create()
        {
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name");
            return View();
        }

        // POST: TestCase/GenerateTestCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_testcase,id_url,description,result,is_test,CreatedDate,ModifiedDate")] Test_case test_case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test_case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", test_case.id_url);
            return View(test_case);
        }

        // GET: TestCase/GenerateTestCases/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test_case = await _context.Test_case.FindAsync(id);
            if (test_case == null)
            {
                return NotFound();
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", test_case.id_url);
            return View(test_case);
        }

        // POST: TestCase/GenerateTestCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_testcase,id_url,description,result,is_test,CreatedDate,ModifiedDate")] Test_case test_case)
        {
            if (id != test_case.id_testcase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test_case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Test_caseExists(test_case.id_testcase))
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
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", test_case.id_url);
            return View(test_case);
        }

        // GET: TestCase/GenerateTestCases/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test_case = await _context.Test_case
                .Include(t => t.id_urlNavigation)
                .FirstOrDefaultAsync(m => m.id_testcase == id);
            if (test_case == null)
            {
                return NotFound();
            }

            return View(test_case);
        }

        // POST: TestCase/GenerateTestCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var test_case = await _context.Test_case.FindAsync(id);
            _context.Test_case.Remove(test_case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Test_caseExists(string id)
        {
            return _context.Test_case.Any(e => e.id_testcase == id);
        }
    }
}
