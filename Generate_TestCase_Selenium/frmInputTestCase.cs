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
using BUL;
using System.Threading;

namespace Generate_TestCase_Selenium
{
    public partial class frmInputTestCase : Form
    {
        public frmInputTestCase(int id_url, string id_testcase)
        {
            InitializeComponent();
            this.ID_URL = id_url;
            this.ID_Testcase = id_testcase;
            lbIdUrl.Text = ID_URL.ToString();
            txtboxId_testcase.Text = ID_Testcase;
            lbResult.Text = BUL.TestCaseBUL.Get_ResultTestcase(ID_URL,ID_Testcase);
        }
        public frmInputTestCase(int id_url, string id_testcase,List<Test_case> listTestcase)
        {
            InitializeComponent();
            ListTestCase = listTestcase;
            indexList = ListTestCase.IndexOf(ListTestCase.Where(p => p.id_testcase == id_testcase).SingleOrDefault());
            this.ID_URL = id_url;
            this.ID_Testcase = id_testcase;
            lbIdUrl.Text = ID_URL.ToString();
            txtboxId_testcase.Text = ID_Testcase;
            lbResult.Text = BUL.TestCaseBUL.Get_ResultTestcase(ID_URL,ID_Testcase);
        }
        private List<Test_case> ListTestCase;
        private int ID_URL;
        private string ID_Testcase;
        private int indexList = 0;
        private bool IsNew = true;
        private bool IsNewRedirect = true;
        private bool IsNewInputTestcase = true;
        private void frmInputTestCase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementDBDataSet4.Element_test' table. You can move, or remove it, as needed.
            //this.element_testTableAdapter.Fill(this.elementDBDataSet4.Element_test);
            // TODO: This line of code loads data into the 'elementDBDataSet4.Input_testcase' table. You can move, or remove it, as needed.
            //this.input_testcaseTableAdapter1.Fill(this.elementDBDataSet4.Input_testcase);

            this.Show();
            this.Select();
            dgvInput.DataSource = BUL.InputTestcaseBUL.Get_InputTestcase_ByIdTestcase(ID_Testcase, ID_URL);
        }

