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
    public partial class frmTestCase : Form
    {
        public frmTestCase()
        {
            InitializeComponent();
        }

        private void frmTestCase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementDBDataSet1.Test_case' table. You can move, or remove it, as needed.
            //this.test_caseTableAdapter.Fill(this.elementDBDataSet1.Test_case);

        }

        private void btnCrawlWeb_Click(object sender, EventArgs e)
        {

        }
    }
}
