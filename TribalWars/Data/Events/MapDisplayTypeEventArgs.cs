#region Using
using System;
using TribalWars.Data.Maps.Displays;
using TribalWars.Data.Maps;
#endregion

namespace TribalWars.Data.Events
{
    /// <summary>
    /// Provides data for a change of DisplayType
    /// </summary>
    public class MapDisplayTypeEventArgs : EventArgs
    {
        #region Fields
        private readonly DisplayTypes _display;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the new map display type
        /// </summary>
        public DisplayTypes DisplayType
        {
            get { return _display; }
        }
        #endregion

        #region Constructors
        public MapDisplayTypeEventArgs(DisplayTypes display)
        {
            _display = display;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}", DisplayType);
        }
    }
}
