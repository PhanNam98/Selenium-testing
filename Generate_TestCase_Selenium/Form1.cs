using BUL;
using Generate_TestCase_Selenium.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generate_TestCase_Selenium
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();

        }
        private ChromeDriver chromedriver;
        private void btnCrawlWeb_Click(object sender, EventArgs e)
        {
            Crawler.ElementCrawl element = new Crawler.ElementCrawl(txtboxUrl.Text);
            element.GetElement();


            //SetUpDriver(txtboxUrl.Text);
            //var a = chromedriver.FindElementsByXPath("//input[@type='text']");
            //var a2 = chromedriver.FindElementByXPath("//button[@id='u_0_13']");
            //var a435 = chromedriver.FindElementByXPath("//input[@id='u_0_o']");

           // a2.Click();
           // a435.Click();
           // var a1 = chromedriver.FindElementByXPath("/html/body/div[1]/div[3]/div[4]/div/div/div");
           // MessageBox.Show(a1.Text, "Input text elements");

            //string lis = "";
            //for (int i = 0; i < a.Count(); i++)
            //{
            //    lis += "\nElement " + i.ToString();
            //    lis += "\n   Input text id: " + a[i].GetAttribute("id");
            //    lis += "\n   Input text name: " + a[i].GetAttribute("name");
            //    lis += "\n   Input text Tagname: " + a[i].TagName;
            //    string xpath = getElementXPath(chromedriver, a[i]);
            //    lis += "\n   Input text xpath relative: " + xpath + "\n";
            //    string xpath1 = getAbsoluteXPath(chromedriver, a[i]);
            //    lis += "\n   Input text xpath relative: " + xpath + "\n";
            //}
            //QuitDriver();
            //MessageBox.Show(lis, "Input text elements");

            //UrlBUL.insertURL(txtboxUrl.Text, txtboxUrl.Text.Substring(8));



        }

        private void SetUpDriver(string url)
        {
            chromedriver = new ChromeDriver();
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
    }
}


