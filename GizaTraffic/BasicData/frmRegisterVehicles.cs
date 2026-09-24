using GizaTraffic.BaseForms;
using GizaTraffic.Models;
using GizaTraffic.Repositories;
using GizaTraffic.Settings;
using QRCoder;
using System.Drawing.Printing;
using Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace GizaTraffic.BasicData
{
    public partial class frmRegisterVehicles : frmBase
    {

        #region Form Members

        int vehicleImpoundID;
        private bool _convertingNumbers;

        #endregion

        #region Constructor

        public frmRegisterVehicles(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        void DisplayVehicleImpound(VehicleImpound vehicleImpound)
        {
            EmptyScreen();
            txtCaseReportNumber.Text = vehicleImpound.CaseReportNumber;
            txtCaseReportType.Text = vehicleImpound.CaseReportType;
            txtDriverName.Text = vehicleImpound.DriverName;
            txtDriverNationalIDNumber.Text = vehicleImpound.DriverNationalIDNumber;
            if (vehicleImpound.ExitDate == null)
            {
                dtpExitDate.Value = DateTime.Now;
                dtpExitDate.Checked = false;
            }
            else
                dtpExitDate.Value = vehicleImpound.ExitDate ?? DateTime.Now;
            if (vehicleImpound.ImpoundDate == null)
            {
                dtpImpoundDate.Value = DateTime.Now;
                dtpImpoundDate.Checked = false;
            }
            else
                dtpImpoundDate.Value = vehicleImpound.ImpoundDate ?? DateTime.Now;
            txtOwnerName.Text = vehicleImpound.OwnerName;
            txtOwnerNationalIDNumber.Text = vehicleImpound.OwnerNationalIDNumber;
            txtVehicleBrand.Text = vehicleImpound.VehicleBrand;
            txtVehicleModel.Text = vehicleImpound.VehicleModel;
            txtVehicleChassisNumber.Text = vehicleImpound.VehicleChassisNumber;
            txtVehicleColor.Text = vehicleImpound.VehicleColor;
            txtVehicleEngineNumber.Text = vehicleImpound.VehicleEngineNumber;
            txtVehicleImpoundNumber.Text = vehicleImpound.VehicleImpoundNumber;
            ddlVehicleType.Text = vehicleImpound.VehicleType;
            ddlVehicleSector.Text = vehicleImpound.VehicleSector;
            if (vehicleImpound.VehicleNo != null)
                DisplayVehicleNo(vehicleImpound.VehicleNo);
        }
        bool ValidateForm()
        {
            errprovFormErrorProvider.Clear();
            bool bIsFormValid = true;

            if (string.IsNullOrWhiteSpace(txtVehicleImpoundNumber.Text))
            {
                errprovFormErrorProvider.SetError(txtVehicleImpoundNumber, "يجب إدخال رقم حجز المركبة");
                bIsFormValid = false;
            }
            if (string.IsNullOrWhiteSpace(ddlVehicleSector.Text))
            {
                errprovFormErrorProvider.SetError(ddlVehicleSector, "يجب إدخال مكان المركبة");
                bIsFormValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtCaseReportNumber.Text))
            {
                errprovFormErrorProvider.SetError(txtCaseReportNumber, "يجب إدخال رقم المحضر");
                bIsFormValid = false;
            }
            return bIsFormValid;
        }
        void EmptyScreen()
        {
            errprovFormErrorProvider.Clear();
            vehicleImpoundID = 0;
            dtpExitDate.Value = dtpImpoundDate.Value = DateTime.Now;
            dtpExitDate.Checked = dtpImpoundDate.Checked = false;
            ntxtCarNo.Text = txtVehicleNoAlphabitics1.Text = txtVehicleNoAlphabitics2.Text = txtCaseReportNumber.Text = txtCaseReportType.Text = txtDriverName.Text = txtDriverNationalIDNumber.Text = txtOwnerName.Text = txtOwnerNationalIDNumber.Text = txtVehicleBrand.Text = txtVehicleNoAlphabitics3.Text = txtVehicleModel.Text = txtVehicleChassisNumber.Text = txtVehicleColor.Text = txtVehicleEngineNumber.Text = txtVehicleImpoundNumber.Text = txtVehicleModel.Text = string.Empty;
            ddlVehicleSector.Text = ddlVehicleType.Text = string.Empty;
            ddlVehicleSector.SelectedIndex = ddlVehicleType.SelectedIndex = -1;
            txtVehicleNoAlphabitics1.Focus();
        }
        private async Task PrintQRCode()
        {
            var settings = await _unitOfWork.repProgramSettings.GetOne(x => x.ProgramSettingID > 0);
            if (settings == null || string.IsNullOrWhiteSpace(AppSettings.Default.PrinterName))
            {
                Helper.ShowMessage("لم يتم تحديد طابعة للطباعة");
                return;
            }
            if (vehicleImpoundID > 0)
            {
                var vehicleImpound = await _unitOfWork.repVehiclesImpounds.Get(vehicleImpoundID);
                if (vehicleImpound != null)
                {
                    string qrCodeText = $"{settings.QRCodeHeader}\n{vehicleImpound}\n{settings.QRCodeFooter}";
                    QRCodeGenerator qrCodeGenerator = new();
                    QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
                    using PngByteQRCode qrCode = new(qrCodeData);

                    byte[] qrCodeBytes = qrCode.GetGraphic(20);
                    using MemoryStream stream = new(qrCodeBytes);
                    using System.Drawing.Image tempImage = System.Drawing.Image.FromStream(stream);
                    using Bitmap qrImage = new(tempImage);
                    using PrintDocument printDocument = new();
                    printDocument.PrinterSettings.PrinterName = AppSettings.Default.PrinterName;
                    if (!printDocument.PrinterSettings.IsValid)
                    {
                        Helper.ShowMessage($"الطابعة {AppSettings.Default.PrinterName} غير صالحة");
                    }
                    printDocument.PrintPage += (sender, e) =>
                    {
                        e.Graphics?.DrawString($"رقم الحجز : {vehicleImpound.VehicleImpoundNumber} - مكان الحجز : {vehicleImpound.VehicleSector}", new System.Drawing.Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(100, 50));
                        e.Graphics?.DrawImage(qrImage, new Rectangle(100, 100, 300, 300));
                    };

                    printDocument.Print();
                }
            }
            else
            {
                Helper.ShowMessage("يجب حفظ بيانات السيارة أولاً قبل طباعة QR Code");
            }
        }
        async Task<string> PrintQRCodeImage()
        {
            var settings = await _unitOfWork.repProgramSettings.GetOne(x => x.ProgramSettingID > 0);
            if (settings == null || string.IsNullOrWhiteSpace(AppSettings.Default.PrintingPath))
            {
                Helper.ShowMessage("لم يتم تحديد مسار حفظ QR Code");
                return string.Empty;
            }
            if (vehicleImpoundID > 0)
            {
                var vehicleImpound = await _unitOfWork.repVehiclesImpounds.Get(vehicleImpoundID);
                if (vehicleImpound != null)
                {
                    string qrCodeText = $"{settings.QRCodeHeader}\n{vehicleImpound}\n{settings.QRCodeFooter}";
                    QRCodeGenerator qrCodeGenerator = new();
                    QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
                    using PngByteQRCode qrCode = new(qrCodeData);
                    byte[] qrCodeBytes = qrCode.GetGraphic(20);
                    using MemoryStream stream = new(qrCodeBytes);
                    using System.Drawing.Image tempImage = System.Drawing.Image.FromStream(stream);
                    using Bitmap qrImage = new(tempImage);
                    int imageWidth = 500;
                    int imageHeight = 500;

                    using Bitmap finalImage = new(imageWidth, imageHeight);

                    using (Graphics graphics = Graphics.FromImage(finalImage))
                    {
                        graphics.Clear(Color.White);

                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        // Text
                        using System.Drawing.Font font = new("Arial", 16, FontStyle.Bold);

                        string information = $"رقم الحجز : {vehicleImpound.VehicleImpoundNumber} - مكان الحجز : {vehicleImpound.VehicleSector}";

                        using StringFormat stringFormat = new();

                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        RectangleF textRectangle = new(20, 20, imageWidth - 40, 60);

                        graphics.DrawString(information, font, Brushes.Black, textRectangle, stringFormat);

                        // QR Code
                        graphics.DrawImage(qrImage, new Rectangle(100, 100, 300, 300));
                    }

                    // -----------------------------
                    // Save image
                    // -----------------------------

                    string folderPath = Path.Combine(AppSettings.Default.PrintingPath);
                    Directory.CreateDirectory(folderPath);
                    string fileName = $"QRCode_{vehicleImpound.VehicleImpoundNumber}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    string filePath = Path.Combine(folderPath, fileName);
                    finalImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    return filePath;
                }
            }
            else
            {
                Helper.ShowMessage("يجب حفظ بيانات السيارة أولاً قبل حفظ QR Code");
            }
            return string.Empty;
        }
        void DisplayVehicleNo(string vehicleNo)
        {
            if (string.IsNullOrWhiteSpace(vehicleNo))
                return;
            string vehicleNoWithoutSpaces = vehicleNo.Replace(" ", string.Empty);
            if (vehicleNoWithoutSpaces.Length < 4)
            {
                txtVehicleNoAlphabitics3.Text = ArabicNumbers.ToArabicDigits(vehicleNoWithoutSpaces);
                return;
            }
            string strIntegralPart = vehicleNoWithoutSpaces.Substring(vehicleNo.Length - 4, 4);
            ntxtCarNo.Text = ArabicNumbers.ToArabicDigits(strIntegralPart);
            string strAlphabiticsPart = vehicleNoWithoutSpaces[..^4];
            txtVehicleNoAlphabitics1.Text = ArabicNumbers.ToArabicDigits(strAlphabiticsPart.Length > 0 ? strAlphabiticsPart[..1] : string.Empty);
            txtVehicleNoAlphabitics2.Text = ArabicNumbers.ToArabicDigits(strAlphabiticsPart.Length > 1 ? strAlphabiticsPart.Substring(1, 1) : string.Empty);
            txtVehicleNoAlphabitics3.Text = ArabicNumbers.ToArabicDigits(strAlphabiticsPart.Length > 2 ? strAlphabiticsPart.Substring(2, 1) : string.Empty);
            txtVehicleNoAlphabitics1.Focus();
        }

        #endregion

        #region Events Handlers

        private async void frmFamilies_Load(object sender, EventArgs e)
        {
            //await GetNextFamilyNo();
        }
        private async void txtFamilyCardCode_Leave(object? sender, EventArgs? e)
        {
            try
            {
                //if (!string.IsNullOrWhiteSpace(txtFamilyCardCode.Text))
                //{
                //    if (await _unitOfWork.repFamilies.Any(x => x.FamilyCardCode == txtFamilyCardCode.Text))
                //    {
                //        Family fmly = await _unitOfWork.repFamilies.GetOne(x => x.FamilyCardCode == txtFamilyCardCode.Text) ?? new();
                //        await DisplayFamily(fmly);
                //    }
                //}
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    VehicleImpound vehicleImpound = new()
                    {
                        VehicleImpoundId = vehicleImpoundID,
                        CaseReportNumber = txtCaseReportNumber.Text,
                        CaseReportType = txtCaseReportType.Text,
                        DriverName = txtDriverName.Text,
                        DriverNationalIDNumber = txtDriverNationalIDNumber.Text,
                        ExitDate = dtpExitDate.Checked ? dtpExitDate.Value : null,
                        ImpoundDate = dtpImpoundDate.Checked ? dtpImpoundDate.Value : null,
                        OwnerName = txtOwnerName.Text,
                        OwnerNationalIDNumber = txtOwnerNationalIDNumber.Text,
                        VehicleBrand = txtVehicleBrand.Text,
                        VehicleNo = ArabicNumbers.ToArabicDigits(txtVehicleNoAlphabitics1.Text + txtVehicleNoAlphabitics2.Text + txtVehicleNoAlphabitics3.Text + ntxtCarNo.Text),
                        VehicleModel = txtVehicleModel.Text,
                        VehicleChassisNumber = txtVehicleChassisNumber.Text,
                        VehicleColor = txtVehicleColor.Text,
                        VehicleEngineNumber = txtVehicleEngineNumber.Text,
                        VehicleImpoundNumber = txtVehicleImpoundNumber.Text,
                        VehicleType = ddlVehicleType.Text,
                        VehicleSector = ddlVehicleSector.Text
                    };

                    if (vehicleImpoundID > 0)
                        await _unitOfWork.repVehiclesImpounds.Update(vehicleImpound, vehicleImpoundID);
                    else
                        await _unitOfWork.repVehiclesImpounds.Add(vehicleImpound);
                    await _unitOfWork.Complete();
                    vehicleImpoundID = vehicleImpound.VehicleImpoundId;
                    var savedImagePath = await PrintQRCodeImage();
                    EmptyScreen();
                    if (vehicleImpoundID > 0)
                        Helper.ShowMessage("تم تعديل بيانات حجز السيارة بنجاح");
                    else
                        Helper.ShowMessage($"تم حفظ بيانات حجز السيارة بنجاح\nمسار حفظ الQR Code :\n{savedImagePath}");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchVehicles searchVehicles = new frmSearchVehicles(_unitOfWork);
                searchVehicles.ShowDialog(this);
                if (searchVehicles.CurrentVehicleImpoundID > 0)
                {
                    VehicleImpound vehicleImpound = await _unitOfWork.repVehiclesImpounds.GetOne(x => x.VehicleImpoundId == searchVehicles.CurrentVehicleImpoundID) ?? new();
                    DisplayVehicleImpound(vehicleImpound);
                    vehicleImpoundID = searchVehicles.CurrentVehicleImpoundID;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }
        private void btnRegisterNewVehicleImpound_Click(object sender, EventArgs e)
        {
            try
            {
                EmptyScreen();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
                throw;
            }
        }
        private async void btnPrintQRCode_Click(object sender, EventArgs e)
        {
            if (vehicleImpoundID <= 0)
            {
                Helper.ShowMessage("لم يتم الحفظ يجب الحفظ أولا قبل الطباعة");
                return;
            }
            await PrintQRCode();
        }
        private void ntxtCarNo_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void ntxtCarNo_TextChanged(object sender, EventArgs e)
        {
            if (_convertingNumbers)
                return;

            string converted = ArabicNumbers.ToArabicDigits(ntxtCarNo.Text);

            if (ntxtCarNo.Text != converted)
            {
                _convertingNumbers = true;

                int cursorPosition = ntxtCarNo.SelectionStart;

                ntxtCarNo.Text = converted;

                ntxtCarNo.SelectionStart = Math.Min(cursorPosition, ntxtCarNo.Text.Length);

                _convertingNumbers = false;
            }
        }
        private void txtVehicleNoAlphabitics3_TextChanged(object sender, EventArgs e)
        {
            ntxtCarNo.Focus();
        }
        private void txtVehicleNoAlphabitics2_TextChanged(object sender, EventArgs e)
        {
            txtVehicleNoAlphabitics3.Focus();
        }
        private void txtVehicleNoAlphabitics1_TextChanged(object sender, EventArgs e)
        {
            txtVehicleNoAlphabitics2.Focus();
        }
        private async void txtVehicleImpoundNumber_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtVehicleImpoundNumber.Text))
            {
                if (await _unitOfWork.repVehiclesImpounds.Any(x => x.VehicleImpoundNumber == txtVehicleImpoundNumber.Text && x.VehicleImpoundId != vehicleImpoundID))
                {
                    Helper.ShowMessage("رقم حجز المركبة موجود مسبقاً");
                    txtVehicleImpoundNumber.Focus();
                }
            }
        }

        #endregion

    }
}