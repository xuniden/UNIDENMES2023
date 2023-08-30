namespace SMTPRORAM
{
    partial class F_ViewRepairData
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
            this.dgView = new System.Windows.Forms.DataGridView();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSeach = new System.Windows.Forms.Button();
            this.btToCSV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQRCode = new System.Windows.Forms.TextBox();
            this.btTim = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(12, 40);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(776, 562);
            this.dgView.TabIndex = 0;
            // 
            // cbDept
            // 
            this.cbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Items.AddRange(new object[] {
            "ASSY",
            "SCL",
            "SMT"});
            this.cbDept.Location = new System.Drawing.Point(68, 12);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(121, 21);
            this.cbDept.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bộ Phận:";
            // 
            // btSeach
            // 
            this.btSeach.Location = new System.Drawing.Point(195, 10);
            this.btSeach.Name = "btSeach";
            this.btSeach.Size = new System.Drawing.Size(62, 23);
            this.btSeach.TabIndex = 3;
            this.btSeach.Text = "Tìm Kiếm";
            this.btSeach.UseVisualStyleBackColor = true;
            this.btSeach.Click += new System.EventHandler(this.btSeach_Click);
            // 
            // btToCSV
            // 
            this.btToCSV.Location = new System.Drawing.Point(263, 11);
            this.btToCSV.Name = "btToCSV";
            this.btToCSV.Size = new System.Drawing.Size(95, 23);
            this.btToCSV.TabIndex = 4;
            this.btToCSV.Text = "Export To CSV";
            this.btToCSV.UseVisualStyleBackColor = true;
            this.btToCSV.Click += new System.EventHandler(this.btToCSV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "QR Code:";
            // 
            // txtQRCode
            // 
            this.txtQRCode.Location = new System.Drawing.Point(427, 13);
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(221, 20);
            this.txtQRCode.TabIndex = 6;
            // 
            // btTim
            // 
            this.btTim.Location = new System.Drawing.Point(654, 11);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(53, 23);
            this.btTim.TabIndex = 7;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = true;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(713, 10);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 8;
            this.btExport.Text = "To CSV";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // F_ViewRepairData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 614);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btTim);
            this.Controls.Add(this.txtQRCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btToCSV);
            this.Controls.Add(this.btSeach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDept);
            this.Controls.Add(this.dgView);
            this.Name = "F_ViewRepairData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_ViewRepairData";
            this.Load += new System.EventHandler(this.F_ViewRepairData_Load);
            this.SizeChanged += new System.EventHandler(this.F_ViewRepairData_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSeach;
        private System.Windows.Forms.Button btToCSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.Button btTim;
        private System.Windows.Forms.Button btExport;
    }
}