#region Imports
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TribalWars.Controls.Maps;
using TribalWars.Data.Maps.Manipulators.Helpers.EventArgs;
using TribalWars.Data.Villages;
using TribalWars.Tools;

#endregion

namespace TribalWars.Data.Maps.Manipulators.Managers
{
    /// <summary>
    /// Manages the user interaction with a map
    /// </summary>
    public class ManipulatorManagerController
    {
        #region Delegates
        public delegate void MouseMovedDelegate(MouseEventArgs e, Point mapLocation, Village village, Point activeLocation, Point activeVillage);
        #endregion

        #region Fields
        private readonly Dictionary<ManipulatorManagerTypes, ManipulatorManagerBase> _manipulators;

        // MouseMove Delegate move to the controller
        // --> the controller makes sure only the necessary MouseMove, KeyDown etc methods are executed
        // --> ScrollableMapControl executes the methods of the Controller
        private MouseMovedDelegate _mouseMoved;


        // MapMoverManipulator: overrides SetFullControl for cursor
        // BBCodeManipulator: implements stuff for contextmenu
        #endregion

        #region Properties
        /// <summary>
        /// Gets the currently active manipulatormanager
        /// </summary>
        public ManipulatorManagerBase CurrentManipulator { get; private set; }

        /// <summary>
        /// Gets all available manipulatormanagers
        /// </summary>
        public Dictionary<ManipulatorManagerTypes, ManipulatorManagerBase> Manipulators
        {
            get { return _manipulators; }
        }

        /// <summary>
        /// Gets the map the manipulators are active on
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        /// Gets the default manipulator
        /// </summary>
        public DefaultManipulatorManager DefaultManipulator { get; private set; }

        /// <summary>
        /// Gets the polygon manipulator
        /// </summary>
        public PolygonManipulatorManager PolygonManipulator { get; private set; }

        /// <summary>
        /// The last village the cursor was on or is still on
        /// </summary>
        public Point ActiveVillage { get; protected set; }

        /// <summary>
        /// The 2nd last village the cursors was on
        /// </summary>
        public Point LastActiveVillage { get; protected set; }