        private void lbIdTestcase_Click(object sender, EventArgs e)
        {

        }

        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvInput.CurrentCell.RowIndex;
            txtBoxInputId_Elt.Text = dgvInput.Rows[r].Cells["idelementDataGridViewTextBoxColumn"].Value.ToString();
            txtBoxInputValue.Text = dgvInput.Rows[r].Cells["valueDataGridViewTextBoxColumn"].Value.ToString();
            txtBoxInputXpath.Text = dgvInput.Rows[r].Cells["xpathDataGridViewTextBoxColumn"].Value.ToString();
            comboBoxAction.SelectedItem= dgvInput.Rows[r].Cells["actionDataGridViewTextBoxColumn"].Value.ToString();
        }

       

        private void btnAddInputElt_Click(object sender, EventArgs e)
        {
            IsNewInputTestcase = true;
        }

        private void btnDeleteInputElt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                
                if (!BUL.InputTestcaseBUL.Delete_ListInputTestcase(ID_Testcase,ID_URL))
                {
                    MessageBox.Show("Delete fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Delete successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            RefreshDataGridViewInput();
        }

        private void btnEditInputElt_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Visible = true;
            groupBoxAction.Visible = false;
            txtBoxInputValue.ReadOnly = false;
            IsNewInputTestcase = false;

        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if(IsNewInputTestcase)
            {

            }
            else
            {
                if(!BUL.InputTestcaseBUL.update_ValueInputTestElement(ID_URL,ID_Testcase, txtBoxInputId_Elt.Text, txtBoxInputValue.Text))
                {
                    MessageBox.Show("Update fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            groupBoxEdit.Visible = false;
            groupBoxAction.Visible = true;
            txtBoxInputValue.ReadOnly = true;
            RefreshDataGridViewInput();
            int r = dgvInput.CurrentCell.RowIndex;
            txtBoxInputId_Elt.Text = dgvInput.Rows[r].Cells["idelementDataGridViewTextBoxColumn"].Value.ToString();
            txtBoxInputValue.Text = dgvInput.Rows[r].Cells["valueDataGridViewTextBoxColumn"].Value.ToString();
            txtBoxInputXpath.Text = dgvInput.Rows[r].Cells["xpathDataGridViewTextBoxColumn"].Value.ToString();
            comboBoxAction.SelectedItem = dgvInput.Rows[r].Cells["actionDataGridViewTextBoxColumn"].Value.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Visible = false;
            groupBoxAction.Visible = true;
            txtBoxInputValue.ReadOnly = true;
            int r = dgvInput.CurrentCell.RowIndex;
            txtBoxInputId_Elt.Text = dgvInput.Rows[r].Cells["idelementDataGridViewTextBoxColumn"].Value.ToString();
            txtBoxInputValue.Text = dgvInput.Rows[r].Cells["valueDataGridViewTextBoxColumn"].Value.ToString();
            txtBoxInputXpath.Text = dgvInput.Rows[r].Cells["xpathDataGridViewTextBoxColumn"].Value.ToString();
            comboBoxAction.SelectedItem = dgvInput.Rows[r].Cells["actionDataGridViewTextBoxColumn"].Value.ToString();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTestElt_Click(object sender, EventArgs e)
        {
            IsNew = true;
            txtBoxClassnameTestElt.ReadOnly = false;
            txtBoxFullxpathTestElt.ReadOnly = false;
            txtBoxXpathTestElt.ReadOnly = false;
            txtBoxTestValue.ReadOnly = false;
            txtBoxClassnameTestElt.Clear();
            txtBoxFullxpathTestElt.Clear();
            txtBoxXpathTestElt.Clear();
            txtBoxTestValue.Clear();
            txtBoxOutputValue.Clear();
            txtBoxIdElementTest.Clear();
            groupBoxActionOutput.Enabled = false;
            groupBoxComfirmOutput.Visible = true;
        }

        private void btnDeleteTestElt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete this test element?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Element_test element_Test = new Element_test();
                element_Test.class_name = txtBoxClassnameTestElt.Text;
                element_Test.id_element = txtBoxIdElementTest.Text;
                element_Test.id_testcase = ID_Testcase;
                element_Test.id_url = ID_URL;
                element_Test.value_test = txtBoxTestValue.Text;
                element_Test.xpath = txtBoxXpathTestElt.Text;
                element_Test.xpath_full = txtBoxFullxpathTestElt.Text;
                element_Test.value_return = txtBoxOutputValue.Text;
                if(!BUL.TestElementBUL.Delete_TestElement(element_Test))
                {
                    MessageBox.Show("Error when delete test element", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Delete test element successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (result == DialogResult.No)
            {
                
            }
            dgvOutputtest.DataSource = BUL.TestElementBUL.Get_ListTestElemt(ID_URL, ID_Testcase);
        }

        private void btnEditTestElt_Click(object sender, EventArgs e)
        {
            IsNew = false;
            txtBoxClassnameTestElt.ReadOnly = false;
            txtBoxFullxpathTestElt.ReadOnly = false;
            txtBoxXpathTestElt.ReadOnly = false;
            txtBoxTestValue.ReadOnly = false;

            groupBoxActionOutput.Enabled = false;
            groupBoxComfirmOutput.Visible = true;
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            if ((txtBoxFullxpathTestElt.Text.Equals("") && txtBoxXpathTestElt.Text.Equals("")))
            {
                MessageBox.Show("Please fill Xpath or Full Xpath", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (IsNew)
                {
                    Random random = new Random();
                    Element_test element_Test = new Element_test();
                    element_Test.class_name = txtBoxClassnameTestElt.Text;
                    element_Test.id_element = ID_Testcase + Generate_RandomString(random, 5, true);
                    element_Test.id_testcase = ID_Testcase;
                    element_Test.id_url = ID_URL;
                    element_Test.value_test = txtBoxTestValue.Text;
                    element_Test.xpath = txtBoxXpathTestElt.Text;
                    element_Test.xpath_full = txtBoxFullxpathTestElt.Text;
                    element_Test.value_return = "";
                    if (!BUL.TestElementBUL.Insert_TestElement(element_Test))
                    {
                        MessageBox.Show("Error when save test element into database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Save test element successfully into database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {

                    Element_test element_Test = new Element_test();
                    element_Test.class_name = txtBoxClassnameTestElt.Text;
                    element_Test.id_element = txtBoxIdElementTest.Text;
                    element_Test.id_testcase = ID_Testcase;
                    element_Test.id_url = ID_URL;
                    element_Test.value_test = txtBoxTestValue.Text;
                    element_Test.xpath = txtBoxXpathTestElt.Text;
                    element_Test.xpath_full = txtBoxFullxpathTestElt.Text;
                    element_Test.value_return = txtBoxOutputValue.Text;
                    if (!BUL.TestElementBUL.Update_TestElement(element_Test))
                    {
                        MessageBox.Show("Error when update test element", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Update test element successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                txtBoxClassnameTestElt.Clear();
                txtBoxFullxpathTestElt.Clear();
                txtBoxXpathTestElt.Clear();
                txtBoxTestValue.Clear();
                txtBoxOutputValue.Clear();
                txtBoxIdElementTest.Clear();
                dgvOutputtest.DataSource = BUL.TestElementBUL.Get_ListTestElemt(ID_URL, ID_Testcase);
                txtBoxClassnameTestElt.ReadOnly = true;
                txtBoxFullxpathTestElt.ReadOnly = true;
                txtBoxXpathTestElt.ReadOnly = true;
                txtBoxTestValue.ReadOnly = true;
                groupBoxActionOutput.Enabled = true;
                groupBoxComfirmOutput.Visible = false;
            }
        }

        private void btnCancelOutput_Click(object sender, EventArgs e)
        {

            txtBoxClassnameTestElt.Clear();
            txtBoxFullxpathTestElt.Clear();
            txtBoxXpathTestElt.Clear();
            txtBoxTestValue.Clear();
            txtBoxOutputValue.Clear();
            txtBoxIdElementTest.Clear();
            txtBoxClassnameTestElt.ReadOnly = true;
            txtBoxFullxpathTestElt.ReadOnly = true;
            txtBoxXpathTestElt.ReadOnly = true;
            txtBoxTestValue.ReadOnly = true;
            groupBoxActionOutput.Enabled = true;
            groupBoxComfirmOutput.Visible = false;
        }

      
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text == "Output")
            {
                dgvOutputtest.DataSource = BUL.TestElementBUL.Get_ListTestElemt(ID_URL, ID_Testcase);
            }
            else
                if (tabControl.SelectedIndex == 2)
            {
                var redirect_Url = BUL.RedirectUrlBUL.Get_RedirectUrlTest(ID_Testcase,ID_URL);
                if(redirect_Url!=null)
                {
                    IsNewRedirect = false;
                    btnAddRedirectTest.Text = "Edit";
                    txtBoxRedirectUrl.Text = redirect_Url.current_url;
                    txtBoxTestRediectUrl.Text = redirect_Url.redirect_url_test;
                    txtBoxTestRediectUrl.ReadOnly = true;
                }
                else
                {
                    btnAddRedirectTest.Text = "Add";
                    IsNewRedirect = true;
                }
              
                txtBoxDescription.Text = ListTestCase[indexList].description;
                
            }


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

        private void dgvOutputtest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvOutputtest.CurrentCell.RowIndex;
            txtBoxTestValue.Text= dgvOutputtest.Rows[r].Cells["value_test"].Value.ToString();
            txtBoxOutputValue.Text = dgvOutputtest.Rows[r].Cells["value_return"].Value.ToString();
            txtBoxClassnameTestElt.Text = dgvOutputtest.Rows[r].Cells["class_name"].Value.ToString();
            txtBoxFullxpathTestElt.Text = dgvOutputtest.Rows[r].Cells["xpath_full"].Value.ToString();
            txtBoxXpathTestElt.Text = dgvOutputtest.Rows[r].Cells["xpath"].Value.ToString();
            txtBoxIdElementTest.Text = dgvOutputtest.Rows[r].Cells["id_element"].Value.ToString();

        }

        private void txtBoxIdElementTest_TextChanged(object sender, EventArgs e)
        {
            if(txtBoxIdElementTest.Text=="")
            {
                btnDeleteTestElt.Enabled = false;
                btnEditTestElt.Enabled = false;
            }
            else
            {
                btnDeleteTestElt.Enabled = true;
                btnEditTestElt.Enabled = true;
            }
        }

        private void btnSaveTestRedirectUrl_Click(object sender, EventArgs e)
        {
            if (txtBoxTestRediectUrl.Text != "")
            {
                if (IsNewRedirect)
                {
                    if (BUL.RedirectUrlBUL.Insert_RedirectUrlTest(new Redirect_url()
                    {
                        id_url = ID_URL,
                        current_url = "",
                        id_testcase = ID_Testcase,
                        redirect_url_test = txtBoxTestRediectUrl.Text
                    }))
                    {
                        MessageBox.Show("Insert successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAddRedirectTest.Text = "Edit";
                    }
                    else
                        MessageBox.Show("Error when insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (!IsNewRedirect)
                {
                    if (BUL.RedirectUrlBUL.Update_RedirectUrlTest(ID_Testcase, ID_URL, txtBoxTestRediectUrl.Text))
                    {
                        MessageBox.Show("Update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAddRedirectTest.Text = "Edit";
                    }
                    else
                        MessageBox.Show("Error when update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Test Redirect Url is required ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnSaveTestRedirectUrl.Visible = false;
            btnCancelAddTestRedirect.Visible = false;
            btnAddRedirectTest.Visible = true;
        }

        private void btnAddRedirectTest_Click(object sender, EventArgs e)
        {
            btnAddRedirectTest.Visible = false;
            btnSaveTestRedirectUrl.Visible = true;
            btnCancelAddTestRedirect.Visible = true;
            txtBoxTestRediectUrl.ReadOnly = false;
            
        }

        private void btnCancelAddTestRedirect_Click(object sender, EventArgs e)
        {
            var redirect_Url = BUL.RedirectUrlBUL.Get_RedirectUrlTest(ID_Testcase, ID_URL);
            if (redirect_Url != null)
            {
                IsNewRedirect = false;
                btnAddRedirectTest.Text = "Edit";
                txtBoxRedirectUrl.Text = redirect_Url.current_url;
                txtBoxTestRediectUrl.Text = redirect_Url.redirect_url_test;
                txtBoxTestRediectUrl.ReadOnly = true;
            }
            else
            {
                btnAddRedirectTest.Text = "Add";
                IsNewRedirect = true;
            }
        }

       
        private void btnAddUpdateDescription_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Update description?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               
                if (!BUL.TestCaseBUL.Update_DescriptionTestcase(ID_URL,ID_Testcase,txtBoxDescription.Text))
                {
                    MessageBox.Show("Update fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
        private void RefreshDataGridViewInput()
        {
            dgvInput.DataSource = BUL.InputTestcaseBUL.Get_InputTestcase_ByIdTestcase(ID_Testcase, ID_URL);
        }

        private void lbResult_TextChanged(object sender, EventArgs e)
        {
            if(lbResult.Text.ToLower().Equals("pass"))
                {
                lbResult.ForeColor = Color.Green;
            }
            else
                if (lbResult.Text.ToLower().Equals("skip"))
            {
                lbResult.ForeColor = Color.Blue;
            }
            else
            {
                lbResult.ForeColor = Color.Red;
            }
        }



        
    }
}
