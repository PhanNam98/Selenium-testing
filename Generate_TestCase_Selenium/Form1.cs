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
            //SetUpDriver(txtboxUrl.Text);
            //var a = chromedriver.FindElementsByXPath("//input[@type='text']");
            //string lis = "";
            //for (int i = 0; i < a.Count(); i++)
            //{
            //    lis += "\nElement " + i.ToString();
            //    lis += "\n   Input text id: " + a[i].GetAttribute("id");
            //    lis += "\n   Input text name: " + a[i].GetAttribute("name");
            //    lis += "\n   Input text Tagname: " + a[i].TagName;
            //    string xpath = getAbsoluteXPath(chromedriver, a[i]);
            //    lis += "\n   Input text xpath relative: " + xpath + "\n";
            //}
            //QuitDriver();
            //MessageBox.Show(lis, "Input text elements");
           
            

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
    }
}


