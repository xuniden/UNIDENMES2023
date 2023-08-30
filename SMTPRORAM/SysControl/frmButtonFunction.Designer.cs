namespace SMTPRORAM.SysControl
{
    partial class frmButtonFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmButtonFunction));
            this.dgButton = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
            this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
            this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtButtonDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtButtonId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgButton)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgButton
            // 
            this.dgButton.AllowUserToAddRows = false;
            this.dgButton.AllowUserToDeleteRows = false;
            this.dgButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgButton.Location = new System.Drawing.Point(0, 0);
            this.dgButton.Name = "dgButton";
            this.dgButton.ReadOnly = true;
            this.dgButton.Size = new System.Drawing.Size(740, 561);
            this.dgButton.TabIndex = 0;
            this.dgButton.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgButton_CellDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.19658F));
            this.tableLayoutPanel1.Controls.Add(this.iconbtnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 135);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 60);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // iconbtnEdit
            // 
            this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
            this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnEdit.IconSize = 16;
            this.iconbtnEdit.Location = new System.Drawing.Point(80, 3);
            this.iconbtnEdit.Name = "iconbtnEdit";
            this.iconbtnEdit.Size = new System.Drawing.Size(62, 23);
            this.iconbtnEdit.TabIndex = 14;
            this.iconbtnEdit.Text = "Sửa";
            this.iconbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnEdit.UseVisualStyleBackColor = true;
            this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
            // 
            // iconbtnDelete
            // 
            this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
            this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDelete.IconSize = 16;
            this.iconbtnDelete.Location = new System.Drawing.Point(163, 3);
            this.iconbtnDelete.Name = "iconbtnDelete";
            this.iconbtnDelete.Size = new System.Drawing.Size(62, 23);
            this.iconbtnDelete.TabIndex = 15;
            this.iconbtnDelete.Text = "Xóa";
            this.iconbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnDelete.UseVisualStyleBackColor = true;
            this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.IconSize = 18;
            this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(62, 23);
            this.iconbtnSave.TabIndex = 16;
            this.iconbtnSave.Text = "Ghi lại";
            this.iconbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSave.UseVisualStyleBackColor = true;
            this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
            // 
            // iconbtnCancel
            // 
            this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
            this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
            this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnCancel.IconSize = 18;
            this.iconbtnCancel.Location = new System.Drawing.Point(80, 33);
            this.iconbtnCancel.Name = "iconbtnCancel";
            this.iconbtnCancel.Size = new System.Drawing.Size(77, 23);
            this.iconbtnCancel.TabIndex = 17;
            this.iconbtnCancel.Text = "Hủy bỏ";
            this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnCancel.UseVisualStyleBackColor = true;
            this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
            // 
            // iconbtnAdd
            // 
            this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
            this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnAdd.IconSize = 18;
            this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
            this.iconbtnAdd.Name = "iconbtnAdd";
            this.iconbtnAdd.Size = new System.Drawing.Size(62, 23);
            this.iconbtnAdd.TabIndex = 13;
            this.iconbtnAdd.Text = "Thêm";
            this.iconbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnAdd.UseVisualStyleBackColor = true;
            this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtButtonDesc);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtButtonId);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgButton);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 2;
            // 
            // iconbtnSearch
            // 
            this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
            this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSearch.IconSize = 16;
            this.iconbtnSearch.Location = new System.Drawing.Point(159, 10);
            this.iconbtnSearch.Name = "iconbtnSearch";
            this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
            this.iconbtnSearch.TabIndex = 14;
            this.iconbtnSearch.Text = "Tìm kiếm";
            this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSearch.UseVisualStyleBackColor = true;
            this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(6, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 20);
            this.txtSearch.TabIndex = 13;
            // 
            // txtButtonDesc
            // 
            this.txtButtonDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtButtonDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtButtonDesc.Location = new System.Drawing.Point(74, 86);
            this.txtButtonDesc.Name = "txtButtonDesc";
            this.txtButtonDesc.Size = new System.Drawing.Size(160, 20);
            this.txtButtonDesc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Button Desc";
            // 
            // txtButtonId
            // 
            this.txtButtonId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtButtonId.Location = new System.Drawing.Point(74, 49);
            this.txtButtonId.Name = "txtButtonId";
            this.txtButtonId.Size = new System.Drawing.Size(160, 20);
            this.txtButtonId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Button Name";
            // 
            // frmButtonFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmButtonFunction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quyền các button trên form";
            this.Load += new System.EventHandler(this.frmButtonFunction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgButton)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconButton iconbtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtButtonDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtButtonId;
        private System.Windows.Forms.Label label1;
    }
}