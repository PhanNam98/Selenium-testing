using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
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

        public void Run()
        {
            //try
            //{
            SetUpDriver(URL);
            chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var list_inputtest = BUL.InputTestcaseBUL.Get_InputTestcase_ByIdTestcase(Id_testcase, ID_URL).ToList();
                var submit = list_inputtest.Where(p => p.action.Equals("submit")).SingleOrDefault();
                foreach (var inputtest in list_inputtest)
                {
                    switch (inputtest.action)
                    {
                       
                        case "fill":
                            {
                            try
                            {
                                var asd = chromedriver.FindElementByXPath(inputtest.xpath);
                                var ta = asd.GetAttribute("id");
                                asd.Click();
                                asd.SendKeys(inputtest.value);
                            }
                            catch(Exception e)
                            {
                                if(e.Message.Equals("element not interactable"))
                                {

                                }
                            }
                            

                                break;
                            }
                        case "select":
                            {
                                break;
                            }
                        case "click":
                            {
                                break;
                            }
                    }
                }
                chromedriver.FindElementByXPath(submit.xpath).Click();
                //QuitDriver();
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
