using GizaTraffic.Repositories;
using Utilities;

namespace GizaTraffic.BaseForms
{
    public partial class frmBase : Form
    {

        #region Members

        protected readonly UnitOfWork _unitOfWork;// = new UnitOfWork(new DataContextFactory().CreateDbContext(Array.Empty<string>()));
        //protected UnitOfWork unitOfWork { get => _unitOfWork ?? new UnitOfWork(new DataContextFactory().CreateDbContext(Array.Empty<string>())); }

        #endregion

        #region Constructor

        public frmBase()
        {
            InitializeComponent();
        }
        public frmBase(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adjusts the tabindex property of the controls.
        /// </summary>
        /// <param name="indxControls">The coolection of controls to be indexed.</param>
        /// <param name="iBeginTabIndex">The begin index for the controls collection.</param>
        /// <returns>Returns the end index of the controls collection.</returns>
        protected int AdjustTabIndexes(System.Windows.Forms.Control.ControlCollection indxControls, int iBeginTabIndex)
        {
            try
            {
                int iEndTabIndex = iBeginTabIndex;
                if (indxControls.Count == 0)
                    return iEndTabIndex;
                Control cntFirstNonIndexedControl = indxControls[0];
                //Get the first non indexed control.
                foreach (Control cntrlNonIndexed in indxControls)
                    if (cntrlNonIndexed.Tag == null || !(cntrlNonIndexed.Tag.ToString()??string.Empty).Contains("indexed"))
                    {
                        cntFirstNonIndexedControl = cntrlNonIndexed;
                        break;
                    }
                //If the list is totaly indexed then return
                if (cntFirstNonIndexedControl == indxControls[0] && cntFirstNonIndexedControl.Tag != null
                    && (cntFirstNonIndexedControl.Tag.ToString()??string.Empty).Contains("indexed"))
                    return iEndTabIndex;
                //Sort the controls.
                for (int i = 1; i < indxControls.Count; i++)
                {
                    if (indxControls[i].Tag != null && ((indxControls[i].Tag??string.Empty).ToString() ?? string.Empty).Contains("indexed"))
                        continue;
                    if (cntFirstNonIndexedControl.Location.Y == indxControls[i].Location.Y)
                    {
                        if (cntFirstNonIndexedControl.Location.X < indxControls[i].Location.X)
                            cntFirstNonIndexedControl = indxControls[i];
                    }
                    if (cntFirstNonIndexedControl.Location.Y > indxControls[i].Location.Y)
                        cntFirstNonIndexedControl = indxControls[i];
                }
                //Return if the minimum control is indexed.
                if (cntFirstNonIndexedControl.Tag != null && (cntFirstNonIndexedControl.Tag.ToString() ?? string.Empty).Contains("indexed"))
                    return iBeginTabIndex;
                //Set the index of the control.
                cntFirstNonIndexedControl.TabIndex = iBeginTabIndex;
                //Set the index for the next control.
                iEndTabIndex = iBeginTabIndex + 1;
                //If the control have child controls then index them.
                if (cntFirstNonIndexedControl.Controls.Count > 0)
                    iEndTabIndex = AdjustTabIndexes(cntFirstNonIndexedControl.Controls, iEndTabIndex);
                //Mark the control as indexed.
                if (cntFirstNonIndexedControl.Tag != null)
                    cntFirstNonIndexedControl.Tag = cntFirstNonIndexedControl.Tag.ToString() + "|indexed";
                else
                    cntFirstNonIndexedControl.Tag = "indexed";
                //Sort the rest of the controls collection.
                iEndTabIndex = AdjustTabIndexes(indxControls, iEndTabIndex);
                return iEndTabIndex;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
                return 0;
            }
        }

        #endregion
    }
}
