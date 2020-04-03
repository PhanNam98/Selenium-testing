using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BUL;
using System.Runtime.InteropServices;

namespace Crawler
{
    public class ElementCrawl
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private string Url;

        private ChromeDriver chromedriver;
        private List<Form_elements> listForm;
        private List<Element> listElt;
        private int id_for_elt = 0;
        private string[] tag_elts;
        private string[] type_elts;
        public ElementCrawl() { }

        public ElementCrawl(string url)
        {

            SetUp(url);
        }


        public int GetElements()
        {
            int flag = 0;
            try
            {
                //Url newurl = new Url();
                //newurl.name = Url.Substring(8);
                //newurl.url1 = Url;
                //int id_Url = UrlBUL.insertURL(newurl);
                //int id_Url = 3; //For example
                //if (id_Url == -1)
                //{
                //    return -1;
                //}

                SetUpDriver(Url);
                var form = chromedriver.FindElementsByXPath("//form");
                if (form != null)// have at least one form
                {
                    listForm = new List<Form_elements>();
                    for (int i = 0; i < form.Count; i++)
                    {
                        Form_elements form_ = new Form_elements();
                        form_.id_form = form[i].GetAttribute("id");
                        //form_.id_url = id_Url;
                        try
                        {
                            form_.name = form[i].GetAttribute("name");
                        }
                        catch { }
                        try
                        {
                            form_.xpath = getAbsoluteXPath(chromedriver, form[i]);
                        }
                        catch { }
                        //BUL.FormBUL.insert_Form(form_);//save into database
                        listForm.Add(form_);

                    }
                    foreach (string tag in tag_elts)
                    {
                        GetElements(chromedriver,  tag, "", listForm);
                    }
                    //GetElements(chromedriver, id_Url, "a", "", listForm);



                }
                else //no form found
                {
                    foreach (string tag in tag_elts)
                    {
                        GetElements(chromedriver, tag, "");
                    }
                }
                flag = 1;
            }
            catch
            {
                flag = -1;
            }
            CloseDriver();
            return flag;
        }
       
        private void SetUp(string url)
        {
            Url = url;
            listElt = new List<Element>();
            tag_elts = new string[4];
            tag_elts[0] = "input";
            tag_elts[1] = "select";
            tag_elts[2] = "button";
            tag_elts[3] = "a";
            type_elts = new string[9];
            type_elts[0] = "text";
            type_elts[1] = "email";
            type_elts[2] = "button";
            type_elts[3] = "password";
            type_elts[4] = "submit";
            type_elts[5] = "radio";
            type_elts[6] = "checkbox";
            type_elts[7] = "number";
            type_elts[8] = "date";
        }

