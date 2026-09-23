using System.ComponentModel;

namespace Utilities
{
    [Serializable]
    public class NumericTextBox : TextBox
    {

        #region Private Members

        bool _IsInt = true;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value that Determines wether the text box should be Integer or Text.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsInt
        {
            get { return _IsInt; }
            set { _IsInt = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Add the events developed to the control.
        /// </summary>
        public NumericTextBox()
        {
            KeyPress += NumericTextBox_KeyPress;
            Leave += NumericTextBox_Leave;
        }

        #endregion

        #region Event Handlers

        private void NumericTextBox_KeyPress(object? sender, KeyPressEventArgs? e)
        {
            //Make the control accepts numeric digits only.
            if (e == null)
                return;
            short siLetter = Convert.ToInt16(e?.KeyChar??1);
            if (_IsInt)
            {
                if ((siLetter < 48 || siLetter > 57) && siLetter != 8)
                    e.Handled = true;
            }
            else
            {
                if ((siLetter < 48 || siLetter > 57) && siLetter != 8 && siLetter != 46 || (siLetter == 46
                    && Text.IndexOf('.') > -1) || (siLetter == 46 && Text.Length == 0))
                    e.Handled = true;
            }
        }
        private void NumericTextBox_Leave(object? sender, EventArgs? e)
        {
            //When the controls is left check the number in the text box.
            if (_IsInt)
            {
                if (Text.Length > 0 && !Helper.CheckNumberInt(Text))
                {
                    Helper.ShowMessage(Resources.ControlsMessages.VldMesEnterIntgr);
                    SelectAll();
                    Focus();
                }
            }
            else
            {
                if (Text.Length > 0 && !Helper.CheckNumberDouble(Text))
                {
                    Helper.ShowMessage(Resources.ControlsMessages.VldMesEnterDecimal);
                    SelectAll();
                    Focus();
                }
            }
        }

        #endregion

    }
}
