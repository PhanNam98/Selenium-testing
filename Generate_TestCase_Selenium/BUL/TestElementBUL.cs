using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BUL
{
    public static class TestElementBUL
    {
        static TestElementDAL testElementDAL;
        static TestElementBUL()
        {
            testElementDAL = new TestElementDAL();
        }
        public static bool Insert_TestElement(Element_test newElttest)
        {
            return testElementDAL.insert_TestElement(newElttest);
        }
        public static bool Update_TestElement(Element_test newElttest)
        {
            return testElementDAL.Update_TestElement(newElttest);
        }
        public static bool Delete_TestElement(Element_test oldElttest)
        {
            return testElementDAL.Delete_TestElement(oldElttest);
        }
        //public static bool Insert_ListTestcase(List<Test_case> newList)
        //{
        //    return testCaseDAL.insert_ListTestcase(newList);
        //}
        public static List<Element_test> Get_ListTestElemt(int id_url,string id_testcase)
        {
            return testElementDAL.get_ElementTest_ByIdTestcase(id_testcase,id_url);
        }
        public static bool Update_ValueResult_Testcase(int id_url, string id_testcase, string valueresult)
        {
            return testElementDAL.update_ValueResult_Testcase(id_url, id_testcase, valueresult);
        }

    }
}
