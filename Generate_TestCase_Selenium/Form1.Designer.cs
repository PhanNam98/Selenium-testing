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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUrl = new System.Windows.Forms.Label();
            this.txtboxUrl = new System.Windows.Forms.TextBox();
            this.chBoxSaveDB = new System.Windows.Forms.CheckBox();
            this.btnCrawlWeb = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 303);
            this.panel1.TabIndex = 0;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(8, 30);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(32, 13);
            this.labelUrl.TabIndex = 0;
            this.labelUrl.Text = "URL:";
            // 
            // txtboxUrl
            // 
            this.txtboxUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxUrl.Location = new System.Drawing.Point(62, 28);
            this.txtboxUrl.Name = "txtboxUrl";
            this.txtboxUrl.Size = new System.Drawing.Size(186, 20);
            this.txtboxUrl.TabIndex = 1;
            this.txtboxUrl.Text = "https://facebook.com/";
            // 
            // chBoxSaveDB
            // 
            this.chBoxSaveDB.AutoSize = true;
            this.chBoxSaveDB.Location = new System.Drawing.Point(11, 58);
            this.chBoxSaveDB.Name = "chBoxSaveDB";
            this.chBoxSaveDB.Size = new System.Drawing.Size(110, 17);
            this.chBoxSaveDB.TabIndex = 2;
            this.chBoxSaveDB.Text = "Save to database";
            this.chBoxSaveDB.UseVisualStyleBackColor = true;
            // 
            // btnCrawlWeb
            // 
            this.btnCrawlWeb.Location = new System.Drawing.Point(273, 24);
            this.btnCrawlWeb.Name = "btnCrawlWeb";
            this.btnCrawlWeb.Size = new System.Drawing.Size(75, 23);
            this.btnCrawlWeb.TabIndex = 3;
            this.btnCrawlWeb.Text = "Crawl Data";
            this.btnCrawlWeb.UseVisualStyleBackColor = true;
            this.btnCrawlWeb.Click += new System.EventHandler(this.btnCrawlWeb_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtboxUrl);
            this.panel2.Controls.Add(this.btnCrawlWeb);
            this.panel2.Controls.Add(this.labelUrl);
            this.panel2.Controls.Add(this.chBoxSaveDB);
            this.panel2.Location = new System.Drawing.Point(68, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 100);
            this.panel2.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCrawlWeb;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 316);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox chBoxSaveDB;
    }
}

