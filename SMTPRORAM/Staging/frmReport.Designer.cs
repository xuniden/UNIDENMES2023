namespace SMTPRORAM.Staging
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.btInventory = new System.Windows.Forms.Button();
            this.btToExcel = new System.Windows.Forms.Button();
            this.btOutputAll = new System.Windows.Forms.Button();
            this.btInputAll = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPeno = new System.Windows.Forms.TextBox();
            this.txtPcbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtToLine = new System.Windows.Forms.TextBox();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.inventorytotal = new System.Windows.Forms.Label();
            this.btTotalInventory = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btInventory
            // 
            this.btInventory.Location = new System.Drawing.Point(3, 3);
            this.btInventory.Name = "btInventory";
            this.btInventory.Size = new System.Drawing.Size(136, 20);
            this.btInventory.TabIndex = 0;
            this.btInventory.Text = "STAGING INVENTORY";
            this.btInventory.UseVisualStyleBackColor = true;
            this.btInventory.Click += new System.EventHandler(this.btInventory_Click);
            // 
            // btToExcel
            // 
            this.btToExcel.Location = new System.Drawing.Point(713, 3);
            this.btToExcel.Name = "btToExcel";
            this.btToExcel.Size = new System.Drawing.Size(75, 20);
            this.btToExcel.TabIndex = 1;
            this.btToExcel.Text = "TO CSV";
            this.btToExcel.UseVisualStyleBackColor = true;
            this.btToExcel.Click += new System.EventHandler(this.btToExcel_Click);
            // 
            // btOutputAll
            // 
            this.btOutputAll.Location = new System.Drawing.Point(429, 3);
            this.btOutputAll.Name = "btOutputAll";
            this.btOutputAll.Size = new System.Drawing.Size(123, 20);
            this.btOutputAll.TabIndex = 0;
            this.btOutputAll.Text = "TÌM KIẾM OUTPUT";
            this.btOutputAll.UseVisualStyleBackColor = true;
            this.btOutputAll.Click += new System.EventHandler(this.btOutputAll_Click);
            // 
            // btInputAll
            // 
            this.btInputAll.Location = new System.Drawing.Point(287, 3);
            this.btInputAll.Name = "btInputAll";
            this.btInputAll.Size = new System.Drawing.Size(119, 20);
            this.btInputAll.TabIndex = 0;
            this.btInputAll.Text = "TÌM KIẾM INPUT";
            this.btInputAll.UseVisualStyleBackColor = true;
            this.btInputAll.Click += new System.EventHandler(this.btInputAll_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocation.Location = new System.Drawing.Point(287, 29);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(119, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // txtLot
            // 
            this.txtLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLot.Location = new System.Drawing.Point(287, 55);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(119, 20);
            this.txtLot.TabIndex = 4;
            // 
            // txtModel
            // 
            this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModel.Location = new System.Drawing.Point(287, 81);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(119, 20);
            this.txtModel.TabIndex = 5;
            // 
            // txtPeno
            // 
            this.txtPeno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeno.Location = new System.Drawing.Point(287, 107);
            this.txtPeno.Name = "txtPeno";
            this.txtPeno.Size = new System.Drawing.Size(119, 20);
            this.txtPeno.TabIndex = 6;
            // 
            // txtPcbname
            // 
            this.txtPcbname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPcbname.Location = new System.Drawing.Point(287, 133);
            this.txtPcbname.Name = "txtPcbname";
            this.txtPcbname.Size = new System.Drawing.Size(119, 20);
            this.txtPcbname.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "LOT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "MODEL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "PE NO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "PCB NAME:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "DATE( mm/dd/yyyy):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOCATION:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "TO LINE:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "CHANGE TARGET LOT";
            // 
            // txtToLine
            // 
            this.txtToLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToLine.Location = new System.Drawing.Point(571, 29);
            this.txtToLine.Name = "txtToLine";
            this.txtToLine.Size = new System.Drawing.Size(119, 20);
            this.txtToLine.TabIndex = 9;
            // 
            // txtChange
            // 
            this.txtChange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChange.Location = new System.Drawing.Point(571, 55);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(119, 20);
            this.txtChange.TabIndex = 10;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(571, 81);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(119, 20);
            this.maskedTextBox1.TabIndex = 11;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(287, 159);
            this.maskedTextBox2.Mask = "00/00/0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(119, 20);
            this.maskedTextBox2.TabIndex = 8;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(429, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "DATE( mm/dd/yyyy):";
            // 
            // inventorytotal
            // 
            this.inventorytotal.AutoSize = true;
            this.inventorytotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventorytotal.Location = new System.Drawing.Point(3, 52);
            this.inventorytotal.Name = "inventorytotal";
            this.inventorytotal.Size = new System.Drawing.Size(58, 16);
            this.inventorytotal.TabIndex = 13;
            this.inventorytotal.Text = "label11";
            // 
            // btTotalInventory
            // 
            this.btTotalInventory.Location = new System.Drawing.Point(3, 81);
            this.btTotalInventory.Name = "btTotalInventory";
            this.btTotalInventory.Size = new System.Drawing.Size(136, 20);
            this.btTotalInventory.TabIndex = 14;
            this.btTotalInventory.Text = "Update Inventory";
            this.btTotalInventory.UseVisualStyleBackColor = true;
            this.btTotalInventory.Click += new System.EventHandler(this.btTotalInventory_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(12, 204);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(952, 382);
            this.dgView.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.btInventory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btToExcel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btOutputAll, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btInputAll, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLocation, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLot, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtModel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPeno, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPcbname, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtToLine, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtChange, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox2, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.inventorytotal, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btTotalInventory, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 186);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 598);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.Text = "Báo cáo Staging";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btInventory;
        private System.Windows.Forms.Button btToExcel;
        private System.Windows.Forms.Button btOutputAll;
        private System.Windows.Forms.Button btInputAll;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPeno;
        private System.Windows.Forms.TextBox txtPcbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtToLine;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label inventorytotal;
        private System.Windows.Forms.Button btTotalInventory;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}