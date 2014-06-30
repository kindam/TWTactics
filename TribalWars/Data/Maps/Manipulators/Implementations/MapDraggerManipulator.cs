#region Using
using System;
using System.Diagnostics;
using System.Drawing;
using TribalWars.Data.Maps.Manipulators.Helpers;
using TribalWars.Data.Maps.Manipulators.Managers;
#endregion

namespace TribalWars.Data.Maps.Manipulators.Implementations
{
    /// <summary>
    /// Allows the user to move the map around by dragging
    /// </summary>
    internal class MapDraggerManipulator : MouseMoveManipulatorBase
    {
        #region Constructors
        public MapDraggerManipulator(Map map, DefaultManipulatorManager parentManipulatorHandler)
            : base(map, parentManipulatorHandler)
        {
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Polygon started
        /// </summary>
        protected override void Start(Polygon polygon)
        {
        }

        protected override bool CanAddPointToPolygon(Point lastMap, Point currentMap)
        {
            Point lastGame = World.Default.Map.Display.GetGameLocation(lastMap);
            Point currentGame = World.Default.Map.Display.GetGameLocation(currentMap);
            return lastGame != currentGame;
        }

        /// <summary>
        /// Point added to the polygon
        /// </summary>
        protected override void Continue(Polygon polygon)
        {
            Location current = _map.Location;
            Point first = polygon.List.First.Value;
            Point last = polygon.List.Last.Value;

            int x = first.X - last.X;
            int y = first.Y - last.Y;

            _map.SetCenter(new Location(current.X + x, current.Y + y, current.Zoom));
        }

        /// <summary>
        /// Polygon finished
        /// </summary>
        protected override void Stop(Polygon polygon)
        {
            Clear();
        }

        protected internal override void SetFullControlManipulatorCore()
        {
            _map.SetCursor(System.Windows.Forms.Cursors.Hand);
        }

        protected internal override void RemoveFullControlManipulatorCore()
        {
            _map.SetCursor();
        }
        #endregion
    }
}