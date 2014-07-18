using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TribalWars.Forms.Small;
using TribalWars.Tools;
using TribalWars.Villages;
using TribalWars.Villages.Units;
using TribalWars.Worlds;
using TribalWars.Worlds.Events;
using TribalWars.Worlds.Events.Impls;

namespace TribalWars.Maps.Manipulators.AttackPlans
{
    public partial class MapDistanceCollectionControl : UserControl
    {
        #region Fields
        private readonly Dictionary<ToolStripMenuItem, MapDistanceControl> _plans = new Dictionary<ToolStripMenuItem, MapDistanceControl>();
        private MapDistanceControl _activePlan;

        private readonly ToolStripItem[] _visibleWhenNoPlans;
        #endregion

        #region Properties
        public MapDistanceControl ActivePlan
        {
            get { return _activePlan; }
            set
            {
                if (_activePlan != null) _activePlan.Visible = false;
                if (value != null) value.Visible = true;
                _activePlan = value;
            }
        }
        #endregion

        #region Constructors
        public MapDistanceCollectionControl()
        {
            InitializeComponent();

            _visibleWhenNoPlans = new ToolStripItem[] { VillageInput, cmdAddTarget };

            World.Default.EventPublisher.SettingsLoaded += Default_SettingsLoaded;
            World.Default.Map.EventPublisher.TargetAdded += EventPublisherOnTargetAdded;
        }

        private void EventPublisherOnTargetAdded(object sender, AttackEventArgs e)
        {
            AddTarget(e.Plan);
        }
        #endregion

        #region Event Handlers
        private void Default_SettingsLoaded(object sender, EventArgs e)
        {
            UnitInput.Combobox.ImageList = WorldUnits.Default.ImageList;
            UnitInput.Combobox.SelectedIndex = WorldUnits.Default[UnitTypes.Ram].Position;

            RemoveAllPlans();

            var plansFromXml = World.Default.Map.Manipulators.AttackManipulator.GetPlans();
            foreach (AttackPlanInfo plan in plansFromXml)
            {
                AddTarget(plan);
                ActivePlan.AttackDate = plan.ArrivalTime;

                foreach (AttackPlanFrom attack in plan.Attacks)
                {
                    ActivePlan.AddVillage(attack.Attacker, attack.SlowestUnit);
                }
            }

            foreach (var toolbarItem in toolStrip1.Items.OfType<ToolStripItem>())
            {
                if (_plans.Any())
                {
                    toolbarItem.Visible = true;
                }
                else
                {
                    toolbarItem.Visible = _visibleWhenNoPlans.Contains(toolbarItem);
                }
            }
        }

