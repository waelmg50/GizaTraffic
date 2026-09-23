using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BasicForms
{
    public partial class frmDisplayImage : Form
    {

        #region Constructor

        public frmDisplayImage(Image imgDisplay)
        {
            InitializeComponent();
            picboxDisplayedImage.BackgroundImage = imgDisplay;
            //Adjust the size of the form according to the new image size.
            if (imgDisplay.Width < 198)
            {
                //The size is to small set the width by the smallest size and don't strech 
                //the image.
                if (imgDisplay.Height + pnlClose.Height >
                    Screen.PrimaryScreen.WorkingArea.Height)
                {
                    //The image is too high.
                    Size = new Size(198, Screen.PrimaryScreen.WorkingArea.Height);
                    picboxDisplayedImage.Dock = DockStyle.Top;
                }
                else
                {
                    Size = new Size(198, imgDisplay.Height + pnlClose.Height);
                    picboxDisplayedImage.Dock = DockStyle.Left;
                    CenterToScreen();
                }
                picboxDisplayedImage.Width = imgDisplay.Width;
            }
            else if (imgDisplay.Width < Screen.PrimaryScreen.WorkingArea.Width && (imgDisplay.Height + pnlClose.Height) <
                Screen.PrimaryScreen.WorkingArea.Height)
            {
                Size = new Size(imgDisplay.Width, imgDisplay.Height + pnlClose.Height);
                picboxDisplayedImage.Dock = DockStyle.Fill;
                CenterToScreen();
            }
            else
            {
                //The screen is smaller than the image, so fit the width or hight of the form to the screen width or hight.
                if (imgDisplay.Width > Screen.PrimaryScreen.WorkingArea.Width && (imgDisplay.Height
                    + pnlClose.Height) < Screen.PrimaryScreen.WorkingArea.Height)
                    //The width of the image is bigger than the width of the screen.So make the width of the form by the
                    //width of the screen and the the adjust the hight.
                    Size = new Size(Screen.PrimaryScreen.WorkingArea.Width,
                        Convert.ToInt32(((double)Screen.PrimaryScreen.WorkingArea.Width / imgDisplay.Width)
                        * imgDisplay.Height) + pnlClose.Height);
                else
                {
                    if (imgDisplay.Width < Screen.PrimaryScreen.WorkingArea.Width &&
                        (imgDisplay.Height + pnlClose.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                        Size = new Size(Convert.ToInt32(((double)Screen.PrimaryScreen.WorkingArea.Height
                            - pnlClose.Height) / imgDisplay.Height * imgDisplay.Width),
                            Screen.PrimaryScreen.WorkingArea.Height);
                    else
                    {
                        if (imgDisplay.Width > Screen.PrimaryScreen.WorkingArea.Width &&
                                                (imgDisplay.Height + pnlClose.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                        {
                            if (imgDisplay.Width > (imgDisplay.Height + pnlClose.Height))
                                Size = new Size(Screen.PrimaryScreen.WorkingArea.Width,
                                    Convert.ToInt32(((double)Screen.PrimaryScreen.WorkingArea.Width / imgDisplay.Width)
                                    * imgDisplay.Height) + pnlClose.Height);
                            else
                                Size = new Size(Convert.ToInt32(((double)Screen.PrimaryScreen.WorkingArea.Height
                                    - pnlClose.Height) / imgDisplay.Height) * imgDisplay.Width,
                                    Screen.PrimaryScreen.WorkingArea.Height);
                        }
                    }
                }
                if (imgDisplay.Width > Screen.PrimaryScreen.WorkingArea.Width && (imgDisplay.Height
                    + pnlClose.Height) < Screen.PrimaryScreen.WorkingArea.Height)
                {
                    Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, imgDisplay.Height + pnlClose.Height);
                    picboxDisplayedImage.Size = imgDisplay.Size;
                    picboxDisplayedImage.Dock = DockStyle.Left;
                }
                else
                {
                    if (imgDisplay.Width < Screen.PrimaryScreen.WorkingArea.Width &&
                        (imgDisplay.Height + pnlClose.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                    {
                        Size = new Size(imgDisplay.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        picboxDisplayedImage.Size = imgDisplay.Size;
                        picboxDisplayedImage.Dock = DockStyle.Top;
                    }
                    else
                    {
                        if (imgDisplay.Width > Screen.PrimaryScreen.WorkingArea.Width &&
                            (imgDisplay.Height + pnlClose.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                        {
                            Size = new Size(Screen.PrimaryScreen.WorkingArea.Width,
                                Screen.PrimaryScreen.WorkingArea.Height);
                            picboxDisplayedImage.Size = imgDisplay.Size;
                            picboxDisplayedImage.Dock = DockStyle.None;
                        }
                    }
                }
            }
        }

        #endregion

        #region Members

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        #endregion

        #region Methods

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        #region Event Handlers

        private void picClose_Click(object sender, EventArgs e)
        {
            //Cloase the form when the user clicks on the close picture box.
            Close();
        }
        private void pnlClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

    }
}