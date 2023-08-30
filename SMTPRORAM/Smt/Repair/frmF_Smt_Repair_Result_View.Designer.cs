namespace SMTPRORAM.Smt.Repair
{
    partial class frmF_Smt_Repair_Result_View
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
			this.btLoad = new System.Windows.Forms.Button();
			this.btTim = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dTo = new System.Windows.Forms.DateTimePicker();
			this.dFrom = new System.Windows.Forms.DateTimePicker();
			this.btDownload = new System.Windows.Forms.Button();
			this.btSearch = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbDept = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btLoad);
			this.panel1.Controls.Add(this.btTim);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dTo);
			this.panel1.Controls.Add(this.dFrom);
			this.panel1.Controls.Add(this.btDownload);
			this.panel1.Controls.Add(this.btSearch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbDept);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 68);
			this.panel1.TabIndex = 0;
			// 
			// btLoad
			// 
			this.btLoad.Location = new System.Drawing.Point(442, 33);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(75, 23);
			this.btLoad.TabIndex = 22;
			this.btLoad.Text = "Download";
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// btTim
			// 
			this.btTim.Location = new System.Drawing.Point(361, 33);
			this.btTim.Name = "btTim";
			this.btTim.Size = new System.Drawing.Size(75, 23);
			this.btTim.TabIndex = 21;
			this.btTim.Text = "Tìm Kiếm";
			this.btTim.UseVisualStyleBackColor = true;
			this.btTim.Click += new System.EventHandler(this.btTim_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(189, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Đến Ngày:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Từ Ngày:";
			// 
			// dTo
			// 
			this.dTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dTo.Location = new System.Drawing.Point(253, 35);
			this.dTo.Name = "dTo";
			this.dTo.Size = new System.Drawing.Size(93, 20);
			this.dTo.TabIndex = 18;
			// 
			// dFrom
			// 
			this.dFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dFrom.Location = new System.Drawing.Point(83, 36);
			this.dFrom.Name = "dFrom";
			this.dFrom.Size = new System.Drawing.Size(100, 20);
			this.dFrom.TabIndex = 17;
			// 
			// btDownload
			// 
			this.btDownload.Location = new System.Drawing.Point(291, 6);
			this.btDownload.Name = "btDownload";
			this.btDownload.Size = new System.Drawing.Size(75, 23);
			this.btDownload.TabIndex = 16;
			this.btDownload.Text = "Download";
			this.btDownload.UseVisualStyleBackColor = true;
			this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
			// 
			// btSearch
			// 
			this.btSearch.Location = new System.Drawing.Point(210, 6);
			this.btSearch.Name = "btSearch";
			this.btSearch.Size = new System.Drawing.Size(75, 23);
			this.btSearch.TabIndex = 15;
			this.btSearch.Text = "Tìm Kiếm";
			this.btSearch.UseVisualStyleBackColor = true;
			this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Department:";
			// 
			// cbDept
			// 
			this.cbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDept.FormattingEnabled = true;
			this.cbDept.Location = new System.Drawing.Point(83, 6);
			this.cbDept.Name = "cbDept";
			this.cbDept.Size = new System.Drawing.Size(121, 21);
			this.cbDept.TabIndex = 13;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 68);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 493);
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
			this.dgView.Location = new System.Drawing.Point(12, 6);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(960, 475);
			this.dgView.TabIndex = 1;
			// 
			// frmF_Smt_Repair_Result_View
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmF_Smt_Repair_Result_View";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Xem kết quả nhập dữ liệu Repair";
			this.Load += new System.EventHandler(this.frmF_Smt_Repair_Result_View_Load);
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
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btTim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTo;
        private System.Windows.Forms.DateTimePicker dFrom;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDept;
    }
}