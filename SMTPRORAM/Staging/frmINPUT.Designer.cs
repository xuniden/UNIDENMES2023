namespace SMTPRORAM.Staging
{
    partial class frmINPUT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINPUT));
            this.dgInput = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSmtLine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLot = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPeNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbProgram = new System.Windows.Forms.ComboBox();
            this.txtInputQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtHsQty = new System.Windows.Forms.TextBox();
            this.txtKeyinPerson = new System.Windows.Forms.TextBox();
            this.cbPcbName = new System.Windows.Forms.ComboBox();
            this.iconbtnSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgInput)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgInput
            // 
            this.dgInput.AllowUserToAddRows = false;
            this.dgInput.AllowUserToDeleteRows = false;
            this.dgInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInput.Location = new System.Drawing.Point(12, 274);
            this.dgInput.Name = "dgInput";
            this.dgInput.ReadOnly = true;
            this.dgInput.Size = new System.Drawing.Size(978, 339);
            this.dgInput.TabIndex = 4;
            this.dgInput.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInput_CellDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "INPUT QTY:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtBarcode.Location = new System.Drawing.Point(117, 3);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(273, 26);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.91832F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.08168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 431F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBarcode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbLocation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbSmtLine, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbLot, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbPeNo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbProgram, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtInputQty, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRemark, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtModel, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHsQty, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtKeyinPerson, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbPcbName, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker, 3, 5);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.75661F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 256);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 777;
            this.label1.Text = "BARCODE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "LOCATION:";
            // 
            // cbLocation
            // 
            this.cbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(117, 40);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(194, 28);
            this.cbLocation.TabIndex = 2;
            this.cbLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLocation_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "SMT LINE:";
            // 
            // cbSmtLine
            // 
            this.cbSmtLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSmtLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbSmtLine.FormattingEnabled = true;
            this.cbSmtLine.Location = new System.Drawing.Point(117, 75);
            this.cbSmtLine.Name = "cbSmtLine";
            this.cbSmtLine.Size = new System.Drawing.Size(194, 28);
            this.cbSmtLine.TabIndex = 3;
            this.cbSmtLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSmtLine_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "LOT:";
            // 
            // cbLot
            // 
            this.cbLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbLot.FormattingEnabled = true;
            this.cbLot.Location = new System.Drawing.Point(117, 111);
            this.cbLot.Name = "cbLot";
            this.cbLot.Size = new System.Drawing.Size(194, 28);
            this.cbLot.TabIndex = 4;
            this.cbLot.SelectedValueChanged += new System.EventHandler(this.cbLot_SelectedValueChanged);
            this.cbLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLot_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "PE NO:";
            // 
            // cbPeNo
            // 
            this.cbPeNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbPeNo.FormattingEnabled = true;
            this.cbPeNo.Location = new System.Drawing.Point(117, 147);
            this.cbPeNo.Name = "cbPeNo";
            this.cbPeNo.Size = new System.Drawing.Size(194, 28);
            this.cbPeNo.TabIndex = 5;
            this.cbPeNo.SelectedValueChanged += new System.EventHandler(this.cbPeNo_SelectedValueChanged);
            this.cbPeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPeNo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "PCB NAME:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "PROGRAM:";
            // 
            // cbProgram
            // 
            this.cbProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbProgram.FormattingEnabled = true;
            this.cbProgram.Location = new System.Drawing.Point(117, 219);
            this.cbProgram.Name = "cbProgram";
            this.cbProgram.Size = new System.Drawing.Size(194, 28);
            this.cbProgram.TabIndex = 7;
            this.cbProgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProgram_KeyPress);
            // 
            // txtInputQty
            // 
            this.txtInputQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtInputQty.Location = new System.Drawing.Point(549, 3);
            this.txtInputQty.Name = "txtInputQty";
            this.txtInputQty.Size = new System.Drawing.Size(153, 26);
            this.txtInputQty.TabIndex = 9;
            this.txtInputQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputQty_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(398, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "REMARK:";
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtRemark.Location = new System.Drawing.Point(549, 40);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(269, 26);
            this.txtRemark.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(398, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "MODEL:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "HS QTY:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(398, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "KEYIN NAME:";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtModel.Enabled = false;
            this.txtModel.Location = new System.Drawing.Point(549, 75);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(153, 26);
            this.txtModel.TabIndex = 11;
            // 
            // txtHsQty
            // 
            this.txtHsQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtHsQty.Enabled = false;
            this.txtHsQty.Location = new System.Drawing.Point(549, 111);
            this.txtHsQty.Name = "txtHsQty";
            this.txtHsQty.Size = new System.Drawing.Size(153, 26);
            this.txtHsQty.TabIndex = 12;
            // 
            // txtKeyinPerson
            // 
            this.txtKeyinPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtKeyinPerson.Enabled = false;
            this.txtKeyinPerson.Location = new System.Drawing.Point(549, 147);
            this.txtKeyinPerson.Name = "txtKeyinPerson";
            this.txtKeyinPerson.Size = new System.Drawing.Size(153, 26);
            this.txtKeyinPerson.TabIndex = 13;
            // 
            // cbPcbName
            // 
            this.cbPcbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPcbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbPcbName.FormattingEnabled = true;
            this.cbPcbName.Location = new System.Drawing.Point(117, 183);
            this.cbPcbName.Name = "cbPcbName";
            this.cbPcbName.Size = new System.Drawing.Size(194, 28);
            this.cbPcbName.TabIndex = 6;
            this.cbPcbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPcbName_KeyPress);
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.Location = new System.Drawing.Point(549, 219);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(153, 30);
            this.iconbtnSave.TabIndex = 14;
            this.iconbtnSave.Text = "SAVE";
            this.iconbtnSave.UseVisualStyleBackColor = true;
            this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(398, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 778;
            this.label13.Text = "KEY IN DATE:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(549, 183);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(178, 26);
            this.dateTimePicker.TabIndex = 779;
            // 
            // frmINPUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 625);
            this.Controls.Add(this.dgInput);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINPUT";
            this.Text = "Nhập dữ liệu STAGING";
            this.Load += new System.EventHandler(this.frmINPUT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInput)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSmtLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPeNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbProgram;
        private System.Windows.Forms.TextBox txtInputQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtHsQty;
        private System.Windows.Forms.TextBox txtKeyinPerson;
        private System.Windows.Forms.ComboBox cbPcbName;
        private System.Windows.Forms.Button iconbtnSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}