        /// <summary>
        /// The location the cursors is on
        /// </summary>
        public Point ActiveLocation { get; protected set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new ManipulatorManager for a minimap
        /// </summary>
        public ManipulatorManagerController(Map miniMap, Map mainMap)
        {
            Map = miniMap;
            _manipulators = new Dictionary<ManipulatorManagerTypes, ManipulatorManagerBase>();
            CurrentManipulator = new MiniMapManipulatorManager(miniMap, mainMap);
            _manipulators.Add(ManipulatorManagerTypes.Default, CurrentManipulator);
        }

        /// <summary>
        /// Initializes a new ManipulatorManager
        /// </summary>
        public ManipulatorManagerController(Map map)
        {
            Map = map;
            _manipulators = new Dictionary<ManipulatorManagerTypes, ManipulatorManagerBase>();
            DefaultManipulator = new DefaultManipulatorManager(map);
            CurrentManipulator = DefaultManipulator;
            _manipulators.Add(ManipulatorManagerTypes.Default, CurrentManipulator);
            PolygonManipulator = new PolygonManipulatorManager(map);
            _manipulators.Add(ManipulatorManagerTypes.Polygon, PolygonManipulator);
        }
        #endregion

        #region Public Methods
        /*/// <summary>
        /// Adds the delegate that will be executed when moving the mouse over the
        /// map to all manipulatormanagers
        /// </summary>
        public void AddMouseMoved(DefaultManipulatorManager.MouseMovedDelegate mouseMoved)
        {
            foreach (ManipulatorManagerBase manipulator in _manipulators.Values)
            {
                manipulator.AddMouseMoved(mouseMoved);
            }
        }*/

        /// <summary>
        /// Add a method that will be triggered each time the mouse
        /// moves over the map
        /// </summary>
        public void AddMouseMoved(MouseMovedDelegate moved)
        {
            _mouseMoved += moved;
        }

        /// <summary>
        /// Changes the active manipulatormanager
        /// </summary>
        public void SetManipulator(ManipulatorManagerTypes manipulator)
        {
            CurrentManipulator = _manipulators[manipulator];
            CurrentManipulator.Initialize();
            Map.EventPublisher.ChangeManipulator(this, new TribalWars.Data.Events.ManipulatorEventArgs(CurrentManipulator, manipulator));
        }

        public bool KeyDown(KeyEventArgs e, ScrollableMapControl mapPicture)
        {
            Graphics g = null;
            return CurrentManipulator.OnKeyDownCore(new MapKeyEventArgs(CurrentManipulator, g, e, mapPicture.ClientRectangle));
        }

        public bool KeyUp(KeyEventArgs e, ScrollableMapControl mapPicture)
        {
            Graphics g = null;
            return CurrentManipulator.OnKeyUpCore(new MapKeyEventArgs(CurrentManipulator, g, e, mapPicture.ClientRectangle));
        }

        public bool OnVillageDoubleClick(MouseEventArgs e, Village village, ScrollableMapControl mapPicture)
        {
            Graphics g = null;
            return CurrentManipulator.OnVillageDoubleClickCore(new MapVillageEventArgs(CurrentManipulator, g, e, village, mapPicture.ClientRectangle));
        }

        public bool MouseDown(MouseEventArgs e, Village village, ScrollableMapControl mapPicture)
        {
            Graphics g = null;
            bool down = false; // TODO: expression is always false
            if (village != null && e.Button == MouseButtons.Left) down = down || CurrentManipulator.OnVillageClickCore(new MapVillageEventArgs(CurrentManipulator, g, e, village, mapPicture.ClientRectangle));
            return CurrentManipulator.MouseDownCore(new MapMouseEventArgs(CurrentManipulator, g, e, village, mapPicture.ClientRectangle)) || down;
        }

        public bool MouseUp(MouseEventArgs e, Village village, ScrollableMapControl mapPicture)
        {
            Graphics g = null;
            bool up = CurrentManipulator.MouseUpCore(new MapMouseEventArgs(CurrentManipulator, g, e, village, mapPicture.ClientRectangle));
            return up;
        }

        public bool MouseMove(MouseEventArgs e, ScrollableMapControl mapPicture, ToolTip villageTooltip)
        {
            // TODO: Creating a graphics object here *every* time might not be a good idea :)
            Point game = Map.Display.GetGameLocation(e.X, e.Y);
            if (!game.IsValidGameCoordinate())
            {
                return false;
            }

            Village village = World.Default.GetVillage(game);
            Point map = Map.Display.GetMapLocation(game);
            Graphics g = mapPicture.CreateGraphics();

            // Display village tooltip
            if (village != null)
            {
                if (ActiveVillage != village.Location || !villageTooltip.Active)
                {
                    LastActiveVillage = ActiveVillage;
                    ActiveVillage = village.Location;

                    if (CurrentManipulator.ShowTooltip)
                    {
                        villageTooltip.Active = true;
                        villageTooltip.ToolTipTitle = village.ToString();
                        villageTooltip.SetToolTip(mapPicture, Map.Manipulators.CurrentManipulator.VillageTooltip(village));
                    }
                }
            }
            else
            {
                if (CurrentManipulator.ShowTooltip)
                    villageTooltip.Active = false;
            }

            // Invoke the MouseMoved delegate each time the current mouse location is different from the last location
            if (_mouseMoved != null && ActiveLocation != game)
            {
                ActiveLocation = game;
                _mouseMoved(e, map, village, ActiveLocation, ActiveVillage);
            }

            // TODO: also only call this one if _activeLocation != game?
            return CurrentManipulator.MouseMoveCore(new MapMouseMoveEventArgs(CurrentManipulator, g, e, map, village, mapPicture.ClientRectangle));
        }

        public void Paint(Graphics graphics, Rectangle rec, Rectangle fullMap)
        {
            foreach (ManipulatorManagerBase manipulator in _manipulators.Values)
                manipulator.Paint(new MapPaintEventArgs(graphics, rec, fullMap, manipulator == CurrentManipulator));
        }

        public void TimerPaint(ScrollableMapControl mapPicture, Rectangle fullMap)
        {
            Graphics g = mapPicture.CreateGraphics();
            foreach (ManipulatorManagerBase manipulator in _manipulators.Values)
                manipulator.TimerPaint(new MapTimerPaintEventArgs(g, fullMap, manipulator == CurrentManipulator));
        }
        #endregion
    }
}