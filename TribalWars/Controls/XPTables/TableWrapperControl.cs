using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TribalWars.Browsers.Reporting;
using TribalWars.Controls.AccordeonLocation;
using TribalWars.Maps;
using TribalWars.Villages;
using TribalWars.Villages.ContextMenu;
using TribalWars.Worlds;
using TribalWars.Worlds.Events;
using TribalWars.Worlds.Events.Impls;
using XPTable.Models;

namespace TribalWars.Controls.XPTables
{
    /// <summary>
    /// Control for displaying villages, players and tribes in an XPTable.
    /// Also provides right click functionality etc.
    /// 
    /// LEGACY: Use Janus GridEx. This one gets problematic with larger datasets.
    /// </summary>
    public partial class TableWrapperControl : UserControl
    {
        #region Enums
        /// <summary>
        /// The fields to display in the XPTable
        /// </summary>
        public enum ColumnDisplayTypeEnum
        {
            All,
            Default,
            Custom
        }

        /// <summary>
        /// The action to take when the user
        /// selects a row in the XPTable
        /// </summary>
        public enum RowSelectionActionEnum
        {
            None,
            RaiseSelectEvent,
            SelectVillage
        }
        #endregion

        #region Events
        public event EventHandler<EventArgs> RowSelected;
        #endregion

        #region Fields
        private readonly Map _map;

