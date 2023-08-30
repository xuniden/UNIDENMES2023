namespace SMTPRORAM.SysControl
{
    partial class frmUser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cbDept = new System.Windows.Forms.ComboBox();
			this.chkAccessStatus = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUserId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
			this.iconbtnSelectFile = new FontAwesome.Sharp.IconButton();
			this.icobtnSearch = new FontAwesome.Sharp.IconButton();
			this.dgUser = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.StripMenuItemUserPermission = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(6, 346);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(229, 13);
			this.progressBar.TabIndex = 19;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnEdit, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnDelete, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 242);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 60);
			this.tableLayoutPanel1.TabIndex = 18;
			// 
			// iconbtnAdd
			// 
			this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
			this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnAdd.IconSize = 16;
			this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
			this.iconbtnAdd.Name = "iconbtnAdd";
			this.iconbtnAdd.Size = new System.Drawing.Size(72, 23);
			this.iconbtnAdd.TabIndex = 13;
			this.iconbtnAdd.Text = "Thêm";
			this.iconbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnAdd.UseVisualStyleBackColor = true;
			this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
			// 
			// iconbtnEdit
			// 
			this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
			this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
			this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnEdit.IconSize = 16;
			this.iconbtnEdit.Location = new System.Drawing.Point(81, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(72, 23);
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
			this.iconbtnDelete.Location = new System.Drawing.Point(159, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(73, 23);
			this.iconbtnDelete.TabIndex = 15;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.IconSize = 16;
			this.iconbtnCancel.Location = new System.Drawing.Point(81, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(71, 23);
			this.iconbtnCancel.TabIndex = 17;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 16;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(72, 23);
			this.iconbtnSave.TabIndex = 16;
			this.iconbtnSave.Text = "Ghi lại";
			this.iconbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(6, 366);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(149, 20);
			this.txtFile.TabIndex = 15;
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(6, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(149, 20);
			this.txtSearch.TabIndex = 13;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// cbDept
			// 
			this.cbDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDept.FormattingEnabled = true;
			this.cbDept.Location = new System.Drawing.Point(59, 156);
			this.cbDept.Name = "cbDept";
			this.cbDept.Size = new System.Drawing.Size(176, 21);
			this.cbDept.TabIndex = 7;
			// 
			// chkAccessStatus
			// 
			this.chkAccessStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkAccessStatus.AutoSize = true;
			this.chkAccessStatus.Location = new System.Drawing.Point(59, 194);
			this.chkAccessStatus.Name = "chkAccessStatus";
			this.chkAccessStatus.Size = new System.Drawing.Size(107, 17);
			this.chkAccessStatus.TabIndex = 8;
			this.chkAccessStatus.Text = "Khóa người dùng";
			this.chkAccessStatus.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Bộ phận:";
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPassword.Location = new System.Drawing.Point(59, 121);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(176, 20);
			this.txtPassword.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mật khẩu:";
			// 
			// txtFullName
			// 
			this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFullName.Location = new System.Drawing.Point(59, 86);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(176, 20);
			this.txtFullName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Họ và tên";
			// 
			// txtUserId
			// 
			this.txtUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUserId.Location = new System.Drawing.Point(59, 49);
			this.txtUserId.Name = "txtUserId";
			this.txtUserId.Size = new System.Drawing.Size(176, 20);
			this.txtUserId.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Id:";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.progressBar);
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Panel1.Controls.Add(this.iconbtnUpload);
			this.splitContainer1.Panel1.Controls.Add(this.iconbtnSelectFile);
			this.splitContainer1.Panel1.Controls.Add(this.txtFile);
			this.splitContainer1.Panel1.Controls.Add(this.icobtnSearch);
			this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
			this.splitContainer1.Panel1.Controls.Add(this.cbDept);
			this.splitContainer1.Panel1.Controls.Add(this.chkAccessStatus);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.txtPassword);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.txtFullName);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.txtUserId);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgUser);
			this.splitContainer1.Size = new System.Drawing.Size(984, 561);
			this.splitContainer1.SplitterDistance = 241;
			this.splitContainer1.TabIndex = 1;
			// 
			// iconbtnUpload
			// 
			this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
			this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
			this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnUpload.IconSize = 16;
			this.iconbtnUpload.Location = new System.Drawing.Point(6, 394);
			this.iconbtnUpload.Name = "iconbtnUpload";
			this.iconbtnUpload.Size = new System.Drawing.Size(75, 23);
			this.iconbtnUpload.TabIndex = 17;
			this.iconbtnUpload.Text = "Upload";
			this.iconbtnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnUpload.UseVisualStyleBackColor = true;
			this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
			// 
			// iconbtnSelectFile
			// 
			this.iconbtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSelectFile.IconChar = FontAwesome.Sharp.IconChar.Child;
			this.iconbtnSelectFile.IconColor = System.Drawing.Color.Black;
			this.iconbtnSelectFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSelectFile.IconSize = 16;
			this.iconbtnSelectFile.Location = new System.Drawing.Point(160, 365);
			this.iconbtnSelectFile.Name = "iconbtnSelectFile";
			this.iconbtnSelectFile.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSelectFile.TabIndex = 16;
			this.iconbtnSelectFile.Text = "Chọn file";
			this.iconbtnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSelectFile.UseVisualStyleBackColor = true;
			this.iconbtnSelectFile.Click += new System.EventHandler(this.iconbtnSelectFile_Click);
			// 
			// icobtnSearch
			// 
			this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.icobtnSearch.IconColor = System.Drawing.Color.Black;
			this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.icobtnSearch.IconSize = 16;
			this.icobtnSearch.Location = new System.Drawing.Point(160, 10);
			this.icobtnSearch.Name = "icobtnSearch";
			this.icobtnSearch.Size = new System.Drawing.Size(75, 23);
			this.icobtnSearch.TabIndex = 14;
			this.icobtnSearch.Text = "Tìm kiếm";
			this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.icobtnSearch.UseVisualStyleBackColor = true;
			this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
			// 
			// dgUser
			// 
			this.dgUser.AllowUserToAddRows = false;
			this.dgUser.AllowUserToDeleteRows = false;
			this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgUser.ContextMenuStrip = this.contextMenuStrip1;
			this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgUser.Location = new System.Drawing.Point(0, 0);
			this.dgUser.Name = "dgUser";
			this.dgUser.ReadOnly = true;
			this.dgUser.Size = new System.Drawing.Size(739, 561);
			this.dgUser.TabIndex = 0;
			this.dgUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUser_CellDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItemUserPermission});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(186, 26);
			// 
			// StripMenuItemUserPermission
			// 
			this.StripMenuItemUserPermission.Name = "StripMenuItemUserPermission";
			this.StripMenuItemUserPermission.Size = new System.Drawing.Size(185, 22);
			this.StripMenuItemUserPermission.Text = "Phân quyền cho user";
			this.StripMenuItemUserPermission.Click += new System.EventHandler(this.StripMenuItemUserPermission_Click);
			// 
			// frmUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.splitContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmUser";
			this.Text = "Quản lý người dùng";
			this.Load += new System.EventHandler(this.frmUser_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private FontAwesome.Sharp.IconButton iconbtnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.CheckBox chkAccessStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemUserPermission;
    }
}