        private void SetUpDriver(string url)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            chromedriver = new ChromeDriver(service, options);
            chromedriver.Url = url;
            chromedriver.Navigate();
        }

        private void QuitDriver()
        {
          
            chromedriver.Quit();

        }
        private void CloseDriver()
        {

            chromedriver.Close();

        }
        public static String getAbsoluteXPath(ChromeDriver driver, IWebElement element)
        {
            //https://gist.github.com/beatngu13/a3312b98de57610c5ecd27ea84a7fbeb
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            return (String)js.ExecuteScript(
                    "function absoluteXPath(element) {" +
                            "var comp, comps = [];" +
                            "var parent = null;" +
                            "var xpath = '';" +
                            "var getPos = function(element) {" +
                            "var position = 1, curNode;" +
                            "if (element.nodeType == Node.ATTRIBUTE_NODE) {" +
                            "return null;" +
                            "}" +
                            "for (curNode = element.previousSibling; curNode; curNode = curNode.previousSibling) {" +
                            "if (curNode.nodeName == element.nodeName) {" +
                            "++position;" +
                            "}" +
                            "}" +
                            "return position;" +
                            "};" +

                            "if (element instanceof Document) {" +
                            "return '/';" +
                            "}" +

                            "for (; element && !(element instanceof Document); element = element.nodeType == Node.ATTRIBUTE_NODE ? element.ownerElement : element.parentNode) {" +
                            "comp = comps[comps.length] = {};" +
                            "switch (element.nodeType) {" +
                            "case Node.TEXT_NODE:" +
                            "comp.name = 'text()';" +
                            "break;" +
                            "case Node.ATTRIBUTE_NODE:" +
                            "comp.name = '@' + element.nodeName;" +
                            "break;" +
                            "case Node.PROCESSING_INSTRUCTION_NODE:" +
                            "comp.name = 'processing-instruction()';" +
                            "break;" +
                            "case Node.COMMENT_NODE:" +
                            "comp.name = 'comment()';" +
                            "break;" +
                            "case Node.ELEMENT_NODE:" +
                            "comp.name = element.nodeName;" +
                            "break;" +
                            "}" +
                            "comp.position = getPos(element);" +
                            "}" +

                            "for (var i = comps.length - 1; i >= 0; i--) {" +
                            "comp = comps[i];" +
                            "xpath += '/' + comp.name.toLowerCase();" +
                            "if (comp.position !== null) {" +
                            "xpath += '[' + comp.position + ']';" +
                            "}" +
                            "}" +

                            "return xpath;" +

                            "} return absoluteXPath(arguments[0]);", element);
        }
        public static String getElementXPath(ChromeDriver driver, IWebElement elt)
        {
            //https://gist.github.com/beatngu13/a3312b98de57610c5ecd27ea84a7fbeb
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            return (String)js.ExecuteScript(
                    "function getElementXPath(elt) {" +

                        "var path = '';" +
                        "for (; elt && elt.nodeType == 1; elt = elt.parentNode){" +

                            " idx = getElementIdx(elt);" +
                             " xname = elt.tagName;" +
                            " if (idx > 1) xname += '[' + idx + ']';" +
                             "path = '/' + xname + path;}" +


                          " return path;}" +

                    "function getElementIdx(elt){" +

                           "var count = 1;" +
                         " for (var sib = elt.previousSibling; sib; sib = sib.previousSibling){" +

                      "   if (sib.nodeType == 1 && sib.tagName == elt.tagName) count++}" +


                    " return count;}" +
                    "return getElementXPath(arguments[0]);", elt);
        }

        public void GetElements(ChromeDriver driver,string TagName, string TypeName, List<Form_elements> form_elts = null)
        {
            List<IWebElement> allElements = new List<IWebElement>();
            if (TypeName != "" && TagName.Equals("input"))
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}[@type='{1}']", TagName, TypeName)).ToList();
            }
            else
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}", TagName, TypeName)).ToList();
            }



            foreach (var item in allElements)
            {
                if (item.TagName.Equals("input") && Array.IndexOf(type_elts, item.GetAttribute("type")) <= -1)
                {

                }
                else
                {
                    Element elt = new Element();
                    elt.xpath = getAbsoluteXPath(driver, item);
                    if (form_elts != null)
                    {
                        foreach (var form in form_elts)
                        {
                            if (elt.xpath.Contains(form.xpath))
                            {

                                elt.id_form = form.id_form;
                                break;
                            }
                        }
                    }
                    //elt.id_url = id_Url;
                    elt.tag_name = item.TagName;
                    try
                    {
                        elt.id_element = item.GetAttribute("id");
                        if (elt.id_element.Equals(""))
                        {
                            elt.id_element = item.TagName + id_for_elt;
                            id_for_elt++;
                        }
                    }
                    catch
                    {
                        elt.id_element = item.TagName + id_for_elt;
                        id_for_elt++;
                    }
                    try
                    {
                        elt.name = item.GetAttribute("name");
                    }
                    catch
                    {

                    }

                    try
                    {
                        elt.value = item.GetAttribute("value");

                    }
                    catch
                    {
                        elt.value = "";
                    }
                    try
                    {
                        elt.type = item.GetAttribute("type");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.title = item.GetAttribute("title");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.href = item.GetAttribute("href");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.required = item.GetAttribute("required").Equals("true") ? true : false;
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.class_name = item.GetAttribute("class");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.maxlength = Double.Parse(item.GetAttribute("maxlength"));
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.minlength = Double.Parse(item.GetAttribute("minlength"));
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.max_value = item.GetAttribute("max");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.min_value = item.GetAttribute("min");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.read_only = item.GetAttribute("readonly").Equals("true") ? true : false;
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.multiple = item.GetAttribute("multiple").Equals("true") ? true : false;
                    }
                    catch
                    {

                    }
                    listElt.Add(elt);
                    //if (BUL.ElementBUL.insert_Element(elt) == -1)
                    //{
                    //    throw new Exception();
                    //}
                }
            }
            //Use later. dont delete
            //if (item.TagName.Equals("input"))
            //{
            //    switch (item.GetAttribute("type"))
            //    {
            //        case "text":
            //            {

            //                break;
            //            }


            //        case "checkbox":
            //            {
            //                break;
            //            }

            //        case "email":
            //            {
            //                break;
            //            }

            //        case "password":
            //            {
            //                break;
            //            }
            //        case "radio":
            //            {
            //                break;
            //            }
            //        case "number":
            //            {
            //                break;
            //            }
            //        case "button":
            //            {
            //                break;
            //            }
            //        case "date":
            //            {
            //                break;
            //            }
            //        case "file":
            //            {
            //                break;
            //            }
            //        case "submit":
            //            {
            //                break;
            //            }
            //    }
            //}
            //else if (item.TagName.Equals("select"))
            //{

            //}
            //else if (item.TagName.Equals("button"))
            //{

            //}
            //else if (item.TagName.Equals("a"))
            //{

            //}

        }
        public List<Element> GetListElement()
        {
            return this.listElt;
        }
        public List<Form_elements> GetListForm()
        {
            return this.listForm;
        }

        public int StopWebDriver()
        {
            try
            {
                QuitDriver();
                return 1;
            }
            catch
            {

            }
            return 0;
        }

    }
}
