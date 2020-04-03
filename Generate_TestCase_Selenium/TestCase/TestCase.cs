using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace TestCase
{
    public class TestCase
    {
        public TestCase() { }
        public TestCase(int id_url) 
        {
            this.Id_Url = id_url;
        }
        private int Id_Url;
        private List<Test_case> ListTestCase;
        public List<Test_case> Generate_testcase()
        {
            ListTestCase = new List<Test_case>();
            NotFill_ClickSubmit();
            return ListTestCase;

        }
        public List<Test_case> GetTestcase_ByIdUrl(int id_url)
        {
           
             Id_Url= id_url;
            return null;
        }
        public void NotFill_ClickSubmit()
        {
            string id_testCase = "NotFill_ClickSubmit_";

            List<Form_elements> forms = BUL.FormBUL.get_ListForm_ByIdUrl(Id_Url);
            if(forms.Count>0)
            {
                for(int i=0;i<forms.Count;i++)
                {
                    List<Element> submit = BUL.ElementBUL.get_List_Elt_Type_Submit(Id_Url,forms[i].id_form);
                    for(int j=0;j<submit.Count;j++)
                    {
                        Test_case newTestCase = new Test_case();
                        newTestCase.id_testcase = id_testCase + (i+1) + "_" + (j+1);
                        newTestCase.id_url = Id_Url;
                        newTestCase.result = "Pass";
                        newTestCase.is_test = true;
                        newTestCase.CreatedDate = DateTime.Now.Date;
                        newTestCase.ModifiedDate = DateTime.Now.Date;
                        ListTestCase.Add(newTestCase);
                    }
                }
            }
            else
            {

            }

        }
    }
}
