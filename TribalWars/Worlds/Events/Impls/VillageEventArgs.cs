#region Using
using TribalWars.Villages;

#endregion

namespace TribalWars.Worlds.Events.Impls
{
    /// <summary>
    /// EventArgs for one village
    /// </summary>
    public class VillageEventArgs : VillagesEventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the village
        /// </summary>
        public Village SelectedVillage { get; private set; }

        /// <summary>
        /// Gets the village
        /// </summary>
        public override Village FirstVillage
        {
            get
            {
                return SelectedVillage;
            }
        }
        #endregion

        #region Constructors
        public VillageEventArgs(Village vil, VillageTools tool)
            : base(vil, tool)
        {
            SelectedVillage = vil;
        }
        #endregion
    }
}
