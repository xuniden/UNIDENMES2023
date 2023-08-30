namespace SMTPRORAM.SysControl
{
    partial class frmLoginSectionManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginSectionManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
            this.iconbtnKillAll = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.iconbtnKill = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.killSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconbtnSearch);
            this.panel1.Controls.Add(this.iconbtnKillAll);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.iconbtnKill);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 41);
            this.panel1.TabIndex = 0;
            // 
            // iconbtnSearch
            // 
            this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
            this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSearch.Location = new System.Drawing.Point(279, 10);
            this.iconbtnSearch.Name = "iconbtnSearch";
            this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
            this.iconbtnSearch.TabIndex = 3;
            this.iconbtnSearch.Text = "Search";
            this.iconbtnSearch.UseVisualStyleBackColor = true;
            this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
            // 
            // iconbtnKillAll
            // 
            this.iconbtnKillAll.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnKillAll.IconColor = System.Drawing.Color.Black;
            this.iconbtnKillAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnKillAll.Location = new System.Drawing.Point(439, 9);
            this.iconbtnKillAll.Name = "iconbtnKillAll";
            this.iconbtnKillAll.Size = new System.Drawing.Size(122, 23);
            this.iconbtnKillAll.TabIndex = 2;
            this.iconbtnKillAll.Text = "Kill All Section";
            this.iconbtnKillAll.UseVisualStyleBackColor = true;
            this.iconbtnKillAll.Click += new System.EventHandler(this.iconbtnKillAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(261, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // iconbtnKill
            // 
            this.iconbtnKill.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnKill.IconColor = System.Drawing.Color.Black;
            this.iconbtnKill.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnKill.Location = new System.Drawing.Point(358, 10);
            this.iconbtnKill.Name = "iconbtnKill";
            this.iconbtnKill.Size = new System.Drawing.Size(75, 23);
            this.iconbtnKill.TabIndex = 0;
            this.iconbtnKill.Text = "Kill Section";
            this.iconbtnKill.UseVisualStyleBackColor = true;
            this.iconbtnKill.Click += new System.EventHandler(this.iconbtnKill_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 520);
            this.panel2.TabIndex = 1;
            // 
            // dgView
            // 
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgView.Location = new System.Drawing.Point(3, 0);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(978, 517);
            this.dgView.TabIndex = 0;
            this.dgView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killSectionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 26);
            // 
            // killSectionToolStripMenuItem
            // 
            this.killSectionToolStripMenuItem.Name = "killSectionToolStripMenuItem";
            this.killSectionToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.killSectionToolStripMenuItem.Text = "Kill Section";
            this.killSectionToolStripMenuItem.Click += new System.EventHandler(this.killSectionToolStripMenuItem_Click);
            // 
            // frmLoginSectionManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoginSectionManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý section đăng nhập của người dùng";
            this.Load += new System.EventHandler(this.frmLoginSectionManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private FontAwesome.Sharp.IconButton iconbtnKill;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem killSectionToolStripMenuItem;
        private FontAwesome.Sharp.IconButton iconbtnSearch;
        private FontAwesome.Sharp.IconButton iconbtnKillAll;
        private System.Windows.Forms.TextBox txtSearch;
    }
}