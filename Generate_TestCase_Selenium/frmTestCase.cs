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
namespace Generate_TestCase_Selenium
{
    public partial class frmTestCase : Form
    {
        private bool isNew;
        private int Id_URL;
        private List<Test_case> ListTestCase;
        private int CountTestcaseTest = 0;
        private int NumberOfTestcase = 0;
        private TestCase.TestCase NewListTestCase;
        private string URL;
        CheckBox headerCheckBox = new CheckBox();
        public frmTestCase(int id_url,string url, bool isnew)
        {
            InitializeComponent();
            this.isNew = isnew;
            this.Id_URL = id_url;
            this.URL = url;
            lbid_url.Text = Id_URL.ToString();
            txtboxUrl.Text = URL;
            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(60, 5);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(13, 13);
            headerCheckBox.Checked = true;
            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridViewListTestCase.Controls.Add(headerCheckBox);
            try
            {


                if (isNew == true)
                {
                    ListTestCase = new List<Test_case>();

                   
                    if (isNew)
                    {
                        NewListTestCase = new TestCase.TestCase(Id_URL);
                        ListTestCase = NewListTestCase.Generate_testcase();
                        dataGridViewListTestCase.DataSource = ListTestCase;
                        CountTestcaseTest = NumberOfTestcase = ListTestCase.Count;
                        lbNumberOfTestcase.Text = "/" + NumberOfTestcase.ToString();
                        lbCurrentCount.Text = CountTestcaseTest.ToString();
                    }
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Error when generate test case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Save_testcase();
        }

        private void frmTestCase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementDBDataSet2.Test_case' table. You can move, or remove it, as needed.
            //this.test_caseTableAdapter1.Fill(this.elementDBDataSet2.Test_case);
            this.Show();
            this.Select();
            if (isNew)
            {
                if (Save_testcase())
                {
                    btnRunTestCase.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error when save test case into database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            dataGridViewListTestCase.ReadOnly = false;


        }
        public bool Save_testcase()
        {
            return NewListTestCase.Save_testcase();
        }




        private void dataGridViewListTestCase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewListTestCase.Rows[e.RowIndex].Cells["resultDataGridViewTextBoxColumn"].Value.Equals("Failure"))
                dataGridViewListTestCase.Columns[4].DefaultCellStyle.ForeColor = Color.Red;
            else
            if (dataGridViewListTestCase.Rows[e.RowIndex].Cells[4].Value.Equals("Pass"))
                dataGridViewListTestCase.Columns[4].DefaultCellStyle.ForeColor = Color.Green;
            else
                if (dataGridViewListTestCase.Rows[e.RowIndex].Cells[4].Value.Equals("Skip"))
                dataGridViewListTestCase.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
        }

        private void dataGridViewListTestCase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListTestCase.Columns["btnRun"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show(String.Format("Button on row {0} clicked" + dataGridViewListTestCase.Rows[e.RowIndex].Cells["idtestcaseDataGridViewTextBoxColumn"].Value.ToString(), e.RowIndex));
            }
            else
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row in dataGridViewListTestCase.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["istestDataGridViewCheckBoxColumn"].EditedFormattedValue) == false)
                        {
                            isChecked = false;
                            break;
                        }
                    }
                    headerCheckBox.Checked = isChecked;

                }
            }
        }


        private void dataGridViewListTestCase_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridViewListTestCase.CommitEdit(DataGridViewDataErrorContexts.Commit);


        }

        private void dataGridViewListTestCase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListTestCase.Columns["istestDataGridViewCheckBoxColumn"].Index && e.RowIndex >= 0)
            {
                bool isChecked = (bool)dataGridViewListTestCase[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                ListTestCase[e.RowIndex].is_test = isChecked;
                dataGridViewListTestCase.DataSource = ListTestCase;



                CountTestcaseTest = ListTestCase.Where(p => p.is_test == true).Count();
                if (CountTestcaseTest == NumberOfTestcase)
                {
                    btnRunTestCase.Text = "Run All";
                    headerCheckBox.Checked = true;
                    btnRunTestCase.Enabled = true;
                    headerCheckBox.Checked = true;
                }
                else
                    if (CountTestcaseTest == 0)
                {
                    btnRunTestCase.Enabled = false;
                    headerCheckBox.Checked = false;
                }
                else
                {
                    btnRunTestCase.Text = "Run " + CountTestcaseTest;
                    btnRunTestCase.Enabled = true;
                    headerCheckBox.Checked = false;
                }
                lbCurrentCount.Text = ListTestCase.Where(p => p.is_test == true).Count().ToString();
            }
        }


        private void btnRunTestCase_Click(object sender, EventArgs e)
        {
            TestCase.RunTestCase a = new TestCase.RunTestCase(Id_URL, txtboxUrl.Text, "Fill_1000_charter_TypeText_reg_0");
            a.Run();
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridViewListTestCase.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridViewListTestCase.Rows)
            {


                DataGridViewCheckBoxCell checkBox = (row.Cells["istestDataGridViewCheckBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;

                if (!headerCheckBox.Checked)
                {
                    btnRunTestCase.Enabled = false;
                    CountTestcaseTest = 0;

                }
                else
                {
                    btnRunTestCase.Text = "Run All";
                    btnRunTestCase.Enabled = true;
                    CountTestcaseTest = NumberOfTestcase;

                }
                lbCurrentCount.Text = ListTestCase.Where(p => p.is_test == true).Count().ToString();
            }
        }

    }
}
