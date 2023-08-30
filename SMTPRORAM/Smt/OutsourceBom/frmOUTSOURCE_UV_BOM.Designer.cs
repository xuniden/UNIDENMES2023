namespace SMTPRORAM.Smt.OutsourceBom
{
    partial class frmOUTSOURCE_UV_BOM
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.lblProcess = new System.Windows.Forms.Label();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.iconbtnBrowse = new FontAwesome.Sharp.IconButton();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.iconbtnDiffBOM = new FontAwesome.Sharp.IconButton();
            this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
            this.dgView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.iconButton1);
            this.splitContainer1.Panel1.Controls.Add(this.lblProcess);
            this.splitContainer1.Panel1.Controls.Add(this.cbSheet);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.txtFilename);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnDiffBOM);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnDelete);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 1;
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(15, 158);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(117, 23);
            this.iconButton1.TabIndex = 86;
            this.iconButton1.Text = "View Diff";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.ForeColor = System.Drawing.Color.Red;
            this.lblProcess.Location = new System.Drawing.Point(12, 91);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(50, 16);
            this.lblProcess.TabIndex = 85;
            this.lblProcess.Text = "label1";
            // 
            // cbSheet
            // 
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(12, 48);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(357, 21);
            this.cbSheet.TabIndex = 84;
            this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
            // 
            // iconbtnBrowse
            // 
            this.iconbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnBrowse.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnBrowse.IconColor = System.Drawing.Color.Black;
            this.iconbtnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnBrowse.IconSize = 16;
            this.iconbtnBrowse.Location = new System.Drawing.Point(295, 11);
            this.iconbtnBrowse.Name = "iconbtnBrowse";
            this.iconbtnBrowse.Size = new System.Drawing.Size(74, 22);
            this.iconbtnBrowse.TabIndex = 83;
            this.iconbtnBrowse.Text = "Chọn file";
            this.iconbtnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnBrowse.UseVisualStyleBackColor = true;
            this.iconbtnBrowse.Click += new System.EventHandler(this.iconbtnBrowse_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(12, 12);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(277, 20);
            this.txtFilename.TabIndex = 82;
            // 
            // iconbtnDiffBOM
            // 
            this.iconbtnDiffBOM.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnDiffBOM.IconColor = System.Drawing.Color.Black;
            this.iconbtnDiffBOM.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDiffBOM.Location = new System.Drawing.Point(15, 197);
            this.iconbtnDiffBOM.Name = "iconbtnDiffBOM";
            this.iconbtnDiffBOM.Size = new System.Drawing.Size(117, 23);
            this.iconbtnDiffBOM.TabIndex = 77;
            this.iconbtnDiffBOM.Text = "Export CSV Diff BOM";
            this.iconbtnDiffBOM.UseVisualStyleBackColor = true;
            this.iconbtnDiffBOM.Click += new System.EventHandler(this.iconbtnDiffBOM_Click);
            // 
            // iconbtnDelete
            // 
            this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
            this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDelete.IconSize = 16;
            this.iconbtnDelete.Location = new System.Drawing.Point(15, 127);
            this.iconbtnDelete.Name = "iconbtnDelete";
            this.iconbtnDelete.Size = new System.Drawing.Size(117, 23);
            this.iconbtnDelete.TabIndex = 76;
            this.iconbtnDelete.Text = "Delete All";
            this.iconbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnDelete.UseVisualStyleBackColor = true;
            this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(3, 3);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(588, 555);
            this.dgView.TabIndex = 0;
            // 
            // frmOUTSOURCE_UV_BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmOUTSOURCE_UV_BOM";
            this.Text = "Upload UV BOM";
            this.Load += new System.EventHandler(this.frmOUTSOURCE_UV_BOM_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private System.Windows.Forms.DataGridView dgView;
        private FontAwesome.Sharp.IconButton iconbtnDiffBOM;
        private System.Windows.Forms.ComboBox cbSheet;
        private FontAwesome.Sharp.IconButton iconbtnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblProcess;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}