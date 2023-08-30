namespace SMTPRORAM
{
    partial class frmTestForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.cbPcbCode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(71, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 25);
            this.label10.TabIndex = 64;
            this.label10.Text = "PCB CODE:";
            // 
            // cbPcbCode
            // 
            this.cbPcbCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPcbCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPcbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPcbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPcbCode.FormattingEnabled = true;
            this.cbPcbCode.Location = new System.Drawing.Point(204, 44);
            this.cbPcbCode.Name = "cbPcbCode";
            this.cbPcbCode.Size = new System.Drawing.Size(371, 32);
            this.cbPcbCode.TabIndex = 63;
            this.cbPcbCode.TextUpdate += new System.EventHandler(this.cbPcbCode_TextUpdate);
            this.cbPcbCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPcbCode_KeyPress);
            // 
            // frmTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbPcbCode);
            this.Name = "frmTestForm";
            this.Text = "frmTestForm";
            this.Load += new System.EventHandler(this.frmTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbPcbCode;
    }
}