using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using TribalWars.Villages;
using TribalWars.Worlds;
using TribalWars.Worlds.Events;

namespace TribalWars.Tools.PropertyGrid.Villages
{
    /// <summary>
    /// UI Editor for showing pinpoint markers from a PropertyGrid
    /// </summary>
    public class VillagePointerUiEditor : System.Drawing.Design.UITypeEditor
    {
        #region Overriden Methods
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IEnumerable<Village> vil = null;

            if (value is IEnumerable<Village>)
            {
                vil = (IEnumerable<Village>)value;
            }
            else if (value is string)
            {
                if (World.Default.Villages != null)
                {
                    string[] loc = ((string)value).Split('|');
                    int x, y;
                    if (int.TryParse(loc[0], out x) && int.TryParse(loc[1], out y))
                    {
                        var p = new Point(x, y);
                        if (World.Default.Villages.ContainsKey(p))
                            vil = World.Default.Villages[p];
                    }
                }
            }

            World.Default.Map.EventPublisher.SelectVillages(this, vil, VillageTools.PinPoint);
            return base.EditValue(context, provider, value);
        }

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return System.Drawing.Design.UITypeEditorEditStyle.Modal;
        }
        #endregion
    }
}
