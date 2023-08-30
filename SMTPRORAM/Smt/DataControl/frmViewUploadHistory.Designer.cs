namespace SMTPRORAM.Smt.DataControl
{
    partial class frmViewUploadHistory
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
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDeleteKey = new System.Windows.Forms.TextBox();
			this.btnSearchDate = new System.Windows.Forms.Button();
			this.btExport = new System.Windows.Forms.Button();
			this.lblCount = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSearchPart = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPart = new System.Windows.Forms.TextBox();
			this.btnSearchProgram = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtpartlist = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtstart = new System.Windows.Forms.DateTimePicker();
			this.txtend = new System.Windows.Forms.DateTimePicker();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.iconbtnDelete);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.txtDeleteKey);
			this.panel1.Controls.Add(this.btnSearchDate);
			this.panel1.Controls.Add(this.btExport);
			this.panel1.Controls.Add(this.lblCount);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.btnSearchPart);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.txtPart);
			this.panel1.Controls.Add(this.btnSearchProgram);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtpartlist);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtstart);
			this.panel1.Controls.Add(this.txtend);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 94);
			this.panel1.TabIndex = 0;
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(907, 9);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(65, 21);
			this.iconbtnDelete.TabIndex = 75;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(556, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 13);
			this.label6.TabIndex = 74;
			this.label6.Text = "Xóa bằng Program Key";
			// 
			// txtDeleteKey
			// 
			this.txtDeleteKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDeleteKey.BackColor = System.Drawing.Color.RosyBrown;
			this.txtDeleteKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDeleteKey.Location = new System.Drawing.Point(678, 9);
			this.txtDeleteKey.Name = "txtDeleteKey";
			this.txtDeleteKey.Size = new System.Drawing.Size(223, 20);
			this.txtDeleteKey.TabIndex = 73;
			// 
			// btnSearchDate
			// 
			this.btnSearchDate.Location = new System.Drawing.Point(355, 8);
			this.btnSearchDate.Name = "btnSearchDate";
			this.btnSearchDate.Size = new System.Drawing.Size(75, 23);
			this.btnSearchDate.TabIndex = 72;
			this.btnSearchDate.Text = "Search";
			this.btnSearchDate.UseVisualStyleBackColor = true;
			this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);
			// 
			// btExport
			// 
			this.btExport.Location = new System.Drawing.Point(436, 8);
			this.btExport.Name = "btExport";
			this.btExport.Size = new System.Drawing.Size(97, 23);
			this.btExport.TabIndex = 71;
			this.btExport.Text = "Export To CSV";
			this.btExport.UseVisualStyleBackColor = true;
			this.btExport.Click += new System.EventHandler(this.btExport_Click);
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCount.ForeColor = System.Drawing.Color.Red;
			this.lblCount.Location = new System.Drawing.Point(620, 65);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(44, 16);
			this.lblCount.TabIndex = 70;
			this.lblCount.Text = "count";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(565, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 69;
			this.label5.Text = "Tổng số:";
			// 
			// btnSearchPart
			// 
			this.btnSearchPart.Location = new System.Drawing.Point(416, 62);
			this.btnSearchPart.Name = "btnSearchPart";
			this.btnSearchPart.Size = new System.Drawing.Size(75, 23);
			this.btnSearchPart.TabIndex = 68;
			this.btnSearchPart.Text = "Search";
			this.btnSearchPart.UseVisualStyleBackColor = true;
			this.btnSearchPart.Click += new System.EventHandler(this.btnSearchPart_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 67;
			this.label4.Text = "PartCode #";
			// 
			// txtPart
			// 
			this.txtPart.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.txtPart.Location = new System.Drawing.Point(187, 63);
			this.txtPart.Name = "txtPart";
			this.txtPart.Size = new System.Drawing.Size(223, 20);
			this.txtPart.TabIndex = 66;
			// 
			// btnSearchProgram
			// 
			this.btnSearchProgram.Location = new System.Drawing.Point(416, 35);
			this.btnSearchProgram.Name = "btnSearchProgram";
			this.btnSearchProgram.Size = new System.Drawing.Size(75, 23);
			this.btnSearchProgram.TabIndex = 64;
			this.btnSearchProgram.Text = "Load Data";
			this.btnSearchProgram.UseVisualStyleBackColor = true;
			this.btnSearchProgram.Click += new System.EventHandler(this.btnSearchProgram_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 63;
			this.label3.Text = "Program Parts List";
			// 
			// txtpartlist
			// 
			this.txtpartlist.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.txtpartlist.Location = new System.Drawing.Point(187, 38);
			this.txtpartlist.Name = "txtpartlist";
			this.txtpartlist.Size = new System.Drawing.Size(223, 20);
			this.txtpartlist.TabIndex = 62;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 61;
			this.label2.Text = "Tới Ngày";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 60;
			this.label1.Text = "Từ Ngày";
			// 
			// txtstart
			// 
			this.txtstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtstart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtstart.Location = new System.Drawing.Point(80, 9);
			this.txtstart.Name = "txtstart";
			this.txtstart.Size = new System.Drawing.Size(97, 20);
			this.txtstart.TabIndex = 58;
			// 
			// txtend
			// 
			this.txtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtend.Location = new System.Drawing.Point(252, 9);
			this.txtend.Name = "txtend";
			this.txtend.Size = new System.Drawing.Size(97, 20);
			this.txtend.TabIndex = 59;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 94);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 467);
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
			this.dgView.Size = new System.Drawing.Size(960, 449);
			this.dgView.TabIndex = 0;
			// 
			// frmViewUploadHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmViewUploadHistory";
			this.Text = "Xem dữ liệu BOM đã Upload";
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
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPart;
        private System.Windows.Forms.Button btnSearchProgram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpartlist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtstart;
        private System.Windows.Forms.DateTimePicker txtend;
        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeleteKey;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
    }
}