namespace SMTPRORAM.Smt.Input
{
    partial class frmFViewIQCCheckerResult
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
			this.lblTong = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblThieu = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btDownload = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLine = new System.Windows.Forms.TextBox();
			this.txtProgram = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblTong);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lblThieu);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.btDownload);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtLine);
			this.panel1.Controls.Add(this.txtProgram);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 72);
			this.panel1.TabIndex = 0;
			// 
			// lblTong
			// 
			this.lblTong.AutoSize = true;
			this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTong.ForeColor = System.Drawing.Color.Blue;
			this.lblTong.Location = new System.Drawing.Point(655, 46);
			this.lblTong.Name = "lblTong";
			this.lblTong.Size = new System.Drawing.Size(49, 13);
			this.lblTong.TabIndex = 20;
			this.lblTong.Text = "lblTong";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(635, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "/";
			// 
			// lblThieu
			// 
			this.lblThieu.AutoSize = true;
			this.lblThieu.ForeColor = System.Drawing.Color.Red;
			this.lblThieu.Location = new System.Drawing.Point(580, 46);
			this.lblThieu.Name = "lblThieu";
			this.lblThieu.Size = new System.Drawing.Size(44, 13);
			this.lblThieu.TabIndex = 18;
			this.lblThieu.Text = "lblThieu";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(537, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Thiếu:";
			// 
			// btDownload
			// 
			this.btDownload.Location = new System.Drawing.Point(779, 9);
			this.btDownload.Name = "btDownload";
			this.btDownload.Size = new System.Drawing.Size(75, 23);
			this.btDownload.TabIndex = 16;
			this.btDownload.Text = "Download";
			this.btDownload.UseVisualStyleBackColor = true;
			this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(658, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "Tìm Kiếm";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(487, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Line:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Program";
			// 
			// txtLine
			// 
			this.txtLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLine.Location = new System.Drawing.Point(540, 10);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(100, 20);
			this.txtLine.TabIndex = 12;
			this.txtLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLine_KeyDown);
			// 
			// txtProgram
			// 
			this.txtProgram.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProgram.Location = new System.Drawing.Point(99, 10);
			this.txtProgram.Name = "txtProgram";
			this.txtProgram.Size = new System.Drawing.Size(341, 20);
			this.txtProgram.TabIndex = 11;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 72);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
			this.splitContainer1.Size = new System.Drawing.Size(984, 489);
			this.splitContainer1.SplitterDistance = 327;
			this.splitContainer1.TabIndex = 1;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 6);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(303, 471);
			this.dataGridView1.TabIndex = 5;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(15, 6);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.Size = new System.Drawing.Size(626, 471);
			this.dataGridView2.TabIndex = 7;
			// 
			// frmFViewIQCCheckerResult
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Name = "frmFViewIQCCheckerResult";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kiểm tra linh kiện thiếu";
			this.Load += new System.EventHandler(this.frmFViewIQCCheckerResult_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}