        private void EventPublisherOnVillagesSelected(object sender, VillagesEventArgs e)
        {
            if (e.Tool == VillageTools.DistanceCalculationTarget)
            {
                AddTarget(e.FirstVillage);
            }
            else if (e.Tool == VillageTools.DistanceCalculation)
            {
                if (ActivePlan != null)
                {
                    ActivePlan.AddVillage(e.FirstVillage);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ActivePlan != null) ActivePlan.Calculate();
        }

        private void cmdAddVillage_Click(object sender, EventArgs e)
        {
            Village village = VillageInput.Village;
            if (village != null)
            {
                World.Default.Map.EventPublisher.AttackAddTarget(this, village);
            }
        }

        private void cmdAddTarget_Click(object sender, EventArgs e)
        {
            Village village = VillageInput.Village;
            if (village != null)
            {
                World.Default.Map.EventPublisher.SelectVillages(this, village, VillageTools.DistanceCalculationTarget);
            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            if (World.Default.You.Empty)
            {
                if (MessageBox.Show("You have not yet selected yourself.\nSet yourself now?", "Select Active Player", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ActivePlayerForm.UpdateDefaultWorld();    
                }
            }
            else if (ActivePlan != null)
            {
                Unit unit = UnitInput.Unit;
                if (unit != null)
                {
                    Village[] villagesAlreadyUsed = ActivePlan.GetPlanInfo().Attacks.Select(x => x.Attacker).ToArray();

                    var villagesWithTimeLeft = 
                        from village in World.Default.You
                        where !villagesAlreadyUsed.Contains(village)
                        let travelTime = Village.TravelTime(ActivePlan.Target, village, unit)
                        let timeBeforeNeedToSend = ActivePlan.AttackDate - World.Default.Settings.ServerTime.Add(travelTime)
                        where timeBeforeNeedToSend.TotalSeconds > 0
                        select new
                            {
                                Village = village,
                                TimeBeforeNeedToSend = timeBeforeNeedToSend
                            };

                    foreach (var village in villagesWithTimeLeft.OrderBy(x => x.TimeBeforeNeedToSend).Take(20))
                    {
                        MapDistanceVillageControl ctl = ActivePlan.AddVillage(village.Village);
                        ctl.UnitSelectedIndex = unit.Position;
                    }

                    ActivePlan.Sort();
                }
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (ActivePlan != null)
            {
                ActivePlan.Clear();
            }
        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            if (ActivePlan != null)
                ActivePlan.Sort();
        }
        #endregion

        #region Public Methods
        private void AddTarget(AttackPlanInfo plan)
        {
            var vil = plan.Target;

            toolStrip1.Items.OfType<ToolStripItem>().ForEach(x => x.Visible = true);

            var newItm = new ToolStripMenuItem(string.Format("{0} {1} ({2}pts)", vil.LocationString, vil.Name, Tools.Common.GetPrettyNumber(vil.Points)), null, SelectPlan);
            if (vil.HasPlayer) newItm.Text += " (" + vil.Player.Name + ")";
            AttackDropDown.DropDownItems.Add(newItm);
            if (AttackDropDown.DropDownItems.Count == 1)
                newItm.Checked = true;

            var distance = new MapDistanceControl(this, WorldUnits.Default.ImageList);
            distance.Target = vil;
            distance.Dock = DockStyle.Fill;
            _plans.Add(newItm, distance);
            AllPlans.Controls.Add(distance);

            SelectPlan(AttackDropDown.DropDownItems[AttackDropDown.DropDownItems.Count - 1], EventArgs.Empty);
            Timer.Enabled = true;
        }

        public void Remove(MapDistanceControl target)
        {
            Collection.Controls.Remove(target);
            ToolStripMenuItem menuItm = null;
            foreach (KeyValuePair<ToolStripMenuItem, MapDistanceControl> pair in _plans)
            {
                if (pair.Value == target)
                {
                    menuItm = pair.Key;
                }
            }
            if (menuItm != null)
            {
                _plans.Remove(menuItm);
                AttackDropDown.DropDownItems.Remove(menuItm);
            }

            if (ActivePlan == target)
            {
                if (AttackDropDown.DropDownItems.Count > 0)
                    SelectPlan(AttackDropDown.DropDownItems[0], EventArgs.Empty);
                else
                {
                    SelectPlan(null, EventArgs.Empty);
                }
            }

            World.Default.Map.Invalidate(false);
        }

        private void RemoveAllPlans()
        {
            var plans = _plans.Values.Select(x => x).ToArray();
            foreach (var plan in plans)
            {
                Remove(plan);
            }
        }

        private void SelectPlan(object sender, EventArgs e)
        {
            // select new active plan
            if (sender != null)
            {
                for (int i = 0; i < AttackDropDown.DropDownItems.Count; i++)
                {
                    ((ToolStripMenuItem)AttackDropDown.DropDownItems[i]).Checked = false;
                }

                var selectedItem = (ToolStripMenuItem)sender;
                selectedItem.Checked = true;
                ActivePlan = _plans[selectedItem];
            }
            else
            {
                ActivePlan = null;
            }
            World.Default.Map.Invalidate(false);
        }
        #endregion

        #region TextOutput
        private void cmdClipboardText_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActivePlan != null)
                    Clipboard.SetText(ActivePlan.GetPlan(false));
            }
            catch
            {
                
            }
        }

        private void cmdClipboardBBCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActivePlan != null)
                    Clipboard.SetText(ActivePlan.GetPlan(true));
            }
            catch
            {

            }
        }

        private void cmdClipboardTextAll_Click(object sender, EventArgs e)
        {
            try
            {
                string str = GetPlans(false);
                if (str.Length != 0) Clipboard.SetText(str);
            }
            catch
            {
                
            }
        }

        private void cmdClipboardBBCodeAll_Click(object sender, EventArgs e)
        {
            try
            {
                string str = GetPlans(true);
                if (str.Length != 0) Clipboard.SetText(str);
            }
            catch
            {
                
            }
        }

        private string GetPlans(bool bbCodes)
        {
            var list = new List<MapDistanceVillageComparor>();
            foreach (MapDistanceControl distance in _plans.Values)
            {
                if (distance != null)
                    list.AddRange(distance.GetVillageList());
            }
            list.Sort();

            var str = new StringBuilder();
            foreach (MapDistanceVillageComparor comp in list)
            {
                str.Append(comp.MapDistanceVillage.ToString(bbCodes, comp.MapDistanceVillage.TargetControl.Target));
            }
            return str.ToString().Trim();
        }
        #endregion        
    }
}
