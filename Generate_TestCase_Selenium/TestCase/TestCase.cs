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
                        NotFill_ClickSubmit(forms[i].id_form, j, submit[j]);
                        Fill_1000_charter_TypeText_ClickSubmit(forms[i].id_form, j, submit[j]);
                    }
                }
            }
            else
            {

            }
            var a = List_ListInputTestcase;
            return ListTestCase;

        }
        public List<Test_case> GetTestcase_ByIdUrl(int id_url)
        {

            Id_Url = id_url;

            return null;
        }
        #region Not Fill, Submit
        public void NotFill_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "NotFill_ClickSubmit_" + id_form + "_" + index_submit;
            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
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
        #endregion
        #region Field Input Type Text
        public void Fill_1000_charter_TypeText_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_1000_charter_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

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
                newinput.value = Generate_RandomString(1000);
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
        public void Fill_Text_TypeText_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

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
                newinput.value = Generate_RandomString(8);
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
        public void Fill_One_letter_characters_TypeText_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_One_letter_characters_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

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
                newinput.value = Generate_RandomString(1);
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
        public void Fill_Text_Number_TypeText_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_Number_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

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
                newinput.value = Generate_RandomString(6) + Generate_RandomNumber(0, 99) + Generate_RandomString(3);
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
        public void Fill_Text_Number_Special_TypeText_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string id_testCase = "Fill_Text_Number_Special_TypeText_" + id_form + "_" + index_submit;
            var listTypeText = BUL.ElementBUL.get_List_Input_Tag_Type(Id_Url, "text", id_form);

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
                newinput.value = Generate_RandomStringNumberSpecialString();
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
        #region Field Input type Number
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

        ////Helper
        ///https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

        public string Generate_RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(4, true));
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
        public string Generate_RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
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
        public string Generate_RandomSpecialString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 19)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public int Generate_RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
}
