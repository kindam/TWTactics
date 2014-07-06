#region Imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using TribalWars.Data.Events;
#endregion

namespace TribalWars.Data.Maps
{
    /// <summary>
    /// Represents the view on a map
    /// </summary>
    public sealed class Location : IEquatable<Location>
    {
        #region Fields
        private readonly int _x;
        private readonly int _y;
        private readonly int _zoom;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the X coordinate
        /// </summary>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// Gets the Y coordinate
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// Gets the zoom level
        /// </summary>
        public int Zoom
        {
            get { return _zoom; }
        }
        #endregion

        #region Constructors
        public Location(int x, int y, int zoom)
        {
            _x = x;
            _y = y;
            _zoom = zoom;
        }

        public Location(Point loc, int zoom)
        {
            _x = loc.X;
            _y = loc.Y;
            _zoom = zoom;
        }

        public Location(Location location)
        {
            _x = location.X;
            _y = location.Y;
            _zoom = location.Zoom;
        }

        /// <summary>
        /// Creates a new Location with a different zoom level
        /// </summary>
        public Location(Location location, int zoom)
        {
            _x = location.X;
            _y = location.Y;
            _zoom = zoom;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return string.Format("{0}|{1} (X{2})", X, Y, Zoom);
        }
        #endregion

        #region IEquatable<MapLocation> Members
        public override int GetHashCode()
        {
            return (_x + _y + _zoom).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }

        public bool Equals(Location obj)
        {
            if (obj == null) return false;
            return X == obj.X && Y == obj.Y && Zoom == obj.Zoom;
        }

        public static bool operator ==(Location left, Location right)
        {
            if (ReferenceEquals(left, right)) return true;
            if ((object)left == null || (object)right == null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }
        #endregion
    }
}
