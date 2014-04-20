using TribalWars.Controls.Accordeon;
using TribalWars.Controls.AttackPlan;
using TribalWars.Controls.Main;
using TribalWars.Controls.Main.Polygon;

namespace TribalWars.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MiniMap = new TribalWars.Controls.Maps.MiniMapControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.PickColor = new System.Windows.Forms.ColorDialog();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusVillage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusPlayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusTribe = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusSettings = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusWorld = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusServerTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.GeneralTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.VillageTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileLoadWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileWorldDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveSettingsAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMapScreenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSave = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripDownload = new System.Windows.Forms.ToolStripButton();
            this.ToolStripHome = new System.Windows.Forms.ToolStripButton();
            this.ToolStripDraw = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripIconDisplay = new System.Windows.Forms.ToolStripButton();
            this.ToolStripShapeDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripDefaultManipulator = new System.Windows.Forms.ToolStripButton();
            this.ToolStripPolygonManipulator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.FormSplitter = new System.Windows.Forms.SplitContainer();
            this.LeftNavigationTable = new System.Windows.Forms.TableLayoutPanel();
            this.LeftNavigation = new Ascend.Windows.Forms.NavigationPane();
            this.LeftNavigation_Location = new Ascend.Windows.Forms.NavigationPanePage();
            this.locationControl1 = new TribalWars.Controls.Accordeon.Location.LocationControl();
            this.LeftNavigation_QuickFind = new Ascend.Windows.Forms.NavigationPanePage();
            this.detailsControl1 = new TribalWars.Controls.Accordeon.Details.DetailsControl();
            this.LeftNavigation_Markers = new Ascend.Windows.Forms.NavigationPanePage();
            this.markersContainerControl1 = new TribalWars.Controls.Accordeon.MarkersContainerControl();
            this.LeftNavigation_Distance = new Ascend.Windows.Forms.NavigationPanePage();
            this.MapDistance = new TribalWars.Controls.AttackPlan.MapDistanceCollectionControl();
            this.Tabs = new Janus.Windows.UI.Tab.UITab();
            this.TabsMap = new Janus.Windows.UI.Tab.UITabPage();
            this.Map = new TribalWars.Controls.Maps.MapControl();
            this.TabsGameBrowser = new Janus.Windows.UI.Tab.UITabPage();
            this.Browser = new TribalWars.Controls.Main.Browser.BrowserControl();
            this.TabsBrowser = new Janus.Windows.UI.Tab.UITabPage();
            this.browserControl1 = new TribalWars.Controls.Main.Browser.BrowserControl();
            this.TabsParser = new Janus.Windows.UI.Tab.UITabPage();
            this.Parser = new TribalWars.Controls.Main.ParserControl();
            this.TabsPolygon = new Janus.Windows.UI.Tab.UITabPage();
            this.Polygon = new TribalWars.Controls.Main.Polygon.PolygonControl();
            this.TabsMonitoring = new Janus.Windows.UI.Tab.UITabPage();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.FormToolbarContainer = new System.Windows.Forms.ToolStripContainer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            this.Status.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormSplitter)).BeginInit();
            this.FormSplitter.Panel1.SuspendLayout();
            this.FormSplitter.Panel2.SuspendLayout();
            this.FormSplitter.SuspendLayout();
            this.LeftNavigationTable.SuspendLayout();
            this.LeftNavigation.SuspendLayout();
            this.LeftNavigation_Location.SuspendLayout();
            this.LeftNavigation_QuickFind.SuspendLayout();
            this.LeftNavigation_Markers.SuspendLayout();
            this.LeftNavigation_Distance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabs)).BeginInit();
            this.Tabs.SuspendLayout();
            this.TabsMap.SuspendLayout();
            this.TabsGameBrowser.SuspendLayout();
            this.TabsBrowser.SuspendLayout();
            this.TabsParser.SuspendLayout();
            this.TabsPolygon.SuspendLayout();
            this.FormToolbarContainer.ContentPanel.SuspendLayout();
            this.FormToolbarContainer.TopToolStripPanel.SuspendLayout();
            this.FormToolbarContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(this.MiniMap);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(313, 229);
            panel1.TabIndex = 1;
            // 
            // MiniMap
            // 
            this.MiniMap.BackColor = System.Drawing.Color.Green;
            this.MiniMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiniMap.Location = new System.Drawing.Point(0, 0);
            this.MiniMap.Name = "MiniMap";
            this.MiniMap.Size = new System.Drawing.Size(311, 227);
            this.MiniMap.TabIndex = 1;
            this.MiniMap.Text = "miniMapControl1";
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusMessage,
            this.StatusXY,
            this.StatusVillage,
            this.StatusPlayer,
            this.StatusTribe,
            this.StatusSettings,
            this.StatusWorld,
            this.StatusServerTime,
            this.toolStripStatusLabel5});
            this.Status.Location = new System.Drawing.Point(0, 661);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(1199, 24);
            this.Status.TabIndex = 17;
            this.Status.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(0, 18);
            // 
            // StatusMessage
            // 
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(539, 19);
            this.StatusMessage.Spring = true;
            this.StatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusXY
            // 
            this.StatusXY.AutoSize = false;
            this.StatusXY.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusXY.Name = "StatusXY";
            this.StatusXY.Size = new System.Drawing.Size(50, 19);
            this.StatusXY.Text = "X|Y";
            // 
            // StatusVillage
            // 
            this.StatusVillage.AutoSize = false;
            this.StatusVillage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusVillage.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusVillage.Name = "StatusVillage";
            this.StatusVillage.Size = new System.Drawing.Size(150, 19);
            this.StatusVillage.Text = "Village";
            this.StatusVillage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusPlayer
            // 
            this.StatusPlayer.AutoSize = false;
            this.StatusPlayer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusPlayer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusPlayer.Name = "StatusPlayer";
            this.StatusPlayer.Size = new System.Drawing.Size(150, 19);
            this.StatusPlayer.Text = "Player";
            this.StatusPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusTribe
            // 
            this.StatusTribe.AutoSize = false;
            this.StatusTribe.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusTribe.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusTribe.Name = "StatusTribe";
            this.StatusTribe.Size = new System.Drawing.Size(50, 19);
            this.StatusTribe.Text = "Tribe";
            this.StatusTribe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusSettings
            // 
            this.StatusSettings.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusSettings.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusSettings.Name = "StatusSettings";
            this.StatusSettings.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.StatusSettings.Size = new System.Drawing.Size(95, 19);
            this.StatusSettings.Text = "Loaded Settings";
            this.StatusSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusWorld
            // 
            this.StatusWorld.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusWorld.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusWorld.Name = "StatusWorld";
            this.StatusWorld.Size = new System.Drawing.Size(58, 19);
            this.StatusWorld.Text = "World 12";
            // 
            // StatusServerTime
            // 
            this.StatusServerTime.AutoSize = false;
            this.StatusServerTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusServerTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusServerTime.Name = "StatusServerTime";
            this.StatusServerTime.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.StatusServerTime.Size = new System.Drawing.Size(65, 19);
            this.StatusServerTime.Text = "ServerTime";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(25, 19);
            // 
            // ServerTimeTimer
            // 
            this.ServerTimeTimer.Enabled = true;
            this.ServerTimeTimer.Interval = 1;
            this.ServerTimeTimer.Tick += new System.EventHandler(this.ServerTimeTimer_Tick);
            // 
            // VillageTooltip
            // 
            this.VillageTooltip.AutoPopDelay = 10000;
            this.VillageTooltip.InitialDelay = 500;
            this.VillageTooltip.IsBalloon = true;
            this.VillageTooltip.ReshowDelay = 100;
            this.VillageTooltip.ShowAlways = true;
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.mapToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1199, 24);
            this.MenuBar.TabIndex = 22;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.MenuFileLoadWorld,
            this.toolStripMenuItem4,
            this.MenuFileWorldDownload,
            this.toolStripSeparator1,
            this.MenuFileSaveSettings,
            this.MenuFileSaveSettingsAs,
            this.toolStripSeparator2,
            this.MenuFileExit});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem1.Text = "&World";
            // 
            // MenuFileNew
            // 
            this.MenuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileNew.Image")));
            this.MenuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileNew.Name = "MenuFileNew";
            this.MenuFileNew.Size = new System.Drawing.Size(155, 22);
            this.MenuFileNew.Text = "&New world";
            this.MenuFileNew.Click += new System.EventHandler(this.MenuFileNew_Click);
            // 
            // MenuFileLoadWorld
            // 
            this.MenuFileLoadWorld.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileLoadWorld.Image")));
            this.MenuFileLoadWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileLoadWorld.Name = "MenuFileLoadWorld";
            this.MenuFileLoadWorld.Size = new System.Drawing.Size(155, 22);
            this.MenuFileLoadWorld.Text = "&Load world";
            this.MenuFileLoadWorld.Click += new System.EventHandler(this.MenuFileLoadWorld_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 6);
            // 
            // MenuFileWorldDownload
            // 
            this.MenuFileWorldDownload.Name = "MenuFileWorldDownload";
            this.MenuFileWorldDownload.Size = new System.Drawing.Size(155, 22);
            this.MenuFileWorldDownload.Text = "&Download Data";
            this.MenuFileWorldDownload.Click += new System.EventHandler(this.MenuFileWorldDownload_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // MenuFileSaveSettings
            // 
            this.MenuFileSaveSettings.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileSaveSettings.Image")));
            this.MenuFileSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileSaveSettings.Name = "MenuFileSaveSettings";
            this.MenuFileSaveSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuFileSaveSettings.Size = new System.Drawing.Size(155, 22);
            this.MenuFileSaveSettings.Text = "&Save";
            this.MenuFileSaveSettings.Click += new System.EventHandler(this.MenuFileSaveSettings_Click);
            // 
            // MenuFileSaveSettingsAs
            // 
            this.MenuFileSaveSettingsAs.Name = "MenuFileSaveSettingsAs";
            this.MenuFileSaveSettingsAs.Size = new System.Drawing.Size(155, 22);
            this.MenuFileSaveSettingsAs.Text = "Save &As";
            this.MenuFileSaveSettingsAs.Click += new System.EventHandler(this.MenuFileSaveSettingsAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(155, 22);
            this.MenuFileExit.Text = "E&xit";
            this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMapScreenshot});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "&Map";
            // 
            // MenuMapScreenshot
            // 
            this.MenuMapScreenshot.Name = "MenuMapScreenshot";
            this.MenuMapScreenshot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.MenuMapScreenshot.Size = new System.Drawing.Size(173, 22);
            this.MenuMapScreenshot.Text = "Screenshot";
            this.MenuMapScreenshot.Click += new System.EventHandler(this.MenuMapScreenshot_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ie0001.png");
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripOpen,
            this.ToolStripSave,
            this.ToolStripSettings,
            this.toolStripSeparator4,
            this.ToolStripDownload,
            this.ToolStripHome,
            this.ToolStripDraw,
            this.toolStripSeparator5,
            this.ToolStripIconDisplay,
            this.ToolStripShapeDisplay,
            this.toolStripSeparator3,
            this.ToolStripDefaultManipulator,
            this.ToolStripPolygonManipulator,
            this.toolStripSeparator});
            this.ToolStrip.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(305, 25);
            this.ToolStrip.TabIndex = 0;
            // 
            // ToolStripOpen
            // 
            this.ToolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripOpen.Image")));
            this.ToolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripOpen.Name = "ToolStripOpen";
            this.ToolStripOpen.Size = new System.Drawing.Size(23, 22);
            this.ToolStripOpen.Text = "&Open";
            this.ToolStripOpen.Click += new System.EventHandler(this.ToolStripOpen_Click);
            // 
            // ToolStripSave
            // 
            this.ToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSave.Image")));
            this.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSave.Name = "ToolStripSave";
            this.ToolStripSave.Size = new System.Drawing.Size(23, 22);
            this.ToolStripSave.Text = "&Save";
            this.ToolStripSave.Click += new System.EventHandler(this.ToolStripSave_Click);
            // 
            // ToolStripSettings
            // 
            this.ToolStripSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripSettings.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSettings.Image")));
            this.ToolStripSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSettings.Name = "ToolStripSettings";
            this.ToolStripSettings.Size = new System.Drawing.Size(62, 22);
            this.ToolStripSettings.Text = "Settings";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripDownload
            // 
            this.ToolStripDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripDownload.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripDownload.Image")));
            this.ToolStripDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDownload.Name = "ToolStripDownload";
            this.ToolStripDownload.Size = new System.Drawing.Size(23, 22);
            this.ToolStripDownload.Text = "Download latest TW data";
            this.ToolStripDownload.Click += new System.EventHandler(this.MenuFileWorldDownload_Click);
            // 
            // ToolStripHome
            // 
            this.ToolStripHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripHome.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripHome.Image")));
            this.ToolStripHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripHome.Name = "ToolStripHome";
            this.ToolStripHome.Size = new System.Drawing.Size(23, 22);
            this.ToolStripHome.Text = "Center the map on your home";
            this.ToolStripHome.Click += new System.EventHandler(this.ToolStripHome_Click);
            // 
            // ToolStripDraw
            // 
            this.ToolStripDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripDraw.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripDraw.Image")));
            this.ToolStripDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDraw.Name = "ToolStripDraw";
            this.ToolStripDraw.Size = new System.Drawing.Size(23, 22);
            this.ToolStripDraw.Text = "Draw the map";
            this.ToolStripDraw.Click += new System.EventHandler(this.ToolStripDraw_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripIconDisplay
            // 
            this.ToolStripIconDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripIconDisplay.Image = global::TribalWars.Properties.Resources.Village;
            this.ToolStripIconDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripIconDisplay.Name = "ToolStripIconDisplay";
            this.ToolStripIconDisplay.Size = new System.Drawing.Size(23, 22);
            this.ToolStripIconDisplay.Text = "Switch map display to tw village images";
            this.ToolStripIconDisplay.Click += new System.EventHandler(this.ToolStripIconDisplay_Click);
            // 
            // ToolStripShapeDisplay
            // 
            this.ToolStripShapeDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripShapeDisplay.Image = global::TribalWars.Properties.Resources.shapes;
            this.ToolStripShapeDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripShapeDisplay.Name = "ToolStripShapeDisplay";
            this.ToolStripShapeDisplay.Size = new System.Drawing.Size(23, 22);
            this.ToolStripShapeDisplay.Text = "Switch map display to shape villages";
            this.ToolStripShapeDisplay.Click += new System.EventHandler(this.ToolStripShapeDisplay_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripDefaultManipulator
            // 
            this.ToolStripDefaultManipulator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripDefaultManipulator.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripDefaultManipulator.Image")));
            this.ToolStripDefaultManipulator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDefaultManipulator.Name = "ToolStripDefaultManipulator";
            this.ToolStripDefaultManipulator.Size = new System.Drawing.Size(23, 22);
            this.ToolStripDefaultManipulator.Text = "Default";
            this.ToolStripDefaultManipulator.Click += new System.EventHandler(this.ToolStripDefaultManipulator_Click);
            // 
            // ToolStripPolygonManipulator
            // 
            this.ToolStripPolygonManipulator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripPolygonManipulator.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripPolygonManipulator.Image")));
            this.ToolStripPolygonManipulator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripPolygonManipulator.Name = "ToolStripPolygonManipulator";
            this.ToolStripPolygonManipulator.Size = new System.Drawing.Size(23, 22);
            this.ToolStripPolygonManipulator.Text = "Polygon";
            this.ToolStripPolygonManipulator.Click += new System.EventHandler(this.ToolStripPolygonManipulator_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ContentPanel.Size = new System.Drawing.Size(1199, 614);
            // 
            // FormSplitter
            // 
            this.FormSplitter.BackColor = System.Drawing.Color.Transparent;
            this.FormSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.FormSplitter.Location = new System.Drawing.Point(0, 0);
            this.FormSplitter.Name = "FormSplitter";
            // 
            // FormSplitter.Panel1
            // 
            this.FormSplitter.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.FormSplitter.Panel1.Controls.Add(this.LeftNavigationTable);
            this.FormSplitter.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            // 
            // FormSplitter.Panel2
            // 
            this.FormSplitter.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.FormSplitter.Panel2.Controls.Add(this.Tabs);
            this.FormSplitter.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.FormSplitter.Size = new System.Drawing.Size(1199, 612);
            this.FormSplitter.SplitterDistance = 322;
            this.FormSplitter.TabIndex = 0;
            // 
            // LeftNavigationTable
            // 
            this.LeftNavigationTable.ColumnCount = 1;
            this.LeftNavigationTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LeftNavigationTable.Controls.Add(this.LeftNavigation, 0, 1);
            this.LeftNavigationTable.Controls.Add(panel1, 0, 0);
            this.LeftNavigationTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftNavigationTable.Location = new System.Drawing.Point(3, 3);
            this.LeftNavigationTable.Margin = new System.Windows.Forms.Padding(0);
            this.LeftNavigationTable.Name = "LeftNavigationTable";
            this.LeftNavigationTable.RowCount = 2;
            this.LeftNavigationTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.LeftNavigationTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LeftNavigationTable.Size = new System.Drawing.Size(319, 606);
            this.LeftNavigationTable.TabIndex = 1;
            // 
            // LeftNavigation
            // 
            this.LeftNavigation.ButtonActiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(155)))));
            this.LeftNavigation.ButtonActiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation.ButtonBorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.LeftNavigation.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LeftNavigation.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftNavigation.ButtonGradientHighColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftNavigation.ButtonGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation.ButtonHighlightGradientHighColor = System.Drawing.Color.White;
            this.LeftNavigation.ButtonHighlightGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation.CaptionBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.LeftNavigation.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LeftNavigation.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LeftNavigation.CaptionGradientHighColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation.CaptionGradientLowColor = System.Drawing.SystemColors.ActiveCaption;
            this.LeftNavigation.Controls.Add(this.LeftNavigation_Location);
            this.LeftNavigation.Controls.Add(this.LeftNavigation_QuickFind);
            this.LeftNavigation.Controls.Add(this.LeftNavigation_Markers);
            this.LeftNavigation.Controls.Add(this.LeftNavigation_Distance);
            this.LeftNavigation.Cursor = System.Windows.Forms.Cursors.Default;
            this.LeftNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftNavigation.FooterGradientHighColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftNavigation.FooterGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation.FooterHeight = 30;
            this.LeftNavigation.FooterHighlightGradientHighColor = System.Drawing.Color.White;
            this.LeftNavigation.FooterHighlightGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation.Location = new System.Drawing.Point(3, 238);
            this.LeftNavigation.Name = "LeftNavigation";
            this.LeftNavigation.NavigationPages.AddRange(new Ascend.Windows.Forms.NavigationPanePage[] {
            this.LeftNavigation_Location,
            this.LeftNavigation_QuickFind,
            this.LeftNavigation_Markers,
            this.LeftNavigation_Distance});
            this.LeftNavigation.Size = new System.Drawing.Size(313, 367);
            this.LeftNavigation.TabIndex = 0;
            this.LeftNavigation.VisibleButtonCount = 4;
            // 
            // LeftNavigation_Location
            // 
            this.LeftNavigation_Location.ActiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(155)))));
            this.LeftNavigation_Location.ActiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_Location.AutoScroll = true;
            this.LeftNavigation_Location.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LeftNavigation_Location.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftNavigation_Location.Controls.Add(this.locationControl1);
            this.LeftNavigation_Location.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftNavigation_Location.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation_Location.HighlightGradientHighColor = System.Drawing.Color.White;
            this.LeftNavigation_Location.HighlightGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_Location.Image = ((System.Drawing.Image)(resources.GetObject("LeftNavigation_Location.Image")));
            this.LeftNavigation_Location.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_Location.ImageFooter = null;
            this.LeftNavigation_Location.ImageIndex = -1;
            this.LeftNavigation_Location.ImageIndexFooter = -1;
            this.LeftNavigation_Location.ImageKey = "";
            this.LeftNavigation_Location.ImageKeyFooter = "";
            this.LeftNavigation_Location.ImageList = null;
            this.LeftNavigation_Location.ImageListFooter = null;
            this.LeftNavigation_Location.Key = "LeftNavigation_Location";
            this.LeftNavigation_Location.Location = new System.Drawing.Point(1, 27);
            this.LeftNavigation_Location.Name = "LeftNavigation_Location";
            this.LeftNavigation_Location.Size = new System.Drawing.Size(311, 174);
            this.LeftNavigation_Location.TabIndex = 1;
            this.LeftNavigation_Location.Text = "Location Options";
            this.LeftNavigation_Location.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_Location.ToolTipText = null;
            // 
            // locationControl1
            // 
            this.locationControl1.BackColor = System.Drawing.Color.Transparent;
            this.locationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationControl1.Location = new System.Drawing.Point(0, 0);
            this.locationControl1.Margin = new System.Windows.Forms.Padding(0);
            this.locationControl1.Name = "locationControl1";
            this.locationControl1.Size = new System.Drawing.Size(311, 174);
            this.locationControl1.TabIndex = 0;
            // 
            // LeftNavigation_QuickFind
            // 
            this.LeftNavigation_QuickFind.ActiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(155)))));
            this.LeftNavigation_QuickFind.ActiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_QuickFind.AutoScroll = true;
            this.LeftNavigation_QuickFind.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LeftNavigation_QuickFind.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftNavigation_QuickFind.Controls.Add(this.detailsControl1);
            this.LeftNavigation_QuickFind.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftNavigation_QuickFind.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation_QuickFind.HighlightGradientHighColor = System.Drawing.Color.White;
            this.LeftNavigation_QuickFind.HighlightGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_QuickFind.Image = ((System.Drawing.Image)(resources.GetObject("LeftNavigation_QuickFind.Image")));
            this.LeftNavigation_QuickFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_QuickFind.ImageFooter = null;
            this.LeftNavigation_QuickFind.ImageIndex = -1;
            this.LeftNavigation_QuickFind.ImageIndexFooter = -1;
            this.LeftNavigation_QuickFind.ImageKey = "";
            this.LeftNavigation_QuickFind.ImageKeyFooter = "";
            this.LeftNavigation_QuickFind.ImageList = null;
            this.LeftNavigation_QuickFind.ImageListFooter = null;
            this.LeftNavigation_QuickFind.Key = "LeftNavigation_QuickFind";
            this.LeftNavigation_QuickFind.Location = new System.Drawing.Point(1, 27);
            this.LeftNavigation_QuickFind.Name = "LeftNavigation_QuickFind";
            this.LeftNavigation_QuickFind.Size = new System.Drawing.Size(311, 174);
            this.LeftNavigation_QuickFind.TabIndex = 4;
            this.LeftNavigation_QuickFind.Text = "Quick Details";
            this.LeftNavigation_QuickFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_QuickFind.ToolTipText = null;
            // 
            // detailsControl1
            // 
            this.detailsControl1.BackColor = System.Drawing.Color.Transparent;
            this.detailsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsControl1.Location = new System.Drawing.Point(0, 0);
            this.detailsControl1.Margin = new System.Windows.Forms.Padding(0);
            this.detailsControl1.Name = "detailsControl1";
            this.detailsControl1.Size = new System.Drawing.Size(311, 174);
            this.detailsControl1.TabIndex = 1;
            // 
            // LeftNavigation_Markers
            // 
            this.LeftNavigation_Markers.ActiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(155)))));
            this.LeftNavigation_Markers.ActiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_Markers.AutoScroll = true;
            this.LeftNavigation_Markers.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LeftNavigation_Markers.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftNavigation_Markers.Controls.Add(this.markersContainerControl1);
            this.LeftNavigation_Markers.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftNavigation_Markers.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation_Markers.HighlightGradientHighColor = System.Drawing.Color.White;
            this.LeftNavigation_Markers.HighlightGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_Markers.Image = ((System.Drawing.Image)(resources.GetObject("LeftNavigation_Markers.Image")));
            this.LeftNavigation_Markers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_Markers.ImageFooter = null;
            this.LeftNavigation_Markers.ImageIndex = -1;
            this.LeftNavigation_Markers.ImageIndexFooter = -1;
            this.LeftNavigation_Markers.ImageKey = "";
            this.LeftNavigation_Markers.ImageKeyFooter = "";
            this.LeftNavigation_Markers.ImageList = null;
            this.LeftNavigation_Markers.ImageListFooter = null;
            this.LeftNavigation_Markers.Key = "LeftNavigation_Markers";
            this.LeftNavigation_Markers.Location = new System.Drawing.Point(1, 27);
            this.LeftNavigation_Markers.Name = "LeftNavigation_Markers";
            this.LeftNavigation_Markers.Size = new System.Drawing.Size(311, 174);
            this.LeftNavigation_Markers.TabIndex = 3;
            this.LeftNavigation_Markers.Text = "Map Markers";
            this.LeftNavigation_Markers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_Markers.ToolTipText = null;
            // 
            // markersContainerControl1
            // 
            this.markersContainerControl1.BackColor = System.Drawing.Color.Transparent;
            this.markersContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markersContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.markersContainerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.markersContainerControl1.Name = "markersContainerControl1";
            this.markersContainerControl1.Size = new System.Drawing.Size(311, 174);
            this.markersContainerControl1.TabIndex = 1;
            // 
            // LeftNavigation_Distance
            // 
            this.LeftNavigation_Distance.ActiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(155)))));
            this.LeftNavigation_Distance.ActiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_Distance.AutoScroll = true;
            this.LeftNavigation_Distance.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LeftNavigation_Distance.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftNavigation_Distance.Controls.Add(this.MapDistance);
            this.LeftNavigation_Distance.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeftNavigation_Distance.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LeftNavigation_Distance.HighlightGradientHighColor = System.Drawing.Color.White;
            this.LeftNavigation_Distance.HighlightGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(78)))));
            this.LeftNavigation_Distance.Image = ((System.Drawing.Image)(resources.GetObject("LeftNavigation_Distance.Image")));
            this.LeftNavigation_Distance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_Distance.ImageFooter = null;
            this.LeftNavigation_Distance.ImageIndex = -1;
            this.LeftNavigation_Distance.ImageIndexFooter = -1;
            this.LeftNavigation_Distance.ImageKey = "";
            this.LeftNavigation_Distance.ImageKeyFooter = "";
            this.LeftNavigation_Distance.ImageList = null;
            this.LeftNavigation_Distance.ImageListFooter = null;
            this.LeftNavigation_Distance.Key = "LeftNavigation_Distance";
            this.LeftNavigation_Distance.Location = new System.Drawing.Point(1, 27);
            this.LeftNavigation_Distance.Name = "LeftNavigation_Distance";
            this.LeftNavigation_Distance.Size = new System.Drawing.Size(311, 174);
            this.LeftNavigation_Distance.TabIndex = 6;
            this.LeftNavigation_Distance.Text = "Plan Attacks";
            this.LeftNavigation_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftNavigation_Distance.ToolTipText = null;
            // 
            // MapDistance
            // 
            this.MapDistance.ActivePlan = null;
            this.MapDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapDistance.Location = new System.Drawing.Point(0, 0);
            this.MapDistance.Margin = new System.Windows.Forms.Padding(0);
            this.MapDistance.Name = "MapDistance";
            this.MapDistance.Size = new System.Drawing.Size(311, 174);
            this.MapDistance.Sound = false;
            this.MapDistance.TabIndex = 0;
            // 
            // Tabs
            // 
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.InputFocusTab = this.TabsMap;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.Size = new System.Drawing.Size(870, 609);
            this.Tabs.TabIndex = 1;
            this.Tabs.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.TabsMap,
            this.TabsGameBrowser,
            this.TabsBrowser,
            this.TabsParser,
            this.TabsPolygon,
            this.TabsMonitoring,
            this.uiTabPage1});
            // 
            // TabsMap
            // 
            this.TabsMap.Controls.Add(this.Map);
            this.TabsMap.Location = new System.Drawing.Point(1, 21);
            this.TabsMap.Name = "TabsMap";
            this.TabsMap.Size = new System.Drawing.Size(866, 585);
            this.TabsMap.TabStop = true;
            this.TabsMap.Text = "Map";
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.Transparent;
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Margin = new System.Windows.Forms.Padding(0);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(866, 585);
            this.Map.TabIndex = 0;
            // 
            // TabsGameBrowser
            // 
            this.TabsGameBrowser.Controls.Add(this.Browser);
            this.TabsGameBrowser.Location = new System.Drawing.Point(1, 21);
            this.TabsGameBrowser.Name = "TabsGameBrowser";
            this.TabsGameBrowser.Size = new System.Drawing.Size(866, 585);
            this.TabsGameBrowser.TabStop = true;
            this.TabsGameBrowser.Text = "Game Browser";
            // 
            // Browser
            // 
            this.Browser.ActiveVillage = 0;
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.GameBrowser = true;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(866, 585);
            this.Browser.TabIndex = 0;
            // 
            // TabsBrowser
            // 
            this.TabsBrowser.Controls.Add(this.browserControl1);
            this.TabsBrowser.Location = new System.Drawing.Point(1, 21);
            this.TabsBrowser.Name = "TabsBrowser";
            this.TabsBrowser.Size = new System.Drawing.Size(866, 585);
            this.TabsBrowser.TabStop = true;
            this.TabsBrowser.Text = "Browser";
            // 
            // browserControl1
            // 
            this.browserControl1.ActiveVillage = 0;
            this.browserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserControl1.GameBrowser = false;
            this.browserControl1.Location = new System.Drawing.Point(0, 0);
            this.browserControl1.Name = "browserControl1";
            this.browserControl1.Size = new System.Drawing.Size(866, 585);
            this.browserControl1.TabIndex = 0;
            // 
            // TabsParser
            // 
            this.TabsParser.Controls.Add(this.Parser);
            this.TabsParser.Location = new System.Drawing.Point(1, 21);
            this.TabsParser.Name = "TabsParser";
            this.TabsParser.Size = new System.Drawing.Size(866, 585);
            this.TabsParser.TabStop = true;
            this.TabsParser.Text = "Parser";
            // 
            // Parser
            // 
            this.Parser.BackColor = System.Drawing.Color.Transparent;
            this.Parser.Dock = System.Windows.Forms.DockStyle.Top;
            this.Parser.Location = new System.Drawing.Point(0, 0);
            this.Parser.Margin = new System.Windows.Forms.Padding(0);
            this.Parser.Name = "Parser";
            this.Parser.Size = new System.Drawing.Size(866, 602);
            this.Parser.TabIndex = 0;
            this.Parser.Visible = false;
            // 
            // TabsPolygon
            // 
            this.TabsPolygon.Controls.Add(this.Polygon);
            this.TabsPolygon.Location = new System.Drawing.Point(1, 21);
            this.TabsPolygon.Name = "TabsPolygon";
            this.TabsPolygon.Size = new System.Drawing.Size(866, 585);
            this.TabsPolygon.TabStop = true;
            this.TabsPolygon.Text = "Polygon";
            // 
            // Polygon
            // 
            this.Polygon.BackColor = System.Drawing.Color.Transparent;
            this.Polygon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Polygon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Polygon.Location = new System.Drawing.Point(0, 0);
            this.Polygon.Name = "Polygon";
            this.Polygon.Size = new System.Drawing.Size(866, 585);
            this.Polygon.TabIndex = 0;
            // 
            // TabsMonitoring
            // 
            this.TabsMonitoring.Location = new System.Drawing.Point(1, 21);
            this.TabsMonitoring.Name = "TabsMonitoring";
            this.TabsMonitoring.Size = new System.Drawing.Size(866, 585);
            this.TabsMonitoring.TabStop = true;
            this.TabsMonitoring.Text = "Monitoring";
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(866, 585);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "New Tab";
            // 
            // FormToolbarContainer
            // 
            // 
            // FormToolbarContainer.ContentPanel
            // 
            this.FormToolbarContainer.ContentPanel.Controls.Add(this.FormSplitter);
            this.FormToolbarContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.FormToolbarContainer.ContentPanel.Size = new System.Drawing.Size(1199, 612);
            this.FormToolbarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormToolbarContainer.Location = new System.Drawing.Point(0, 24);
            this.FormToolbarContainer.Name = "FormToolbarContainer";
            this.FormToolbarContainer.Size = new System.Drawing.Size(1199, 637);
            this.FormToolbarContainer.TabIndex = 26;
            this.FormToolbarContainer.Text = "toolStripContainer1";
            // 
            // FormToolbarContainer.TopToolStripPanel
            // 
            this.FormToolbarContainer.TopToolStripPanel.Controls.Add(this.ToolStrip);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sets";
            this.saveFileDialog1.Filter = "Settings|*.sets";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 685);
            this.Controls.Add(this.FormToolbarContainer);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TW Tactics v0.2 - by Sangu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            panel1.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.FormSplitter.Panel1.ResumeLayout(false);
            this.FormSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormSplitter)).EndInit();
            this.FormSplitter.ResumeLayout(false);
            this.LeftNavigationTable.ResumeLayout(false);
            this.LeftNavigation.ResumeLayout(false);
            this.LeftNavigation_Location.ResumeLayout(false);
            this.LeftNavigation_QuickFind.ResumeLayout(false);
            this.LeftNavigation_Markers.ResumeLayout(false);
            this.LeftNavigation_Distance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tabs)).EndInit();
            this.Tabs.ResumeLayout(false);
            this.TabsMap.ResumeLayout(false);
            this.TabsGameBrowser.ResumeLayout(false);
            this.TabsBrowser.ResumeLayout(false);
            this.TabsParser.ResumeLayout(false);
            this.TabsPolygon.ResumeLayout(false);
            this.FormToolbarContainer.ContentPanel.ResumeLayout(false);
            this.FormToolbarContainer.TopToolStripPanel.ResumeLayout(false);
            this.FormToolbarContainer.TopToolStripPanel.PerformLayout();
            this.FormToolbarContainer.ResumeLayout(false);
            this.FormToolbarContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ColorDialog PickColor;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.Timer ServerTimeTimer;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolTip GeneralTooltip;
        private System.Windows.Forms.ToolTip VillageTooltip;
        private System.Windows.Forms.MenuStrip MenuBar;
        internal System.Windows.Forms.ToolStripStatusLabel StatusMessage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel StatusServerTime;
        internal System.Windows.Forms.ToolStripStatusLabel StatusXY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton ToolStripOpen;
        private System.Windows.Forms.ToolStripButton ToolStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton ToolStripDraw;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.SplitContainer FormSplitter;
        private System.Windows.Forms.ToolStripContainer FormToolbarContainer;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileNew;
        private System.Windows.Forms.ToolStripMenuItem MenuFileLoadWorld;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveSettingsAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private Ascend.Windows.Forms.NavigationPanePage LeftNavigation_Markers;
        private Ascend.Windows.Forms.NavigationPanePage LeftNavigation_QuickFind;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMapScreenshot;
        internal System.Windows.Forms.ToolStripStatusLabel StatusPlayer;
        internal System.Windows.Forms.ToolStripStatusLabel StatusTribe;
        internal System.Windows.Forms.ToolStripStatusLabel StatusVillage;
        private System.Windows.Forms.ToolStripDropDownButton ToolStripSettings;
        //private Controls.YouTreeold YouTree;
        private Ascend.Windows.Forms.NavigationPanePage LeftNavigation_Distance;
        private MapDistanceCollectionControl MapDistance;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuFileWorldDownload;
        private Ascend.Windows.Forms.NavigationPanePage LeftNavigation_Location;
        //private TribalWars.Controls.Accordeon.Location.LocationControl locationControl1;
        private MarkersContainerControl markersContainerControl1;
        private TribalWars.Controls.Maps.MapControl Map;
        private TribalWars.Controls.Main.Browser.BrowserControl Browser;
        private ParserControl Parser;
        private PolygonControl Polygon;
        //private TribalWars.Controls.Accordeon.Details.DetailsControl QuickDetails;
        //private TribalWars.Controls.Main.Monitoring.MonitoringControl monitoringControl1;
        private TribalWars.Controls.Main.Browser.BrowserControl browserControl1;
        private System.Windows.Forms.ToolStripButton ToolStripDownload;
        private System.Windows.Forms.ToolStripButton ToolStripHome;
        internal System.Windows.Forms.ToolStripStatusLabel StatusSettings;
        internal System.Windows.Forms.ToolStripStatusLabel StatusWorld;
        private Janus.Windows.UI.Tab.UITab Tabs;
        private Janus.Windows.UI.Tab.UITabPage TabsMap;
        private Janus.Windows.UI.Tab.UITabPage TabsGameBrowser;
        private Janus.Windows.UI.Tab.UITabPage TabsBrowser;
        private Janus.Windows.UI.Tab.UITabPage TabsParser;
        private Janus.Windows.UI.Tab.UITabPage TabsPolygon;
        private Janus.Windows.UI.Tab.UITabPage TabsMonitoring;
        private System.Windows.Forms.TableLayoutPanel LeftNavigationTable;
        private System.Windows.Forms.ToolStripButton ToolStripIconDisplay;
        private System.Windows.Forms.ToolStripButton ToolStripShapeDisplay;
        private TribalWars.Controls.Maps.MiniMapControl MiniMap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ToolStripDefaultManipulator;
        private System.Windows.Forms.ToolStripButton ToolStripPolygonManipulator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Ascend.Windows.Forms.NavigationPane LeftNavigation;
        private Controls.Accordeon.Details.DetailsControl detailsControl1;
        private Controls.Accordeon.Location.LocationControl locationControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

