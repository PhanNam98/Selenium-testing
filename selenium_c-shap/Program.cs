using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_c_shap
{
    class Program
    {

        static void Main(string[] args)
        {
            ChromeDriver chromedriver = new ChromeDriver();
            chromedriver.Url = "https://facebook.com/";
            chromedriver.Navigate();
            var a = chromedriver.FindElementsByXPath("//input[@type='text']");
            Console.WriteLine("Count: " + a.Count());
            
            //for (int i = 0; i < a.Count(); i++)
            //{
            //    Console.WriteLine("input text name: " + a[i].GetAttribute("name"));
            //    Console.WriteLine("input text id: " + a[i].GetAttribute("id"));
            //    Console.WriteLine("input text Tagname: " + a[i].TagName);
            //    string xpath = getAbsoluteXPath(chromedriver, a[i]);
            //    Console.WriteLine("input text xpath relative: " + xpath);
            //    var a1 = chromedriver.FindElementByXPath(xpath);
            //    Console.WriteLine("Compare"+ a[i].Equals(a1).ToString());

            //}

            IWebElement formElement =chromedriver.FindElementById("login_form");
            var allFormChildElements = formElement.FindElements(By.XPath("//input[@type='text']"));
            var allFormChildElements1 = chromedriver.FindElementsByXPath("//form[@id='login_form']/*");
            for (int i = 0; i < allFormChildElements.Count(); i++)
            {
                Console.WriteLine("input text name: " + allFormChildElements[i].GetAttribute("name"));
                Console.WriteLine("input text id: " + allFormChildElements[i].GetAttribute("id"));
                Console.WriteLine("input text Tagname: " + allFormChildElements[i].TagName);
                string xpath = getAbsoluteXPath(chromedriver, allFormChildElements[i]);
                Console.WriteLine("input text xpath relative: " + xpath);
              

            }
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

    }
}
