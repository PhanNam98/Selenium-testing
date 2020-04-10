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
    }
}
