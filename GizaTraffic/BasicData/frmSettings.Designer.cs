using Utilities;

namespace GizaTraffic.BasicData
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            btnSave = new Button();
            tpcntSettings = new TabControl();
            tbpgRecieptHeader = new TabPage();
            txtRecieptHeader = new TextBox();
            lblRecieptHeader = new Label();
            tbpgRecieptFooter = new TabPage();
            txtReceiptFooter = new TextBox();
            lblRecieptFooter = new Label();
            lblPrinterName = new Label();
            ddlPrinterName = new ComboBox();
            lblPrintingPath = new Label();
            txtPriningPath = new TextBox();
            btnBrowsePrintingPath = new Button();
            ((System.ComponentModel.ISupportInitialize)errprovFormErrorProvider).BeginInit();
            tpcntSettings.SuspendLayout();
            tbpgRecieptHeader.SuspendLayout();
            tbpgRecieptFooter.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(382, 85);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // tpcntSettings
            // 
            tpcntSettings.Controls.Add(tbpgRecieptHeader);
            tpcntSettings.Controls.Add(tbpgRecieptFooter);
            tpcntSettings.Dock = DockStyle.Bottom;
            tpcntSettings.Location = new Point(0, 120);
            tpcntSettings.Name = "tpcntSettings";
            tpcntSettings.RightToLeftLayout = true;
            tpcntSettings.SelectedIndex = 0;
            tpcntSettings.Size = new Size(800, 290);
            tpcntSettings.TabIndex = 12;
            // 
            // tbpgRecieptHeader
            // 
            tbpgRecieptHeader.Controls.Add(txtRecieptHeader);
            tbpgRecieptHeader.Controls.Add(lblRecieptHeader);
            tbpgRecieptHeader.Location = new Point(4, 29);
            tbpgRecieptHeader.Name = "tbpgRecieptHeader";
            tbpgRecieptHeader.Padding = new Padding(3);
            tbpgRecieptHeader.Size = new Size(792, 257);
            tbpgRecieptHeader.TabIndex = 1;
            tbpgRecieptHeader.Text = "مقدمة الQR Code";
            tbpgRecieptHeader.UseVisualStyleBackColor = true;
            // 
            // txtRecieptHeader
            // 
            txtRecieptHeader.Location = new Point(193, 43);
            txtRecieptHeader.Multiline = true;
            txtRecieptHeader.Name = "txtRecieptHeader";
            txtRecieptHeader.Size = new Size(562, 136);
            txtRecieptHeader.TabIndex = 7;
            // 
            // lblRecieptHeader
            // 
            lblRecieptHeader.AutoSize = true;
            lblRecieptHeader.Location = new Point(441, 3);
            lblRecieptHeader.Name = "lblRecieptHeader";
            lblRecieptHeader.Size = new Size(343, 20);
            lblRecieptHeader.TabIndex = 6;
            lblRecieptHeader.Text = "أدخل النص الذي سيتم عرضه في مقدمة كل QR Code";
            // 
            // tbpgRecieptFooter
            // 
            tbpgRecieptFooter.Controls.Add(txtReceiptFooter);
            tbpgRecieptFooter.Controls.Add(lblRecieptFooter);
            tbpgRecieptFooter.Location = new Point(4, 29);
            tbpgRecieptFooter.Name = "tbpgRecieptFooter";
            tbpgRecieptFooter.Size = new Size(792, 257);
            tbpgRecieptFooter.TabIndex = 2;
            tbpgRecieptFooter.Text = "تذييل الQR Code";
            tbpgRecieptFooter.UseVisualStyleBackColor = true;
            // 
            // txtReceiptFooter
            // 
            txtReceiptFooter.Location = new Point(198, 50);
            txtReceiptFooter.Multiline = true;
            txtReceiptFooter.Name = "txtReceiptFooter";
            txtReceiptFooter.Size = new Size(562, 136);
            txtReceiptFooter.TabIndex = 9;
            // 
            // lblRecieptFooter
            // 
            lblRecieptFooter.AutoSize = true;
            lblRecieptFooter.Location = new Point(450, 11);
            lblRecieptFooter.Name = "lblRecieptFooter";
            lblRecieptFooter.Size = new Size(334, 20);
            lblRecieptFooter.TabIndex = 8;
            lblRecieptFooter.Text = "أدخل النص الذي سيتم عرضه في تذييل كل QR Code";
            // 
            // lblPrinterName
            // 
            lblPrinterName.AutoSize = true;
            lblPrinterName.Location = new Point(12, 9);
            lblPrinterName.Name = "lblPrinterName";
            lblPrinterName.Size = new Size(127, 20);
            lblPrinterName.TabIndex = 6;
            lblPrinterName.Text = "طابعة الQR COde";
            // 
            // ddlPrinterName
            // 
            ddlPrinterName.FormattingEnabled = true;
            ddlPrinterName.Location = new Point(192, 6);
            ddlPrinterName.Name = "ddlPrinterName";
            ddlPrinterName.Size = new Size(344, 28);
            ddlPrinterName.TabIndex = 13;
            // 
            // lblPrintingPath
            // 
            lblPrintingPath.AutoSize = true;
            lblPrintingPath.Location = new Point(12, 52);
            lblPrintingPath.Name = "lblPrintingPath";
            lblPrintingPath.Size = new Size(126, 20);
            lblPrintingPath.TabIndex = 6;
            lblPrintingPath.Text = "مسار طباعة الصور";
            // 
            // txtPriningPath
            // 
            txtPriningPath.Location = new Point(191, 49);
            txtPriningPath.Name = "txtPriningPath";
            txtPriningPath.ReadOnly = true;
            txtPriningPath.Size = new Size(497, 27);
            txtPriningPath.TabIndex = 14;
            // 
            // btnBrowsePrintingPath
            // 
            btnBrowsePrintingPath.Location = new Point(697, 48);
            btnBrowsePrintingPath.Name = "btnBrowsePrintingPath";
            btnBrowsePrintingPath.Size = new Size(94, 29);
            btnBrowsePrintingPath.TabIndex = 15;
            btnBrowsePrintingPath.Text = "استعراض ...";
            btnBrowsePrintingPath.UseVisualStyleBackColor = true;
            btnBrowsePrintingPath.Click += btnBrowsePrintingPath_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 410);
            Controls.Add(btnBrowsePrintingPath);
            Controls.Add(txtPriningPath);
            Controls.Add(ddlPrinterName);
            Controls.Add(btnSave);
            Controls.Add(tpcntSettings);
            Controls.Add(lblPrintingPath);
            Controls.Add(lblPrinterName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmSettings";
            Text = "مرور الجيزة - الإعدادات";
            Load += FrmSettings_Load;
            ((System.ComponentModel.ISupportInitialize)errprovFormErrorProvider).EndInit();
            tpcntSettings.ResumeLayout(false);
            tbpgRecieptHeader.ResumeLayout(false);
            tbpgRecieptHeader.PerformLayout();
            tbpgRecieptFooter.ResumeLayout(false);
            tbpgRecieptFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSave;
        private TabControl tpcntSettings;
        private TabPage tbpgRecieptHeader;
        private TabPage tbpgRecieptFooter;
        private Label lblRecieptHeader;
        private TextBox txtRecieptHeader;
        private TextBox txtReceiptFooter;
        private Label lblRecieptFooter;
        private Label lblPrinterName;
        private ComboBox ddlPrinterName;
        private Label lblPrintingPath;
        private TextBox txtPriningPath;
        private Button btnBrowsePrintingPath;
    }
}