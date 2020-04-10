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
            this.istestDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idtestcaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idurlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRun = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnViewTestcase = new System.Windows.Forms.DataGridViewButtonColumn();
            this.testcaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.elementDBDataSet2 = new Generate_TestCase_Selenium.ElementDBDataSet2();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbCurrentCount = new System.Windows.Forms.Label();
            this.lbNumberOfTestcase = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnRunTestCase = new System.Windows.Forms.Button();
            this.txtboxUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.elementDBDataSet1 = new Generate_TestCase_Selenium.ElementDBDataSet1();
            this.test_caseTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSet1TableAdapters.Test_caseTableAdapter();
            this.fKInputtestcaseTestcase1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.input_testcaseTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSet1TableAdapters.Input_testcaseTableAdapter();
            this.test_caseTableAdapter1 = new Generate_TestCase_Selenium.ElementDBDataSet2TableAdapters.Test_caseTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.lbid_url = new System.Windows.Forms.Label();
            this.pnlForm.SuspendLayout();
            this.pnlTestcase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListTestCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testcaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet2)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKInputtestcaseTestcase1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.pnlTestcase);
            this.pnlForm.Controls.Add(this.pnlTitle);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(811, 590);
            this.pnlForm.TabIndex = 0;
            // 
            // pnlTestcase
            // 
            this.pnlTestcase.Controls.Add(this.dataGridViewListTestCase);
            this.pnlTestcase.Controls.Add(this.pnlStatus);
            this.pnlTestcase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTestcase.Location = new System.Drawing.Point(0, 86);
            this.pnlTestcase.Name = "pnlTestcase";
            this.pnlTestcase.Size = new System.Drawing.Size(811, 504);
            this.pnlTestcase.TabIndex = 1;
            // 
            // dataGridViewListTestCase
            // 
            this.dataGridViewListTestCase.AllowUserToAddRows = false;
            this.dataGridViewListTestCase.AllowUserToDeleteRows = false;
            this.dataGridViewListTestCase.AutoGenerateColumns = false;
            this.dataGridViewListTestCase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListTestCase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.istestDataGridViewCheckBoxColumn,
            this.idtestcaseDataGridViewTextBoxColumn,
            this.idurlDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.resultDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.modifiedDateDataGridViewTextBoxColumn,
            this.btnRun,
            this.btnViewTestcase});
            this.dataGridViewListTestCase.DataSource = this.testcaseBindingSource;
            this.dataGridViewListTestCase.Location = new System.Drawing.Point(9, 56);
            this.dataGridViewListTestCase.Name = "dataGridViewListTestCase";
            this.dataGridViewListTestCase.ReadOnly = true;
            this.dataGridViewListTestCase.Size = new System.Drawing.Size(793, 439);
            this.dataGridViewListTestCase.TabIndex = 1;
            this.dataGridViewListTestCase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListTestCase_CellClick);
            this.dataGridViewListTestCase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListTestCase_CellContentClick);
            this.dataGridViewListTestCase.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewListTestCase_CellFormatting);
            this.dataGridViewListTestCase.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewListTestCase_CurrentCellDirtyStateChanged);
            // 
            // istestDataGridViewCheckBoxColumn
            // 
            this.istestDataGridViewCheckBoxColumn.DataPropertyName = "is_test";
            this.istestDataGridViewCheckBoxColumn.HeaderText = "";
            this.istestDataGridViewCheckBoxColumn.Name = "istestDataGridViewCheckBoxColumn";
            this.istestDataGridViewCheckBoxColumn.ReadOnly = true;
            this.istestDataGridViewCheckBoxColumn.Width = 50;
            // 
            // idtestcaseDataGridViewTextBoxColumn
            // 
            this.idtestcaseDataGridViewTextBoxColumn.DataPropertyName = "id_testcase";
            this.idtestcaseDataGridViewTextBoxColumn.HeaderText = "id_testcase";
            this.idtestcaseDataGridViewTextBoxColumn.Name = "idtestcaseDataGridViewTextBoxColumn";
            this.idtestcaseDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtestcaseDataGridViewTextBoxColumn.Width = 220;
            // 
            // idurlDataGridViewTextBoxColumn
            // 
            this.idurlDataGridViewTextBoxColumn.DataPropertyName = "id_url";
            this.idurlDataGridViewTextBoxColumn.HeaderText = "id_url";
            this.idurlDataGridViewTextBoxColumn.Name = "idurlDataGridViewTextBoxColumn";
            this.idurlDataGridViewTextBoxColumn.ReadOnly = true;
            this.idurlDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modifiedDateDataGridViewTextBoxColumn
            // 
            this.modifiedDateDataGridViewTextBoxColumn.DataPropertyName = "ModifiedDate";
            this.modifiedDateDataGridViewTextBoxColumn.HeaderText = "ModifiedDate";
            this.modifiedDateDataGridViewTextBoxColumn.Name = "modifiedDateDataGridViewTextBoxColumn";
            this.modifiedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnRun
            // 
            this.btnRun.HeaderText = "Run";
            this.btnRun.Name = "btnRun";
            this.btnRun.ReadOnly = true;
            this.btnRun.Text = "Run";
            this.btnRun.UseColumnTextForButtonValue = true;
            this.btnRun.Width = 50;
            // 
            // btnViewTestcase
            // 
            this.btnViewTestcase.HeaderText = "";
            this.btnViewTestcase.Name = "btnViewTestcase";
            this.btnViewTestcase.ReadOnly = true;
            this.btnViewTestcase.Text = "Detail";
            this.btnViewTestcase.UseColumnTextForButtonValue = true;
            this.btnViewTestcase.Width = 60;
            // 
            // testcaseBindingSource
            // 
            this.testcaseBindingSource.DataMember = "Test_case";
            this.testcaseBindingSource.DataSource = this.elementDBDataSet2;
            // 
            // elementDBDataSet2
            // 
            this.elementDBDataSet2.DataSetName = "ElementDBDataSet2";
            this.elementDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lbCurrentCount);
            this.pnlStatus.Controls.Add(this.lbNumberOfTestcase);
            this.pnlStatus.Controls.Add(this.labelNumber);
            this.pnlStatus.Location = new System.Drawing.Point(9, 3);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(738, 47);
            this.pnlStatus.TabIndex = 0;
            // 
            // lbCurrentCount
            // 
            this.lbCurrentCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrentCount.AutoSize = true;
            this.lbCurrentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentCount.Location = new System.Drawing.Point(141, 16);
            this.lbCurrentCount.Name = "lbCurrentCount";
            this.lbCurrentCount.Size = new System.Drawing.Size(15, 16);
            this.lbCurrentCount.TabIndex = 8;
            this.lbCurrentCount.Text = "0";
            this.lbCurrentCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbNumberOfTestcase
            // 
            this.lbNumberOfTestcase.AutoSize = true;
            this.lbNumberOfTestcase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberOfTestcase.Location = new System.Drawing.Point(162, 16);
            this.lbNumberOfTestcase.Name = "lbNumberOfTestcase";
            this.lbNumberOfTestcase.Size = new System.Drawing.Size(15, 16);
            this.lbNumberOfTestcase.TabIndex = 7;
            this.lbNumberOfTestcase.Text = "0";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumber.Location = new System.Drawing.Point(3, 16);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(136, 16);
            this.labelNumber.TabIndex = 6;
            this.labelNumber.Text = "Number of Test case:";
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.lbid_url);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.btnRunTestCase);
            this.pnlTitle.Controls.Add(this.txtboxUrl);
            this.pnlTitle.Controls.Add(this.labelUrl);
            this.pnlTitle.Location = new System.Drawing.Point(3, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(669, 77);
            this.pnlTitle.TabIndex = 0;
            // 
            // btnRunTestCase
            // 
            this.btnRunTestCase.Location = new System.Drawing.Point(423, 11);
            this.btnRunTestCase.Name = "btnRunTestCase";
            this.btnRunTestCase.Size = new System.Drawing.Size(90, 28);
            this.btnRunTestCase.TabIndex = 4;
            this.btnRunTestCase.Text = "Run All";
            this.btnRunTestCase.UseVisualStyleBackColor = true;
            this.btnRunTestCase.Click += new System.EventHandler(this.btnRunTestCase_Click);
            // 
            // txtboxUrl
            // 
            this.txtboxUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxUrl.Location = new System.Drawing.Point(135, 11);
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
            this.labelUrl.Location = new System.Drawing.Point(62, 16);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(38, 16);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "URL:";
            // 
            // elementDBDataSet1
            // 
            this.elementDBDataSet1.DataSetName = "ElementDBDataSet1";
            this.elementDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // test_caseTableAdapter
            // 
            this.test_caseTableAdapter.ClearBeforeFill = true;
            // 
            // input_testcaseTableAdapter
            // 
            this.input_testcaseTableAdapter.ClearBeforeFill = true;
            // 
            // test_caseTableAdapter1
            // 
            this.test_caseTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID_URL:";
            // 
            // lbid_url
            // 
            this.lbid_url.AutoSize = true;
            this.lbid_url.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbid_url.Location = new System.Drawing.Point(132, 42);
            this.lbid_url.Name = "lbid_url";
            this.lbid_url.Size = new System.Drawing.Size(15, 16);
            this.lbid_url.TabIndex = 6;
            this.lbid_url.Text = "0";
            // 
            // frmTestCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 590);
            this.Controls.Add(this.pnlForm);
            this.MaximizeBox = false;
            this.Name = "frmTestCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Case";
            this.Load += new System.EventHandler(this.frmTestCase_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlTestcase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListTestCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testcaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet2)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKInputtestcaseTestcase1BindingSource)).EndInit();
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
        private System.Windows.Forms.Label lbNumberOfTestcase;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label lbCurrentCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn istestDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtestcaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idurlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnRun;
        private System.Windows.Forms.DataGridViewButtonColumn btnViewTestcase;
        private System.Windows.Forms.Label lbid_url;
        private System.Windows.Forms.Label label1;
    }
}