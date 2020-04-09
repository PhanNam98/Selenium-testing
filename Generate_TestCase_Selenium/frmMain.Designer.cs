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
            this.elementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.elementDBDataSet = new Generate_TestCase_Selenium.ElementDBDataSet();
            this.elementTableAdapter = new Generate_TestCase_Selenium.ElementDBDataSetTableAdapters.ElementTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerateTestCase = new System.Windows.Forms.Button();
            this.txtboxUrl = new System.Windows.Forms.TextBox();
            this.btnCrawlWeb = new System.Windows.Forms.Button();
            this.labelUrl = new System.Windows.Forms.Label();
            this.dgvElements = new System.Windows.Forms.DataGridView();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.idelementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idformDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.required = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xpathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // elementTableAdapter
            // 
            this.elementTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnGenerateTestCase);
            this.panel2.Controls.Add(this.txtboxUrl);
            this.panel2.Controls.Add(this.btnCrawlWeb);
            this.panel2.Controls.Add(this.labelUrl);
            this.panel2.Location = new System.Drawing.Point(67, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 69);
            this.panel2.TabIndex = 4;
            // 
            // btnGenerateTestCase
            // 
            this.btnGenerateTestCase.Location = new System.Drawing.Point(432, 23);
            this.btnGenerateTestCase.Name = "btnGenerateTestCase";
            this.btnGenerateTestCase.Size = new System.Drawing.Size(115, 28);
            this.btnGenerateTestCase.TabIndex = 4;
            this.btnGenerateTestCase.Text = "Generate TestCase";
            this.btnGenerateTestCase.UseVisualStyleBackColor = true;
            this.btnGenerateTestCase.Click += new System.EventHandler(this.btnGenerateTestCase_Click);
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
            // dgvElements
            // 
            this.dgvElements.AllowUserToAddRows = false;
            this.dgvElements.AllowUserToDeleteRows = false;
            this.dgvElements.AutoGenerateColumns = false;
            this.dgvElements.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idelementDataGridViewTextBoxColumn,
            this.idformDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.classnameDataGridViewTextBoxColumn,
            this.tagnameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.hrefDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.required,
            this.xpathDataGridViewTextBoxColumn});
            this.dgvElements.DataSource = this.elementBindingSource;
            this.dgvElements.Location = new System.Drawing.Point(3, 111);
            this.dgvElements.Name = "dgvElements";
            this.dgvElements.ReadOnly = true;
            this.dgvElements.Size = new System.Drawing.Size(787, 367);
            this.dgvElements.TabIndex = 5;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.Location = new System.Drawing.Point(3, 84);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(241, 24);
            this.lbMessage.TabIndex = 7;
            this.lbMessage.Text = "Crawling data, please wait...";
            this.lbMessage.Visible = false;
            this.lbMessage.Click += new System.EventHandler(this.lbMessage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.dgvElements);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 481);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // idelementDataGridViewTextBoxColumn
            // 
            this.idelementDataGridViewTextBoxColumn.DataPropertyName = "id_element";
            this.idelementDataGridViewTextBoxColumn.HeaderText = "Element id";
            this.idelementDataGridViewTextBoxColumn.Name = "idelementDataGridViewTextBoxColumn";
            this.idelementDataGridViewTextBoxColumn.ReadOnly = true;
            this.idelementDataGridViewTextBoxColumn.Width = 69;
            // 
            // idformDataGridViewTextBoxColumn
            // 
            this.idformDataGridViewTextBoxColumn.DataPropertyName = "id_form";
            this.idformDataGridViewTextBoxColumn.HeaderText = "id_form";
            this.idformDataGridViewTextBoxColumn.Name = "idformDataGridViewTextBoxColumn";
            this.idformDataGridViewTextBoxColumn.ReadOnly = true;
            this.idformDataGridViewTextBoxColumn.Width = 68;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 68;
            // 
            // classnameDataGridViewTextBoxColumn
            // 
            this.classnameDataGridViewTextBoxColumn.DataPropertyName = "class_name";
            this.classnameDataGridViewTextBoxColumn.HeaderText = "class name";
            this.classnameDataGridViewTextBoxColumn.Name = "classnameDataGridViewTextBoxColumn";
            this.classnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.classnameDataGridViewTextBoxColumn.Width = 69;
            // 
            // tagnameDataGridViewTextBoxColumn
            // 
            this.tagnameDataGridViewTextBoxColumn.DataPropertyName = "tag_name";
            this.tagnameDataGridViewTextBoxColumn.HeaderText = "tag name";
            this.tagnameDataGridViewTextBoxColumn.Name = "tagnameDataGridViewTextBoxColumn";
            this.tagnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tagnameDataGridViewTextBoxColumn.Width = 69;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 68;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 69;
            // 
            // hrefDataGridViewTextBoxColumn
            // 
            this.hrefDataGridViewTextBoxColumn.DataPropertyName = "href";
            this.hrefDataGridViewTextBoxColumn.HeaderText = "href";
            this.hrefDataGridViewTextBoxColumn.Name = "hrefDataGridViewTextBoxColumn";
            this.hrefDataGridViewTextBoxColumn.ReadOnly = true;
            this.hrefDataGridViewTextBoxColumn.Width = 69;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 69;
            // 
            // required
            // 
            this.required.DataPropertyName = "required";
            this.required.HeaderText = "required";
            this.required.Name = "required";
            this.required.ReadOnly = true;
            // 
            // xpathDataGridViewTextBoxColumn
            // 
            this.xpathDataGridViewTextBoxColumn.DataPropertyName = "xpath";
            this.xpathDataGridViewTextBoxColumn.HeaderText = "xpath";
            this.xpathDataGridViewTextBoxColumn.Name = "xpathDataGridViewTextBoxColumn";
            this.xpathDataGridViewTextBoxColumn.ReadOnly = true;
            this.xpathDataGridViewTextBoxColumn.Width = 69;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCrawlWeb;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementDBDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ElementDBDataSet elementDBDataSet;
        private System.Windows.Forms.BindingSource elementBindingSource;
        private ElementDBDataSetTableAdapters.ElementTableAdapter elementTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerateTestCase;
        private System.Windows.Forms.TextBox txtboxUrl;
        private System.Windows.Forms.Button btnCrawlWeb;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.DataGridView dgvElements;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idelementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idformDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hrefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn required;
        private System.Windows.Forms.DataGridViewTextBoxColumn xpathDataGridViewTextBoxColumn;
    }
}