        private ColumnModel _playerColumnModel;
        private ColumnModel _villageColumnModel;
        private ColumnModel _tribeColumnModel;
        private ColumnModel _reportColumnModel;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether
        /// all columns, the most import columns or
        /// custom selected columns are visible
        /// </summary>
        public ColumnDisplayTypeEnum DisplayType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the report display
        /// </summary>
        public ReportFields VisibleReportFields { get; set; }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the tribe display
        /// </summary>
        public TribeFields VisibleTribeFields { get; set; }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the village display
        /// </summary>
        public VillageFields VisibleVillageFields { get; set; }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the player display
        /// </summary>
        public PlayerFields VisiblePlayerFields { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the row should be automatically selected
        /// when there is only one record
        /// </summary>
        public bool AutoSelectSingleRow { get; set; }

        /// <summary>
        /// Gets or sets the action when the user
        /// selects a row
        /// </summary>
        public RowSelectionActionEnum RowSelectionAction { get; set; }

        /// <summary>
        /// Gets the player XPTable ColumnModel
        /// </summary>
        private ColumnModel PlayerColumnModel
        {
            get
            {
                if (_playerColumnModel == null)
                {
                    switch (DisplayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _playerColumnModel = ColumnDisplay.CreateColumnModel(VisiblePlayerFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _playerColumnModel = ColumnDisplay.CreateColumnModel(PlayerFields.All);
                            break;
                        default:
                            _playerColumnModel = ColumnDisplay.CreateColumnModel(PlayerFields.Default);
                            break;
                    }
                }
                return _playerColumnModel;
            }
        }

        /// <summary>
        /// Gets the village XPTable ColumnModel
        /// </summary>
        private ColumnModel VillageColumnModel
        {
            get
            {
                if (_villageColumnModel == null)
                {
                    switch (DisplayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _villageColumnModel = ColumnDisplay.CreateColumnModel(VisibleVillageFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _villageColumnModel = ColumnDisplay.CreateColumnModel(VillageFields.All);
                            break;
                        default:
                            _villageColumnModel = ColumnDisplay.CreateColumnModel(VillageFields.Default);
                            break;
                    }
                }
                return _villageColumnModel;
            }
        }

        /// <summary>
        /// Gets the tribe XPTable ColumnModel
        /// </summary>
        private ColumnModel TribeColumnModel
        {
            get
            {
                if (_tribeColumnModel == null)
                {
                    switch (DisplayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _tribeColumnModel = ColumnDisplay.CreateColumnModel(VisibleTribeFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _tribeColumnModel = ColumnDisplay.CreateColumnModel(TribeFields.All);
                            break;
                        default:
                            _tribeColumnModel = ColumnDisplay.CreateColumnModel(TribeFields.Default);
                            break;
                    }
                }
                return _tribeColumnModel;
            }
        }

        /// <summary>
        /// Gets the report XPTable ColumnModel
        /// </summary>
        private ColumnModel ReportColumnModel
        {
            get
            {
                if (_reportColumnModel == null)
                {
                    switch (DisplayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _reportColumnModel = ColumnDisplay.CreateColumnModel(VisibleReportFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _reportColumnModel = ColumnDisplay.CreateColumnModel(ReportFields.All);
                            break;
                        default:
                            _reportColumnModel = ColumnDisplay.CreateColumnModel(ReportFields.Default);
                            break;
                    }
                }
                return _reportColumnModel;
            }
        }
        #endregion

        #region Constructors
        public TableWrapperControl()
        {
            RowSelectionAction = RowSelectionActionEnum.SelectVillage;
            AutoSelectSingleRow = true;
            DisplayType = ColumnDisplayTypeEnum.Default;
            InitializeComponent();

            _map = World.Default.Map;
        }

        private void TableWrapperControl_Load(object sender, EventArgs e)
        {
            _map.EventPublisher.LocationChanged += EventPublisher_LocationChanged;
        }
        #endregion

        #region EventHandlers
        private void EventPublisher_LocationChanged(object sender, MapLocationEventArgs e)
        {
            foreach (var row in Table.TableModel.Rows.OfType<Row>())
            {
                var twRow = row as ITwContextMenu;
                if (twRow != null)
                {
                    row.Cells[0].Image = GetVisibleImage(twRow.GetVillages());
                }
            }
        }

        private Image GetVisibleImage(IEnumerable<Village> villages)
        {
            if (_map.Display.IsVisible(villages))
            {
                return Properties.Resources.Visible;
            }
            return null;
        }

        /// <summary>
        /// Right click village context menu on the XPTable
        /// </summary>
        private void TableControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Table.TableModel.Selections.SelectedItems.Length > 1)
                {
                    // Show context menu for multiple villages
                    var vils = new List<Village>();
                    foreach (Row row in Table.TableModel.Selections.SelectedItems)
                    {
                        vils.AddRange(((ITwContextMenu)row).GetVillages());
                    }

                    var menu = new VillagesContextMenu(_map, vils, (villageTypeSetTo) =>
                        {
                            foreach (Row row in Table.TableModel.Selections.SelectedItems)
                            {
                                row.Cells[1].Image = villageTypeSetTo.GetImage(true);
                            }
                        });
                    menu.Show(Table, e.Location);
                }
                else
                {
                    // Display context menu for one village, player or tribe
                    Table.TableModel.Selections.Clear();
                    if (Table.ColumnModel != null)
                    {
                        Table.TableModel.Selections.SelectCells(Table.RowIndexAt(e.Location), 0, Table.RowIndexAt(e.Location), Table.ColumnModel.Columns.Count - 1);
                        if (Table.TableModel.Selections.SelectedItems.Length == 1)
                        {
                            var row = (ITwContextMenu)Table.TableModel.Selections.SelectedItems[0];
                            row.ShowContext(e.Location);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Double click to pinpoint the selected row
        /// </summary>
        private void TableControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Table.TableModel.Selections.SelectedItems.Length > 0)
            {
                var row = (ITwContextMenu)Table.TableModel.Selections.SelectedItems[0];

                Village[] villages = row.GetVillages().ToArray();
                World.Default.Map.EventPublisher.SelectVillages(null, villages, VillageTools.PinPoint);
                World.Default.Map.SetCenter(villages);
            }
        }

        private void Table_SelectionChanged(object sender, XPTable.Events.SelectionEventArgs e)
        {
            // Raise the select event
            if (Table.TableModel.Selections.SelectedItems.Length == 1)
            {
                var row = (ITwContextMenu)Table.TableModel.Selections.SelectedItems[0];
                switch (RowSelectionAction)
                {
                    case RowSelectionActionEnum.RaiseSelectEvent:
                        if (RowSelected != null)
                        {
                            RowSelected(row, EventArgs.Empty);
                        }
                        break;

                    case RowSelectionActionEnum.SelectVillage:
                        row.DisplayDetails();
                        break;
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Show a list of players in the XPTable
        /// </summary>
        /// <param name="players">A list of players</param>
        public void DisplayPlayers(IEnumerable<Player> players)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = PlayerColumnModel;
            if (World.Default.HasLoaded && players != null)
            {
                Table.SuspendLayout();
                foreach (Player ply in players)
                {
                    Table.TableModel.Rows.Add(new PlayerTableRow(_map, ply));
                }
                if (AutoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Player player = ((PlayerTableRow)Table.TableModel.Rows[0]).Player;
                    World.Default.Map.EventPublisher.SelectVillages(null, player, VillageTools.PinPoint);
                }
                Table.ResumeLayout();
            }
        }

        /// <summary>
        /// Show a list of tribes in the XPTable
        /// </summary>
        /// <param name="tribes">A list of tribes</param>
        public void DisplayTribes(IEnumerable<Tribe> tribes)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = TribeColumnModel;
            if (tribes != null)
            {
                Table.SuspendLayout();
                foreach (Tribe tribe in tribes)
                {
                    Table.TableModel.Rows.Add(new TribeTableRow(_map, tribe));
                }
                if (AutoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Tribe tribe = ((TribeTableRow)Table.TableModel.Rows[0]).Tribe;
                    World.Default.Map.EventPublisher.SelectVillages(null, tribe, VillageTools.PinPoint);
                }
                Table.ResumeLayout();
            }
        }

        /// <summary>
        /// Show a list of villages in the XPTable
        /// </summary>
        /// <param name="villages">A list of villages</param>
        public void DisplayVillages(IEnumerable<Village> villages)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = VillageColumnModel;
            if (villages != null)
            {
                Table.SuspendLayout();
                foreach (Village vil in villages)
                {
                    Table.TableModel.Rows.Add(new VillageTableRow(_map, vil));
                }
                Table.ResumeLayout();
                if (AutoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Village village = ((VillageTableRow)Table.TableModel.Rows[0]).Village;
                    World.Default.Map.EventPublisher.SelectVillages(null, village, VillageTools.PinPoint);
                }
            }
        }

        /// <summary>
        /// Show a list of reports in the XPTable
        /// </summary>
        /// <param name="village">The village the reports are for</param>
        /// <param name="reports">The list of reports</param>
        public void DisplayReports(Village village, IEnumerable<Report> reports)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = ReportColumnModel;
            if (reports != null)
            {
                Table.SuspendLayout();
                foreach (Report report in reports)
                {
                    Table.TableModel.Rows.Add(new ReportTableRow(village, report));
                }
                Table.ResumeLayout();
                if (AutoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Report report = ((ReportTableRow)Table.TableModel.Rows[0]).Report;
                    var list = new List<Village>();
                    list.Add(report.Defender.Village);
                    list.Add(report.Attacker.Village);
                    World.Default.Map.EventPublisher.SelectVillages(null, list, VillageTools.PinPoint);
                }
            }
        }

        /// <summary>
        /// Displays a list of villages, players or tribes
        /// </summary>
        /// <param name="options">The search conditions</param>
        public void Display(FinderOptions options)
        {
            Table.BeginUpdate();
            Table.TableModel.Rows.Clear();
            switch (options.SearchFor)
            {
                case SearchForEnum.Tribes:
                    Table.ColumnModel = TribeColumnModel;
                    foreach (Tribe vil in options.TribeMatches())
                    {
                        Table.TableModel.Rows.Add(new TribeTableRow(_map, vil));
                    }
                    break;
                case SearchForEnum.Villages:
                    Table.ColumnModel = VillageColumnModel;
                    foreach (Village vil in options.VillageMatches())
                    {
                        Table.TableModel.Rows.Add(new VillageTableRow(_map, vil));
                    }
                    break;
                default:
                    Table.ColumnModel = PlayerColumnModel;
                    foreach (Player vil in options.PlayerMatches())
                    {
                        Table.TableModel.Rows.Add(new PlayerTableRow(_map, vil));
                    }
                    break;
            }

            // auto sorting
            if (Table.SortingColumn != -1)
            {
                Table.Sort(Table.SortingColumn, Table.ColumnModel.Columns[Table.SortingColumn].SortOrder);
            }
            Table.EndUpdate();
        }

        /// <summary>
        /// Clears the XPTable
        /// </summary>
        public void Clear()
        {
            TableRows.Rows.Clear();
        }
        #endregion
    }
}