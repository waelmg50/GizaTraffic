using GizaTraffic.BaseForms;
using GizaTraffic.DTOs.VehiclesImpound;
using GizaTraffic.Models;
using GizaTraffic.Repositories;
using GizaTraffic.Repositories.SortingAndPagination;
using GizaTraffic.Settings;
using System.Drawing.Printing;
using Utilities;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace GizaTraffic
{
    public partial class frmSearchVehicles : frmBase
    {

        #region Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentVehicleImpoundID { get; set; }
        private int _currentPage = 1;
        private int _pageSize = 50;
        private int _totalPages = 1;
        private int _totalRecords = 0;
        private bool _isLoading;

        #endregion

        #region Constructor

        public frmSearchVehicles(UnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            InitializeComponent();
        }

        #endregion

        #region Events Handlers

        private async void frmSearchVehicles_Load(object sender, EventArgs e)
        {
            try
            {
                cmbPageSize.SelectedItem = _pageSize.ToString();
                _currentPage = 1;
                await LoadSearchResultsAsync();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // Always start a new search from page 1
            _currentPage = 1;
            await LoadSearchResultsAsync();
        }
        private void dgvSearchResults_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSearchResults.CurrentRow != null && dgvSearchResults.CurrentRow.DataBoundItem is VehiclesImpoundDto selectedVehicle)
            {
                object? vehicleImpoundIdValue = dgvSearchResults.CurrentRow.Cells["VehicleImpoundId"].Value;
                CurrentVehicleImpoundID = vehicleImpoundIdValue != null ? Convert.ToInt32(vehicleImpoundIdValue) : 0;
                Close();
            }
        }
        private async void txtPageNumber_Leave(object sender, EventArgs e)
        {
            await GoToPageAsync();
        }
        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage >= _totalPages)
                return;

            _currentPage++;

            await LoadSearchResultsAsync();
        }
        private async void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;
            _currentPage = 1;
            await LoadSearchResultsAsync();
        }
        private async void btnLastPage_Click(object sender, EventArgs e)
        {
            if (_currentPage >= _totalPages)
                return;
            _currentPage = _totalPages;
            await LoadSearchResultsAsync();
        }
        private async void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;
            _currentPage--;
            await LoadSearchResultsAsync();
        }
        private async void txtPageNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            e.Handled = true;
            await GoToPageAsync();
        }
        private async void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPageSize.SelectedItem == null)
                return;


            _pageSize =
                Convert.ToInt32(
                    cmbPageSize.SelectedItem);


            // Changing page size starts from page 1
            _currentPage = 1;


            await LoadSearchResultsAsync();

        }
        private async void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var settings = await _unitOfWork.repProgramSettings.GetOne(x => x.ProgramSettingID > 0);
                if (settings == null)
                {
                    Helper.ShowMessage("لم يتم إدخال إعدادات الطباعة");
                    return;
                }
                if (e.ColumnIndex == dgvSearchResults.Columns["PrintText"]?.Index && e.RowIndex >= 0)
                {
                    if (dgvSearchResults.CurrentRow != null && dgvSearchResults.CurrentRow.DataBoundItem is VehiclesImpoundDto selectedVehicle)
                    {
                        VehicleImpound? vehicleImpound = await _unitOfWork.repVehiclesImpounds.GetOne(x => x.VehicleImpoundId == selectedVehicle.VehicleImpoundId);
                        if (vehicleImpound != null)
                        {
                            string printText = vehicleImpound.ToString();
                            PrintDialog printDialog = new();

                            PrintDocument printDocument = new();
                            using System.Drawing.Font font = new("Arial", 12);

                            using StringFormat format = new(StringFormatFlags.DirectionRightToLeft)
                            {
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Near
                            };
                            printDocument.PrintPage += (sender, e) =>
                            {
                                RectangleF textArea = new(
                                    20,                         // Left margin
                                    50,                         // Top margin
                                    e.PageBounds.Width - 40,    // Width
                                    e.PageBounds.Height - 70    // Height
                                );

                                e.Graphics?.DrawString($"{settings.QRCodeHeader}\n{printText}\n{settings.QRCodeFooter}", font, Brushes.Black, textArea, format);
                            };
                            printDialog.Document = printDocument;
                            if (printDialog.ShowDialog(this) == DialogResult.OK)
                            {
                                printDocument.PrinterSettings = printDialog.PrinterSettings;
                                printDocument.Print();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Methods

        private async Task LoadSearchResultsAsync()
        {
            try
            {
                if (_isLoading)
                    return;
                _isLoading = true;
                string searchText = txtSearchFor.Text.Trim().ToLower();
                string arabicText = ArabicNumbers.ToArabicDigits(txtSearchFor.Text.Trim().ToLower());
                var result = await _unitOfWork.repVehiclesImpounds.Get(x =>
                (x.OwnerName != null && x.OwnerName.ToLower().Contains(searchText)) ||
                (x.CaseReportType != null && x.CaseReportType.ToLower().Contains(searchText)) ||
                (x.VehicleType != null && x.VehicleType.ToLower().Contains(searchText)) ||
                (x.CaseReportNumber != null && x.CaseReportNumber.ToLower().Contains(searchText)) ||
                (x.DriverName != null && x.DriverName.ToLower().Contains(searchText)) ||
                (x.DriverNationalIDNumber != null && x.DriverNationalIDNumber.ToLower().Contains(searchText)) ||
                (x.OwnerNationalIDNumber != null && x.OwnerNationalIDNumber.ToLower().Contains(searchText)) ||
                (x.VehicleBrand != null && x.VehicleBrand.ToLower().Contains(searchText)) ||
                (x.VehicleModel != null && x.VehicleModel.ToLower().Contains(searchText)) ||
                (x.VehicleNo != null && x.VehicleNo.ToLower().Contains(arabicText)) ||
                (x.VehicleChassisNumber != null && x.VehicleChassisNumber.ToLower().Contains(searchText)) ||
                (x.VehicleEngineNumber != null && x.VehicleEngineNumber.ToLower().Contains(searchText)) ||
                (x.VehicleColor != null && x.VehicleColor.ToLower().Contains(searchText)) ||
                x.VehicleImpoundNumber.ToLower().Contains(searchText) ||
                x.VehicleSector == searchText, x => new VehiclesImpoundDto() { CaseReportNumber = x.CaseReportNumber, CaseReportType = x.CaseReportType, OwnerName = x.OwnerName, VehicleImpoundId = x.VehicleImpoundId, VehicleImpoundNumber = x.VehicleImpoundNumber, VehicleNo = x.VehicleNo, VehicleSector = x.VehicleSector },
                [
                    //new SortColumn<VehicleImpound>() { Expression = x => x.VehicleNo, Ascending = true },
                new SortColumn<VehicleImpound>() { Expression = x => x.VehicleImpoundId, Ascending = false }
                ], _currentPage, _pageSize);

                _totalRecords = result.TotalCount;
                _totalPages = result.TotalPages;
                // If there are no records
                if (_totalRecords == 0)
                {
                    _currentPage = 1;
                }
                else if (_currentPage > _totalPages)
                {
                    _currentPage = _totalPages;
                    // Reload using corrected page number
                    await LoadSearchResultsAsync(); return;
                }
                lblNoOfSearchResultsLabel.Text = _totalRecords.ToString();
                foreach (var item in result.Items)
                {
                    item.VehicleNo = VehicleImpound.DisplayVehicleNo(item.VehicleNo ?? string.Empty);
                }
                dgvSearchResults.DataSource = result.Items;
                UpdatePaginationUI();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            finally
            {
                _isLoading = false;
            }
        }
        private async Task GoToPageAsync()
        {
            if (!int.TryParse(txtPageNumber.Text.Trim(), out int pageNumber))
            {
                Helper.ShowMessage(
                    "من فضلك أدخل رقم صفحة صحيح");

                txtPageNumber.Focus();
                txtPageNumber.SelectAll();

                return;
            }

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            // Don't allow a page that doesn't exist
            if (pageNumber > _totalPages)
            {
                pageNumber = _totalPages;
            }
            if (pageNumber == _currentPage)
            {
                txtPageNumber.Text =
                    _currentPage.ToString();

                return;
            }

            _currentPage = pageNumber;

            await LoadSearchResultsAsync();
        }
        private void UpdatePaginationUI()
        {
            // --------------------------------------------------------
            // Page information
            // --------------------------------------------------------

            lblPageInfo.Text = $"صفحة {_currentPage} من {_totalPages}";


            // --------------------------------------------------------
            // Page number TextBox
            // --------------------------------------------------------

            txtPageNumber.Text = _currentPage.ToString();


            // --------------------------------------------------------
            // Buttons
            // --------------------------------------------------------

            bool hasPrevious = _currentPage > 1;

            bool hasNext = _currentPage < _totalPages;


            btnFirstPage.Enabled = hasPrevious;

            btnPreviousPage.Enabled = hasPrevious;

            btnNextPage.Enabled = hasNext;

            btnLastPage.Enabled = hasNext;


            // --------------------------------------------------------
            // Record range
            // --------------------------------------------------------

            if (_totalRecords == 0)
            {
                lblRecordRange.Text = "لا يوجد سجلات";

                return;
            }


            int firstRecord = ((_currentPage - 1) * _pageSize) + 1;


            int lastRecord = Math.Min(_currentPage * _pageSize, _totalRecords);


            lblRecordRange.Text = $"إظهار {firstRecord} - {lastRecord} من {_totalRecords}";

        }

        #endregion

    }
}
