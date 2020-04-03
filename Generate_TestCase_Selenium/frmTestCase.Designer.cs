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
            this.dataGridViewListTestCase = new System.Windows.Forms.DataGridView();
            this.elementDBDataSet1 = new Generate_TestCase_Selenium.ElementDBDataSet1();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnRunTestCase = new System.Windows.Forms.Button();
            this.txtboxUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.test_caseTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSet1TableAdapters.Test_caseTableAdapter();
            this.fKInputtestcaseTestcase1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.input_testcaseTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSet1TableAdapters.Input_testcaseTableAdapter();
            this.elementDBDataSet2 = new Generate_TestCase_Selenium.ElementDBDataSet2();
            this.testcaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.test_caseTableAdapter1 = new Generate_TestCase_Selenium.ElementDBDataSet2TableAdapters.Test_caseTableAdapter();
            this.istestDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idtestcaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idurlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlForm.SuspendLayout();
            this.pnlTestcase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListTestCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKInputtestcaseTestcase1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testcaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.pnlTestcase);
            this.pnlForm.Controls.Add(this.pnlTitle);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(587, 590);
            this.pnlForm.TabIndex = 0;
            // 
            // pnlTestcase
            // 
            this.pnlTestcase.Controls.Add(this.dataGridViewListTestCase);
            this.pnlTestcase.Controls.Add(this.pnlStatus);
            this.pnlTestcase.Location = new System.Drawing.Point(3, 83);
            this.pnlTestcase.Name = "pnlTestcase";
            this.pnlTestcase.Size = new System.Drawing.Size(580, 504);
            this.pnlTestcase.TabIndex = 1;
            // 
            // dataGridViewListTestCase
            // 
            this.dataGridViewListTestCase.AutoGenerateColumns = false;
            this.dataGridViewListTestCase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListTestCase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.istestDataGridViewCheckBoxColumn,
            this.idtestcaseDataGridViewTextBoxColumn,
            this.idurlDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.resultDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.modifiedDateDataGridViewTextBoxColumn});
            this.dataGridViewListTestCase.DataSource = this.testcaseBindingSource;
            this.dataGridViewListTestCase.Location = new System.Drawing.Point(9, 56);
            this.dataGridViewListTestCase.Name = "dataGridViewListTestCase";
            this.dataGridViewListTestCase.Size = new System.Drawing.Size(561, 439);
            this.dataGridViewListTestCase.TabIndex = 1;
            this.dataGridViewListTestCase.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewListTestCase_CellFormatting);
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
            this.pnlTitle.Controls.Add(this.btnRunTestCase);
            this.pnlTitle.Controls.Add(this.txtboxUrl);
            this.pnlTitle.Controls.Add(this.labelUrl);
            this.pnlTitle.Location = new System.Drawing.Point(3, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(580, 77);
            this.pnlTitle.TabIndex = 0;
            // 
            // btnRunTestCase
            // 
            this.btnRunTestCase.Location = new System.Drawing.Point(399, 22);
            this.btnRunTestCase.Name = "btnRunTestCase";
            this.btnRunTestCase.Size = new System.Drawing.Size(75, 28);
            this.btnRunTestCase.TabIndex = 4;
            this.btnRunTestCase.Text = "Run";
            this.btnRunTestCase.UseVisualStyleBackColor = true;
            this.btnRunTestCase.Click += new System.EventHandler(this.btnCrawlWeb_Click);
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
            // input_testcaseTableAdapter
            // 
            this.input_testcaseTableAdapter.ClearBeforeFill = true;
            // 
            // elementDBDataSet2
            // 
            this.elementDBDataSet2.DataSetName = "ElementDBDataSet2";
            this.elementDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testcaseBindingSource
            // 
            this.testcaseBindingSource.DataMember = "Test_case";
            this.testcaseBindingSource.DataSource = this.elementDBDataSet2;
            // 
            // test_caseTableAdapter1
            // 
            this.test_caseTableAdapter1.ClearBeforeFill = true;
            // 
            // istestDataGridViewCheckBoxColumn
            // 
            this.istestDataGridViewCheckBoxColumn.DataPropertyName = "is_test";
            this.istestDataGridViewCheckBoxColumn.HeaderText = "";
            this.istestDataGridViewCheckBoxColumn.Name = "istestDataGridViewCheckBoxColumn";
            this.istestDataGridViewCheckBoxColumn.Width = 50;
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
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "result";
            this.resultDataGridViewTextBoxColumn.HeaderText = "result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            this.resultDataGridViewTextBoxColumn.ReadOnly = true;
            this.resultDataGridViewTextBoxColumn.Width = 50;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            // 
            // modifiedDateDataGridViewTextBoxColumn
            // 
            this.modifiedDateDataGridViewTextBoxColumn.DataPropertyName = "ModifiedDate";
            this.modifiedDateDataGridViewTextBoxColumn.HeaderText = "ModifiedDate";
            this.modifiedDateDataGridViewTextBoxColumn.Name = "modifiedDateDataGridViewTextBoxColumn";
            // 
            // frmTestCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 590);
            this.Controls.Add(this.pnlForm);
            this.Name = "frmTestCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Case";
            this.Load += new System.EventHandler(this.frmTestCase_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlTestcase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListTestCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet1)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKInputtestcaseTestcase1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testcaseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlTestcase;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox txtboxUrl;
        private System.Windows.Forms.DataGridView dataGridViewListTestCase;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Button btnRunTestCase;
        private ElementDBDataSet1 elementDBDataSet1;
        private ElementDBDataSet1TableAdapters.Test_caseTableAdapter test_caseTableAdapter;
        private System.Windows.Forms.BindingSource fKInputtestcaseTestcase1BindingSource;
        private ElementDBDataSet1TableAdapters.Input_testcaseTableAdapter input_testcaseTableAdapter;
        private ElementDBDataSet2 elementDBDataSet2;
        private System.Windows.Forms.BindingSource testcaseBindingSource;
        private ElementDBDataSet2TableAdapters.Test_caseTableAdapter test_caseTableAdapter1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn istestDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtestcaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idurlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDateDataGridViewTextBoxColumn;
    }
}