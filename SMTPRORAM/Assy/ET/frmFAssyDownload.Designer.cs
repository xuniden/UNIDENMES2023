namespace SMTPRORAM.Assy.ET
{
    partial class frmFAssyDownload
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
            this.btDaily = new System.Windows.Forms.Button();
            this.btExportModelSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbltongso = new System.Windows.Forms.Label();
            this.btDownload = new System.Windows.Forms.Button();
            this.btModelSearch = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPcbtype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btDaily);
            this.panel1.Controls.Add(this.btExportModelSearch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbltongso);
            this.panel1.Controls.Add(this.btDownload);
            this.panel1.Controls.Add(this.btModelSearch);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbPcbtype);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 81);
            this.panel1.TabIndex = 0;
            // 
            // btDaily
            // 
            this.btDaily.Location = new System.Drawing.Point(430, 46);
            this.btDaily.Name = "btDaily";
            this.btDaily.Size = new System.Drawing.Size(111, 23);
            this.btDaily.TabIndex = 30;
            this.btDaily.Text = "Daily OutPut";
            this.btDaily.UseVisualStyleBackColor = true;
            this.btDaily.SizeChanged += new System.EventHandler(this.btDaily_SizeChanged);
            this.btDaily.Click += new System.EventHandler(this.btDaily_Click);
            // 
            // btExportModelSearch
            // 
            this.btExportModelSearch.Location = new System.Drawing.Point(312, 46);
            this.btExportModelSearch.Name = "btExportModelSearch";
            this.btExportModelSearch.Size = new System.Drawing.Size(112, 23);
            this.btExportModelSearch.TabIndex = 29;
            this.btExportModelSearch.Text = "Exp Model Search";
            this.btExportModelSearch.UseVisualStyleBackColor = true;
            this.btExportModelSearch.Click += new System.EventHandler(this.btExportModelSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tổng số:";
            // 
            // lbltongso
            // 
            this.lbltongso.AutoSize = true;
            this.lbltongso.ForeColor = System.Drawing.Color.Red;
            this.lbltongso.Location = new System.Drawing.Point(638, 56);
            this.lbltongso.Name = "lbltongso";
            this.lbltongso.Size = new System.Drawing.Size(35, 13);
            this.lbltongso.TabIndex = 27;
            this.lbltongso.Text = "label5";
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(99, 46);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(105, 23);
            this.btDownload.TabIndex = 26;
            this.btDownload.Text = "Download Search";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // btModelSearch
            // 
            this.btModelSearch.Location = new System.Drawing.Point(210, 46);
            this.btModelSearch.Name = "btModelSearch";
            this.btModelSearch.Size = new System.Drawing.Size(96, 23);
            this.btModelSearch.TabIndex = 25;
            this.btModelSearch.Text = "Model Search";
            this.btModelSearch.UseVisualStyleBackColor = true;
            this.btModelSearch.Click += new System.EventHandler(this.btModelSearch_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(18, 46);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 24;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(599, 13);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(141, 20);
            this.dateTo.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(570, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "To:";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(404, 13);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(145, 20);
            this.dateFrom.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "From:";
            // 
            // cbPcbtype
            // 
            this.cbPcbtype.FormattingEnabled = true;
            this.cbPcbtype.Location = new System.Drawing.Point(238, 12);
            this.cbPcbtype.Name = "cbPcbtype";
            this.cbPcbtype.Size = new System.Drawing.Size(121, 21);
            this.cbPcbtype.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Pcb Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Model:";
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(54, 12);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(105, 21);
            this.cbModel.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 480);
            this.panel2.TabIndex = 1;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(3, 6);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(978, 462);
            this.dgView.TabIndex = 0;
            // 
            // frmFAssyDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmFAssyDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download kết quả sản xuất ET";
            this.Load += new System.EventHandler(this.frmFAssyDownload_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button btDaily;
        private System.Windows.Forms.Button btExportModelSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbltongso;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Button btModelSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPcbtype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbModel;
    }
}