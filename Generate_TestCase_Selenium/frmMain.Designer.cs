namespace Generate_TestCase_Selenium
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.dgvElements = new System.Windows.Forms.DataGridView();
            this.idelementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idurlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idformDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minlengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxlengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.readonlyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maxvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multipleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xpathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.elementDBDataSet = new Generate_TestCase_Selenium.ElementDBDataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtboxUrl = new System.Windows.Forms.TextBox();
            this.btnCrawlWeb = new System.Windows.Forms.Button();
            this.labelUrl = new System.Windows.Forms.Label();
            this.elementTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSetTableAdapters.ElementTableAdapter();
            this.btnGenerateTestCase = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.dgvElements);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 460);
            this.panel1.TabIndex = 0;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.Location = new System.Drawing.Point(3, 100);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(241, 24);
            this.lbMessage.TabIndex = 7;
            this.lbMessage.Text = "Crawling data, please wait...";
            this.lbMessage.Visible = false;
            // 
            // dgvElements
            // 
            this.dgvElements.AllowUserToAddRows = false;
            this.dgvElements.AllowUserToDeleteRows = false;
            this.dgvElements.AutoGenerateColumns = false;
            this.dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idelementDataGridViewTextBoxColumn,
            this.idurlDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.classnameDataGridViewTextBoxColumn,
            this.tagnameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.hrefDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.idformDataGridViewTextBoxColumn,
            this.minlengthDataGridViewTextBoxColumn,
            this.maxlengthDataGridViewTextBoxColumn,
            this.requiredDataGridViewCheckBoxColumn,
            this.readonlyDataGridViewCheckBoxColumn,
            this.maxvalueDataGridViewTextBoxColumn,
            this.minvalueDataGridViewTextBoxColumn,
            this.multipleDataGridViewCheckBoxColumn,
            this.xpathDataGridViewTextBoxColumn});
            this.dgvElements.DataSource = this.elementBindingSource;
            this.dgvElements.Location = new System.Drawing.Point(3, 142);
            this.dgvElements.Name = "dgvElements";
            this.dgvElements.ReadOnly = true;
            this.dgvElements.Size = new System.Drawing.Size(730, 318);
            this.dgvElements.TabIndex = 5;
            // 
            // idelementDataGridViewTextBoxColumn
            // 
            this.idelementDataGridViewTextBoxColumn.DataPropertyName = "id_element";
            this.idelementDataGridViewTextBoxColumn.HeaderText = "Element id";
            this.idelementDataGridViewTextBoxColumn.Name = "idelementDataGridViewTextBoxColumn";
            this.idelementDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idurlDataGridViewTextBoxColumn
            // 
            this.idurlDataGridViewTextBoxColumn.DataPropertyName = "id_url";
            this.idurlDataGridViewTextBoxColumn.HeaderText = "id_url";
            this.idurlDataGridViewTextBoxColumn.Name = "idurlDataGridViewTextBoxColumn";
            this.idurlDataGridViewTextBoxColumn.ReadOnly = true;
            this.idurlDataGridViewTextBoxColumn.Visible = false;
            this.idurlDataGridViewTextBoxColumn.Width = 57;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // classnameDataGridViewTextBoxColumn
            // 
            this.classnameDataGridViewTextBoxColumn.DataPropertyName = "class_name";
            this.classnameDataGridViewTextBoxColumn.HeaderText = "class name";
            this.classnameDataGridViewTextBoxColumn.Name = "classnameDataGridViewTextBoxColumn";
            this.classnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tagnameDataGridViewTextBoxColumn
            // 
            this.tagnameDataGridViewTextBoxColumn.DataPropertyName = "tag_name";
            this.tagnameDataGridViewTextBoxColumn.HeaderText = "tag name";
            this.tagnameDataGridViewTextBoxColumn.Name = "tagnameDataGridViewTextBoxColumn";
            this.tagnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hrefDataGridViewTextBoxColumn
            // 
            this.hrefDataGridViewTextBoxColumn.DataPropertyName = "href";
            this.hrefDataGridViewTextBoxColumn.HeaderText = "href";
            this.hrefDataGridViewTextBoxColumn.Name = "hrefDataGridViewTextBoxColumn";
            this.hrefDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idformDataGridViewTextBoxColumn
            // 
            this.idformDataGridViewTextBoxColumn.DataPropertyName = "id_form";
            this.idformDataGridViewTextBoxColumn.HeaderText = "id_form";
            this.idformDataGridViewTextBoxColumn.Name = "idformDataGridViewTextBoxColumn";
            this.idformDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // minlengthDataGridViewTextBoxColumn
            // 
            this.minlengthDataGridViewTextBoxColumn.DataPropertyName = "minlength";
            this.minlengthDataGridViewTextBoxColumn.HeaderText = "minlength";
            this.minlengthDataGridViewTextBoxColumn.Name = "minlengthDataGridViewTextBoxColumn";
            this.minlengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.minlengthDataGridViewTextBoxColumn.Visible = false;
            this.minlengthDataGridViewTextBoxColumn.Width = 77;
            // 
            // maxlengthDataGridViewTextBoxColumn
            // 
            this.maxlengthDataGridViewTextBoxColumn.DataPropertyName = "maxlength";
            this.maxlengthDataGridViewTextBoxColumn.HeaderText = "maxlength";
            this.maxlengthDataGridViewTextBoxColumn.Name = "maxlengthDataGridViewTextBoxColumn";
            this.maxlengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxlengthDataGridViewTextBoxColumn.Visible = false;
            this.maxlengthDataGridViewTextBoxColumn.Width = 80;
            // 
            // requiredDataGridViewCheckBoxColumn
            // 
            this.requiredDataGridViewCheckBoxColumn.DataPropertyName = "required";
            this.requiredDataGridViewCheckBoxColumn.HeaderText = "required";
            this.requiredDataGridViewCheckBoxColumn.Name = "requiredDataGridViewCheckBoxColumn";
            this.requiredDataGridViewCheckBoxColumn.ReadOnly = true;
            this.requiredDataGridViewCheckBoxColumn.Visible = false;
            this.requiredDataGridViewCheckBoxColumn.Width = 51;
            // 
            // readonlyDataGridViewCheckBoxColumn
            // 
            this.readonlyDataGridViewCheckBoxColumn.DataPropertyName = "read_only";
            this.readonlyDataGridViewCheckBoxColumn.HeaderText = "read_only";
            this.readonlyDataGridViewCheckBoxColumn.Name = "readonlyDataGridViewCheckBoxColumn";
            this.readonlyDataGridViewCheckBoxColumn.ReadOnly = true;
            this.readonlyDataGridViewCheckBoxColumn.Visible = false;
            this.readonlyDataGridViewCheckBoxColumn.Width = 59;
            // 
            // maxvalueDataGridViewTextBoxColumn
            // 
            this.maxvalueDataGridViewTextBoxColumn.DataPropertyName = "max_value";
            this.maxvalueDataGridViewTextBoxColumn.HeaderText = "max_value";
            this.maxvalueDataGridViewTextBoxColumn.Name = "maxvalueDataGridViewTextBoxColumn";
            this.maxvalueDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxvalueDataGridViewTextBoxColumn.Visible = false;
            this.maxvalueDataGridViewTextBoxColumn.Width = 83;
            // 
            // minvalueDataGridViewTextBoxColumn
            // 
            this.minvalueDataGridViewTextBoxColumn.DataPropertyName = "min_value";
            this.minvalueDataGridViewTextBoxColumn.HeaderText = "min_value";
            this.minvalueDataGridViewTextBoxColumn.Name = "minvalueDataGridViewTextBoxColumn";
            this.minvalueDataGridViewTextBoxColumn.ReadOnly = true;
            this.minvalueDataGridViewTextBoxColumn.Visible = false;
            this.minvalueDataGridViewTextBoxColumn.Width = 80;
            // 
            // multipleDataGridViewCheckBoxColumn
            // 
            this.multipleDataGridViewCheckBoxColumn.DataPropertyName = "multiple";
            this.multipleDataGridViewCheckBoxColumn.HeaderText = "multiple";
            this.multipleDataGridViewCheckBoxColumn.Name = "multipleDataGridViewCheckBoxColumn";
            this.multipleDataGridViewCheckBoxColumn.ReadOnly = true;
            this.multipleDataGridViewCheckBoxColumn.Visible = false;
            this.multipleDataGridViewCheckBoxColumn.Width = 48;
            // 
            // xpathDataGridViewTextBoxColumn
            // 
            this.xpathDataGridViewTextBoxColumn.DataPropertyName = "xpath";
            this.xpathDataGridViewTextBoxColumn.HeaderText = "xpath";
            this.xpathDataGridViewTextBoxColumn.Name = "xpathDataGridViewTextBoxColumn";
            this.xpathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // elementBindingSource
            // 
            this.elementBindingSource.DataMember = "Element";
            this.elementBindingSource.DataSource = this.elementDBDataSet;
            // 
            // elementDBDataSet
            // 
            this.elementDBDataSet.DataSetName = "ElementDBDataSet";
            this.elementDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnGenerateTestCase);
            this.panel2.Controls.Add(this.txtboxUrl);
            this.panel2.Controls.Add(this.btnCrawlWeb);
            this.panel2.Controls.Add(this.labelUrl);
            this.panel2.Location = new System.Drawing.Point(74, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 69);
            this.panel2.TabIndex = 4;
            // 
            // txtboxUrl
            // 
            this.txtboxUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxUrl.Location = new System.Drawing.Point(60, 25);
            this.txtboxUrl.Name = "txtboxUrl";
            this.txtboxUrl.Size = new System.Drawing.Size(272, 26);
            this.txtboxUrl.TabIndex = 1;
            this.txtboxUrl.Text = "https://facebook.com/";
            // 
            // btnCrawlWeb
            // 
            this.btnCrawlWeb.Location = new System.Drawing.Point(338, 23);
            this.btnCrawlWeb.Name = "btnCrawlWeb";
            this.btnCrawlWeb.Size = new System.Drawing.Size(75, 28);
            this.btnCrawlWeb.TabIndex = 3;
            this.btnCrawlWeb.Text = "Crawl Data";
            this.btnCrawlWeb.UseVisualStyleBackColor = true;
            this.btnCrawlWeb.Click += new System.EventHandler(this.btnCrawlWeb_Click);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUrl.Location = new System.Drawing.Point(16, 29);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(38, 16);
            this.labelUrl.TabIndex = 0;
            this.labelUrl.Text = "URL:";
            // 
            // elementTableAdapter
            // 
            this.elementTableAdapter.ClearBeforeFill = true;
            // 
            // btnGenerateTestCase
            // 
            this.btnGenerateTestCase.Enabled = false;
            this.btnGenerateTestCase.Location = new System.Drawing.Point(432, 23);
            this.btnGenerateTestCase.Name = "btnGenerateTestCase";
            this.btnGenerateTestCase.Size = new System.Drawing.Size(115, 28);
            this.btnGenerateTestCase.TabIndex = 4;
            this.btnGenerateTestCase.Text = "Generate TestCase";
            this.btnGenerateTestCase.UseVisualStyleBackColor = true;
            this.btnGenerateTestCase.Click += new System.EventHandler(this.btnGenerateTestCase_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCrawlWeb;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 484);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtboxUrl;
        private System.Windows.Forms.Button btnCrawlWeb;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.DataGridView dgvElements;
        private ElementDBDataSet elementDBDataSet;
        private System.Windows.Forms.BindingSource elementBindingSource;
        private ElementDBDataSetTableAdapters.ElementTableAdapter elementTableAdapter;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn idelementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idurlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hrefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idformDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minlengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxlengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn requiredDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn readonlyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn multipleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xpathDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnGenerateTestCase;
    }
}

