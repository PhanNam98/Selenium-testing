using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BUL
{
    public static class TestCaseBUL
    {
        static TestCaseDAL testCaseDAL;
        static TestCaseBUL()
        {
            testCaseDAL = new TestCaseDAL();
        }
        public static bool InsertTestcase(Test_case newTestcase)
        {
            return testCaseDAL.insert_Testcase(newTestcase);
        }
        public static bool Insert_ListTestcase(List<Test_case> newList)
        {
            return testCaseDAL.insert_ListTestcase(newList);
        }
        public static List<Test_case> Get_ListTestcase(int id_url)
        {
            return testCaseDAL.get_ListTestcase(id_url);
        }
        public static string Get_ResultTestcase(int id_url, string id_testcase)
        {
            return testCaseDAL.get_ResultTestcase(id_url, id_testcase);
        }
    }
}
