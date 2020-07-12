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
        [Description("Description")]
        public string Description { get; set; }
        [Description("Result")]
        public string Result { get; set; }
        [Description("Test Data")]
        public string TestData { get; set; }
        [Description("Test Elements")]
        public string TestElement{ get; set; }
        [Description("Result Test Elements")]
        public string ResultTestElement { get; set; }

        public TestcaseExcel()
        {

        }
        public List<TestcaseExcel> ConvertToTestcaseExcel(List<Test_case> listtest_Cases)
        {
            List<TestcaseExcel> testcaseExcels = new List<TestcaseExcel>();
            foreach(var testcase in listtest_Cases)
            {
                TestcaseExcel testcaseExcel = new TestcaseExcel();
                testcaseExcel.Id_testcase = testcase.id_testcase;
                testcaseExcel.Description = testcase.description;
                string testdata = "";
                string testelement = "";
                string resulttestelement = "";
                foreach (var data in testcase.Input_testcase)
                {
                    testdata += data.id_element+ ": ("+data.action+") " + data.value + "\n";
                }
                testcaseExcel.TestData = testdata;
                foreach (var data in testcase.Element_test)
                {
                    testelement += data.xpath_full + ": " + data.value_test + "\n";
                    resulttestelement += data.xpath_full + ": " + data.value_return + "\n";
                }
                testcaseExcel.Result = testcase.result;
                testcaseExcel.ResultTestElement = resulttestelement;
                testcaseExcel.TestElement = testelement;

                testcaseExcels.Add(testcaseExcel);
            }
            return testcaseExcels;
        }
        public List<TestcaseExcel> ConvertToTestcaseExcel(List<Result_testcase> listtest_Cases,Result_AlertMessage result_Alert=null,Result_Url result_Url=null)
        {
            List<TestcaseExcel> testcaseExcels = new List<TestcaseExcel>();
            foreach (var testcase in listtest_Cases)
            {
                TestcaseExcel testcaseExcel = new TestcaseExcel();
                testcaseExcel.Id_testcase = testcase.id_testcase;
                testcaseExcel.Description = testcase.id_.description;
                string testdata = "";
                string testelement = "";
                string resulttestelement = "";
                foreach (var data in testcase.Input_Result_test.OrderBy(p=>p.step))
                {
                    testdata += data.id_element + ": (" + data.action + ") " + data.value + "\n";
                }
                testcaseExcel.TestData = testdata;
                foreach (var data in testcase.Test_element_Result_test)
                {
                    testelement += data.xpath + ": " + data.value_test + "\n";
                    resulttestelement += data.xpath + ": " + data.value + "\n";
                }
                if(result_Alert!=null)
                {
                    testelement +=  "Alert: " + result_Alert.test_message + "\n";
                    resulttestelement += "Alert: " + result_Alert.message + "\n";
                }
                if(result_Url != null)
                {
                    testelement +=  "Redirect url: " + result_Url.test_url + "\n";
                    resulttestelement += "Redirect url: " + result_Url.return_url + "\n";
                }
                testcaseExcel.Result = testcase.Result;
                testcaseExcel.ResultTestElement = resulttestelement;
                testcaseExcel.TestElement = testelement;

                testcaseExcels.Add(testcaseExcel);
            }
            return testcaseExcels;
        }


    }
}
