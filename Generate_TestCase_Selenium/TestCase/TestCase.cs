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
        private List<List<Input_testcase>> List_ListInputTestcase;
        public List<Test_case> Generate_testcase()
        {
            ListTestCase = new List<Test_case>();
            List_ListInputTestcase = new List<List<Input_testcase>>();
            List<Form_elements> forms = BUL.FormBUL.get_ListForm_ByIdUrl(Id_Url);
            if (forms.Count > 0)
            {
                for (int i = 0; i < forms.Count; i++)
                {
                    List<Element> submit = BUL.ElementBUL.get_List_Elt_Type_Submit(Id_Url, forms[i].id_form);
                    for (int j = 0; j < submit.Count; j++)
                    {
                        NotFill_ClickSubmit(forms[i].id_form, j, submit[j]);
                    }
                }
            }
            else
            {

            }
            var a= List_ListInputTestcase;
            return ListTestCase;

        }
        public List<Test_case> GetTestcase_ByIdUrl(int id_url)
        {

            Id_Url = id_url;

            return null;
        }
        public void NotFill_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotFill_ClickSubmit_" + id_form + "_" + index_submit + "_";
            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "Pass";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            Input_testcase newinput = new Input_testcase();
            newinput.id_element = submit.id_element;
            newinput.id_testcase = id_testCase;
            newinput.id_url = Id_Url;
            newinput.action = "click";
            newinput.xpath = submit.xpath;
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            listInputElt.Add(newinput);
            List_ListInputTestcase.Add(listInputElt);

        }
    }
}
