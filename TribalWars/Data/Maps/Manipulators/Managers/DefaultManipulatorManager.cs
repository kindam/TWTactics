#region Using
using System.Drawing;
using System.Windows.Forms;
using TribalWars.Data.Maps.Manipulators.Helpers.EventArgs;
using TribalWars.Data.Maps.Manipulators.Implementations;
using TribalWars.Data.Villages;
#endregion

namespace TribalWars.Data.Maps.Manipulators.Managers
{
    /// <summary>
    /// The default manipulatormanager for a map
    /// </summary>
    public class DefaultManipulatorManager : ManipulatorManagerBase
    {
        #region Properties
        /// <summary>
        /// Moves the map with the mouse
        /// </summary>
        private MapDraggerManipulator MapDragger { get; set; }

        /// <summary>
        /// Marks the active village
        /// </summary>
        private ActiveVillageManipulator ActiveVillageManipulator { get; set; }

        /// <summary>
        /// Moves the map with the keyboard
        /// </summary>
        internal MapMoverManipulator MapMover { get; private set; }
        #endregion

        #region Constructors
        public DefaultManipulatorManager(Map map)
            : base(map)
        {
            // Active manipulators
            ActiveVillageManipulator = new ActiveVillageManipulator(map);
            MapMover = new MapMoverManipulator(map);
            MapDragger = new MapDraggerManipulator(map, this);

            _manipulators.Add(ActiveVillageManipulator);
            _manipulators.Add(MapMover);
            _manipulators.Add(MapDragger);
        }
        #endregion
    }
}