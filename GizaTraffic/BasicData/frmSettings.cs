using GizaTraffic.BaseForms;
using GizaTraffic.Models;
using GizaTraffic.Repositories;
using GizaTraffic.Settings;
using Utilities;

namespace GizaTraffic.BasicData
{
    public partial class frmSettings : frmBase
    {

        #region Members

        private int CurrentProgramSettingID { get; set; }

        #endregion

        #region Constructor

        public frmSettings(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        bool ValidateForm()
        {
            errprovFormErrorProvider.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(ddlPrinterName.Text))
            {
                errprovFormErrorProvider.SetError(ddlPrinterName, "اختر طابعة ال QR Code");
                isValid = false;
            }
            if(string.IsNullOrWhiteSpace(txtPriningPath.Text))
            {
                errprovFormErrorProvider.SetError(txtPriningPath, "اختر مسار حفظ ال QR Code");
                isValid = false;
            }
            return isValid;
        }

        #endregion

        #region Event Handlers

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ProgramSetting programSetting = new() { ProgramSettingID = CurrentProgramSettingID, QRCodeFooter = txtReceiptFooter.Text, QRCodeHeader = txtRecieptHeader.Text };

                if (CurrentProgramSettingID > 0)
                    await _unitOfWork.repProgramSettings.Update(programSetting, CurrentProgramSettingID);
                else
                    await _unitOfWork.repProgramSettings.Add(programSetting);
                await _unitOfWork.Complete();
                AppSettings.Default.PrinterName = ddlPrinterName.Text;
                AppSettings.Default.PrintingPath = txtPriningPath.Text;
                AppSettings.Default.Save();
                Helper.ShowMessage(Resources.Messages.SaveSuccessfull);
            }
        }
        private async void FrmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
                    ddlPrinterName.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters[i]);
                if (await _unitOfWork.repProgramSettings.Any(x => x.ProgramSettingID > 0))
                {
                    ProgramSetting programSetting = await _unitOfWork.repProgramSettings.GetOne(x => x.ProgramSettingID > 0) ?? new ProgramSetting();
                    if (programSetting != null)
                    {
                        CurrentProgramSettingID = programSetting.ProgramSettingID;
                        txtReceiptFooter.Text = programSetting.QRCodeFooter;
                        txtRecieptHeader.Text = programSetting.QRCodeHeader;
                    }
                    if(!string.IsNullOrWhiteSpace(AppSettings.Default.PrinterName))
                        ddlPrinterName.SelectedItem = AppSettings.Default.PrinterName;
                    if(!string.IsNullOrWhiteSpace(AppSettings.Default.PrintingPath))
                        txtPriningPath.Text = AppSettings.Default.PrintingPath;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }

        #endregion

        private void btnBrowsePrintingPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog printingPath = new FolderBrowserDialog();
            if (printingPath.ShowDialog() == DialogResult.OK)
            {
                txtPriningPath.Text = printingPath.SelectedPath;
            }
        }
    }
}
