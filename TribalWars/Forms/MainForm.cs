#region Using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using TribalWars.Browsers;
using TribalWars.Controls.Common;
using Ascend.Windows.Forms;
using TribalWars.Forms.NotUsed;
using TribalWars.Forms.Small;
using TribalWars.Maps.Drawing.Displays;
using TribalWars.Maps.Manipulators.Implementations;
using TribalWars.Maps.Manipulators.Implementations.Church;
using TribalWars.Maps.Manipulators.Managers;
using TribalWars.Maps.Monitoring;
using TribalWars.Tools;
using TribalWars.Villages;
using TribalWars.Villages.ContextMenu;
using TribalWars.Worlds;
using TribalWars.Worlds.Events;
using TribalWars.Worlds.Events.Impls;

#endregion

namespace TribalWars.Forms
{
    /// <summary>
    /// This is the form where it's all happening
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        private readonly ToolStripLocationChangerControl _locationChanger;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            _locationChanger = new ToolStripLocationChangerControl();
            ToolStrip.Items.Add(_locationChanger);
            ToolStrip.Items.Add(new ToolStripSeparator());

            // Distance calc toolstrip
            //TribalWars.Controls.DistanceToolStrip.DistanceControlHost ctl = new TribalWars.Controls.DistanceToolStrip.DistanceControlHost();
            //ToolStrip.Items.Add(ctl);

            var ctl2 = new ToolStripTimeConverterCalculator();
            ToolStrip.Items.Add(ctl2);
        }

        /// <summary>
        /// Loading the world data, initializing the map
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = string.Format("TW Tactics v{0} - by Sangu", AboutForm.ProgramVersion);

#if DEBUG
            ToolStripProgramSettings.Visible = true;
