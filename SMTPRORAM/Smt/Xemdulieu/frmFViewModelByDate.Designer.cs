namespace SMTPRORAM.Smt.Xemdulieu
{
    partial class frmFViewModelByDate
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
            this.lblRecod = new System.Windows.Forms.Label();
            this.btFind = new System.Windows.Forms.Button();
            this.dtp_2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btToCsv = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btDownload = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecod);
            this.panel1.Controls.Add(this.btFind);
            this.panel1.Controls.Add(this.dtp_2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtp_1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btToCsv);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btDownload);
            this.panel1.Controls.Add(this.txtModel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 43);
            this.panel1.TabIndex = 2;
            // 
            // lblRecod
            // 
            this.lblRecod.AutoSize = true;
            this.lblRecod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRecod.ForeColor = System.Drawing.Color.Blue;
            this.lblRecod.Location = new System.Drawing.Point(931, 13);
            this.lblRecod.Name = "lblRecod";
            this.lblRecod.Size = new System.Drawing.Size(41, 13);
            this.lblRecod.TabIndex = 32;
            this.lblRecod.Text = "label5";
            // 
            // btFind
            // 
            this.btFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFind.Location = new System.Drawing.Point(591, 8);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(74, 23);
            this.btFind.TabIndex = 31;
            this.btFind.Text = "Tìm Kiếm";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // dtp_2
            // 
            this.dtp_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_2.Location = new System.Drawing.Point(491, 10);
            this.dtp_2.Name = "dtp_2";
            this.dtp_2.Size = new System.Drawing.Size(93, 20);
            this.dtp_2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Đến ngày:";
            // 
            // dtp_1
            // 
            this.dtp_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_1.Location = new System.Drawing.Point(306, 10);
            this.dtp_1.Name = "dtp_1";
            this.dtp_1.Size = new System.Drawing.Size(115, 20);
            this.dtp_1.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(251, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Từ ngày:";
            // 
            // btToCsv
            // 
            this.btToCsv.Location = new System.Drawing.Point(671, 9);
            this.btToCsv.Name = "btToCsv";
            this.btToCsv.Size = new System.Drawing.Size(79, 22);
            this.btToCsv.TabIndex = 26;
            this.btToCsv.Text = "Export Csv";
            this.btToCsv.UseVisualStyleBackColor = true;
            this.btToCsv.Click += new System.EventHandler(this.btToCsv_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(861, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Total Rows:";
            // 
            // btDownload
            // 
            this.btDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDownload.Location = new System.Drawing.Point(755, 9);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(100, 22);
            this.btDownload.TabIndex = 23;
            this.btDownload.Text = "Download Excel";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // txtModel
            // 
            this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(73, 10);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(172, 20);
            this.txtModel.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Model:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 561);
            this.panel2.TabIndex = 3;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(3, 49);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(978, 509);
            this.dgView.TabIndex = 0;
            // 
            // frmFViewModelByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmFViewModelByDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XEM DỮ LIỆU THEO MODEL VÀ NGÀY THÁNG";
            this.Load += new System.EventHandler(this.frmFViewModelByDate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRecod;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.DateTimePicker dtp_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btToCsv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
    }
}