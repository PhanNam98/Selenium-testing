using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            listSpecialCharacter = new List<string>();
            listSpecialCharacter.Add("!");
            listSpecialCharacter.Add("#");
            listSpecialCharacter.Add("$");
            listSpecialCharacter.Add("%");
            listSpecialCharacter.Add("&");
            listSpecialCharacter.Add("^");
            listSpecialCharacter.Add("|");
            listSpecialCharacter.Add(@"\");
            listSpecialCharacter.Add("/");
            listSpecialCharacter.Add("=");
            listSpecialCharacter.Add("?");
            listSpecialCharacter.Add(";");
            listSpecialCharacter.Add(">");
            listSpecialCharacter.Add("<");
            listSpecialCharacter.Add("-");
            listSpecialCharacter.Add("*");
            listSpecialCharacter.Add("+");
            listSpecialCharacter.Add("{");
            listSpecialCharacter.Add("}");
            listSpecialCharacter.Add("(");
            listSpecialCharacter.Add(")");

        }
        private int Id_Url;
        private List<Test_case> ListTestCase;
        private List<List<Input_testcase>> List_ListInputTestcase;
        private List<string> listSpecialCharacter;

        private enum Actions
        {
            fill,
            click,
            select,
            submit
        }

        public List<Test_case> Generate_testcase()
        {
            ListTestCase = new List<Test_case>();
            List_ListInputTestcase = new List<List<Input_testcase>>();
            string b = Generate_RandomSpecialString(1);
            List<Form_elements> forms = BUL.FormBUL.get_ListForm_ByIdUrl(Id_Url);
            if (forms.Count > 0)
            {
                for (int i = 0; i < forms.Count; i++)
                {
                    List<Element> submit = BUL.ElementBUL.get_List_Elt_Type_Submit(Id_Url, forms[i].id_form);
                    for (int j = 0; j < submit.Count; j++)
                    {
                        //NotFill_ClickSubmit(forms[i].id_form, j, submit[j]);
                        Input_Type_Text(forms[i].id_form, j, submit[j]);

                        //ClickAll_TypeRadio(forms[i].id_form, j, submit[j]);
                    }
                }
            }
            else
            {

            }
            var a = List_ListInputTestcase;
            return ListTestCase;

        }
        public bool Save_testcase()
        {
          
            
            if (BUL.TestCaseBUL.Insert_ListTestcase(ListTestCase))
            {
                foreach (var inputtest in List_ListInputTestcase)
                {
                    if (!BUL.InputTestcaseBUL.Insert_ListInputTestcase(inputtest))
                        return false;
                }
                return true;
            }
            return false;
        }
        public List<Test_case> GetTestcase_ByIdUrl(int id_url)
        {

            Id_Url = id_url;

            return null;
        }
        #region Not Fill, Submit
        private void NotFill_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotFill_ClickSubmit_" + id_form + "_" + index_submit;

            Crate_Testcase(id_testCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            int step = 1;
            
            listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));
            List_ListInputTestcase.Add(listInputElt);
           

        }
        #endregion
        #region Input Type Text
        private void Input_Type_Text(string id_form, int index_submit, Element submit)
        {
            Fill_1000_charter_TypeText(id_form, index_submit, submit);
            Fill_Text_TypeText(id_form, index_submit, submit);
            Fill_out_1_Field_Blank_TypeText(id_form, index_submit, submit);
            Fill_Text_Two_Leading_Spaces_TypeText(id_form, index_submit, submit);
            Fill_One_letter_characters_TypeText(id_form, index_submit, submit);
            Fill_Text_Number_TypeText(id_form, index_submit, submit);
            Fill_Text_Number_Special_TypeText(id_form, index_submit, submit);
        }
        private void Fill_1000_charter_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_1000_charter_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);
            if (listTypeText.Count > 0)
            {
                int step = 1;
                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 1000), Actions.fill.ToString(),step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                List_ListInputTestcase.Add(listInputElt);

            }

        }
        private void Fill_Text_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);


            if (listTypeText.Count > 0)
            {
                int step = 1;
                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 8), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                List_ListInputTestcase.Add(listInputElt);

            }
        }
        private void Fill_out_1_Field_Blank_TypeText(string id_form, int index_submit, Element submit)
        {

            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);
            int number_of_elements = listTypeText.Count;

            if (number_of_elements > 0)
            {
                
                for (int i = 0; i < number_of_elements; i++)
                {
                    string id_testCase = "Fill_out_1_Field_Blank_TypeText_" + id_form + "_" + index_submit + "_" + i;
                    Crate_Testcase(id_testCase);
                    List<Input_testcase> listInputElt = new List<Input_testcase>();
                    int step = 1;
                    for (int j = 0; j < listTypeText.Count; j++)
                    {
                        if(i==j)
                        {
                            listInputElt.Add(Crate_InputTestcase(listTypeText[j], id_testCase,"", Actions.fill.ToString(),step++));
                        }
                        else
                        {
                            Random random = new Random();
                            listInputElt.Add(Crate_InputTestcase(listTypeText[j], id_testCase, Generate_RandomString(random, 8), Actions.fill.ToString(),step++));
                        }
                        

                    }
                    listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                    List_ListInputTestcase.Add(listInputElt);

                }

            }
        }
        private void Fill_Text_Two_Leading_Spaces_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_Two_Leading_Spaces_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);


            if (listTypeText.Count > 0)
            {

                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                int step = 1;
                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, " " + Generate_RandomString(random, 8) + " ", Actions.fill.ToString(),step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                List_ListInputTestcase.Add(listInputElt);

            }
        }
        private void Fill_One_letter_characters_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_One_letter_characters_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);
            if (listTypeText.Count > 0)
            {

                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                int step = 1;
                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 1), Actions.fill.ToString(),step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                List_ListInputTestcase.Add(listInputElt);

            }

        }
        private void Fill_Text_Number_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_Number_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

            if (listTypeText.Count > 0)
            {

                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                int step = 1;
                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 6) + Generate_RandomNumber(random, 0, 100) + Generate_RandomString(random, 3), Actions.fill.ToString(),step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                List_ListInputTestcase.Add(listInputElt);

            }
        }
        private void Fill_Text_Number_Special_TypeText(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_Number_Special_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);


            if (listTypeText.Count > 0)
            {

                Crate_Testcase(id_testCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                int step = 1;
                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomStringNumberSpecialString(random), Actions.fill.ToString(),step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(),step++));

                List_ListInputTestcase.Add(listInputElt);

            }
        }
        #endregion


        #region Input type Number
        public void Fill_Big_Number_TypeNumber_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Big_Number_TypeNumber_" + id_form + "_" + index_submit;
            var listTypeNumber = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "number", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeNumber.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeNumber[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = (99999999999999999).ToString();
                newinput.action = "fill";
                newinput.xpath = listTypeNumber[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Letter_characters_TypeNumber_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Letter_charter_TypeNumber_" + id_form + "_" + index_submit;
            var listTypeNumber = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "number", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeNumber.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeNumber[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(2);
                newinput.action = "fill";
                newinput.xpath = listTypeNumber[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Special_characters_TypeNumber_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Letter_charter_TypeNumber_" + id_form + "_" + index_submit;
            var listTypeNumber = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "number", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeNumber.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeNumber[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomSpecialString(2);
                newinput.action = "fill";
                newinput.xpath = listTypeNumber[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Number_characters_TypeNumber_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Number_characters_TypeNumber_" + id_form + "_" + index_submit;
            var listTypeNumber = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "number", id_form);
            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeNumber.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeNumber[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                try
                {
                    newinput.value = Generate_RandomNumber((int)listTypeNumber[i].minlength, (int)listTypeNumber[i].maxlength).ToString();
                }
                catch
                {
                    newinput.value = Generate_RandomNumber(0, 9).ToString();
                }

                newinput.action = "fill";
                newinput.xpath = listTypeNumber[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Input Type Email
        public void Fill_Not_Format_Email_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Not_Format_Email_TypeEmail_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "email", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeText.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeText[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(5) + "@" + Generate_RandomString(4);
                newinput.action = "fill";
                newinput.xpath = listTypeText[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Format_Email_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Format_Email_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "email", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeText.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeText[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomEmail();
                newinput.action = "fill";
                newinput.xpath = listTypeText[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Special_characters_TypeEmail_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Special_characters_TypeEmail_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "email", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeText.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeText[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(1) + Generate_RandomSpecialString(1) + Generate_RandomEmail();
                newinput.action = "fill";
                newinput.xpath = listTypeText[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Input Type Password
        public void Fill_1000_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_1000_character_TypePassword_" + id_form + "_" + index_submit;
            var listTypePass = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "password", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypePass.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypePass[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(1000);
                newinput.action = "fill";
                newinput.xpath = listTypePass[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill__Less_Than_8_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Less_Than_8_character_TypePassword_" + id_form + "_" + index_submit;
            var listTypePass = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "password", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypePass.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypePass[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(7);
                newinput.action = "fill";
                newinput.xpath = listTypePass[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill__Special_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Special_character_TypePassword_" + id_form + "_" + index_submit;
            var listTypePass = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "password", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypePass.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypePass[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(7) + Generate_RandomSpecialString(1);
                newinput.action = "fill";
                newinput.xpath = listTypePass[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill__Number_Special_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Number_Special_character_TypePassword_" + id_form + "_" + index_submit;
            var listTypePass = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "password", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypePass.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypePass[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomString(7) + Generate_RandomNumber(0, 99) + Generate_RandomSpecialString(1);
                newinput.action = "fill";
                newinput.xpath = listTypePass[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill__Capital_Number_Special_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Number_Special_character_TypePassword_" + id_form + "_" + index_submit;
            var listTypePass = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "password", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypePass.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypePass[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomPassword();
                newinput.action = "fill";
                newinput.xpath = listTypePass[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Input Type Date
        public void Fill_Only_Day_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Only_Day_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "0000-00" + Generate_RandomNumber(1, 31).ToString();
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Only_Month_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Only_Month_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "0000-" + Generate_RandomNumber(1, 31).ToString() + "-00";
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Only_Year_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Only_Year_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomNumber(1, 31).ToString() + "-00-00";
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Incorrect_format_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Incorrect_format_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomNumber(1990, (int)DateTime.Now.Year) + "," + Generate_RandomNumber(1, 31).ToString() + "," + Generate_RandomNumber(1, 12);
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_OverDayInMonth_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_OverDayInMonth_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomNumber(1990, (int)DateTime.Now.Year) + "-" + Generate_RandomNumber(1, 12) + "-" + 32;
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_OverMonthInYear_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_OverMonthInYear_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomNumber(1990, (int)DateTime.Now.Year) + "-" + 13 + "-" + Generate_RandomNumber(1, 31);
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_LeapYear_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_LeapYear_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "1996-02-29";
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_NotLeapYear_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_LeapYear_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "1998-02-29";
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_Day31InMonth_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Day31InMonth_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomNumber(1990, DateTime.Now.Year) + "-05-31";
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void Fill_NotDay31InMonth_TypeDate(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Day31InMonth_TypeDate_" + id_form + "_" + index_submit;
            var listTypeDate = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "date", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeDate.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeDate[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = Generate_RandomNumber(1990, DateTime.Now.Year) + "-04-31";
                newinput.action = "fill";
                newinput.xpath = listTypeDate[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Input CheckBox
        public void Click_Any_CheckBox_TypeCheckBox(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotClick_TypeCkeckBox_" + id_form + "_" + index_submit;
            var listTypeCheckbox = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "checkbox", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            bool isclick = true;
            for (int i = 0; i < listTypeCheckbox.Count; i++)
            {
                if (isclick)
                {
                    Input_testcase newinput = new Input_testcase();
                    newinput.id_element = listTypeCheckbox[i].id_element;
                    newinput.id_testcase = id_testCase;
                    newinput.id_url = Id_Url;
                    newinput.value = "";
                    newinput.action = "click";
                    newinput.xpath = listTypeCheckbox[i].xpath;
                    listInputElt.Add(newinput);
                    isclick = false;
                }
                else
                    isclick = true;

            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void ClickAll_TypeCheckBox(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotClick_TypeCkeckBox_" + id_form + "_" + index_submit;
            var listTypeCheckbox = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "checkbox", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            for (int i = 0; i < listTypeCheckbox.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeCheckbox[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "";
                newinput.action = "click";
                newinput.xpath = listTypeCheckbox[i].xpath;
                listInputElt.Add(newinput);
            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Select
        public void NotSelect_TypeSelect(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotSelect_TypeSelect_" + id_form + "_" + index_submit;
            var listTypeSelect = BUL.ElementBUL.get_List_Element_Tag(Id_Url, "select", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            bool isclick = true;
            for (int i = 0; i < listTypeSelect.Count; i++)
            {
                if (isclick)
                {
                    Input_testcase newinput = new Input_testcase();
                    newinput.id_element = listTypeSelect[i].id_element;
                    newinput.id_testcase = id_testCase;
                    newinput.id_url = Id_Url;
                    newinput.value = "1";
                    newinput.action = "select";
                    newinput.xpath = listTypeSelect[i].xpath;
                    listInputElt.Add(newinput);
                    isclick = false;
                }
                else
                    isclick = true;

            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void SelectAllElement_TypeSelect(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "SelectAllElement_TypeSelect_" + id_form + "_" + index_submit;
            var listTypeSelect = BUL.ElementBUL.get_List_Element_Tag(Id_Url, "select", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();

            for (int i = 0; i < listTypeSelect.Count; i++)
            {
                Input_testcase newinput = new Input_testcase();
                newinput.id_element = listTypeSelect[i].id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "1";
                newinput.action = "select";
                newinput.xpath = listTypeSelect[i].xpath;
                listInputElt.Add(newinput);

            }
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Input Type Radio
        public void ClickAll_TypeRadio(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "ClickAll_TypeRadio_" + id_form + "_" + index_submit;
            var listTypeRadio = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "radio", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            List<List<Element>> listRadio = new List<List<Element>>();
            List<Element> listEltRadio = new List<Element>();
            var groupedRadioList = listTypeRadio
            .GroupBy(u => u.name)
            .Select(grp => grp.ToList())
            .ToList();
            foreach (var group in groupedRadioList)
            {

                Input_testcase newinput = new Input_testcase();
                Random random = new Random();
                Element radio = group[random.Next(0, group.Count + 1)];
                newinput.id_element = radio.id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = "";
                //newinput.action = "select";
                newinput.action = "click";
                newinput.xpath = radio.xpath;
                listInputElt.Add(newinput);

            }
            //for (int i = 0; i < listTypeRadio.Count; i++)
            //{
            //    Input_testcase newinput = new Input_testcase();
            //    newinput.id_element = listTypeRadio[i].id_element;
            //    newinput.id_testcase = id_testCase;
            //    newinput.id_url = Id_Url;
            //    newinput.value = "";
            //    newinput.action = "select";
            //    newinput.xpath = listTypeRadio[i].xpath;
            //    listInputElt.Add(newinput);
            //}
            Input_testcase newsubmit = new Input_testcase();
            newsubmit.id_element = submit.id_element;
            newsubmit.id_testcase = id_testCase;
            newsubmit.id_url = Id_Url;
            newsubmit.action = "click";
            newsubmit.xpath = submit.xpath;
            listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        public void NotClick_TypeRadio(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotClick_TypeRadio_" + id_form + "_" + index_submit;
            var listTypeRadio = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "radio", id_form);

            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            //List<List<Element>> listRadio = new List<List<Element>>();
            //List<Element> listEltRadio = new List<Element>();
            //var groupedRadioList = listTypeRadio
            //.GroupBy(u => u.name)
            //.Select(grp => grp.ToList())
            //.ToList();
            //foreach (var group in groupedRadioList)
            //{

            //    Input_testcase newinput = new Input_testcase();
            //    Random random = new Random();
            //    Element radio = group[random.Next(0, group.Count)];
            //    newinput.id_element = radio.id_element;
            //    newinput.id_testcase = id_testCase;
            //    newinput.id_url = Id_Url;
            //    newinput.value = "";
            //    newinput.action = "select";
            //    newinput.xpath = radio.xpath;
            //    listInputElt.Add(newinput);

            //}
            //for (int i = 0; i < listTypeRadio.Count; i++)
            //{
            //    Input_testcase newinput = new Input_testcase();
            //    newinput.id_element = listTypeRadio[i].id_element;
            //    newinput.id_testcase = id_testCase;
            //    newinput.id_url = Id_Url;
            //    newinput.value = "";
            //    newinput.action = "select";
            //    newinput.xpath = listTypeRadio[i].xpath;
            //    listInputElt.Add(newinput);
            //}
            //Input_testcase newsubmit = new Input_testcase();
            //newsubmit.id_element = submit.id_element;
            //newsubmit.id_testcase = id_testCase;
            //newsubmit.id_url = Id_Url;
            //newsubmit.action = "click";
            //newsubmit.xpath = submit.xpath;
            //listInputElt.Add(newsubmit);
            List_ListInputTestcase.Add(listInputElt);
        }
        #endregion
        #region Tag a
        public void ClickAll_Tag_a()
        {
            string id_testCase = "ClickAll_Tag_a_";
            var listTaga = BUL.ElementBUL.get_List_Element_Tag(Id_Url, "a");
            if (listTaga.Count > 0)
            {
                for (int i = 0; i < listTaga.Count; i++)
                {
                    Test_case newTestCase = new Test_case();
                    newTestCase.id_testcase = id_testCase + i;
                    newTestCase.id_url = Id_Url;
                    newTestCase.result = "";
                    newTestCase.is_test = true;
                    newTestCase.CreatedDate = DateTime.Now.Date;
                    newTestCase.ModifiedDate = DateTime.Now.Date;
                    ListTestCase.Add(newTestCase);
                    List<Input_testcase> listInputElt = new List<Input_testcase>();
                    Input_testcase newinput = new Input_testcase();
                    Element a = listTaga[i];
                    newinput.id_element = a.id_element;
                    newinput.id_testcase = id_testCase;
                    newinput.id_url = Id_Url;
                    newinput.value = "";
                    newinput.action = "click";
                    newinput.xpath = a.xpath;
                    listInputElt.Add(newinput);
                }

            }


        }
        #endregion
        #region Tag Button
        public void ClickAll_Tag_Button()
        {
            string id_testCase = "ClickAll_Tag_Button_";
            var listTaga = BUL.ElementBUL.get_List_Button_Not_Type_Submit(Id_Url);
            if (listTaga.Count > 0)
            {
                for (int i = 0; i < listTaga.Count; i++)
                {
                    Test_case newTestCase = new Test_case();
                    newTestCase.id_testcase = id_testCase + i;
                    newTestCase.id_url = Id_Url;
                    newTestCase.result = "";
                    newTestCase.is_test = true;
                    newTestCase.CreatedDate = DateTime.Now.Date;
                    newTestCase.ModifiedDate = DateTime.Now.Date;
                    ListTestCase.Add(newTestCase);
                    List<Input_testcase> listInputElt = new List<Input_testcase>();
                    Input_testcase newinput = new Input_testcase();
                    Element a = listTaga[i];
                    newinput.id_element = a.id_element;
                    newinput.id_testcase = id_testCase;
                    newinput.id_url = Id_Url;
                    newinput.value = "";
                    newinput.action = "click";
                    newinput.xpath = a.xpath;
                    listInputElt.Add(newinput);
                }

            }


        }
        #endregion
        #region Helper Generate
        ///https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

        public string Generate_RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(4, true));
            builder.Append(Generate_RandomSpecialString(1));
            builder.Append(Generate_RandomNumber(1000, 9999));
            builder.Append(Generate_RandomString(2, false));
            return builder.ToString();
        }
        public string Generate_RandomEmail()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(8, true));
            builder.Append(Generate_RandomNumber(0, 99));
            builder.Append("@email.com");
            return builder.ToString();
        }
        public string Generate_RandomStringNumberSpecialString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(8, true));
            builder.Append(Generate_RandomNumber(0, 99));
            builder.Append(Generate_RandomSpecialString(2));
            return builder.ToString();
        }
        public string Generate_RandomStringNumberSpecialString(Random random)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(random, 8, true));
            builder.Append(Generate_RandomSpecialString(random, 2));
            builder.Append(Generate_RandomNumber(random, 0, 100));
            builder.Append(Generate_RandomString(random, 3, true));
            return builder.ToString();
        }
        public string Generate_RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Thread.Sleep(10);
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string Generate_RandomString(Random random, int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Thread.Sleep(10);

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string Generate_RandomSpecialString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 20)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public string Generate_RandomSpecialString(Random random, int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 20)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public int Generate_RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public int Generate_RandomNumber(Random random, int min, int max)
        {

            return random.Next(min, max);
        }
      
        public bool Crate_Testcase(string id_testCase)
        {
            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            //return BUL.TestCaseBUL.InsertTestcase(newTestCase);
            return true;

        }
        public Input_testcase Crate_InputTestcase(Element testElt, string id_testCase, string value, string action,int step)
        {
            Input_testcase newinput = new Input_testcase();
            try
            {
                newinput.id_element = testElt.id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = value;
                newinput.action = action;
                newinput.xpath = testElt.xpath;
                newinput.test_step = step;
            }
            catch
            {
                return null;
            }
            return newinput;


        }
        #endregion

    }
}