#endif

            World.Default.InitializeMaps(Map, MiniMap);

            World.Default.EventPublisher.Loaded += OnWorldLoaded;
            World.Default.EventPublisher.SettingsLoaded += OnWorldSettingsLoaded;
            World.Default.Map.EventPublisher.ManipulatorChanged += EventPublisher_ManipulatorChanged;
            World.Default.Map.EventPublisher.PolygonActivated += EventPublisher_PolygonActivated;
            World.Default.Map.EventPublisher.LocationChanged += EventPublisher_LocationChanged;
            World.Default.EventPublisher.Browse += EventPublisher_Browse;
            World.Default.Map.EventPublisher.VillagesSelected += EventPublisher_VillagesSelected;
            World.Default.Map.EventPublisher.PlayerSelected += EventPublisher_VillagesSelected;
            World.Default.Map.EventPublisher.TribeSelected += EventPublisher_VillagesSelected;

            // Auto load world
            string lastWorld = Properties.Settings.Default.LastWorld;
            string lastSettings = Properties.Settings.Default.LastSettings;
            if (!World.Default.LoadWorld(lastWorld, lastSettings))
            {
                if (Directory.GetDirectories(World.InternalStructure.WorldDataDirectory).Length > 0)
                {
                    // Load an existing world
                    using (var loadForm = new LoadWorldForm())
                    {
                        loadForm.ShowDialog();
                    }
                }
                else
                {
                    // Here begins the wizard for creating a new world...
                    using (var createForm = new NewWorldForm())
                    {
                        createForm.ShowDialog();
                    }
                }
            }

            // If user has big enough screen, show the 4 Outlook pane buttons
            if (LeftNavigation.Height > 400)
            {
                LeftNavigation.VisibleButtonCount = 4;
            }

            Polygon.Initialize();
            ToolStripDefaultManipulator.CheckState = CheckState.Checked;
        }
        #endregion

        #region Switching Location & Map Display
        private void ToolStripShapeDisplay_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.SwitchDisplay();
            }
        }

        private void ToolStripIconDisplay_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.SwitchDisplay();
            }
        }
        
        private void EventPublisher_LocationChanged(object sender, MapLocationEventArgs e)
        {
            if (e.IsDisplayChange)
            {
                bool isInShapeDisplay = e.NewLocation.Display == DisplayTypes.Shape;

                ToolStripIconDisplay.CheckState = !isInShapeDisplay ? CheckState.Checked : CheckState.Unchecked;
                ToolStripShapeDisplay.CheckState = isInShapeDisplay ? CheckState.Checked : CheckState.Unchecked;

                MenuMapIconDisplay.CheckState = ToolStripIconDisplay.CheckState;
                MenuMapShapeDisplay.CheckState = ToolStripShapeDisplay.CheckState;
            }
        }

        private void Map_MouseMoved(MouseEventArgs e, Point mapLocation, Village village, Point activeLocation, Point activeVillage)
        {
            StatusXY.Text = string.Format("{0}|{1}", activeLocation.X, activeLocation.Y);
            if (village == null)
            {
                StatusPlayer.Text = string.Empty;
                StatusTribe.Text = string.Empty;
                StatusVillage.Text = string.Empty;
            }
            else
            {
                StatusPlayer.Text = village.HasPlayer ? string.Format("{0} (#{1})", village.Player.Name, village.Player.Rank) : string.Empty;
                StatusTribe.Text = village.HasTribe ? village.Player.Tribe.ToString() : string.Empty;
                StatusVillage.Text = village.ToString();
            }
        }
        #endregion

        #region Manipulators
        private void EventPublisher_PolygonActivated(object sender, PolygonEventArgs e)
        {
            Tabs.SelectedTab = TabsPolygon;
        }

        private void EventPublisher_ManipulatorChanged(object sender, ManipulatorEventArgs e)
        {
            // Visual indication of current manipulator
            var manipulators = new TupleList<ManipulatorManagerTypes, ToolStripButton>
                {
                    {ManipulatorManagerTypes.Default, ToolStripDefaultManipulator},
                    {ManipulatorManagerTypes.Polygon, ToolStripPolygonManipulator},
                    {ManipulatorManagerTypes.Attack, ToolStripAttackManipulator}
                };

            foreach (var manipulator in manipulators)
            {
                manipulator.Item2.Checked = manipulator.Item1 == e.ManipulatorType;
            }

            if (e.ManipulatorType == ManipulatorManagerTypes.Attack)
            {
                var pane = GetNavigationPane(NavigationPanes.Attack);
                LeftNavigation.SelectNavigationPage(pane.Key);
            }
        }

        private void ToolStripDefaultManipulator_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.Manipulators.SetManipulator(ManipulatorManagerTypes.Default);
            }
        }

        private void ToolStripAttackManipulator_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.Manipulators.SetManipulator(ManipulatorManagerTypes.Attack);
            }
        }

        private void ToolStripPolygonManipulator_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.Manipulators.SetManipulator(ManipulatorManagerTypes.Polygon);
            }
        }

        private void ToolStripChurchManipulator_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                ToolStripChurchManipulator.Checked = !ToolStripChurchManipulator.Checked;
                World.Default.Map.Manipulators.ToggleChurchManipulator();
                World.Default.DrawMaps(false);
            }
        }
        #endregion

        #region Settings Loading & Saving
        private void OnWorldSettingsLoaded(object sender, EventArgs e)
        {
            StatusSettings.Text = World.Default.SettingsName;

            World w = World.Default;
            if (w.SettingsName != null)
            {
                StatusWorld.Text = w.Settings.Name;

                // Fill settings contextmenu
                ToolStripSettings.DropDownItems.Clear();
                string[] settingFiles = Directory.GetFiles(w.Structure.CurrentWorldSettingsDirectory, "*" + World.InternalStructure.SettingsExtensionString);
                foreach (string setting in settingFiles)
                {
                    var settingInfo = new FileInfo(setting);
                    var itm = new ToolStripMenuItem(settingInfo.Name);
                    ToolStripSettings.DropDownItems.Add(itm);
                    itm.Click += Settings_Click;
                    if (settingInfo.Name == w.SettingsName)
                    {
                        itm.Checked = true;
                    }
                }
            }

            Map.Invalidate();
        }

        private void OnWorldLoaded(object sender, EventArgs e)
        {
            _locationChanger.LocationChanger.Initialize(World.Default.Map);

            ToolStripChurchManipulator.Visible = World.Default.Settings.Church;
            if (ToolStripChurchManipulator.Visible && !ToolStripChurchManipulator.Checked)
            {
                ToolStripChurchManipulator.PerformClick();
            }

            World.Default.Map.Manipulators.AddMouseMoved(Map_MouseMoved);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var selected = sender as ToolStripMenuItem;
            if (selected != null)
            {
                World.Default.SaveSettings();

                foreach (ToolStripMenuItem itm in ToolStripSettings.DropDownItems)
                {
                    itm.Checked = false;
                }
                selected.Checked = true;
                if (World.Default.LoadSettings(selected.Text))
                {
                    Properties.Settings.Default.LastSettings = selected.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void MenuFileSaveSettings_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.SaveSettings();
            }
        }

        private void MenuFileSaveSettingsAs_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                saveFileDialog1.InitialDirectory = World.Default.Structure.CurrentWorldSettingsDirectory;
                saveFileDialog1.FileName = "";
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string settingsName = new FileInfo(saveFileDialog1.FileName).Name;
                    World.Default.SaveSettings(settingsName);
                    World.Default.LoadWorld(World.Default.Structure.CurrentWorldDirectory, World.Default.SettingsName);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.SaveSettings();
            }
        }
        #endregion

        #region Menu & Toolstrip Handlers
        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            World.Default.SaveSettings();

            var frm = new NewWorldForm();
            frm.ShowDialog();
        }

        private void MenuFileLoadWorld_Click(object sender, EventArgs e)
        {
            World.Default.SaveSettings();

            var frm = new LoadWorldForm();
            frm.ShowDialog();
        }

        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuFileWorldDownload_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.SaveSettings();
                World.Default.Structure.DownloadNewTwSnapshot();
                World.Default.LoadWorld(World.Default.Structure.CurrentWorldDirectory, World.Default.SettingsName);
            }
        }

        private void MenuFileSynchronizeTime_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                using (var timeSetter = new TimeZoneForm())
                {
                    timeSetter.ServerOffset = World.Default.Settings.ServerOffset;
                    var result = timeSetter.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        World.Default.Settings.ServerOffset = timeSetter.ServerOffset;
                        World.Default.SaveSettings();
                    }
                }
            }
        }

        private void MenuFileSetActivePlayer_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                ActivePlayerForm.UpdateDefaultWorld();
            }
        }

        private void ToolStripOpen_Click(object sender, EventArgs e)
        {
            World.Default.SaveSettings();
            using (var frm = new LoadWorldForm())
            {
                frm.ShowDialog();
            }
        }

        private void ToolstripButtonCreateWorld_Click(object sender, EventArgs e)
        {
            World.Default.SaveSettings();
            using (var frm = new NewWorldForm())
            {
                frm.ShowDialog();
            }
        }

        private void ToolStripSave_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.SaveSettings();
            }
        }

        private void ToolStripProgramSettings_Click(object sender, EventArgs e)
        {
            // This is the debug window
            //var settings = new SettingsForm();
            //settings.Show();

            using (var f = new TestForm())
            {
                f.ShowDialog();
            }
        }

        private void ToolStripDraw_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.DrawMaps();
            }
        }

        private void ToolStripHome_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                World.Default.Map.GoHome();
            }
        }

        private void ToolStripActiveRectangle_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                if (ToolStripActiveRectangle.Checked)
                {
                    ToolStripActiveRectangle.Checked = false;
                    World.Default.Map.Manipulators.CurrentManipulator.RemoveFullControlManipulator();
                }
                else
                {
                    ToolStripActiveRectangle.Checked = true;

                    var setActiveRectangle = new ActiveRectangleManipulator(World.Default.Map, (bool newRectangleSet) =>
                        {
                            ToolStripActiveRectangle.Checked = false;
                            if (newRectangleSet)
                            {
                                Tabs.SelectedTab = TabsMonitoring;
                            }
                        });
                    World.Default.Map.Manipulators.CurrentManipulator.SetFullControlManipulator(setActiveRectangle);
                }
            }
        }

        private void MenuMapSetHomeLocation_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                DialogResult result = MessageBox.Show("Use the current position as your home?\n(You can use the Home key to jump to the Home location)", "Set Home Location", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    World.Default.Map.SaveHome();
                }
            }
        }
        #endregion

        #region Small functionality
        private void ServerTimeTimer_Tick(object sender, EventArgs e)
        {
            StatusServerTime.Text = World.Default.Settings.ServerTime.ToLongTimeString();
        }

        private void MenuMapScreenshot_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                int i = 0;
                string lFile = string.Format(@"{0}TW{1:yyyyMMdd}-", World.Default.Structure.CurrentWorldScreenshotDirectory, DateTime.Now);
                while (File.Exists(lFile + i.ToString(CultureInfo.InvariantCulture) + ".png")) i++;
                lFile += i.ToString(CultureInfo.InvariantCulture) + ".png";

                World.Default.Map.Screenshot(lFile);

                StatusMessage.Text = "Screenshot saved as " + lFile;
            }
        }

        private void MenuMapSeeScreenshots_Click(object sender, EventArgs e)
        {
            if (World.Default.HasLoaded)
            {
                Process.Start(World.Default.Structure.CurrentWorldScreenshotDirectory);
            }
        }

        private void MenuHelpReportBug_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/SanguPackage/TWTactics/issues");
        }

        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog();
            }
        }

        private void EventPublisher_Browse(object sender, BrowserEventArgs e)
        {
            Tabs.SelectedTab = TabsBrowser;
        }

        private void EventPublisher_VillagesSelected(object sender, VillagesEventArgs e)
        {
            if (e.Tool == VillageTools.PinPoint)
            {
                if (sender is string && (string)sender == VillageContextMenu.OnDetailsHack)
                {
                    var pane = GetNavigationPane(NavigationPanes.Details);
                    LeftNavigation.SelectNavigationPage(pane.Key);

                    Tabs.SelectedTab = TabsMap;
                }
            }
        }
        #endregion

        #region General Pane Stuff
        private void MenuMapSelectPane_Click(object sender, EventArgs e)
        {
            var paneIndex = int.Parse(((ToolStripMenuItem) sender).Tag.ToString());
            LeftNavigation.SelectNavigationPage(paneIndex);
        }

        private enum NavigationPanes
        {
            Location = 0,
            Details,
            Markers,
            Attack
        }

        private NavigationPanePage GetNavigationPane(NavigationPanes pane)
        {
            return LeftNavigation.NavigationPages[(int)pane];
        }
        #endregion

        #region Other Windows
        private void MenuWindowsManageYourVillages_Click(object sender, EventArgs e)
        {
            YourVillagesForm.ShowForm();
        }

        private void MenuWindowsImportVillageCoordinates_Click(object sender, EventArgs e)
        {
            var frm = new VillageCoordinatesImporterForm();
            frm.Show();
        }
        #endregion
    }
}
