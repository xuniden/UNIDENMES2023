namespace SMTPRORAM.Smt.Input
{
    partial class frmFrmDeleteCheckCutLotData
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
			this.lblkiemtra = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLine = new System.Windows.Forms.TextBox();
			this.txtProgram = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblkiemtra);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtLine);
			this.panel1.Controls.Add(this.txtProgram);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 64);
			this.panel1.TabIndex = 0;
			// 
			// lblkiemtra
			// 
			this.lblkiemtra.AutoSize = true;
			this.lblkiemtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblkiemtra.ForeColor = System.Drawing.Color.Red;
			this.lblkiemtra.Location = new System.Drawing.Point(158, 40);
			this.lblkiemtra.Name = "lblkiemtra";
			this.lblkiemtra.Size = new System.Drawing.Size(41, 13);
			this.lblkiemtra.TabIndex = 22;
			this.lblkiemtra.Text = "label4";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Tổng số feeder đã kiểm tra:";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(805, 9);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 20;
			this.btnDelete.Text = "Xóa dữ liệu";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(681, 9);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(91, 23);
			this.btnSearch.TabIndex = 18;
			this.btnSearch.Text = "Tìm Kiếm";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(481, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Line Mới:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Program";
			// 
			// txtLine
			// 
			this.txtLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLine.Location = new System.Drawing.Point(551, 10);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(100, 20);
			this.txtLine.TabIndex = 16;
			// 
			// txtProgram
			// 
			this.txtProgram.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProgram.Location = new System.Drawing.Point(88, 10);
			this.txtProgram.Name = "txtProgram";
			this.txtProgram.Size = new System.Drawing.Size(326, 20);
			this.txtProgram.TabIndex = 15;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 64);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 497);
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
			this.dgView.Location = new System.Drawing.Point(11, 6);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(961, 479);
			this.dgView.TabIndex = 13;
			// 
			// frmFrmDeleteCheckCutLotData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmFrmDeleteCheckCutLotData";
			this.Text = "Xóa dữ liệu sau khi kiểm tra lại cắt lot";
			this.Load += new System.EventHandler(this.frmFrmDeleteCheckCutLotData_Load);
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
        private System.Windows.Forms.Label lblkiemtra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.TextBox txtProgram;
    }
}