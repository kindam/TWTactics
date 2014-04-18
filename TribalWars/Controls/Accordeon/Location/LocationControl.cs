#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using TribalWars.Data.Maps;
using TribalWars.Data.Events;
#endregion

namespace TribalWars.Controls.Accordeon.Location
{
    /// <summary>
    /// UI control with Location, History, You (=current player) setting,
    /// continent center and grid with search options for village, player
    /// and tribe
    /// </summary>
    public partial class LocationControl : UserControl
    {
        Data.Maps.Location _startLocation;

        public LocationControl()
        {
            InitializeComponent();
        }

        private void LocationControl_Load(object sender, EventArgs e)
        {
            World.Default.EventPublisher.SettingsLoaded += new EventHandler<EventArgs>(World_SettingsLoaded);
            World.Default.Map.EventPublisher.LocationChanged += new EventHandler<MapLocationEventArgs>(Location_Changed);
        }

        private void World_SettingsLoaded(object sender, EventArgs e)
        {
            _startLocation = World.Default.Map.Location;
            txtX.Text = World.Default.Map.Location.X.ToString();
            txtY.Text = World.Default.Map.Location.Y.ToString();
            txtZ.Text = World.Default.Map.Location.Zoom.ToString();
            //txtWidth.Text = World.Default.Map.Location.Width.ToString();

            if (World.Default.PlayerSelected)
            {
                You.Text = World.Default.You.Player.Name;
            }
        }

        private void cmdDraw_Click(object sender, EventArgs e)
        {
            int x, y, z;
            if (int.TryParse(txtX.Text, out x) && int.TryParse(txtY.Text, out y) && int.TryParse(txtZ.Text, out z))
            {
                World.Default.Map.SetCenter(x, y, z);
            }
        }

        #region Focusselect
        private void txtX_Enter(object sender, EventArgs e)
        {
            txtX.SelectAll();
        }

        private void txtY_Enter(object sender, EventArgs e)
        {
            txtY.SelectAll();
        }

        private void txtZ_Enter(object sender, EventArgs e)
        {
            txtZ.SelectAll();
        }

        private void txtWidth_Enter(object sender, EventArgs e)
        {
            txtWidth.SelectAll();
        }

        private void txtX_Click(object sender, EventArgs e)
        {
            txtX.SelectAll();
        }

        private void txtY_Click(object sender, EventArgs e)
        {
            txtY.SelectAll();
        }

        private void txtZ_Click(object sender, EventArgs e)
        {
            txtZ.SelectAll();
        }

        private void txtWidth_Click(object sender, EventArgs e)
        {
            txtWidth.SelectAll();
        }
        #endregion

        private void Location_Changed(object sender, MapLocationEventArgs e)
        {
            LocationHistory.Add(e.NewLocation, e.NewLocation.ToString());

            txtX.Text = e.NewLocation.X.ToString(CultureInfo.InvariantCulture);
            txtY.Text = e.NewLocation.Y.ToString(CultureInfo.InvariantCulture);
            txtZ.Text = e.NewLocation.Zoom.ToString(CultureInfo.InvariantCulture);
        }

        private void cmdCenterKingdom_Click(object sender, EventArgs e)
        {
            int continent;
            if (int.TryParse(txtK.Text, out continent) && continent <= 99 && continent >= 0)
            {
                int x = continent % 10 * 100 + 50;
                int y = (continent - continent % 10) * 10 + 50;
                World.Default.Map.SetCenter(x, y);
            }
        }

        private void StripHome_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.SetCenter(_startLocation);
            }
        }

        private void You_TextChanged(object sender, EventArgs e)
        {
            if (World.Default.Players.ContainsKey(You.Text.ToUpper()))
            {
                World.Default.You.Player = World.Default.Players[You.Text.ToUpper()];
                //World.Default.You.MarkPlayer.Clear();
                //World.Default.You.MarkPlayer.Add(new PlayerMarker(World.Default.Settings.You.MarkPlayer, World.Default.You));
            }
        }
    }
}
