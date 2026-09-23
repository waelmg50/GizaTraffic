namespace GizaTraffic.BasicData
{
    partial class frmRegisterVehicles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterVehicles));
            lblVehicleType = new Label();
            lblVehicleNo = new Label();
            lblvehicleChassisNumber = new Label();
            lblVehicleEngineNumber = new Label();
            lblCaseReportNumber = new Label();
            txtVehicleNoAlphabitics3 = new TextBox();
            txtVehicleChassisNumber = new TextBox();
            txtVehicleEngineNumber = new TextBox();
            txtCaseReportNumber = new TextBox();
            btnPrintQRCode = new Button();
            ddlVehicleType = new ComboBox();
            lblCaseReportType = new Label();
            txtCaseReportType = new TextBox();
            lblOwnerName = new Label();
            txtOwnerName = new TextBox();
            lblOwnerNationalIDNumber = new Label();
            txtOwnerNationalIDNumber = new Utilities.NumericTextBox();
            lblDriverName = new Label();
            txtDriverName = new TextBox();
            lblDriverNationalIDNumber = new Label();
            txtDriverNationalIDNumber = new Utilities.NumericTextBox();
            lblVehicleColor = new Label();
            txtVehicleColor = new TextBox();
            lblVehicleBrand = new Label();
            txtVehicleBrand = new TextBox();
            lblVehicleModel = new Label();
            txtVehicleModel = new TextBox();
            txtVehicleImpoundNumber = new TextBox();
            lblVehicleImpoundNumber = new Label();
            lblImpoundDate = new Label();
            dtpImpoundDate = new DateTimePicker();
            lblExitDate = new Label();
            dtpExitDate = new DateTimePicker();
            btnSearch = new Button();
            btnSave = new Button();
            btnRegisterNewVehicleImpound = new Button();
            ntxtCarNo = new Utilities.NumericTextBox();
            lblVehicleSector = new Label();
            ddlVehicleSector = new ComboBox();
            txtVehicleNoAlphabitics2 = new TextBox();
            txtVehicleNoAlphabitics1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errprovFormErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.Location = new Point(444, 9);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(79, 20);
            lblVehicleType.TabIndex = 5;
            lblVehicleType.Text = "نوع المركبة";
            // 
            // lblVehicleNo
            // 
            lblVehicleNo.AutoSize = true;
            lblVehicleNo.Location = new Point(39, 9);
            lblVehicleNo.Name = "lblVehicleNo";
            lblVehicleNo.Size = new Size(79, 20);
            lblVehicleNo.TabIndex = 5;
            lblVehicleNo.Text = "رقم المركبة";
            // 
            // lblvehicleChassisNumber
            // 
            lblvehicleChassisNumber.AutoSize = true;
            lblvehicleChassisNumber.Location = new Point(39, 50);
            lblvehicleChassisNumber.Name = "lblvehicleChassisNumber";
            lblvehicleChassisNumber.Size = new Size(126, 20);
            lblvehicleChassisNumber.TabIndex = 5;
            lblvehicleChassisNumber.Text = "رقم شاسيه المركبة";
            // 
            // lblVehicleEngineNumber
            // 
            lblVehicleEngineNumber.AutoSize = true;
            lblVehicleEngineNumber.Location = new Point(444, 50);
            lblVehicleEngineNumber.Name = "lblVehicleEngineNumber";
            lblVehicleEngineNumber.Size = new Size(119, 20);
            lblVehicleEngineNumber.TabIndex = 5;
            lblVehicleEngineNumber.Text = "رقم موتور المركبة";
            // 
            // lblCaseReportNumber
            // 
            lblCaseReportNumber.AutoSize = true;
            lblCaseReportNumber.Location = new Point(39, 91);
            lblCaseReportNumber.Name = "lblCaseReportNumber";
            lblCaseReportNumber.Size = new Size(82, 20);
            lblCaseReportNumber.TabIndex = 5;
            lblCaseReportNumber.Text = "رقم المحضر";
            // 
            // txtVehicleNoAlphabitics3
            // 
            txtVehicleNoAlphabitics3.Location = new Point(313, 5);
            txtVehicleNoAlphabitics3.MaxLength = 1;
            txtVehicleNoAlphabitics3.Name = "txtVehicleNoAlphabitics3";
            txtVehicleNoAlphabitics3.Size = new Size(21, 27);
            txtVehicleNoAlphabitics3.TabIndex = 0;
            txtVehicleNoAlphabitics3.TextChanged += txtVehicleNoAlphabitics3_TextChanged;
            // 
            // txtVehicleChassisNumber
            // 
            txtVehicleChassisNumber.Location = new Point(258, 47);
            txtVehicleChassisNumber.MaxLength = 100;
            txtVehicleChassisNumber.Name = "txtVehicleChassisNumber";
            txtVehicleChassisNumber.Size = new Size(172, 27);
            txtVehicleChassisNumber.TabIndex = 6;
            txtVehicleChassisNumber.Leave += txtFamilyCardCode_Leave;
            // 
            // txtVehicleEngineNumber
            // 
            txtVehicleEngineNumber.Location = new Point(698, 47);
            txtVehicleEngineNumber.MaxLength = 100;
            txtVehicleEngineNumber.Name = "txtVehicleEngineNumber";
            txtVehicleEngineNumber.Size = new Size(172, 27);
            txtVehicleEngineNumber.TabIndex = 7;
            // 
            // txtCaseReportNumber
            // 
            txtCaseReportNumber.Location = new Point(258, 88);
            txtCaseReportNumber.MaxLength = 100;
            txtCaseReportNumber.Name = "txtCaseReportNumber";
            txtCaseReportNumber.Size = new Size(172, 27);
            txtCaseReportNumber.TabIndex = 8;
            // 
            // btnPrintQRCode
            // 
            btnPrintQRCode.Location = new Point(314, 387);
            btnPrintQRCode.Name = "btnPrintQRCode";
            btnPrintQRCode.Size = new Size(119, 29);
            btnPrintQRCode.TabIndex = 22;
            btnPrintQRCode.Text = "طباعة QR Code";
            btnPrintQRCode.UseVisualStyleBackColor = true;
            btnPrintQRCode.Click += btnPrintQRCode_Click;
            // 
            // ddlVehicleType
            // 
            ddlVehicleType.FormattingEnabled = true;
            ddlVehicleType.Items.AddRange(new object[] { "ملاكي", "أجرة", "أتوبيس خاص", "مقطورة", "سياحة", "تروسيكل", "دراجة نارية", "أتوبيس عام", "محافظة", "حكومة", "جمرك", "توكتوك", "نقل", "رحلات", "مدارس", "معدة" });
            ddlVehicleType.Location = new Point(698, 5);
            ddlVehicleType.Name = "ddlVehicleType";
            ddlVehicleType.Size = new Size(151, 28);
            ddlVehicleType.TabIndex = 5;
            // 
            // lblCaseReportType
            // 
            lblCaseReportType.AutoSize = true;
            lblCaseReportType.Location = new Point(444, 91);
            lblCaseReportType.Name = "lblCaseReportType";
            lblCaseReportType.Size = new Size(82, 20);
            lblCaseReportType.TabIndex = 5;
            lblCaseReportType.Text = "نوع المحضر";
            // 
            // txtCaseReportType
            // 
            txtCaseReportType.Location = new Point(698, 88);
            txtCaseReportType.MaxLength = 100;
            txtCaseReportType.Name = "txtCaseReportType";
            txtCaseReportType.Size = new Size(172, 27);
            txtCaseReportType.TabIndex = 9;
            // 
            // lblOwnerName
            // 
            lblOwnerName.AutoSize = true;
            lblOwnerName.Location = new Point(39, 132);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(79, 20);
            lblOwnerName.TabIndex = 5;
            lblOwnerName.Text = "اسم المالك";
            // 
            // txtOwnerName
            // 
            txtOwnerName.Location = new Point(258, 129);
            txtOwnerName.MaxLength = 200;
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.Size = new Size(172, 27);
            txtOwnerName.TabIndex = 10;
            // 
            // lblOwnerNationalIDNumber
            // 
            lblOwnerNationalIDNumber.AutoSize = true;
            lblOwnerNationalIDNumber.Location = new Point(444, 132);
            lblOwnerNationalIDNumber.Name = "lblOwnerNationalIDNumber";
            lblOwnerNationalIDNumber.Size = new Size(136, 20);
            lblOwnerNationalIDNumber.TabIndex = 5;
            lblOwnerNationalIDNumber.Text = "الرقم القومي للمالك";
            // 
            // txtOwnerNationalIDNumber
            // 
            txtOwnerNationalIDNumber.IsInt = true;
            txtOwnerNationalIDNumber.Location = new Point(698, 129);
            txtOwnerNationalIDNumber.MaxLength = 14;
            txtOwnerNationalIDNumber.Name = "txtOwnerNationalIDNumber";
            txtOwnerNationalIDNumber.Size = new Size(172, 27);
            txtOwnerNationalIDNumber.TabIndex = 11;
            // 
            // lblDriverName
            // 
            lblDriverName.AutoSize = true;
            lblDriverName.Location = new Point(39, 173);
            lblDriverName.Name = "lblDriverName";
            lblDriverName.Size = new Size(186, 20);
            lblDriverName.TabIndex = 5;
            lblDriverName.Text = "اسم قائد المركبة أثناء الضبط";
            // 
            // txtDriverName
            // 
            txtDriverName.Location = new Point(258, 170);
            txtDriverName.MaxLength = 200;
            txtDriverName.Name = "txtDriverName";
            txtDriverName.Size = new Size(172, 27);
            txtDriverName.TabIndex = 12;
            // 
            // lblDriverNationalIDNumber
            // 
            lblDriverNationalIDNumber.AutoSize = true;
            lblDriverNationalIDNumber.Location = new Point(444, 173);
            lblDriverNationalIDNumber.Name = "lblDriverNationalIDNumber";
            lblDriverNationalIDNumber.Size = new Size(247, 20);
            lblDriverNationalIDNumber.TabIndex = 5;
            lblDriverNationalIDNumber.Text = "الرقم القومي لقائد المركبة أثناء الضبط";
            // 
            // txtDriverNationalIDNumber
            // 
            txtDriverNationalIDNumber.IsInt = true;
            txtDriverNationalIDNumber.Location = new Point(700, 170);
            txtDriverNationalIDNumber.MaxLength = 14;
            txtDriverNationalIDNumber.Name = "txtDriverNationalIDNumber";
            txtDriverNationalIDNumber.Size = new Size(172, 27);
            txtDriverNationalIDNumber.TabIndex = 13;
            // 
            // lblVehicleColor
            // 
            lblVehicleColor.AutoSize = true;
            lblVehicleColor.Location = new Point(39, 214);
            lblVehicleColor.Name = "lblVehicleColor";
            lblVehicleColor.Size = new Size(80, 20);
            lblVehicleColor.TabIndex = 5;
            lblVehicleColor.Text = "لون المركبة";
            // 
            // txtVehicleColor
            // 
            txtVehicleColor.Location = new Point(258, 211);
            txtVehicleColor.MaxLength = 100;
            txtVehicleColor.Name = "txtVehicleColor";
            txtVehicleColor.Size = new Size(172, 27);
            txtVehicleColor.TabIndex = 14;
            // 
            // lblVehicleBrand
            // 
            lblVehicleBrand.AutoSize = true;
            lblVehicleBrand.Location = new Point(444, 214);
            lblVehicleBrand.Name = "lblVehicleBrand";
            lblVehicleBrand.Size = new Size(91, 20);
            lblVehicleBrand.TabIndex = 5;
            lblVehicleBrand.Text = "ماركة المركبة";
            // 
            // txtVehicleBrand
            // 
            txtVehicleBrand.Location = new Point(700, 211);
            txtVehicleBrand.MaxLength = 100;
            txtVehicleBrand.Name = "txtVehicleBrand";
            txtVehicleBrand.Size = new Size(172, 27);
            txtVehicleBrand.TabIndex = 15;
            // 
            // lblVehicleModel
            // 
            lblVehicleModel.AutoSize = true;
            lblVehicleModel.Location = new Point(39, 255);
            lblVehicleModel.Name = "lblVehicleModel";
            lblVehicleModel.Size = new Size(58, 20);
            lblVehicleModel.TabIndex = 5;
            lblVehicleModel.Text = "الموديل";
            // 
            // txtVehicleModel
            // 
            txtVehicleModel.Location = new Point(258, 252);
            txtVehicleModel.MaxLength = 100;
            txtVehicleModel.Name = "txtVehicleModel";
            txtVehicleModel.Size = new Size(172, 27);
            txtVehicleModel.TabIndex = 16;
            // 
            // txtVehicleImpoundNumber
            // 
            txtVehicleImpoundNumber.Location = new Point(258, 293);
            txtVehicleImpoundNumber.MaxLength = 100;
            txtVehicleImpoundNumber.Name = "txtVehicleImpoundNumber";
            txtVehicleImpoundNumber.Size = new Size(172, 27);
            txtVehicleImpoundNumber.TabIndex = 17;
            txtVehicleImpoundNumber.Leave += txtVehicleImpoundNumber_Leave;
            // 
            // lblVehicleImpoundNumber
            // 
            lblVehicleImpoundNumber.AutoSize = true;
            lblVehicleImpoundNumber.Location = new Point(39, 296);
            lblVehicleImpoundNumber.Name = "lblVehicleImpoundNumber";
            lblVehicleImpoundNumber.Size = new Size(107, 20);
            lblVehicleImpoundNumber.TabIndex = 5;
            lblVehicleImpoundNumber.Text = "رقم حجز المركبة";
            // 
            // lblImpoundDate
            // 
            lblImpoundDate.AutoSize = true;
            lblImpoundDate.Location = new Point(39, 337);
            lblImpoundDate.Name = "lblImpoundDate";
            lblImpoundDate.Size = new Size(76, 20);
            lblImpoundDate.TabIndex = 5;
            lblImpoundDate.Text = "تاريخ الحجز";
            // 
            // dtpImpoundDate
            // 
            dtpImpoundDate.Checked = false;
            dtpImpoundDate.CustomFormat = "yyyy/MM/dd";
            dtpImpoundDate.Format = DateTimePickerFormat.Custom;
            dtpImpoundDate.Location = new Point(258, 334);
            dtpImpoundDate.Name = "dtpImpoundDate";
            dtpImpoundDate.RightToLeftLayout = true;
            dtpImpoundDate.ShowCheckBox = true;
            dtpImpoundDate.Size = new Size(172, 27);
            dtpImpoundDate.TabIndex = 19;
            // 
            // lblExitDate
            // 
            lblExitDate.AutoSize = true;
            lblExitDate.Location = new Point(444, 337);
            lblExitDate.Name = "lblExitDate";
            lblExitDate.Size = new Size(84, 20);
            lblExitDate.TabIndex = 5;
            lblExitDate.Text = "تاريخ الخروج";
            // 
            // dtpExitDate
            // 
            dtpExitDate.Checked = false;
            dtpExitDate.CustomFormat = "yyyy/MM/dd";
            dtpExitDate.Format = DateTimePickerFormat.Custom;
            dtpExitDate.Location = new Point(698, 334);
            dtpExitDate.Name = "dtpExitDate";
            dtpExitDate.RightToLeftLayout = true;
            dtpExitDate.ShowCheckBox = true;
            dtpExitDate.Size = new Size(172, 27);
            dtpExitDate.TabIndex = 20;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(502, 387);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 23;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(151, 387);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 21;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRegisterNewVehicleImpound
            // 
            btnRegisterNewVehicleImpound.Location = new Point(665, 387);
            btnRegisterNewVehicleImpound.Name = "btnRegisterNewVehicleImpound";
            btnRegisterNewVehicleImpound.Size = new Size(94, 29);
            btnRegisterNewVehicleImpound.TabIndex = 24;
            btnRegisterNewVehicleImpound.Text = "حجز جديد";
            btnRegisterNewVehicleImpound.UseVisualStyleBackColor = true;
            btnRegisterNewVehicleImpound.Click += btnRegisterNewVehicleImpound_Click;
            // 
            // ntxtCarNo
            // 
            ntxtCarNo.IsInt = true;
            ntxtCarNo.Location = new Point(345, 5);
            ntxtCarNo.MaxLength = 4;
            ntxtCarNo.Name = "ntxtCarNo";
            ntxtCarNo.Size = new Size(64, 27);
            ntxtCarNo.TabIndex = 4;
            ntxtCarNo.TextChanged += ntxtCarNo_TextChanged;
            ntxtCarNo.Enter += ntxtCarNo_Enter;
            // 
            // lblVehicleSector
            // 
            lblVehicleSector.AutoSize = true;
            lblVehicleSector.Location = new Point(444, 296);
            lblVehicleSector.Name = "lblVehicleSector";
            lblVehicleSector.Size = new Size(88, 20);
            lblVehicleSector.TabIndex = 5;
            lblVehicleSector.Text = "مكان المركبة";
            // 
            // ddlVehicleSector
            // 
            ddlVehicleSector.FormattingEnabled = true;
            ddlVehicleSector.Items.AddRange(new object[] { "أ", "ب", "ج", "د", "ه", "و", "ز", "ح" });
            ddlVehicleSector.Location = new Point(700, 293);
            ddlVehicleSector.Name = "ddlVehicleSector";
            ddlVehicleSector.Size = new Size(59, 28);
            ddlVehicleSector.TabIndex = 18;
            // 
            // txtVehicleNoAlphabitics2
            // 
            txtVehicleNoAlphabitics2.Location = new Point(285, 5);
            txtVehicleNoAlphabitics2.MaxLength = 1;
            txtVehicleNoAlphabitics2.Name = "txtVehicleNoAlphabitics2";
            txtVehicleNoAlphabitics2.Size = new Size(21, 27);
            txtVehicleNoAlphabitics2.TabIndex = 0;
            txtVehicleNoAlphabitics2.TextChanged += txtVehicleNoAlphabitics2_TextChanged;
            // 
            // txtVehicleNoAlphabitics1
            // 
            txtVehicleNoAlphabitics1.Location = new Point(258, 5);
            txtVehicleNoAlphabitics1.MaxLength = 1;
            txtVehicleNoAlphabitics1.Name = "txtVehicleNoAlphabitics1";
            txtVehicleNoAlphabitics1.Size = new Size(21, 27);
            txtVehicleNoAlphabitics1.TabIndex = 0;
            txtVehicleNoAlphabitics1.TextChanged += txtVehicleNoAlphabitics1_TextChanged;
            // 
            // frmRegisterVehicles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 426);
            Controls.Add(ddlVehicleSector);
            Controls.Add(ntxtCarNo);
            Controls.Add(dtpExitDate);
            Controls.Add(dtpImpoundDate);
            Controls.Add(txtOwnerNationalIDNumber);
            Controls.Add(ddlVehicleType);
            Controls.Add(btnRegisterNewVehicleImpound);
            Controls.Add(btnSearch);
            Controls.Add(btnSave);
            Controls.Add(btnPrintQRCode);
            Controls.Add(txtCaseReportType);
            Controls.Add(txtDriverNationalIDNumber);
            Controls.Add(txtVehicleBrand);
            Controls.Add(txtVehicleImpoundNumber);
            Controls.Add(txtVehicleModel);
            Controls.Add(txtVehicleColor);
            Controls.Add(txtDriverName);
            Controls.Add(txtOwnerName);
            Controls.Add(txtCaseReportNumber);
            Controls.Add(txtVehicleEngineNumber);
            Controls.Add(txtVehicleChassisNumber);
            Controls.Add(txtVehicleNoAlphabitics1);
            Controls.Add(txtVehicleNoAlphabitics2);
            Controls.Add(txtVehicleNoAlphabitics3);
            Controls.Add(lblVehicleNo);
            Controls.Add(lblvehicleChassisNumber);
            Controls.Add(lblCaseReportType);
            Controls.Add(lblOwnerNationalIDNumber);
            Controls.Add(lblVehicleSector);
            Controls.Add(lblVehicleBrand);
            Controls.Add(lblDriverNationalIDNumber);
            Controls.Add(lblExitDate);
            Controls.Add(lblImpoundDate);
            Controls.Add(lblVehicleImpoundNumber);
            Controls.Add(lblVehicleModel);
            Controls.Add(lblVehicleColor);
            Controls.Add(lblDriverName);
            Controls.Add(lblOwnerName);
            Controls.Add(lblCaseReportNumber);
            Controls.Add(lblVehicleEngineNumber);
            Controls.Add(lblVehicleType);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRegisterVehicles";
            Text = "مرور الجيزة - تسجيل حجز المركبات";
            Load += frmFamilies_Load;
            ((System.ComponentModel.ISupportInitialize)errprovFormErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVehicleType;
        private Label lblVehicleNo;
        private Label lblvehicleChassisNumber;
        private Label lblVehicleEngineNumber;
        private Label lblCaseReportNumber;
        private TextBox txtVehicleNoAlphabitics3;
        private TextBox txtVehicleChassisNumber;
        private TextBox txtVehicleEngineNumber;
        private TextBox txtCaseReportNumber;
        private Button btnPrintQRCode;
        private ComboBox ddlVehicleType;
        private Label lblCaseReportType;
        private TextBox txtCaseReportType;
        private Label lblOwnerName;
        private TextBox txtOwnerName;
        private Label lblOwnerNationalIDNumber;
        private Utilities.NumericTextBox txtOwnerNationalIDNumber;
        private Label lblDriverName;
        private TextBox txtDriverName;
        private Label lblDriverNationalIDNumber;
        private Utilities.NumericTextBox txtDriverNationalIDNumber;
        private Label lblVehicleColor;
        private TextBox txtVehicleColor;
        private Label lblVehicleBrand;
        private TextBox txtVehicleBrand;
        private Label lblVehicleModel;
        private TextBox txtVehicleModel;
        private TextBox txtVehicleImpoundNumber;
        private Label lblVehicleImpoundNumber;
        private Label lblImpoundDate;
        private DateTimePicker dtpImpoundDate;
        private Label lblExitDate;
        private DateTimePicker dtpExitDate;
        private Button btnSearch;
        private Button btnSave;
        private Button btnRegisterNewVehicleImpound;
        private Utilities.NumericTextBox ntxtCarNo;
        private Label lblVehicleSector;
        private ComboBox ddlVehicleSector;
        private TextBox txtVehicleNoAlphabitics2;
        private TextBox txtVehicleNoAlphabitics1;
    }
}