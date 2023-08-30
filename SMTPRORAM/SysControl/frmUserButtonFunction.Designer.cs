namespace SMTPRORAM.SysControl
{
    partial class frmUserButtonFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserButtonFunction));
            this.listViewButtonFunc = new System.Windows.Forms.ListView();
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dgButtonFunction = new System.Windows.Forms.DataGridView();
            this.contextMenuStripListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgButtonFunction)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewButtonFunc
            // 
            this.listViewButtonFunc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewButtonFunc.ContextMenuStrip = this.contextMenuStripListView;
            this.listViewButtonFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewButtonFunc.GridLines = true;
            this.listViewButtonFunc.HideSelection = false;
            this.listViewButtonFunc.Location = new System.Drawing.Point(0, 0);
            this.listViewButtonFunc.Name = "listViewButtonFunc";
            this.listViewButtonFunc.Size = new System.Drawing.Size(323, 561);
            this.listViewButtonFunc.TabIndex = 0;
            this.listViewButtonFunc.UseCompatibleStateImageBehavior = false;
            this.listViewButtonFunc.View = System.Windows.Forms.View.Details;
            this.listViewButtonFunc.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewButtonFunc_ItemChecked);
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(141, 26);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.SaveToolStripMenuItem.Text = "Lưu thay đổi";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgUser);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgUser
            // 
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AllowUserToDeleteRows = false;
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.Location = new System.Drawing.Point(0, 51);
            this.dgUser.Name = "dgUser";
            this.dgUser.ReadOnly = true;
            this.dgUser.Size = new System.Drawing.Size(242, 510);
            this.dgUser.TabIndex = 1;
            this.dgUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUser_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconbtnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 51);
            this.panel1.TabIndex = 2;
            // 
            // iconbtnSearch
            // 
            this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
            this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSearch.IconSize = 16;
            this.iconbtnSearch.Location = new System.Drawing.Point(163, 11);
            this.iconbtnSearch.Name = "iconbtnSearch";
            this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
            this.iconbtnSearch.TabIndex = 1;
            this.iconbtnSearch.Text = "Tìm kiếm";
            this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSearch.UseVisualStyleBackColor = true;
            this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(3, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chkAll);
            this.splitContainer2.Panel1.Controls.Add(this.listViewButtonFunc);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgButtonFunction);
            this.splitContainer2.Size = new System.Drawing.Size(738, 561);
            this.splitContainer2.SplitterDistance = 323;
            this.splitContainer2.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(5, 6);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 1;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dgButtonFunction
            // 
            this.dgButtonFunction.AllowUserToAddRows = false;
            this.dgButtonFunction.AllowUserToDeleteRows = false;
            this.dgButtonFunction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgButtonFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgButtonFunction.Location = new System.Drawing.Point(0, 0);
            this.dgButtonFunction.Name = "dgButtonFunction";
            this.dgButtonFunction.ReadOnly = true;
            this.dgButtonFunction.Size = new System.Drawing.Size(411, 561);
            this.dgButtonFunction.TabIndex = 0;
            // 
            // frmUserButtonFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUserButtonFunction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền các button trên form";
            this.Load += new System.EventHandler(this.frmUserButtonFunction_Load);
            this.contextMenuStripListView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgButtonFunction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewButtonFunc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconbtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridView dgButtonFunction;
    }
}