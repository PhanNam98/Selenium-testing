namespace Generate_TestCase_Selenium
{
    partial class frmTestCase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlTestcase = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idtestcaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idurlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.istestDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.testcaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.elementDBDataSet1 = new Generate_TestCase_Selenium.ElementDBDataSet1();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnCrawlWeb = new System.Windows.Forms.Button();
            this.txtboxUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.test_caseTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSet1TableAdapters.Test_caseTableAdapter();
            this.pnlForm.SuspendLayout();
            this.pnlTestcase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testcaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.pnlTestcase);
            this.pnlForm.Controls.Add(this.pnlTitle);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(525, 590);
            this.pnlForm.TabIndex = 0;
            // 
            // pnlTestcase
            // 
            this.pnlTestcase.Controls.Add(this.dataGridView1);
            this.pnlTestcase.Controls.Add(this.pnlStatus);
            this.pnlTestcase.Location = new System.Drawing.Point(3, 83);
            this.pnlTestcase.Name = "pnlTestcase";
            this.pnlTestcase.Size = new System.Drawing.Size(519, 504);
            this.pnlTestcase.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtestcaseDataGridViewTextBoxColumn,
            this.idurlDataGridViewTextBoxColumn,
            this.resultDataGridViewTextBoxColumn,
            this.istestDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.testcaseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(498, 439);
            this.dataGridView1.TabIndex = 1;
            // 
            // idtestcaseDataGridViewTextBoxColumn
            // 
            this.idtestcaseDataGridViewTextBoxColumn.DataPropertyName = "id_testcase";
            this.idtestcaseDataGridViewTextBoxColumn.HeaderText = "id_testcase";
            this.idtestcaseDataGridViewTextBoxColumn.Name = "idtestcaseDataGridViewTextBoxColumn";
            // 
            // idurlDataGridViewTextBoxColumn
            // 
            this.idurlDataGridViewTextBoxColumn.DataPropertyName = "id_url";
            this.idurlDataGridViewTextBoxColumn.HeaderText = "id_url";
            this.idurlDataGridViewTextBoxColumn.Name = "idurlDataGridViewTextBoxColumn";
            this.idurlDataGridViewTextBoxColumn.Visible = false;
            // 
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "result";
            this.resultDataGridViewTextBoxColumn.HeaderText = "result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            // 
            // istestDataGridViewCheckBoxColumn
            // 
            this.istestDataGridViewCheckBoxColumn.DataPropertyName = "is_test";
            this.istestDataGridViewCheckBoxColumn.HeaderText = "is_test";
            this.istestDataGridViewCheckBoxColumn.Name = "istestDataGridViewCheckBoxColumn";
            // 
            // testcaseBindingSource
            // 
            this.testcaseBindingSource.DataMember = "Test_case";
            this.testcaseBindingSource.DataSource = this.elementDBDataSet1;
            // 
            // elementDBDataSet1
            // 
            this.elementDBDataSet1.DataSetName = "ElementDBDataSet1";
            this.elementDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Location = new System.Drawing.Point(9, 3);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(498, 47);
            this.pnlStatus.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.btnCrawlWeb);
            this.pnlTitle.Controls.Add(this.txtboxUrl);
            this.pnlTitle.Controls.Add(this.labelUrl);
            this.pnlTitle.Location = new System.Drawing.Point(3, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(519, 77);
            this.pnlTitle.TabIndex = 0;
            // 
            // btnCrawlWeb
            // 
            this.btnCrawlWeb.Location = new System.Drawing.Point(399, 22);
            this.btnCrawlWeb.Name = "btnCrawlWeb";
            this.btnCrawlWeb.Size = new System.Drawing.Size(75, 28);
            this.btnCrawlWeb.TabIndex = 4;
            this.btnCrawlWeb.Text = "Run";
            this.btnCrawlWeb.UseVisualStyleBackColor = true;
            this.btnCrawlWeb.Click += new System.EventHandler(this.btnCrawlWeb_Click);
            // 
            // txtboxUrl
            // 
            this.txtboxUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxUrl.Location = new System.Drawing.Point(106, 22);
            this.txtboxUrl.Name = "txtboxUrl";
            this.txtboxUrl.ReadOnly = true;
            this.txtboxUrl.Size = new System.Drawing.Size(272, 26);
            this.txtboxUrl.TabIndex = 2;
            this.txtboxUrl.Text = "https://facebook.com/";
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUrl.Location = new System.Drawing.Point(62, 27);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(38, 16);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "URL:";
            // 
            // test_caseTableAdapter
            // 
            this.test_caseTableAdapter.ClearBeforeFill = true;
            // 
            // frmTestCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 590);
            this.Controls.Add(this.pnlForm);
            this.Name = "frmTestCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Case";
            this.Load += new System.EventHandler(this.frmTestCase_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlTestcase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testcaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet1)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlTestcase;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox txtboxUrl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Button btnCrawlWeb;
        private ElementDBDataSet1 elementDBDataSet1;
        private System.Windows.Forms.BindingSource testcaseBindingSource;
        private ElementDBDataSet1TableAdapters.Test_caseTableAdapter test_caseTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtestcaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idurlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn istestDataGridViewCheckBoxColumn;
    }
}