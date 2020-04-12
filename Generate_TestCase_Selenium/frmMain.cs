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
using Model;
using System.Threading;

namespace Generate_TestCase_Selenium
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        
        private List<Element> listElements;
        private int Crawwling = 1;
        Thread CrawlThread;
        Crawler.ElementCrawl Craw_element;
        private int Id_Url;
        private void btnCrawlWeb_Click(object sender, EventArgs e)
        {
            btnGenerateTestCase.Enabled = false;
            dgvElements.DataSource = null;
            if (Crawwling > 0)
            {
                
                lbMessage.Visible = true;
                lbMessage.Text = "Crawling data, please wait a few minutes...";
                CrawlThread = new Thread(CrawlingElement);
                CrawlThread.Start();
                Crawwling--;
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
            else if (Crawwling == 0)
            {
                
               
                DialogResult result = MessageBox.Show("Stop the process?", "Message", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    btnCrawlWeb.Enabled = false;
                    lbMessage.Text = "Stoping the process...";
                    Thread stop = new Thread(StopCrawl);
                    stop.Start();
                    //btnCrawlWeb.Enabled = false;
                    //lbMessage.Visible = false;
                    //btnCrawlWeb.Text = "Crawl Data";
                    //Crawwling++;
                    //lbMessage.Text = "";
                    //lbMessage.Visible = true;

                    //CrawlThread.Abort();
                    //btnCrawlWeb.Enabled = true;
                }
                else if (result == DialogResult.No)
                {
                    //no...
                }

            }
        }

       private void StopCrawl()
        {
            try
            {

                //btnCrawlWeb.Enabled = false;
                //lbMessage.Visible = false;

                if (Craw_element.StopWebDriver() == 0)
                {
                    btnCrawlWeb.Enabled = true;
                    lbMessage.Visible = true;
                    throw new Exception();
                }
                btnCrawlWeb.Enabled = false;
                lbMessage.Visible = false;
                btnCrawlWeb.Text = "Crawl Data";
                Crawwling++;
                lbMessage.Text = "";
                lbMessage.Visible = true;
                btnCrawlWeb.Enabled = true;

                MessageBox.Show("Stop the process successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Stop the process failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CrawlThread.Abort();
            
        }
      
        public static class ThreadHelperClass
        {
            delegate void SetTextCallback(Form f, Control ctrl, string text);
            /// <summary>
            /// Set text property of various controls
            /// </summary>
            /// <param name="form">The calling form</param>
            /// <param name="ctrl"></param>
            /// <param name="text"></param>
            public static void SetText(Form form, Control ctrl, string text)
            {
                // InvokeRequired required compares the thread ID of the 
                // calling thread to the thread ID of the creating thread. 
                // If these threads are different, it returns true. 
                if (ctrl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                else
                {
                    ctrl.Text = text;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementDBDataSet.Element' table. You can move, or remove it, as needed.
            // this.elementTableAdapter.Fill(this.elementDBDataSet.Element);

        }

        private void CrawlingElement()
        {
            string url_test = txtboxUrl.Text;
            Craw_element = new Crawler.ElementCrawl(url_test);
            btnCrawlWeb.Text = "Cancel";
            if (Craw_element.GetElements() == 1)
            {
                listElements = Craw_element.GetListElement();
                dgvElements.DataSource = listElements;
                ThreadHelperClass.SetText(this, lbMessage, String.Format("{0} elements found. Saving into database...", listElements.Count));
                btnCrawlWeb.Enabled = false;
               
                try
                {

                    //InsertIntoDB(url_test);//insert into DB
                    MessageBox.Show("Retrieve and save data into database successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGenerateTestCase.Enabled = true;
                    
                }
                catch
                {
                    MessageBox.Show("Retrieve data successfully, but save data failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Retrieve data failed, please try again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
            btnCrawlWeb.Text = "Crawl Data";
            btnCrawlWeb.Enabled = true;
            ThreadHelperClass.SetText(this, lbMessage, String.Format("{0} elements found.", listElements.Count));
           
            Crawwling++;

        }
        public void InsertIntoDB(string url_test)
        {
            
            Url newurl = new Url();
            newurl.name = url_test.Substring(8);
            newurl.url1 = url_test;
            int id_Url = UrlBUL.insertURL(newurl);
            List<Form_elements> listForm = Craw_element.GetListForm();
            foreach (Form_elements item in listForm)
            {
                item.id_url = id_Url;
                BUL.FormBUL.insert_Form(item);
            }
            List<Element> listElt = Craw_element.GetListElement();
            foreach (Element item in listElt)
            {
                item.id_url = id_Url;
                BUL.ElementBUL.insert_Element(item);
            }
        }
        private void btnGenerateTestCase_Click(object sender, EventArgs e)
        {
            btnCrawlWeb.Enabled = false;
            lbMessage.Visible = true;
            lbMessage.Text="Generating testcase, Please wait a few minutes...";
            //frmTestCase newfrmTestCase = new frmTestCase(Id_Url,true);
            Thread GenerateThread = new Thread(GenerateTestCase);
            GenerateThread.Start();
           

        }
        private void GenerateTestCase()
        {
            frmTestCase newfrmTestCase = new frmTestCase(27, "https://facebook.com/", true);
            //frmTestCase newfrmTestCase = new frmTestCase(27, txtboxUrl.Text, true);
            this.Hide();
            newfrmTestCase.ShowDialog();
            lbMessage.Text = "";
            this.Show();
            this.Select(true,true);
            //this.TopMost = true;
            
        }
        private void LoadListTestCase()
        {
            frmTestCase newfrmTestCase = new frmTestCase(27, "https://facebook.com/", false);
            this.Hide();
            newfrmTestCase.ShowDialog();
            lbMessage.Text = "";
            btnCrawlWeb.Enabled = true;
            this.Show();
            this.Select(true, true);
           

        }
        private void lbMessage_Click(object sender, EventArgs e)
        {

        }
        // used to test code
        private void button1_Click(object sender, EventArgs e)
        {
            btnCrawlWeb.Enabled = false;
            lbMessage.Visible = true;
            lbMessage.Text = "Loading testcase, Please wait a few minutes...";
            Thread GenerateThread = new Thread(LoadListTestCase);
            GenerateThread.Start();
        }
    }
}


