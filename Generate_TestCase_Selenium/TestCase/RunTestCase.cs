using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace TestCase
{
    public class RunTestCase
    {
        public RunTestCase() { }
        public RunTestCase(int id_url, string url, string id_testcase)
        {
            ID_URL = id_url;
            URL = url;
            Id_testcase = id_testcase;

        }
        private ChromeDriver chromedriver;
        private int ID_URL;
        private string URL;
        private string Id_testcase;
        private Thread runTest;
        public void Run()
        {
          
            int isPass = 1;
            //try
            //{
            SetUpDriver(URL);
            chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var list_inputtest = BUL.InputTestcaseBUL.Get_InputTestcase_ByIdTestcase(Id_testcase, ID_URL).ToList();
            var list_output = BUL.TestElementBUL.Get_ListTestElemt(ID_URL, Id_testcase).ToList();
            //var submit = list_inputtest.Where(p => p.action.Equals("submit")).SingleOrDefault();
            foreach (var inputtest in list_inputtest)
            {
                switch (inputtest.action)
                {

                    case "fill":
                        {
                            try
                            {
                                var fill = chromedriver.FindElementByXPath(inputtest.xpath);
                                fill.Click();
                                fill.SendKeys(inputtest.value);
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
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
                            chromedriver.FindElementByXPath(inputtest.xpath).Click();
                            break;
                        }
                }
            }


            if (list_output.Count > 0)
            {
                foreach (var outputtest in list_output)
                {
                    try
                    {
                        IWebElement testelt;
                        try
                        {
                            testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                        }
                        catch
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
                                        isPass = 0;
                                    }
                                }
                                break;
                            }
                            catch
                            {

                            }
                        }
                    }
                    catch
                    {
                        foreach (var inputtest in list_inputtest)
                        {
                            try
                            {
                                chromedriver.FindElementByXPath(inputtest.xpath).Click();
                                try
                                {
                                    IWebElement testelt;
                                    try
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                    }
                                    catch
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
                                                    isPass = 0;
                                                }
                                            }
                                            break;
                                        }
                                        catch
                                        {

                                        }

                                    }


                                }
                                catch
                                {

                                }
                            }
                            catch
                            {

                            }



                        }
                    }



                }
            }
            else
            {
                isPass = -1;
            }

            QuitDriver();
            if(isPass==1)
            {
                BUL.TestCaseBUL.Update_ResultTestcase(ID_URL, Id_testcase, "Pass");
            }
            else
            {
                if (isPass == 0)
                {
                    BUL.TestCaseBUL.Update_ResultTestcase(ID_URL, Id_testcase, "Failure");
                }
                else
                {
                    BUL.TestCaseBUL.Update_ResultTestcase(ID_URL, Id_testcase, "Skip");
                }
            }
            //}
            //catch
            //{

            //}
        }
        public string Run_ReturnResult()
        {

            int isPass = 1;
            //try
            //{
            SetUpDriver(URL);
            chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var list_inputtest = BUL.InputTestcaseBUL.Get_InputTestcase_ByIdTestcase(Id_testcase, ID_URL).ToList();
            var list_output = BUL.TestElementBUL.Get_ListTestElemt(ID_URL, Id_testcase).ToList();
            //var submit = list_inputtest.Where(p => p.action.Equals("submit")).SingleOrDefault();
            foreach (var inputtest in list_inputtest)
            {
                switch (inputtest.action)
                {

                    case "fill":
                        {
                            try
                            {
                                var fill = chromedriver.FindElementByXPath(inputtest.xpath);
                                fill.Click();
                                fill.SendKeys(inputtest.value);
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
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
                    try
                    {
                        IWebElement testelt;
                        try
                        {
                            testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                        }
                        catch
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
                                        isPass = 0;
                                    }
                                }
                                break;
                            }
                            catch
                            {

                            }
                        }
                    }
                    catch
                    {
                        foreach (var inputtest in list_inputtest)
                        {
                            try
                            {
                                chromedriver.FindElementByXPath(inputtest.xpath).Click();
                                try
                                {
                                    IWebElement testelt;
                                    try
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                    }
                                    catch
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
                                                    isPass = 0;
                                                }
                                            }
                                            break;
                                        }
                                        catch
                                        {

                                        }

                                    }


                                }
                                catch
                                {

                                }
                            }
                            catch
                            {

                            }



                        }
                    }



                }
            }
            else
            {
                isPass = -1;
            }

            QuitDriver();
            string result;
            if (isPass == 1)
            {
                BUL.TestCaseBUL.Update_ResultTestcase(ID_URL, Id_testcase, "Pass");
                result = "Pass";
            }
            else
            {
                if (isPass == 0)
                {
                    BUL.TestCaseBUL.Update_ResultTestcase(ID_URL, Id_testcase, "Failure");
                    result = "Failure";
                }
                else
                {
                    BUL.TestCaseBUL.Update_ResultTestcase(ID_URL, Id_testcase, "Skip");
                    result = "Skip";
                }
            }
            return result;
            //}
            //catch
            //{

            //}
        }
        private void SetUpDriver(string url)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            chromedriver = new ChromeDriver(service, options);
            chromedriver.Url = url;
            chromedriver.Navigate();
        }

        private void QuitDriver()
        {

            chromedriver.Quit();

        }
        private void CloseDriver()
        {

            chromedriver.Close();

        }
    }
}
