namespace GizaTraffic
{
    partial class frmSearchVehicles
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchVehicles));
            lblSearchFor = new Label();
            txtSearchFor = new TextBox();
            btnSearch = new Button();
            dgvSearchResults = new DataGridView();
            btnPreviousPage = new Button();
            btnFirstPage = new Button();
            btnNextPage = new Button();
            btnLastPage = new Button();
            txtPageNumber = new Utilities.NumericTextBox();
            lblPage = new Label();
            lblPageInfo = new Label();
            lblRecordRange = new Label();
            lblFrom = new Label();
            lblNoOfSearchResultsLabel = new Label();
            lblNoOfSearchResults = new Label();
            cmbPageSize = new ComboBox();
            lblPageSize = new Label();
            ttControls = new ToolTip(components);
            pnlNavigationControls = new Panel();
            pnlSearchControls = new Panel();
            VehicleImpoundId = new DataGridViewTextBoxColumn();
            VehicleNo = new DataGridViewTextBoxColumn();
            OwnerName = new DataGridViewTextBoxColumn();
            VehicleImpoundNumber = new DataGridViewTextBoxColumn();
            VehicleSector = new DataGridViewTextBoxColumn();
            CaseReportNumber = new DataGridViewTextBoxColumn();
            CaseReportType = new DataGridViewTextBoxColumn();
            PrintText = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)errprovFormErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
            pnlNavigationControls.SuspendLayout();
            pnlSearchControls.SuspendLayout();
            SuspendLayout();
            // 
            // lblSearchFor
            // 
            lblSearchFor.AutoSize = true;
            lblSearchFor.Location = new Point(736, 8);
            lblSearchFor.Name = "lblSearchFor";
            lblSearchFor.Size = new Size(76, 20);
            lblSearchFor.TabIndex = 1;
            lblSearchFor.Text = "البحث عن :";
            // 
            // txtSearchFor
            // 
            txtSearchFor.Location = new Point(410, 8);
            txtSearchFor.Name = "txtSearchFor";
            txtSearchFor.PlaceholderText = "أدخل نص البحث";
            txtSearchFor.Size = new Size(271, 27);
            txtSearchFor.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(427, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.AllowUserToAddRows = false;
            dgvSearchResults.AllowUserToDeleteRows = false;
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchResults.Columns.AddRange(new DataGridViewColumn[] { VehicleImpoundId, VehicleNo, OwnerName, VehicleImpoundNumber, VehicleSector, CaseReportNumber, CaseReportType, PrintText });
            dgvSearchResults.Dock = DockStyle.Fill;
            dgvSearchResults.Location = new Point(0, 186);
            dgvSearchResults.MultiSelect = false;
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.ReadOnly = true;
            dgvSearchResults.RowHeadersWidth = 50;
            dgvSearchResults.Size = new Size(956, 673);
            dgvSearchResults.TabIndex = 2;
            dgvSearchResults.CellContentClick += dgvSearchResults_CellContentClick;
            dgvSearchResults.DoubleClick += dgvSearchResults_DoubleClick;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Enabled = false;
            btnPreviousPage.Location = new Point(586, 8);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(36, 29);
            btnPreviousPage.TabIndex = 4;
            btnPreviousPage.Text = "<";
            ttControls.SetToolTip(btnPreviousPage, "الصفحة السابقة");
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Enabled = false;
            btnFirstPage.Location = new Point(628, 8);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(36, 29);
            btnFirstPage.TabIndex = 5;
            btnFirstPage.Text = "|<";
            ttControls.SetToolTip(btnFirstPage, "أول صفحة");
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Enabled = false;
            btnNextPage.Location = new Point(409, 8);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(36, 29);
            btnNextPage.TabIndex = 6;
            btnNextPage.Text = ">";
            ttControls.SetToolTip(btnNextPage, "الصفحة التالية");
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnLastPage
            // 
            btnLastPage.Enabled = false;
            btnLastPage.Location = new Point(367, 8);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(36, 29);
            btnLastPage.TabIndex = 7;
            btnLastPage.Text = ">|";
            ttControls.SetToolTip(btnLastPage, "الصفحة الأخيرة");
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // txtPageNumber
            // 
            txtPageNumber.IsInt = true;
            txtPageNumber.Location = new Point(471, 9);
            txtPageNumber.Name = "txtPageNumber";
            txtPageNumber.Size = new Size(45, 27);
            txtPageNumber.TabIndex = 8;
            ttControls.SetToolTip(txtPageNumber, "الصفحة الحالية");
            txtPageNumber.KeyDown += txtPageNumber_KeyDown;
            txtPageNumber.Leave += txtPageNumber_Leave;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(522, 12);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(58, 20);
            lblPage.TabIndex = 9;
            lblPage.Text = "صفحة [";
            // 
            // lblPageInfo
            // 
            lblPageInfo.Dock = DockStyle.Top;
            lblPageInfo.Location = new Point(0, 161);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(956, 25);
            lblPageInfo.TabIndex = 10;
            // 
            // lblRecordRange
            // 
            lblRecordRange.Dock = DockStyle.Top;
            lblRecordRange.Location = new Point(0, 136);
            lblRecordRange.Name = "lblRecordRange";
            lblRecordRange.Size = new Size(956, 25);
            lblRecordRange.TabIndex = 11;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(451, 12);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(14, 20);
            lblFrom.TabIndex = 12;
            lblFrom.Text = "]";
            // 
            // lblNoOfSearchResultsLabel
            // 
            lblNoOfSearchResultsLabel.AutoSize = true;
            lblNoOfSearchResultsLabel.Location = new Point(681, 44);
            lblNoOfSearchResultsLabel.Name = "lblNoOfSearchResultsLabel";
            lblNoOfSearchResultsLabel.Size = new Size(0, 20);
            lblNoOfSearchResultsLabel.TabIndex = 14;
            // 
            // lblNoOfSearchResults
            // 
            lblNoOfSearchResults.AutoSize = true;
            lblNoOfSearchResults.Location = new Point(701, 44);
            lblNoOfSearchResults.Name = "lblNoOfSearchResults";
            lblNoOfSearchResults.Size = new Size(114, 20);
            lblNoOfSearchResults.TabIndex = 1;
            lblNoOfSearchResults.Text = "عدد نتائج البحث :";
            // 
            // cmbPageSize
            // 
            cmbPageSize.FormattingEnabled = true;
            cmbPageSize.Items.AddRange(new object[] { "2", "10", "25", "50", "100" });
            cmbPageSize.Location = new Point(216, 8);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(43, 28);
            cmbPageSize.TabIndex = 15;
            cmbPageSize.Text = "25";
            cmbPageSize.SelectedIndexChanged += cmbPageSize_SelectedIndexChanged;
            // 
            // lblPageSize
            // 
            lblPageSize.AutoSize = true;
            lblPageSize.Location = new Point(265, 12);
            lblPageSize.Name = "lblPageSize";
            lblPageSize.Size = new Size(96, 20);
            lblPageSize.TabIndex = 16;
            lblPageSize.Text = "حجم الصفحة :";
            // 
            // pnlNavigationControls
            // 
            pnlNavigationControls.Controls.Add(btnFirstPage);
            pnlNavigationControls.Controls.Add(cmbPageSize);
            pnlNavigationControls.Controls.Add(lblPageSize);
            pnlNavigationControls.Controls.Add(btnPreviousPage);
            pnlNavigationControls.Controls.Add(lblPage);
            pnlNavigationControls.Controls.Add(txtPageNumber);
            pnlNavigationControls.Controls.Add(lblFrom);
            pnlNavigationControls.Controls.Add(btnNextPage);
            pnlNavigationControls.Controls.Add(btnLastPage);
            pnlNavigationControls.Dock = DockStyle.Top;
            pnlNavigationControls.Location = new Point(0, 85);
            pnlNavigationControls.Name = "pnlNavigationControls";
            pnlNavigationControls.RightToLeft = RightToLeft.Yes;
            pnlNavigationControls.Size = new Size(956, 51);
            pnlNavigationControls.TabIndex = 17;
            // 
            // pnlSearchControls
            // 
            pnlSearchControls.Controls.Add(lblSearchFor);
            pnlSearchControls.Controls.Add(txtSearchFor);
            pnlSearchControls.Controls.Add(lblNoOfSearchResultsLabel);
            pnlSearchControls.Controls.Add(btnSearch);
            pnlSearchControls.Controls.Add(lblNoOfSearchResults);
            pnlSearchControls.Dock = DockStyle.Top;
            pnlSearchControls.Location = new Point(0, 0);
            pnlSearchControls.Name = "pnlSearchControls";
            pnlSearchControls.Size = new Size(956, 85);
            pnlSearchControls.TabIndex = 18;
            // 
            // VehicleImpoundId
            // 
            VehicleImpoundId.DataPropertyName = "VehicleImpoundId";
            VehicleImpoundId.HeaderText = "مسلسل التسجيل";
            VehicleImpoundId.MinimumWidth = 6;
            VehicleImpoundId.Name = "VehicleImpoundId";
            VehicleImpoundId.ReadOnly = true;
            VehicleImpoundId.Visible = false;
            VehicleImpoundId.Width = 125;
            // 
            // VehicleNo
            // 
            VehicleNo.DataPropertyName = "VehicleNo";
            VehicleNo.HeaderText = "رقم المركبة";
            VehicleNo.MinimumWidth = 6;
            VehicleNo.Name = "VehicleNo";
            VehicleNo.ReadOnly = true;
            VehicleNo.Width = 125;
            // 
            // OwnerName
            // 
            OwnerName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OwnerName.DataPropertyName = "OwnerName";
            OwnerName.HeaderText = "اسم صاحب المركبة";
            OwnerName.MinimumWidth = 6;
            OwnerName.Name = "OwnerName";
            OwnerName.ReadOnly = true;
            // 
            // VehicleImpoundNumber
            // 
            VehicleImpoundNumber.DataPropertyName = "VehicleImpoundNumber";
            VehicleImpoundNumber.HeaderText = "رقم الحجز";
            VehicleImpoundNumber.MinimumWidth = 6;
            VehicleImpoundNumber.Name = "VehicleImpoundNumber";
            VehicleImpoundNumber.ReadOnly = true;
            VehicleImpoundNumber.Width = 125;
            // 
            // VehicleSector
            // 
            VehicleSector.DataPropertyName = "VehicleSector";
            VehicleSector.HeaderText = "مكان المركبة";
            VehicleSector.MinimumWidth = 6;
            VehicleSector.Name = "VehicleSector";
            VehicleSector.ReadOnly = true;
            VehicleSector.Width = 125;
            // 
            // CaseReportNumber
            // 
            CaseReportNumber.DataPropertyName = "CaseReportNumber";
            CaseReportNumber.HeaderText = "رقم المحضر";
            CaseReportNumber.MinimumWidth = 6;
            CaseReportNumber.Name = "CaseReportNumber";
            CaseReportNumber.ReadOnly = true;
            CaseReportNumber.Width = 125;
            // 
            // CaseReportType
            // 
            CaseReportType.DataPropertyName = "CaseReportType";
            CaseReportType.HeaderText = "نوع المحضر";
            CaseReportType.MinimumWidth = 6;
            CaseReportType.Name = "CaseReportType";
            CaseReportType.ReadOnly = true;
            CaseReportType.Width = 125;
            // 
            // PrintText
            // 
            PrintText.FlatStyle = FlatStyle.System;
            PrintText.HeaderText = "";
            PrintText.MinimumWidth = 6;
            PrintText.Name = "PrintText";
            PrintText.ReadOnly = true;
            PrintText.Text = "طباعة";
            PrintText.ToolTipText = "طباعة بيانات الحجز";
            PrintText.UseColumnTextForButtonValue = true;
            PrintText.Width = 50;
            // 
            // frmSearchVehicles
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(956, 859);
            Controls.Add(dgvSearchResults);
            Controls.Add(lblPageInfo);
            Controls.Add(lblRecordRange);
            Controls.Add(pnlNavigationControls);
            Controls.Add(pnlSearchControls);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSearchVehicles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مرور الجيزة - البحث عن مركبة";
            Load += frmSearchVehicles_Load;
            ((System.ComponentModel.ISupportInitialize)errprovFormErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            pnlNavigationControls.ResumeLayout(false);
            pnlNavigationControls.PerformLayout();
            pnlSearchControls.ResumeLayout(false);
            pnlSearchControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblSearchFor;
        private TextBox txtSearchFor;
        private Button btnSearch;
        private DataGridView dgvSearchResults;
        private Button btnPreviousPage;
        private Button btnFirstPage;
        private Button btnNextPage;
        private Button btnLastPage;
        private Utilities.NumericTextBox txtPageNumber;
        private Label lblPage;
        private Label lblPageInfo;
        private Label lblRecordRange;
        private Label lblFrom;
        private Label lblNoOfSearchResultsLabel;
        private Label lblNoOfSearchResults;
        private ComboBox cmbPageSize;
        private Label lblPageSize;
        private ToolTip ttControls;
        private Panel pnlNavigationControls;
        private Panel pnlSearchControls;
        private DataGridViewTextBoxColumn VehicleImpoundId;
        private DataGridViewTextBoxColumn VehicleNo;
        private DataGridViewTextBoxColumn OwnerName;
        private DataGridViewTextBoxColumn VehicleImpoundNumber;
        private DataGridViewTextBoxColumn VehicleSector;
        private DataGridViewTextBoxColumn CaseReportNumber;
        private DataGridViewTextBoxColumn CaseReportType;
        private DataGridViewButtonColumn PrintText;
    }
}