#region Using
using System.Drawing;
using TribalWars.Data.Villages;

#endregion

namespace TribalWars.Data.Maps.Drawers.VillageDrawers
{
    /// <summary>
    /// Draws an extra icon (Attack, Defense, ...)
    /// on an existing village bitmap
    /// </summary>
    public class IconDrawerDecorator : DrawerBase
    {
        #region Fields
        private readonly Bitmap _bitmap;
        private readonly bool _comments;
        private readonly bool _nobles;

        private static readonly Bitmap _commentsBitmap;
        private static readonly Bitmap _noblesBitmap;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the village decorator bitmap
        /// </summary>
        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }
        #endregion

        #region Constructors
        public IconDrawerDecorator(VillageType type, Bitmap icon)
        {
            _bitmap = icon;
            if ((type & VillageType.Comments) == VillageType.Comments) _comments = true;
            if ((type & VillageType.Noble) == VillageType.Noble) _nobles = true;
        }

        static IconDrawerDecorator()
        {
            _commentsBitmap = Icons.Other.Comment;
            _noblesBitmap = Icons.Other.Noble;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Paints a decorator on one village bitmap
        /// </summary>
        protected override void PaintVillageCore(Graphics g, int x, int y, int width, int height)
        {
            if (_bitmap != null)
                g.DrawImageUnscaledAndClipped(_bitmap, new Rectangle(x + 36, y, 16, 16));

            if (_comments)
                g.DrawImageUnscaledAndClipped(_commentsBitmap, new Rectangle(x + 9, y + 20, 10, 12));

            if (_nobles)
                g.DrawImageUnscaledAndClipped(_noblesBitmap, new Rectangle(x + 36, y + 19, 16, 16));
        }

        /// <summary>
        /// Dispose of unmanaged resources
        /// </summary>
        public override void Dispose(bool disposing)
        {
            if (_bitmap != null)
                _bitmap.Dispose();
        }
        #endregion
    }
}