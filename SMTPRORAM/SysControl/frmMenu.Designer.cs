namespace SMTPRORAM.SysControl
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.splitContainerMenu = new System.Windows.Forms.SplitContainer();
            this.dgMenu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenu)).BeginInit();
            this.splitContainerMenu.Panel1.SuspendLayout();
            this.splitContainerMenu.Panel2.SuspendLayout();
            this.splitContainerMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(12, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 25);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật Menu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // splitContainerMenu
            // 
            this.splitContainerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMenu.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMenu.Name = "splitContainerMenu";
            this.splitContainerMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMenu.Panel1
            // 
            this.splitContainerMenu.Panel1.Controls.Add(this.btnUpdate);
            // 
            // splitContainerMenu.Panel2
            // 
            this.splitContainerMenu.Panel2.Controls.Add(this.dgMenu);
            this.splitContainerMenu.Size = new System.Drawing.Size(984, 561);
            this.splitContainerMenu.SplitterDistance = 59;
            this.splitContainerMenu.TabIndex = 1;
            // 
            // dgMenu
            // 
            this.dgMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMenu.Location = new System.Drawing.Point(0, 0);
            this.dgMenu.Name = "dgMenu";
            this.dgMenu.Size = new System.Drawing.Size(984, 498);
            this.dgMenu.TabIndex = 0;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainerMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẬP NHẬT MENU HỆ THỐNG";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.splitContainerMenu.Panel1.ResumeLayout(false);
            this.splitContainerMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenu)).EndInit();
            this.splitContainerMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.SplitContainer splitContainerMenu;
        private System.Windows.Forms.DataGridView dgMenu;
    }
}