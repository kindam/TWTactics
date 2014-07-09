﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TribalWars.Tools;
using TribalWars.Villages;
using TribalWars.Worlds;

namespace TribalWars.Maps.Markers
{
    public partial class MarkersControl : UserControl
    {
        public MarkersControl()
        {
            InitializeComponent();

            World.Default.EventPublisher.SettingsLoaded += WorldEventPublisher_SettingsLoaded;
        }

        private void WorldEventPublisher_SettingsLoaded(object sender, EventArgs e)
        {
            EnemyMarker.SetMarker(World.Default.Map.MarkerManager.EnemyMarkerSettings);
            AbandonedMarker.SetMarker(World.Default.Map.MarkerManager.AbandonedMarkerSettings);


        }

        private void MarkersControl_Load(object sender, EventArgs e)
        {
            MarkersGrid.Configure(true, false);

            MarkersGrid.RootTable.Columns["Color"].ConfigureAsColor();
            MarkersGrid.RootTable.Columns["ExtraColor"].ConfigureAsColor();

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var markers = World.Default.Map.MarkerManager.GetMarkers();

            MarkersGrid.DataSource = markers.ToArray();
        }
    }

    /// <summary>
    /// A marker as displayed in the GridEX
    /// </summary>
    public class MarkerGridRow
    {
        public bool Enabled { get; set; }
        public Color Color { get; set; }
        public Color ExtraColor { get; set; }
        public Tribe Tribe { get; set; }
        public Player Player { get; set; }
        public string View { get; set; }

        public string Name
        {
            get
            {
                if (Tribe != null)
                {
                    return Tribe.Tag;
                }
                if (Player != null)
                {
                    return Player.Name;
                }
                return "";
            }
            set
            {
                
            }
        }

        // no row highlight

        public MarkerGridRow(Marker marker)
        {
            Enabled = marker.Settings.Enabled;
            Color = marker.Settings.Color;
            ExtraColor = marker.Settings.ExtraColor;
            View = marker.Settings.View;
            Tribe = marker.Tribe;
            Player = marker.Player;
        }
    }
}