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
        public frmTestCase(int id_url, bool isnew)
        {
            InitializeComponent();
            this.isNew = isnew;
            this.Id_URL = id_url;
            if (isNew == true)
            {
                ListTestCase = new List<Test_case>();
                if (isNew)
                {
                    TestCase.TestCase NewListTestCase = new TestCase.TestCase(Id_URL);
                    ListTestCase = NewListTestCase.Generate_testcase();
                    dataGridViewListTestCase.DataSource = ListTestCase;

                }
            }
            else
            {

            }
        }

        private void frmTestCase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementDBDataSet2.Test_case' table. You can move, or remove it, as needed.
            //this.test_caseTableAdapter1.Fill(this.elementDBDataSet2.Test_case);




        }

        private void btnCrawlWeb_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewListTestCase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewListTestCase.Rows[e.RowIndex].Cells[4].Value.Equals("Failure"))
                dataGridViewListTestCase.Columns[4].DefaultCellStyle.ForeColor = Color.Red;
            else
            if (dataGridViewListTestCase.Rows[e.RowIndex].Cells[4].Value.Equals("Pass"))
                dataGridViewListTestCase.Columns[4].DefaultCellStyle.ForeColor = Color.Green;
            else
                if (dataGridViewListTestCase.Rows[e.RowIndex].Cells[4].Value.Equals("Skip"))
                dataGridViewListTestCase.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
        }
    }
}
