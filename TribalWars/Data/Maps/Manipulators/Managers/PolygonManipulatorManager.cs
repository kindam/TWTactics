#region Using
using System.Collections.Generic;
using System.Xml;
using Janus.Windows.UI;
using Janus.Windows.UI.CommandBars;
using TribalWars.Controls.TWContextMenu;
using TribalWars.Controls;
using TribalWars.Data.Maps.Manipulators.Implementations;
using TribalWars.Data.Villages;
using TribalWars.Data.Maps.Manipulators.Helpers;
#endregion

namespace TribalWars.Data.Maps.Manipulators.Managers
{
    /// <summary>
    /// The managing polygonmanipulator
    /// </summary>
    public class PolygonManipulatorManager : DefaultManipulatorManager
    {
        #region Fields
        private readonly BbCodeManipulator _bbCode;
        private readonly UICommand _menu;
        #endregion

        #region Constructors
        public PolygonManipulatorManager(Map map)
            : base(map)
        {
            // Active manipulators
            _bbCode = new BbCodeManipulator(map, this);
            _manipulators.Add(_bbCode);

            MapMover.RightClickToMove = false;

            _menu = new UICommand();

            // Contextmenu
            UICommand generate = new UICommand(ContextMenuKeys.Polygon.Generate, "Generate", CommandType.Command);
            generate.Click += OnGenerate;

            UICommand delete = new UICommand(ContextMenuKeys.Polygon.Delete, "Delete", CommandType.Command);
            delete.Click += OnDelete;

            UICommand edit = new UICommand(ContextMenuKeys.Polygon.Edit, "Edit", CommandType.Command);
            edit.Click += OnEdit;

            UICommand hide = new UICommand(ContextMenuKeys.Polygon.Hide, "Hide", CommandType.Command);
            hide.Click += OnHide;

            UICommand show = new UICommand(ContextMenuKeys.Polygon.Show, "Show", CommandType.Command);
            show.Click += OnHide;

            UICommand clearAll = new UICommand(ContextMenuKeys.Polygon.Clearall, "Clear All", CommandType.Command);
            clearAll.Click += OnClear;

            UICommand hideAll = new UICommand(ContextMenuKeys.Polygon.Hideall, "Hide All", CommandType.Command);
            hideAll.Click += OnClear;

            UICommand showAll = new UICommand(ContextMenuKeys.Polygon.Showall, "Show All", CommandType.Command);
            showAll.Click += OnShowAll;

            _menu.Commands.AddRange(new UICommand[] { 
                generate, delete, edit, hide, show,
                new UICommand("SEP", string.Empty, CommandType.Separator),
                clearAll, hideAll
            });
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads state from stream
        /// </summary>
        protected internal override void ReadXmlCore(XmlReader r)
        {
            _bbCode.ReadXmlCore(r);
        }

        /// <summary>
        /// Saves state to stream
        /// </summary>
        protected internal override void WriteXmlCore(XmlWriter w)
        {
            _bbCode.WriteXmlCore(w);
        }

        //protected override IContextMenu GetContextMenu(System.Drawing.Point location, Village village)
        //{
        //    InheritableBoolean isPolygonSelected = _bbCode.ActivePolygon != null ? InheritableBoolean.True : InheritableBoolean.False;

        //    _menu.Commands[ContextMenuKeys.Polygon.Delete].Enabled = isPolygonSelected;
        //    _menu.Commands[ContextMenuKeys.Polygon.Edit].Enabled = isPolygonSelected;


        //    _contextHide.Enabled = ActivePolygon != null;
        //    if (ActivePolygon != null && ActivePolygon.Visible) _contextHide.Text = "Hide";
        //    else _contextHide.Text = "Show";

        //    bool oneVisible = false;
        //    foreach (Polygon poly in Polygons)
        //        if (poly.Visible) oneVisible = true;

        //    if (oneVisible) _contextHideAll.Text = "Hide All";
        //    else _contextHideAll.Text = "Show All";

        //    return _menu;
        //}

        /// <summary>
        /// Gets all villages that are in the polygons
        /// </summary>
        public IEnumerable<Village> GetAllPolygonVillages()
        {
            foreach (Polygon poly in _bbCode.Polygons)
            {
                foreach (Village village in poly.GetVillages())
                {
                    yield return village;
                }
            }
        }

        /// <summary>
        /// Clears the polygons
        /// </summary>
        private void OnClear(object sender, CommandEventArgs e)
        {
            _bbCode.Clear();
        }

        /// <summary>
        /// Deletes a polygon
        /// </summary>
        private void OnDelete(object sender, CommandEventArgs e)
        {
            _bbCode.Delete();
        }

        /// <summary>
        /// Renames a polygon
        /// </summary>
        private void OnEdit(object sender, CommandEventArgs e)
        {
            _bbCode.AddControl();
        }

        /// <summary>
        /// Raise the polygon event for the villages inside
        /// the selected polygon(s)
        /// </summary>
        private void OnGenerate(object sender, CommandEventArgs e)
        {
            PolygonDataSet ds = new PolygonDataSet();
            if (_bbCode.ActivePolygon != null)
            {
                foreach (Village v in _bbCode.ActivePolygon.GetVillages())
                {
                    ds.AddVILLAGERow(v, _bbCode.ActivePolygon.Name);
                }
            }
            else
            {
                foreach (Polygon poly in _bbCode.Polygons)
                {
                    foreach (Village v in poly.GetVillages())
                    {
                        ds.AddVILLAGERow(v, poly.Name);
                    }
                }
            }
            World.Default.Map.EventPublisher.ActivatePolygon(this, ds);
        }

        /// <summary>
        /// Hides the polygons
        /// </summary>
        private void OnHideAll(object sender, CommandEventArgs e)
        {
            _bbCode.ToggleVisibility(false);
        }

        /// <summary>
        /// Shows the polygons
        /// </summary>
        private void OnShowAll(object sender, CommandEventArgs e)
        {
            _bbCode.ToggleVisibility(true);
        }

        /// <summary>
        /// Hides/Shows one polygon
        /// </summary>
        private void OnHide(object sender, CommandEventArgs e)
        {
            _bbCode.ToggleVisibility();
        }
        #endregion
    }
}
