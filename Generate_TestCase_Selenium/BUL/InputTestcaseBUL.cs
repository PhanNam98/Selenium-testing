using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BUL
{
    public static class InputTestcaseBUL
    {
        static InputTestcaseDAL inputTestcase;
        static InputTestcaseBUL()
        {
            inputTestcase = new InputTestcaseDAL();
        }
        public static bool Insert_InputTestcase(Input_testcase newInput)
        {
           
            return inputTestcase.insert_InputTestcase(newInput);
        }
        public static bool Insert_ListInputTestcase(List<Input_testcase> newListInput)
        { 
            return inputTestcase.insert_ListInputTestcase(newListInput);
        }
        public static List<Input_testcase> Get_InputTestcase_ByIdTestcase(string id_testcase, int id_url)
        {
           
            return inputTestcase.get_InputTestcase_ByIdTestcase(id_testcase,id_url);
        }
        public static bool Delete_ListInputTestcase(string id_testcase, int id_url)
        {
            return inputTestcase.delete_InputTestElement(id_testcase, id_url);
        }
        public static bool Update_ListInputTestcase(Input_testcase oldElement)
        {
            return inputTestcase.update_InputTestElement(oldElement);
        }
        public static bool update_ValueInputTestElement(int id_url, string id_testcase,string id_element, string value)
        {
            return inputTestcase.update_ValueInputTestElement(id_url, id_testcase, id_element, value);
        }
    }
}
