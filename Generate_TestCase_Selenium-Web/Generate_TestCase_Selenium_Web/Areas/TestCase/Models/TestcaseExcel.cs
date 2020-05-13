using Generate_TestCase_Selenium_Web.Models.ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Models
{
    public class TestcaseExcel
    {
        [Description("Test case")]
        public string Id_testcase { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string TestData { get; set; }
        public string TestElement{ get; set; }
        public string ResultTestElement { get; set; }

        public TestcaseExcel()
        {

        }
        public TestcaseExcel(List<Test_case> listtest_Cases)
        {

        }


    }
}
