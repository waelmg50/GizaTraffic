using GizaTraffic.DBContext;
using GizaTraffic.Models;
using GizaTraffic.Repositories;
using Utilities;

namespace GizaTraffic
{
    public partial class frmLogin : BaseForms.frmBase
    {

        public frmLogin(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            bool bIsFormValid = true;
            errprovFormErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errprovFormErrorProvider.SetError(txtUserName, "أدخل اسم المستخدم");
                bIsFormValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errprovFormErrorProvider.SetError(txtPassword, "أدخل كلمة المرور");
                bIsFormValid = false;
            }
            if (!bIsFormValid)
                return;
            
            //if (await _unitOfWork.repEmployees.Any(x => x.UserName == txtUserName.Text))
            //{
            //    Employee emp = (await _unitOfWork.repEmployees.Get(x => x.UserName == txtUserName.Text, 0, 1, true)).FirstOrDefault()??new Employee();
            //    if (emp == null || emp.EmployeeID == 0)
            //        Helper.ShowMessage("لا يوجد مستخدم بهذا الاسم");
            //    else
            //    {
            //        (bool, string) PasswordDecryptionResult = Downloader.Download(emp.Password, ConstantValues.BaseURL);
            //        if (PasswordDecryptionResult.Item1)
            //        {
            //            if (txtPassword.Text == PasswordDecryptionResult.Item2)
            //            {
            //                UserLogin.LoggedUserID = emp.EmployeeID;
            //                UserLogin.UserType = emp.UserTypeID;
            //                Close();
            //            }
            //            else
            //                Helper.ShowMessage("لا يوجد مستخدم بهذا الاسم");
            //        }
            //        else
            //            Helper.ShowMessage(PasswordDecryptionResult.Item2);
            //    }
            //}
            //else
            //    Helper.ShowMessage("لا يوجد مستخدم بهذا الاسم");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}