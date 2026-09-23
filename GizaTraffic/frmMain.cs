using GizaTraffic.BaseForms;
using GizaTraffic.BasicData;
using GizaTraffic.Repositories;
//using GizaTraffic.Tools;
using System.Data;
using Utilities;

namespace GizaTraffic
{
    public partial class frmMain : Form
    {

        #region Members

        protected readonly UnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public frmMain(UnitOfWork unitOfWork) //: base(unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        static bool IsFormOpened(string strFormName)
        {
            if (Application.OpenForms[strFormName] == null)
                return false;
            Application.OpenForms[strFormName]?.BringToFront();
            return true;
        }
        
        #endregion

        #region Events Handlers

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            Helper.ShowMessage("تحت الإنشاء");
        }
        private void TsmiSettings_Click(object sender, EventArgs e)
        {
            if (IsFormOpened("frmSettings"))
                return;
            new frmSettings(_unitOfWork) { MdiParent = this }.Show();
        }
        private void TsmiFamilies_Click(object sender, EventArgs e)
        {
            if (IsFormOpened("frmRegisterVehicles"))
                return;
            new frmRegisterVehicles(_unitOfWork) { MdiParent = this }.Show();
        }
        private void ContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void IndexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
                
        #region Main Form Events

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //zkCurrentAccessBoard.Disconnect();
        }
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
            }
        }

        #endregion

        #endregion

        
    }
}
