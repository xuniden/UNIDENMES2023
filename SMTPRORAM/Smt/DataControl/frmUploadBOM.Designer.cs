namespace SMTPRORAM.Smt.DataControl
{
    partial class frmUploadBOM
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btCancel = new System.Windows.Forms.Button();
			this.btUploadD = new System.Windows.Forms.Button();
			this.txtUpload = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btUpload = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(50, 11);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(394, 18);
			this.progressBar1.TabIndex = 11;
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(329, 82);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(115, 28);
			this.btCancel.TabIndex = 10;
			this.btCancel.Text = "Close";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btUploadD
			// 
			this.btUploadD.Location = new System.Drawing.Point(450, 42);
			this.btUploadD.Name = "btUploadD";
			this.btUploadD.Size = new System.Drawing.Size(104, 23);
			this.btUploadD.TabIndex = 9;
			this.btUploadD.Text = "Chọn Đường Dẫn";
			this.btUploadD.UseVisualStyleBackColor = true;
			this.btUploadD.Click += new System.EventHandler(this.btUploadD_Click);
			// 
			// txtUpload
			// 
			this.txtUpload.Location = new System.Drawing.Point(50, 45);
			this.txtUpload.Name = "txtUpload";
			this.txtUpload.Size = new System.Drawing.Size(394, 20);
			this.txtUpload.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Path";
			// 
			// btUpload
			// 
			this.btUpload.Location = new System.Drawing.Point(50, 82);
			this.btUpload.Name = "btUpload";
			this.btUpload.Size = new System.Drawing.Size(115, 28);
			this.btUpload.TabIndex = 6;
			this.btUpload.Text = "Upload Dữ Liệu";
			this.btUpload.UseVisualStyleBackColor = true;
			this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
			// 
			// frmUploadBOM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 123);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btUploadD);
			this.Controls.Add(this.txtUpload);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btUpload);
			this.MaximizeBox = false;
			this.Name = "frmUploadBOM";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Upload SMT BOM";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btUploadD;
        private System.Windows.Forms.TextBox txtUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btUpload;
    }
}