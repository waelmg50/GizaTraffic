using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Helper
    {
        #region Members

        private static readonly DateTime dtMinDate = new(1753, 1, 1);
        public enum StampActions
        {
            EditedBy = 1,
            DateTime = 2,
            Custom = 4
        }

        #endregion

        #region Properties
        /// <summary>
        /// Get the minimum date in the program.
        /// </summary>
        public static DateTime MinDate
        {
            get
            {
                return dtMinDate;
            }
        }

        /// <summary>
        /// Gets the message header of the program.
        /// </summary>
        public static string MessageHeader
        {
            get
            {
                return Resources.ProgramMessages.MesHeader;
            }
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Checks whether a string is an integer number or not.
        /// </summary>
        /// <param name="Input">The string to check whether it is an integer number or not.</param>
        /// <returns>Returns true if the input string is an integer number otherwise it returns false.</returns>
        public static bool CheckStringInt(string Input)
        {
            //return long.TryParse(Input, out long result);
            if (Input.Length == 0)
                return false;
            if (Input[0] == '-')
                Input = Input[1..];
            foreach (char A in Input.ToCharArray())
            {
                if (A == '0' || A == '1' || A == '2' || A == '3' ||
                    A == '4' || A == '5' || A == '6' || A == '7' ||
                    A == '8' || A == '9'
                    || A == '٠' || A == '١' || A == '٢' || A == '٣' ||
                    A == '٤' || A == '٥' || A == '٦' || A == '٧' ||
                    A == '٨' || A == '٩')
                    continue;
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Checks whether an object  is an integer number or not.
        /// </summary>
        /// <param name="objInput">The object to check whether it is an integer number or not.</param>
        /// <returns>Returns true if the input object is an integer number otherwise it returns false.</returns>
        public static bool CheckNumberInt(object objInput)
        {
            if (objInput == null)
                return false;
            else
                return CheckStringInt(objInput.ToString()??string.Empty);
        }
        /// <summary>
        /// Checks whether a string is a double number or not.
        /// </summary>
        /// <param name="Input">The string to check whether it is a double number or not.</param>
        /// <returns>Returns true if the input string is a double number otherwise it returns false.</returns>
        public static bool CheckNumberDouble(string strInput)
        {
            if (strInput.Length == 0)
                return false;
            if (strInput.StartsWith('.')) return false;
            if (strInput.EndsWith('.')) return false;
            string SubInput = strInput[(strInput.IndexOf('.') + 1)..];
            if (SubInput.Contains('.')) return false;
            foreach (char A in strInput.ToCharArray())
            {
                if (A == '0' || A == '1' || A == '2' || A == '3' ||
                    A == '4' || A == '5' || A == '6' || A == '7' ||
                    A == '8' || A == '9' || A == '.')
                    continue;
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Checks whether an object is a double number or not.
        /// </summary>
        /// <param name="Input">The object to check whether it is a double number or not.</param>
        /// <returns>Returns true if the input object is a double number otherwise it returns false.</returns>
        public static bool CheckNumberDouble(object objInput)
        {
            if (objInput == null)
                return false;
            else
                return CheckNumberDouble(objInput.ToString() ?? string.Empty);
        }
        /// <summary>
        /// Gets the suitable option for the message in the message box according to the current language.
        /// </summary>
        /// <returns>Returns the option of the message in the message box according to the current language.</returns>
        public static MessageBoxOptions GetMessageBoxOptions()
        {
            return MessageBoxOptions.RtlReading;
        }
        /// <summary>
        /// Displays a message box to the user.
        /// </summary>
        /// <param name="Message">The message that will appear to the user in the message box.</param>
        /// <returns>Returns the button that the user pressed in the message box.</returns>
        public static DialogResult ShowMessage(string Message)
        {
            
            return MessageBox.Show(Message, MessageHeader, MessageBoxButtons.OK
                   , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                   GetMessageBoxOptions());
        }
        /// <summary>
        /// Displays a message box to the user.
        /// </summary>
        /// <param name="Message">The message that will appear to the user in the message box.</param>
        /// <param name="MessageButtons">The buttons that will appear to the user in the message box.</param>
        /// <returns>Returns the button that the user pressed in the message box.</returns>
        public static DialogResult ShowMessage(string Message, MessageBoxButtons MessageButtons)
        {
            return MessageBox.Show(Message, MessageHeader, MessageButtons
                   , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                   GetMessageBoxOptions());
        }
        /// <summary>
        /// Displays a message box to the user.
        /// </summary>
        /// <param name="Message">The message that will appear to the user in the message box.</param>
        /// <param name="MessageButtons">The buttons that will appear to the user in the message box.</param>
        /// <param name="MessageIcon">The icon that will appear to the user in the message box.</param>
        /// <returns>Returns the button that the user pressed in the message box.</returns>
        public static DialogResult ShowMessage(string Message, MessageBoxButtons MessageButtons, MessageBoxIcon MessageIcon)
        {
            return MessageBox.Show(Message, MessageHeader, MessageButtons, MessageIcon
                , MessageBoxDefaultButton.Button1, GetMessageBoxOptions());
        }
        /// <summary>
        /// Displays a message box to the user.
        /// </summary>
        /// <param name="Message">The message that will appear to the user in the message box.</param>
        /// <param name="MessageButtons">The buttons that will appear to the user in the message box.</param>
        /// <param name="MessageIcon">The icon that will appear to the user in the message box.</param>
        /// <param name="MessageDefBtn">The default button that it is focused when the message box appears.</param>
        /// <returns>Returns the button that the user pressed in the message box.</returns>
        public static DialogResult ShowMessage(string Message, MessageBoxButtons MessageButtons, MessageBoxIcon MessageIcon, MessageBoxDefaultButton MessageDefBtn)
        {
            return MessageBox.Show(Message, MessageHeader, MessageButtons, MessageIcon
                , MessageDefBtn, GetMessageBoxOptions());
        }
        /// <summary>
        /// Gets the error icon alignment according to the language in the
        /// configuration file.
        /// </summary>
        /// <returns>Returns the icon alignment.</returns>
        public static ErrorIconAlignment GetErrorIconAlignment()
        {
            return ErrorIconAlignment.MiddleLeft;
        }
        /// <summary>
        /// Tests if the supplied byte array represents an image or not.
        /// </summary>
        /// <param name="data">The byte array to test.</param>
        /// <returns>Returns true if the supplied byte array is an image other wise it returns false.</returns>
        public static bool IsImage(byte[] data)
        {
            //read 64 bytes of the stream only to determine the type
            string myStr = Encoding.ASCII.GetString(data)[..16];
            //check if its definately an image.
            if (!myStr.Substring(8, 2).Equals("if", StringComparison.CurrentCultureIgnoreCase))
            {         //its not a jpeg
                if (!myStr[..3].Equals("gif", StringComparison.CurrentCultureIgnoreCase))
                {                //its not a gif 
                    if (!myStr[..2].ToString().Equals("bm", StringComparison.CurrentCultureIgnoreCase))
                    {                   //its not a .bmp                   
                        if (!myStr[..2].ToString().Equals("ii", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //myStr = null;
                            return false;
                        }
                    }
                }
            }
            //myStr = null;
            return true;
        }
        /// <summary>
        /// Gets the input language corresponding to the supplied culture name.
        /// </summary>
        /// <param name="strRequiredLanguage">The culture name of the required input language (it is "ar" or "en").
        /// </param>
        /// <returns>Returns the input language of the supplied culture name if it was not installed it returns the
        /// current input language.</returns>
        public static InputLanguage GetInputLanguage(string strRequiredLanguage)
        {
            foreach (InputLanguage inplang in InputLanguage.InstalledInputLanguages)
                if (inplang.Culture.Name.Contains(strRequiredLanguage))
                    return inplang;
            //If the code reached here then there is no approperiate installed language.
            string strRequiredLanguageAbsent = Resources.ProgramMessages.MesNoArabicInput;
            if (strRequiredLanguage.Contains("en", StringComparison.CurrentCultureIgnoreCase))
                strRequiredLanguageAbsent = Resources.ProgramMessages.MesNoEnglishInput;
            if (Helper.ShowMessage(strRequiredLanguageAbsent, MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Question) == DialogResult.Retry)
                return GetInputLanguage(strRequiredLanguage);
            else
                Helper.ShowMessage(Resources.ProgramMessages.MesCantWriteInField);
            //Return the current input language.
            return InputLanguage.CurrentInputLanguage;
        }
        /// <summary>
        /// Converts a string in arabic language to it's finger print to avoid arabic dictation errors.
        /// </summary>
        /// <param name="inString">The string that we want to calculate it's finger print.</param>
        /// <returns>Returns a finger print for the string.</returns>
        public static string FingerPrintString(string inString)
        {
            string FpString = inString;
            if (FpString.Contains("اللة", StringComparison.CurrentCulture)) FpString = FpString.Replace("اللة", "الله");
            if (FpString.Contains('أ')) FpString = FpString.Replace('أ', 'ا');
            if (FpString.Contains('إ')) FpString = FpString.Replace('إ', 'ا');
            if (FpString.Contains('آ')) FpString = FpString.Replace('آ', 'ا');
            if (FpString.Contains('ئ')) FpString = FpString.Replace('ئ', 'ى');
            if (FpString.Contains('ي')) FpString = FpString.Replace('ي', 'ى');
            if (FpString.Contains('-')) FpString = FpString.Replace("-", "");
            if (FpString.Contains(' ', StringComparison.CurrentCulture)) FpString = FpString.Replace(" ", "");
            return FpString;
        }
        public static string DisplayParkingPeriod(TimeSpan tsPeriod)
        {
            int iHours = 0, iMinitues, iSeconds;
            if (tsPeriod.Days > 0)
                iHours = tsPeriod.Days * 24;
            iHours += tsPeriod.Hours;
            iMinitues = tsPeriod.Minutes;
            iSeconds = tsPeriod.Seconds;
            return string.Format("{0} h: {1} : m : {2} s", iHours, iMinitues, iSeconds);
        }
        #region Reflection Methods

        static readonly List<Type> lstApplicationTypes = [];
        public static Type GetType(string TypeName)
        {
            if (lstApplicationTypes == null || lstApplicationTypes.Count < 1)
            {
                foreach (System.Reflection.Assembly AppAssemblies in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (AppAssemblies.Location.Contains("C:\\Windows"))
                        continue;
                    Type[] ApplicationTypes = AppAssemblies.GetTypes();
                    lstApplicationTypes?.AddRange(ApplicationTypes);
                }
            }
            return lstApplicationTypes?.Find(x => x.Name == TypeName)??typeof(int);
        }
        /// <summary>
        /// Executing a method inside a class.
        /// </summary>
        /// <param name="strSourceLibraryFile">The full path of the file that contains the class of the method we want to execute.</param>
        /// <param name="strClassNameSpace">The name space of the class.</param>
        /// <param name="strClassName">The bane of the class that contains the method we wnat to execute.</param>
        /// <param name="bIsAbstractClass">Determining weather this class is abstract or not.</param>
        /// <param name="strMethodName">The name of the method to be executed.</param>
        /// <param name="objarrParameters">The parameters of the method to execute.</param>
        /// <returns>Returns an object as the return result of the method other wise it returns null.</returns>
        public static object InvokeMethod(string strSourceLibraryFile, string strClassNameSpace, string strClassName, bool bIsAbstractClass, string strMethodName, params object[] objarrParameters)
        {
            try
            {
                System.Reflection.Assembly assmInvokerAssembly = string.IsNullOrEmpty(strSourceLibraryFile) ? System.Reflection.Assembly.GetExecutingAssembly() : System.Reflection.Assembly.LoadFrom(strSourceLibraryFile);
                string strFullClassName = string.Empty;
                if (string.IsNullOrEmpty(strClassNameSpace))
                    strFullClassName = strClassName;
                else
                    strFullClassName = string.Format("{0}.{1}", strClassNameSpace, strClassName);
                Type tpContainerClass = assmInvokerAssembly.GetType(strFullClassName)??typeof(int);
                return InvokeMethod(tpContainerClass, bIsAbstractClass, strMethodName, objarrParameters);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            return new object();
        }
        /// <summary>
        /// Excuting a method in a certain type.
        /// </summary>
        /// <param name="tpContainerClass">The type of the class that the method will be invoked from.</param>
        /// <param name="bIsAbstractClass">Determining weather this class is abstract or not.</param>
        /// <param name="strMethodName">The name of the method to be executed.</param>
        /// <param name="objarrParameters">The parameters of the method to execute.</param>
        /// <returns>Returns an object as the return result of the method other wise it returns null.</returns>
        public static object InvokeMethod(Type tpContainerClass, bool bIsAbstractClass, string strMethodName, params object[] objarrParameters)
        {
            try
            {
                if (tpContainerClass == null)
                {
                    MessageBox.Show($"Type {tpContainerClass?.Name} does not exist.");
                    return new object();
                }
                Type[] tparrParmetersTypes = [];
                System.Reflection.MethodInfo mthdinfExecutingMethod;

                if (objarrParameters == null || objarrParameters.Length < 1)
                    mthdinfExecutingMethod = tpContainerClass.GetMethod(strMethodName);
                else
                {
                    tparrParmetersTypes = new Type[objarrParameters.Length];
                    for (int i = 0; i < tparrParmetersTypes.Length; i++)
                        tparrParmetersTypes[i] = objarrParameters[i].GetType();
                    mthdinfExecutingMethod = tpContainerClass.GetMethod(strMethodName, tparrParmetersTypes);
                }
                if (mthdinfExecutingMethod == null)
                {
                    MessageBox.Show(string.Format("Method {0} does not exist in class {1} with the supplied parameters.", strMethodName, tpContainerClass.Name));
                    return new();
                }
                if (bIsAbstractClass)
                    return mthdinfExecutingMethod.Invoke(null, objarrParameters)??new();
                else
                    return mthdinfExecutingMethod.Invoke(Activator.CreateInstance(tpContainerClass), objarrParameters)??new();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            return new();
        }
        /// <summary>
        /// Excuting a method in a certain type.
        /// </summary>
        /// <param name="tpContainerClass">The type of the class that the method will be invoked from.</param>
        /// <param name="bIsAbstractClass">Determining weather this class is abstract or not.</param>
        /// <param name="strMethodName">The name of the method to be executed.</param>
        /// <param name="objarrParameters">The parameters of the method to execute.</param>
        /// <returns>Returns an object as the return result of the method other wise it returns null.</returns>
        public static object InvokeMethod(object objClassInstance, string strMethodName, params object[] objarrParameters)
        {
            try
            {
                if (objClassInstance == null)
                    return new();
                Type tpContainerClass = objClassInstance.GetType();
                if (tpContainerClass == null)
                {
                    MessageBox.Show($"Type {tpContainerClass?.Name} does not exist.");
                    return new();
                }
                Type[] tparrParmetersTypes = [];
                System.Reflection.MethodInfo mthdinfExecutingMethod;

                if (objarrParameters == null || objarrParameters.Length < 1)
                    mthdinfExecutingMethod = tpContainerClass.GetMethod(strMethodName);
                else
                {
                    tparrParmetersTypes = new Type[objarrParameters.Length];
                    for (int i = 0; i < tparrParmetersTypes.Length; i++)
                        tparrParmetersTypes[i] = objarrParameters[i].GetType();
                    mthdinfExecutingMethod = tpContainerClass.GetMethod(strMethodName, tparrParmetersTypes);
                }
                if (mthdinfExecutingMethod == null)
                {
                    MessageBox.Show(string.Format("Method {0} does not exist in class {1}.", strMethodName, tpContainerClass.Name));
                    return new();
                }
                return mthdinfExecutingMethod?.Invoke(objClassInstance, objarrParameters)??new();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
            return new();
        }

        /// <summary>
        /// Getting the current active form.
        /// </summary>
        /// <returns>Rturns the current active form. If there is no active form it returns null.</returns>
        public static Form GetActiveForm()
        {
            //If there is a value in ActiveForm then return it.
            if (Form.ActiveForm != null)
                return Form.ActiveForm;
            //Define a variable to hold the main form.
            Form MainForm = new();
            //Loop through all opened forms.
            foreach (Form frmOpenedForm in Application.OpenForms)
            {
                //If there is a MDI container form then return its active mdi child form.
                if (frmOpenedForm.IsMdiContainer)
                    return MainForm.ActiveMdiChild ?? new();
                //If the form has owned forms then it is the main forom of the application.
                if (frmOpenedForm.OwnedForms != null && frmOpenedForm.OwnedForms.Length > 0)
                {
                    MainForm = frmOpenedForm;
                    break;
                }
                //If there is a form thet contains focus then return it.
                if (frmOpenedForm.ContainsFocus)
                    return frmOpenedForm;
            }
            //Search for the form that has the focus in the main form owned forms.
            foreach (Form frmChildForms in MainForm.OwnedForms)
            {
                if (frmChildForms.ContainsFocus)
                    return frmChildForms;
            }
            //if the user didn't assign the owner property then search for the form that has the focus in all open forms.
            foreach (Form frmOpenedForm in Application.OpenForms)
            {
                if (frmOpenedForm.ContainsFocus)
                    return frmOpenedForm;
            }
            return new();
        }

        #endregion

        #endregion

    }
}
