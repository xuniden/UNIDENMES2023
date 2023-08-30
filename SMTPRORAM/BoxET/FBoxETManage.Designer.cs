
namespace SMTPRORAM.BoxET
{
    partial class FBoxETManage
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioBtnBox = new System.Windows.Forms.RadioButton();
			this.radioBtnPalletKeep = new System.Windows.Forms.RadioButton();
			this.radioBtnPalletShipment = new System.Windows.Forms.RadioButton();
			this.btnBaocao = new System.Windows.Forms.Button();
			this.lbltemdatao = new System.Windows.Forms.Label();
			this.lbltongsotem = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnCreate = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.reportViewerBoxET = new Microsoft.Reporting.WinForms.ReportViewer();
			this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.dataGridView);
			this.splitContainer.Size = new System.Drawing.Size(899, 558);
			this.splitContainer.SplitterDistance = 455;
			this.splitContainer.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel1.Controls.Add(this.btnBaocao);
			this.splitContainer1.Panel1.Controls.Add(this.lbltemdatao);
			this.splitContainer1.Panel1.Controls.Add(this.lbltongsotem);
			this.splitContainer1.Panel1.Controls.Add(this.label5);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
			this.splitContainer1.Panel1.Controls.Add(this.btnCreate);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.numericUpDown2);
			this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(455, 558);
			this.splitContainer1.SplitterDistance = 227;
			this.splitContainer1.TabIndex = 9;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioBtnBox);
			this.groupBox1.Controls.Add(this.radioBtnPalletKeep);
			this.groupBox1.Controls.Add(this.radioBtnPalletShipment);
			this.groupBox1.Location = new System.Drawing.Point(12, 102);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(173, 111);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lựa chọn";
			// 
			// radioBtnBox
			// 
			this.radioBtnBox.AutoSize = true;
			this.radioBtnBox.Location = new System.Drawing.Point(9, 21);
			this.radioBtnBox.Name = "radioBtnBox";
			this.radioBtnBox.Size = new System.Drawing.Size(88, 17);
			this.radioBtnBox.TabIndex = 21;
			this.radioBtnBox.TabStop = true;
			this.radioBtnBox.Tag = "UV00";
			this.radioBtnBox.Text = "Tem cho Box";
			this.radioBtnBox.UseVisualStyleBackColor = true;
			this.radioBtnBox.CheckedChanged += new System.EventHandler(this.radioBtnBox_CheckedChanged);
			// 
			// radioBtnPalletKeep
			// 
			this.radioBtnPalletKeep.AutoSize = true;
			this.radioBtnPalletKeep.Location = new System.Drawing.Point(9, 84);
			this.radioBtnPalletKeep.Name = "radioBtnPalletKeep";
			this.radioBtnPalletKeep.Size = new System.Drawing.Size(125, 17);
			this.radioBtnPalletKeep.TabIndex = 23;
			this.radioBtnPalletKeep.TabStop = true;
			this.radioBtnPalletKeep.Tag = "UVPK";
			this.radioBtnPalletKeep.Text = "Tem Cho Pallet Keep";
			this.radioBtnPalletKeep.UseVisualStyleBackColor = true;
			this.radioBtnPalletKeep.CheckedChanged += new System.EventHandler(this.radioBtnPalletKeep_CheckedChanged);
			// 
			// radioBtnPalletShipment
			// 
			this.radioBtnPalletShipment.AutoSize = true;
			this.radioBtnPalletShipment.Location = new System.Drawing.Point(9, 51);
			this.radioBtnPalletShipment.Name = "radioBtnPalletShipment";
			this.radioBtnPalletShipment.Size = new System.Drawing.Size(143, 17);
			this.radioBtnPalletShipment.TabIndex = 22;
			this.radioBtnPalletShipment.TabStop = true;
			this.radioBtnPalletShipment.Tag = "UVPS";
			this.radioBtnPalletShipment.Text = "Tem cho Pallet Shipment";
			this.radioBtnPalletShipment.UseVisualStyleBackColor = true;
			this.radioBtnPalletShipment.CheckedChanged += new System.EventHandler(this.radioBtnPalletShipment_CheckedChanged);
			// 
			// btnBaocao
			// 
			this.btnBaocao.Location = new System.Drawing.Point(337, 190);
			this.btnBaocao.Name = "btnBaocao";
			this.btnBaocao.Size = new System.Drawing.Size(63, 23);
			this.btnBaocao.TabIndex = 20;
			this.btnBaocao.Text = "Xem báo cáo";
			this.btnBaocao.UseVisualStyleBackColor = true;
			this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
			// 
			// lbltemdatao
			// 
			this.lbltemdatao.AutoSize = true;
			this.lbltemdatao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbltemdatao.ForeColor = System.Drawing.Color.Fuchsia;
			this.lbltemdatao.Location = new System.Drawing.Point(188, 44);
			this.lbltemdatao.Name = "lbltemdatao";
			this.lbltemdatao.Size = new System.Drawing.Size(75, 17);
			this.lbltemdatao.TabIndex = 19;
			this.lbltemdatao.Text = "temdatao";
			// 
			// lbltongsotem
			// 
			this.lbltongsotem.AutoSize = true;
			this.lbltongsotem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbltongsotem.Location = new System.Drawing.Point(159, 73);
			this.lbltongsotem.Name = "lbltongsotem";
			this.lbltongsotem.Size = new System.Drawing.Size(83, 17);
			this.lbltongsotem.TabIndex = 17;
			this.lbltongsotem.Text = "tongsotem";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(18, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(135, 17);
			this.label5.TabIndex = 18;
			this.label5.Text = "Tổng số tem đã tạo:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(17, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(165, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "Số tem cuối cùng đã tạo:";
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(259, 190);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(72, 23);
			this.btnPrint.TabIndex = 15;
			this.btnPrint.Text = "In Tem";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(191, 190);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(62, 23);
			this.btnCreate.TabIndex = 14;
			this.btnCreate.Text = "Tạo Tem";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click_1);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Blue;
			this.label3.Location = new System.Drawing.Point(130, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(188, 20);
			this.label3.TabIndex = 13;
			this.label3.Text = "Tạo Tem dán vào BOX";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(188, 157);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Tạo đến số:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(188, 122);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Tạo từ số:";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(280, 155);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown2.TabIndex = 10;
			this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(280, 120);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.reportViewerBoxET);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.crystalReportViewer);
			this.splitContainer2.Size = new System.Drawing.Size(455, 327);
			this.splitContainer2.SplitterDistance = 151;
			this.splitContainer2.TabIndex = 0;
			// 
			// reportViewerBoxET
			// 
			this.reportViewerBoxET.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reportViewerBoxET.Location = new System.Drawing.Point(0, 0);
			this.reportViewerBoxET.Name = "reportViewerBoxET";
			this.reportViewerBoxET.ServerReport.BearerToken = null;
			this.reportViewerBoxET.Size = new System.Drawing.Size(455, 151);
			this.reportViewerBoxET.TabIndex = 10;
			// 
			// crystalReportViewer
			// 
			this.crystalReportViewer.ActiveViewIndex = -1;
			this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
			this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer.Name = "crystalReportViewer";
			this.crystalReportViewer.Size = new System.Drawing.Size(455, 172);
			this.crystalReportViewer.TabIndex = 9;
			this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(440, 558);
			this.dataGridView.TabIndex = 0;
			// 
			// FBoxETManage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 558);
			this.Controls.Add(this.splitContainer);
			this.MinimizeBox = false;
			this.Name = "FBoxETManage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý số serial của BOX";
			this.Load += new System.EventHandler(this.FBoxETManage_Load);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridView;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbltemdatao;
        private System.Windows.Forms.Label lbltongsotem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnBaocao;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerBoxET;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton radioBtnPalletKeep;
        private System.Windows.Forms.RadioButton radioBtnPalletShipment;
        private System.Windows.Forms.RadioButton radioBtnBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}