namespace SMTPRORAM.Smt.OutsourceBom
{
    partial class frmOUTSOURCE_ET_BOM
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblProcess = new System.Windows.Forms.Label();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.iconbtnBrowse = new FontAwesome.Sharp.IconButton();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.iconbtnExportCSV = new FontAwesome.Sharp.IconButton();
            this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.sMT_PROGRAMDataSet = new SMTPRORAM.SMT_PROGRAMDataSet();
            this.oUTSOURCEETBOMBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oUTSOURCE_ET_BOMTableAdapter = new SMTPRORAM.SMT_PROGRAMDataSetTableAdapters.OUTSOURCE_ET_BOMTableAdapter();
            this.iconbtnView = new FontAwesome.Sharp.IconButton();
            this.oUTSOURCEETBOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMT_PROGRAMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oUTSOURCEETBOMBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oUTSOURCEETBOMBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnView);
            this.splitContainer1.Panel1.Controls.Add(this.lblProcess);
            this.splitContainer1.Panel1.Controls.Add(this.cbSheet);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.txtFilename);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnExportCSV);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnDelete);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.ForeColor = System.Drawing.Color.Red;
            this.lblProcess.Location = new System.Drawing.Point(12, 86);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(50, 16);
            this.lblProcess.TabIndex = 82;
            this.lblProcess.Text = "label1";
            // 
            // cbSheet
            // 
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(12, 48);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(362, 21);
            this.cbSheet.TabIndex = 81;
            this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
            // 
            // iconbtnBrowse
            // 
            this.iconbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnBrowse.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnBrowse.IconColor = System.Drawing.Color.Black;
            this.iconbtnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnBrowse.IconSize = 16;
            this.iconbtnBrowse.Location = new System.Drawing.Point(300, 10);
            this.iconbtnBrowse.Name = "iconbtnBrowse";
            this.iconbtnBrowse.Size = new System.Drawing.Size(74, 22);
            this.iconbtnBrowse.TabIndex = 79;
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
            this.txtFilename.Size = new System.Drawing.Size(282, 20);
            this.txtFilename.TabIndex = 78;
            // 
            // iconbtnExportCSV
            // 
            this.iconbtnExportCSV.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnExportCSV.IconColor = System.Drawing.Color.Black;
            this.iconbtnExportCSV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnExportCSV.Location = new System.Drawing.Point(12, 196);
            this.iconbtnExportCSV.Name = "iconbtnExportCSV";
            this.iconbtnExportCSV.Size = new System.Drawing.Size(117, 23);
            this.iconbtnExportCSV.TabIndex = 77;
            this.iconbtnExportCSV.Text = "Export UV Lot to CSV";
            this.iconbtnExportCSV.UseVisualStyleBackColor = true;
            this.iconbtnExportCSV.Click += new System.EventHandler(this.iconbtnExportCSV_Click);
            // 
            // iconbtnDelete
            // 
            this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
            this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDelete.IconSize = 16;
            this.iconbtnDelete.Location = new System.Drawing.Point(12, 123);
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
            // sMT_PROGRAMDataSet
            // 
            this.sMT_PROGRAMDataSet.DataSetName = "SMT_PROGRAMDataSet";
            this.sMT_PROGRAMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oUTSOURCEETBOMBindingSource1
            // 
            this.oUTSOURCEETBOMBindingSource1.DataMember = "OUTSOURCE_ET_BOM";
            this.oUTSOURCEETBOMBindingSource1.DataSource = this.sMT_PROGRAMDataSet;
            // 
            // oUTSOURCE_ET_BOMTableAdapter
            // 
            this.oUTSOURCE_ET_BOMTableAdapter.ClearBeforeFill = true;
            // 
            // iconbtnView
            // 
            this.iconbtnView.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnView.IconColor = System.Drawing.Color.Black;
            this.iconbtnView.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnView.Location = new System.Drawing.Point(12, 152);
            this.iconbtnView.Name = "iconbtnView";
            this.iconbtnView.Size = new System.Drawing.Size(137, 23);
            this.iconbtnView.TabIndex = 83;
            this.iconbtnView.Text = "View UV Lot vs ET Order";
            this.iconbtnView.UseVisualStyleBackColor = true;
            this.iconbtnView.Click += new System.EventHandler(this.iconbtnView_Click);
            // 
            // oUTSOURCEETBOMBindingSource
            // 
            this.oUTSOURCEETBOMBindingSource.DataSource = typeof(UnidenDTO.OUTSOURCE_ET_BOM);
            // 
            // frmOUTSOURCE_ET_BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmOUTSOURCE_ET_BOM";
            this.Text = "Upload BOM ET";
            this.Load += new System.EventHandler(this.frmOUTSOURCE_ET_BOM_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMT_PROGRAMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oUTSOURCEETBOMBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oUTSOURCEETBOMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgView;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnExportCSV;
        private System.Windows.Forms.ComboBox cbSheet;
        private FontAwesome.Sharp.IconButton iconbtnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.BindingSource oUTSOURCEETBOMBindingSource;
        private SMT_PROGRAMDataSet sMT_PROGRAMDataSet;
        private System.Windows.Forms.BindingSource oUTSOURCEETBOMBindingSource1;
        private SMT_PROGRAMDataSetTableAdapters.OUTSOURCE_ET_BOMTableAdapter oUTSOURCE_ET_BOMTableAdapter;
        private System.Windows.Forms.Label lblProcess;
        private FontAwesome.Sharp.IconButton iconbtnView;
    }
}