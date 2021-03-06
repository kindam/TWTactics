using System.Windows.Forms;
using System.Windows.Forms.Design;
using TribalWars.Villages.Units;
using TribalWars.Worlds;

namespace TribalWars.Controls.Common.ToolStripControlHostWrappers
{
    /// <summary>
    /// Wrapper for a Unit ImageCombobox for use in a ToolStrip
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripUnitsImageCombobox : ToolStripControlHost
    {
        private bool _allowEmpty;

        #region Properties
        /// <summary>
        /// Gets the underlying ImageCombobox
        /// </summary>
        public ImageCombobox Combobox
        {
            get { return Control as ImageCombobox; }
        }

        /// <summary>
        /// Gets the currently selected unit
        /// </summary>
        public Unit Unit
        {
            get
            {
                if (World.Default.HasLoaded)
                {
                    int i = Combobox.SelectedIndex;
                    if (_allowEmpty)
                    {
                        return i == 0 ? null : WorldUnits.Default[i - 1];
                    }
                    return WorldUnits.Default[i];
                }
                return null;
            }
        }
        #endregion

        #region Constructors
        public ToolStripUnitsImageCombobox()
            : base(new ImageCombobox())
        {
            AutoSize = false;
            Text = string.Empty;
            ToolTipText = string.Empty;
        }
        #endregion

        public void SetWorldUnits(bool addEmpty)
        {
            _allowEmpty = addEmpty;
            Combobox.ImageList = WorldUnits.Default.GetImageList(addEmpty);
        }
    }
}