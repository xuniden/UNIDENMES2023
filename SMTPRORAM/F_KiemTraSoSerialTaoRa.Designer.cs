namespace SMTPRORAM
{
    partial class F_KiemTraSoSerialTaoRa
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
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btall = new System.Windows.Forms.Button();
            this.btKiemtra = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.lbcount = new System.Windows.Forms.Label();
            this.btTimkiem = new System.Windows.Forms.Button();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // cbModel
            // 
            this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(54, 19);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(121, 21);
            this.cbModel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btall);
            this.groupBox1.Controls.Add(this.btKiemtra);
            this.groupBox1.Controls.Add(this.btExport);
            this.groupBox1.Controls.Add(this.lbcount);
            this.groupBox1.Controls.Add(this.btTimkiem);
            this.groupBox1.Controls.Add(this.cbDay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbModel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 381);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btall
            // 
            this.btall.Location = new System.Drawing.Point(139, 348);
            this.btall.Name = "btall";
            this.btall.Size = new System.Drawing.Size(75, 23);
            this.btall.TabIndex = 12;
            this.btall.Text = "All Of Model";
            this.btall.UseVisualStyleBackColor = true;
            this.btall.Click += new System.EventHandler(this.btall_Click);
            // 
            // btKiemtra
            // 
            this.btKiemtra.Location = new System.Drawing.Point(139, 313);
            this.btKiemtra.Name = "btKiemtra";
            this.btKiemtra.Size = new System.Drawing.Size(75, 23);
            this.btKiemtra.TabIndex = 11;
            this.btKiemtra.Text = "Kiểm Tra";
            this.btKiemtra.UseVisualStyleBackColor = true;
            this.btKiemtra.Click += new System.EventHandler(this.btKiemtra_Click);
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(12, 348);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 10;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // lbcount
            // 
            this.lbcount.AutoSize = true;
            this.lbcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcount.ForeColor = System.Drawing.Color.Red;
            this.lbcount.Location = new System.Drawing.Point(181, 22);
            this.lbcount.Name = "lbcount";
            this.lbcount.Size = new System.Drawing.Size(0, 13);
            this.lbcount.TabIndex = 9;
            // 
            // btTimkiem
            // 
            this.btTimkiem.Location = new System.Drawing.Point(12, 313);
            this.btTimkiem.Name = "btTimkiem";
            this.btTimkiem.Size = new System.Drawing.Size(75, 23);
            this.btTimkiem.TabIndex = 8;
            this.btTimkiem.Text = "Tìm Kiếm";
            this.btTimkiem.UseVisualStyleBackColor = true;
            this.btTimkiem.Click += new System.EventHandler(this.btTimkiem_Click);
            // 
            // cbDay
            // 
            this.cbDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V"});
            this.cbDay.Location = new System.Drawing.Point(54, 131);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(121, 21);
            this.cbDay.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày:";
            // 
            // cbMonth
            // 
            this.cbMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C"});
            this.cbMonth.Location = new System.Drawing.Point(54, 95);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(121, 21);
            this.cbMonth.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tháng:";
            // 
            // cbYear
            // 
            this.cbYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbYear.Location = new System.Drawing.Point(54, 57);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(121, 21);
            this.cbYear.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm:";
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(243, 12);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(565, 463);
            this.dgView.TabIndex = 5;
            // 
            // F_KiemTraSoSerialTaoRa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgView);
            this.Name = "F_KiemTraSoSerialTaoRa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KIỂM TRA SỐ QR CODE ĐÃ TẠO RA";
            this.Load += new System.EventHandler(this.F_KiemTraSoSerialTaoRa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btall;
        private System.Windows.Forms.Button btKiemtra;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label lbcount;
        private System.Windows.Forms.Button btTimkiem;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgView;
    }
}