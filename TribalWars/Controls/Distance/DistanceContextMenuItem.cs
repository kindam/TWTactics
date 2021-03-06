using System;
using System.Windows.Forms;

namespace TribalWars.Controls.Distance
{
    /// <summary>
    /// A ContextMenuItem to change the displayed time in the DistanceCollectionControl
    /// </summary>
    class DistanceContextMenuItem : ToolStripMenuItem
    {
        #region Fields
        private readonly ShowDistanceEnum _distance;
        private readonly DistanceCollectionControl _collection;
        #endregion

        #region Constructors
        public DistanceContextMenuItem(string text, ShowDistanceEnum dist, DistanceCollectionControl parent)
            : base(text)
        {
            _distance = dist;
            _collection = parent;
            Click += DistanceContextMenuItem_Click;
        }
        #endregion

        #region Event Handlers
        private void DistanceContextMenuItem_Click(object sender, EventArgs e)
        {
            // checks the clicked item
            foreach (ToolStripMenuItem itm in _collection.SpeedStrip.Items)
                itm.Checked = false;

            var sent = (DistanceContextMenuItem)sender;
            sent.Checked = true;

            // Changes the size of the DistanceControls
            if ((_collection.CurrentSpeed == ShowDistanceEnum.ArrivalTime || _collection.CurrentSpeed == ShowDistanceEnum.ReturnTime) &&
                    (_distance == ShowDistanceEnum.TravelTime || _distance == ShowDistanceEnum.TravelTime2))
            {
                SetDistance(DistanceCollectionControl.TravelWidth);
            }
            else if ((_collection.CurrentSpeed == ShowDistanceEnum.TravelTime || _collection.CurrentSpeed == ShowDistanceEnum.TravelTime2) &&
                    (_distance == ShowDistanceEnum.ArrivalTime || _distance == ShowDistanceEnum.ReturnTime))
            {
                SetDistance(DistanceCollectionControl.TimeWidth);
            }
            _collection.CurrentSpeed = _distance;
        }
        #endregion

        #region Private Implementation
        /// <summary>
        /// Changes the width of the DistanceControls
        /// </summary>
        /// <param name="width">New width for each DistanceControl</param>
        private void SetDistance(int width)
        {
            foreach (DistanceControl dist in _collection.Items)
            {
                if (dist != null)
                {
                    dist.Width = width;
                }
            }

            // also set the new size of the collection
            _collection.SetSize();
        }
        #endregion
    }
}
