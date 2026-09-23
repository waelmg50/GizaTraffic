using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Utilities
{
    /// <summary>
    /// Manages the login to the program for the user.
    /// </summary>
    public class UserLogin
    {

        #region Enumerations

        public enum AccessType
        {
            SingleBoard, MultibleEntryBoards, MultibleExitBoards
        }

        #endregion

        #region Class members

        static int iLoggedUserID;
        static int iUserTypeID;
        static bool bPrintReceipt;
        static AccessType accsstpCurrentAccessType;

        #endregion

        #region Class Properties

        /// <summary>
        /// The ID of the current logged user.
        /// </summary>
        public static int LoggedUserID
        {
            get
            {
                return iLoggedUserID;
            }
            set
            {
                iLoggedUserID = value;
            }
        }
        /// <summary>
        /// The type of the logged user.
        /// </summary>
        public static int UserType
        {
            get { return UserLogin.iUserTypeID; }
            set { UserLogin.iUserTypeID = value; }
        }
        ///// <summary>
        ///// The current open shift ID.
        ///// </summary>
        //public static int CurrentOpenShiftID
        //{
        //    get { return UserLogin.iCurrentOpenShiftID; }
        //    set { UserLogin.iCurrentOpenShiftID = value; }
        //}
        /// <summary>
        /// Gets or sets a value that allows the user to print the receipt after each financial operation or not.
        /// </summary>
        public static bool PrintReceipt
        {
            get { return UserLogin.bPrintReceipt; }
            set { UserLogin.bPrintReceipt = value; }
        }
        
        /// <summary>
        /// The current access type of the system.
        /// </summary>
        public static AccessType CurrentAccessType
        {
            get { return UserLogin.accsstpCurrentAccessType; }
            set { UserLogin.accsstpCurrentAccessType = value; }
        }

        #endregion

        #region Public Functions

        ///// <summary>
        ///// Checks if there is a user with this username and password.
        ///// </summary>
        ///// <param name="UserName">The user name of the logged user.</param>
        ///// <param name="Password">The Password of the logged user.</param>
        ///// <returns>Returns true if the user exists otherwise it returns false.</returns>
        //public static bool CheckUser(string UserName, string Password)
        //{
        //    try
        //    {
        //        GizaTrafficDBContext dbContext = new DataContextFactory().CreateDbContext(null);
        //        UnitOfWork uow = new UnitOfWork(dbContext);
        //        DBService<Employee> ser = new DBService<Employee>(uow);
        //        SqlParameter[] sqlprmCheckUser = new SqlParameter[2];
        //        sqlprmCheckUser[0] = new SqlParameter("@UserName", UserName);
        //        sqlprmCheckUser[1] = new SqlParameter("@Password", Downloader.Download(Password, ConstantValues.BaseURL));
                
        //        object objUserID = SqlAdoWrapper.ExecuteScalarCommand("Users_SelectCheck", sqlprmCheckUser, false);
        //        if (objUserID != null)
        //        {
        //            iLoggedUserID = Convert.ToInt32(objUserID);
        //            string strUserType = RecordsFunctions.GetNameUsingID("Users", "UserTypeID", iLoggedUserID);
        //            if(Helper.CheckNumberInt(strUserType))
        //                iUserTypeID = Convert.ToInt32(strUserType);
        //        }
        //        return objUserID != null;
        //    }
        //    catch (Exception e)
        //    {
        //        ErrorHandler.LogError(e);
        //        return false;
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}
        
        #endregion

    }
}
