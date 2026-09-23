namespace BasicForms
{
    partial class frmDisplayImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplayImage));
            pnlClose = new Panel();
            lblHeader = new Label();
            picClose = new PictureBox();
            picboxDisplayedImage = new PictureBox();
            pnlImageContainer = new Panel();
            pnlClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxDisplayedImage).BeginInit();
            pnlImageContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlClose
            // 
            pnlClose.BackColor = Color.LightSteelBlue;
            pnlClose.Controls.Add(lblHeader);
            pnlClose.Controls.Add(picClose);
            resources.ApplyResources(pnlClose, "pnlClose");
            pnlClose.Name = "pnlClose";
            pnlClose.MouseDown += pnlClose_MouseDown;
            // 
            // lblHeader
            // 
            resources.ApplyResources(lblHeader, "lblHeader");
            lblHeader.ForeColor = Color.Black;
            lblHeader.Name = "lblHeader";
            // 
            // picClose
            // 
            resources.ApplyResources(picClose, "picClose");
            picClose.Name = "picClose";
            picClose.TabStop = false;
            picClose.Click += picClose_Click;
            // 
            // picboxDisplayedImage
            // 
            picboxDisplayedImage.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(picboxDisplayedImage, "picboxDisplayedImage");
            picboxDisplayedImage.Name = "picboxDisplayedImage";
            picboxDisplayedImage.TabStop = false;
            // 
            // pnlImageContainer
            // 
            resources.ApplyResources(pnlImageContainer, "pnlImageContainer");
            pnlImageContainer.BackColor = Color.WhiteSmoke;
            pnlImageContainer.Controls.Add(picboxDisplayedImage);
            pnlImageContainer.Name = "pnlImageContainer";
            // 
            // frmDisplayImage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(pnlImageContainer);
            Controls.Add(pnlClose);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmDisplayImage";
            pnlClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxDisplayedImage).EndInit();
            pnlImageContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlClose;
        public System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picboxDisplayedImage;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlImageContainer;
    }
}