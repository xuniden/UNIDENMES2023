namespace SMTPRORAM
{
    partial class F_Update_CutLot_ChangeLine
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.txtprogram = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfeeder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDatecode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbnumber = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Line:";
            // 
            // txtLineName
            // 
            this.txtLineName.Location = new System.Drawing.Point(116, 110);
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(100, 20);
            this.txtLineName.TabIndex = 4;
            this.txtLineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLineName_KeyDown);
            // 
            // txtprogram
            // 
            this.txtprogram.Location = new System.Drawing.Point(116, 32);
            this.txtprogram.Name = "txtprogram";
            this.txtprogram.Size = new System.Drawing.Size(290, 20);
            this.txtprogram.TabIndex = 1;
            this.txtprogram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtprogram_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Chương Trình:";
            // 
            // txtfeeder
            // 
            this.txtfeeder.Location = new System.Drawing.Point(116, 58);
            this.txtfeeder.Name = "txtfeeder";
            this.txtfeeder.Size = new System.Drawing.Size(100, 20);
            this.txtfeeder.TabIndex = 2;
            this.txtfeeder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfeeder_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số Feeder:";
            // 
            // txtpart
            // 
            this.txtpart.Location = new System.Drawing.Point(116, 84);
            this.txtpart.Name = "txtpart";
            this.txtpart.Size = new System.Drawing.Size(154, 20);
            this.txtpart.TabIndex = 3;
            this.txtpart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpart_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã linh Kiện:";
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(116, 163);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(154, 20);
            this.txtqty.TabIndex = 6;
            this.txtqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqty_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số Lượng:";
            // 
            // txtDatecode
            // 
            this.txtDatecode.Location = new System.Drawing.Point(116, 189);
            this.txtDatecode.Name = "txtDatecode";
            this.txtDatecode.Size = new System.Drawing.Size(154, 20);
            this.txtDatecode.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Date Code:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(116, 215);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(290, 20);
            this.txtDesc.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Desc:";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(116, 255);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 7;
            this.btSave.Text = "Ghi Lại";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(216, 255);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Hủy Bỏ";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tên người thay";
            // 
            // cbnumber
            // 
            this.cbnumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbnumber.FormattingEnabled = true;
            this.cbnumber.Location = new System.Drawing.Point(116, 136);
            this.cbnumber.Name = "cbnumber";
            this.cbnumber.Size = new System.Drawing.Size(121, 21);
            this.cbnumber.TabIndex = 5;
            this.cbnumber.SelectedIndexChanged += new System.EventHandler(this.cbnumber_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Số lần nhập liệu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(412, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(276, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "label13";
            // 
            // txtUsage
            // 
            this.txtUsage.Enabled = false;
            this.txtUsage.Location = new System.Drawing.Point(299, 163);
            this.txtUsage.Name = "txtUsage";
            this.txtUsage.Size = new System.Drawing.Size(100, 20);
            this.txtUsage.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(380, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "label14";
            // 
            // F_Update_CutLot_ChangeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 297);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtUsage);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbnumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDatecode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtqty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtfeeder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtprogram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLineName);
            this.Controls.Add(this.label1);
            this.Name = "F_Update_CutLot_ChangeLine";
            this.Text = "Cập Nhật Dữ Liệu Cho Việc Cut Lot và Chuyển Line";
            this.Load += new System.EventHandler(this.F_Update_CutLot_ChangeLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.TextBox txtprogram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtfeeder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDatecode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbnumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsage;
        private System.Windows.Forms.Label label14;
    }
}