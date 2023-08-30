namespace SMTPRORAM.SysControl.Setup
{
    partial class frmFACTORY
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.iconbtnSave);
            this.panelTop.Controls.Add(this.iconbtnAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 41);
            this.panelTop.TabIndex = 0;
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.Location = new System.Drawing.Point(93, 12);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(87, 23);
            this.iconbtnSave.TabIndex = 1;
            this.iconbtnSave.Text = "Lưu thông tin";
            this.iconbtnSave.UseVisualStyleBackColor = true;
            this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
            // 
            // iconbtnAdd
            // 
            this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
            this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnAdd.Location = new System.Drawing.Point(12, 12);
            this.iconbtnAdd.Name = "iconbtnAdd";
            this.iconbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.iconbtnAdd.TabIndex = 0;
            this.iconbtnAdd.Text = "Thêm mới";
            this.iconbtnAdd.UseVisualStyleBackColor = true;
            this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgView);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 41);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(984, 520);
            this.panelContent.TabIndex = 2;
            // 
            // dgView
            // 
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(6, 6);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(966, 502);
            this.dgView.TabIndex = 0;
            this.dgView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellEndEdit);
            this.dgView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgView_CellFormatting);
            this.dgView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgView_CellValidating);
            this.dgView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgView_DataError);
            
            // 
            // frmFACTORY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Name = "frmFACTORY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THIẾT LẬP KÝ HIỆU ĐẦU TIÊN CHO QRCODE";
            this.Load += new System.EventHandler(this.frmFACTORY_Load);
            this.panelTop.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgView;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnSave;
    }
}