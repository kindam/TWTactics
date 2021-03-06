#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using TribalWars.Maps.AttackPlans.Controls;
using TribalWars.Maps.AttackPlans.EventArg;
using TribalWars.Maps.Manipulators;
using TribalWars.Maps.Manipulators.EventArg;
using TribalWars.Properties;
using TribalWars.Villages;
using TribalWars.Villages.ContextMenu;
using TribalWars.Villages.Units;
using TribalWars.Worlds;
using TribalWars.Worlds.Events;

#endregion

namespace TribalWars.Maps.AttackPlans
{
    /// <summary>
    /// Plan attacks on the map
    /// </summary>
    public class AttackManipulator : ManipulatorBase
    {
        #region Constants
        /// <summary>
        /// Village width below this: don't show any attack markers
        /// </summary>
        private const int MinVillageWidthToShowMarkers = 5;

        /// <summary>
        /// Bigger village width: show Pins, otherwise show small flags
        /// </summary>
        private const int VillageWidthToSwitchToSmallerFlags = 30;
        #endregion

        #region Fields
        private readonly List<AttackPlan> _plans;
        private Village _hoverVillage;

        public AttackPlan ActivePlan { get; private set; }
        private AttackPlanFrom ActiveAttacker { get; set; }
        #endregion

        #region Properties
        /// <summary>
        /// Global attack planner configuration
        /// </summary>
        public SettingsInfo Settings { get; private set; }

        /// <summary>
        /// Workaround for the <see cref="VillageContextMenu"/>:
        /// Do not show the contextmenu when your village is not yet assigned as an attacker.
        /// But by the time the <see cref="AttackManipulatorManager"/> checks whether the contextmenu is required, the attacker has already been added in <see cref="MouseDownCore"/>.
        /// </summary>
        public bool IsAddingTarget { get; private set; }
        #endregion

        #region Constructors
        public AttackManipulator(Map map)
            : base(map)
        {
            _plans = new List<AttackPlan>();
            Settings = new SettingsInfo();

            map.EventPublisher.TargetAdded += EventPublisherOnTargetAdded;
            map.EventPublisher.TargetUpdated += EventPublisherOnTargetUpdated;
            map.EventPublisher.TargetSelected += EventPublisherOnTargetSelected;
            map.EventPublisher.TargetRemoved += EventPublisherOnTargetRemoved;
        }
        #endregion

        #region AttackPlan Events

        private void EventPublisherOnTargetRemoved(object sender, AttackEventArgs e)
        {
            _plans.Remove(e.Plan);

            if (ActivePlan == e.Plan)
            {
                var selectedPlan = _plans.OrderBy(x => x.Target.DistanceTo(ActivePlan.Target)).FirstOrDefault();
                _map.EventPublisher.AttackSelect(sender, selectedPlan);
            }

            _map.Invalidate(false);
        }

        private void EventPublisherOnTargetSelected(object sender, AttackEventArgs e)
        {
            ActiveAttacker = e.Attacker;
            ActivePlan = e.Plan;
            _map.Invalidate(false);
        }

        private void EventPublisherOnTargetAdded(object sender, AttackEventArgs e)
        {
            Debug.Assert(!_plans.Contains(e.Plan));
            _plans.Add(e.Plan);
        }

        private void EventPublisherOnTargetUpdated(object sender, AttackUpdateEventArgs e)
        {
            foreach (AttackPlanFrom attacker in e.AttackFrom.ToArray())
            {
                Debug.Assert(_plans.Contains(attacker.Plan));
                AttackPlan plan = _plans.Single(x => x == attacker.Plan);
                switch (e.Action)
                {
                    case AttackUpdateEventArgs.ActionKind.Add:
                        AddAttacker(plan, attacker);
                        break;
                        
                   case AttackUpdateEventArgs.ActionKind.Delete:
                        RemoveAttacker(plan, attacker);
                        break;

                   case AttackUpdateEventArgs.ActionKind.Update:
                        break;

                    default:
                        Debug.Assert(false);
                        break;
                }
            }
            _map.Invalidate(false);
        }

        private void RemoveAttacker(AttackPlan plan, AttackPlanFrom attacker)
        {
            Debug.Assert(plan.Attacks.Contains(attacker));
            ActiveAttacker = null;
            plan.RemoveAttack(attacker);
        }

        private void AddAttacker(AttackPlan plan, AttackPlanFrom attacker)
        {
            Debug.Assert(!plan.Attacks.Contains(attacker));
            ActiveAttacker = attacker;
            plan.AddAttacker(attacker);
        }
        #endregion

        #region Map Painting
        public override void Paint(MapPaintEventArgs e, bool isActiveManipulator)
        {
            if (!Settings.ShowIfNotActiveManipulator && !isActiveManipulator)
            {
                return;
            }

            Size villageSize = _map.Display.Dimensions.Size;
            if (villageSize.Width < MinVillageWidthToShowMarkers)
            {
                return;
            }

            Rectangle gameSize = _map.Display.GetGameRectangle();
            Graphics g = e.Graphics;

            if (isActiveManipulator && ActivePlan != null)
            {
                PaintWhenActiveManipulator(gameSize, g, villageSize);
            }

            PaintNonActivePlans(villageSize, g, gameSize);

            if (ActivePlan != null)
            {
                PaintActivePlan(villageSize, g, gameSize);
            }
        }

        private void PaintActivePlan(Size villageSize, Graphics g, Rectangle gameSize)
        {
            Point activePlanTargetLocation = _map.Display.GetMapLocation(ActivePlan.Target.Location);

            if (_map.Display.IsVisible(ActivePlan.Target))
            {
                // The active plan attacked village
                activePlanTargetLocation.Offset(villageSize.Width/2, villageSize.Height/2);
                activePlanTargetLocation.Offset(-8, -48); // more - means to the top or the left
                g.DrawImage(AttackIcons.FlagGreen, activePlanTargetLocation);

                activePlanTargetLocation = _map.Display.GetMapLocation(ActivePlan.Target.Location);
                activePlanTargetLocation.Offset(villageSize.Width/2, villageSize.Height/2);
                using (var font = new Font("Verdana", 10, FontStyle.Bold))
                {
                    g.DrawString(
                        ActivePlan.Attacks.Count().ToString(CultureInfo.InvariantCulture),
                        font,
                        Brushes.Black,
                        activePlanTargetLocation.X + 1,
                        activePlanTargetLocation.Y - 40);
                }
            }

            foreach (AttackPlanFrom attacker in FilterAttacksForDrawing(ActivePlan.Attacks, gameSize))
            {
                // Villages attacking the active target village
                var attackerLocation = _map.Display.GetMapLocation(attacker.Attacker.Location);
                attackerLocation.Offset(villageSize.Width / 2, villageSize.Height / 2);

                if (villageSize.Width < VillageWidthToSwitchToSmallerFlags)
                {
                    attackerLocation.Offset(-10, -17);
                    g.DrawImage(Resources.FlagGreen, attackerLocation);
                }
                else
                {
                    attackerLocation.Offset(-6, -25);
                    g.DrawImage(AttackIcons.PinGreen20, attackerLocation);

                    int attackerUsedCount = VillageUsedCount(attacker.Attacker);
                    if (attackerUsedCount > 1)
                    {
                        using (var font = new Font("Verdana", 10, FontStyle.Bold))
                        {
                            g.DrawString(
                                attackerUsedCount.ToString(),
                                font,
                                Brushes.Black,
                                attackerLocation.X + 0,
                                attackerLocation.Y - 0);
                        }
                    }
                }
            }
        }

        private void PaintWhenActiveManipulator(Rectangle gameSize, Graphics g, Size villageSize)
        {
            if (_map.Display.IsVisible(ActivePlan.Target))
            {
                // Paint circles around the active plan
                using (var activeTargetPen = new Pen(Color.Yellow, 2))
                {
                    if (gameSize.Contains(ActivePlan.Target.Location))
                    {
                        Point villageLocation = _map.Display.GetMapLocation(ActivePlan.Target.Location);
                        g.DrawEllipse(
                            activeTargetPen,
                            villageLocation.X,
                            villageLocation.Y,
                            villageSize.Width,
                            villageSize.Height);

                        g.DrawEllipse(
                            activeTargetPen,
                            villageLocation.X - 4,
                            villageLocation.Y - 4,
                            villageSize.Width + 8,
                            villageSize.Height + 8);
                    }
                }
            }

            using (var activeAttackersPen = new Pen(Color.Yellow, 1))
            using (var warningAttackersPen = new Pen(Color.Red, 1))
            using (var selectedActiveAttackersPen = new Pen(Color.Yellow, 3))
            using (var selectedWarningAttackersPen = new Pen(Color.Red, 3))
            {
                // cirkels for the active plan attackers
                foreach (AttackPlanFrom attacker in FilterAttacksForDrawing(ActivePlan.Attacks, gameSize))
                {
                    int attackerUsedCount = VillageUsedCount(attacker.Attacker);
                    Pen penToUse;
                    if (attackerUsedCount > 1)
                    {
                        penToUse = ActiveAttacker == attacker ? selectedWarningAttackersPen : warningAttackersPen;
                    }
                    else
                    {
                        penToUse = ActiveAttacker == attacker ? selectedActiveAttackersPen : activeAttackersPen;
                    }

                    Point attackerLocation = _map.Display.GetMapLocation(attacker.Attacker.Location);
                    g.DrawEllipse(
                        penToUse,
                        attackerLocation.X,
                        attackerLocation.Y,
                        villageSize.Width,
                        villageSize.Height);
                }
            }
        }

        private void PaintNonActivePlans(Size villageSize, Graphics g, Rectangle gameSize)
        {
            if (!Settings.ShowOtherTargets && !Settings.ShowOtherAttackers)
            {
                return;
            }

            foreach (var plan in _plans)
            {
                Point planLoc = _map.Display.GetMapLocation(plan.Target.Location);
                if (plan != ActivePlan)
                {
                    // Other villages attacked but not the active plan
                    if (Settings.ShowOtherTargets)
                    {
                        planLoc.Offset(villageSize.Width / 2, villageSize.Height / 2);
                        planLoc.Offset(-5, -27); // more - means to the top or the left
                        g.DrawImage(AttackIcons.FlagBlue25, planLoc);

                        planLoc = _map.Display.GetMapLocation(plan.Target.Location);
                        planLoc.Offset(villageSize.Width / 2, villageSize.Height / 2);
                        using (var font = new Font("Verdana", 8, FontStyle.Bold))
                        {
                            g.DrawString(
                                plan.Attacks.Count().ToString(CultureInfo.InvariantCulture),
                                font,
                                Brushes.Black,
                                planLoc.X + 0,
                                planLoc.Y - 24);
                        }
                    }

                    if (Settings.ShowOtherAttackers)
                    {
                        foreach (AttackPlanFrom attacker in FilterAttacksForDrawing(plan.Attacks, gameSize))
                        {
                            // Villages attacking other target villages
                            var attackerLocation = _map.Display.GetMapLocation(attacker.Attacker.Location);
                            attackerLocation.Offset(villageSize.Width / 2, villageSize.Height / 2);

                            int attackerUsedCount = VillageUsedCount(attacker.Attacker);
                            if (villageSize.Width > VillageWidthToSwitchToSmallerFlags)
                            {
                                Image biggerAttackerImage = attackerUsedCount > 1 ? AttackIcons.PinRed20 : AttackIcons.PinBlue20;
                                attackerLocation.Offset(-6, -25);
                                g.DrawImage(biggerAttackerImage, attackerLocation);

                                if (attackerUsedCount > 1)
                                {
                                    using (var font = new Font("Verdana", 10, FontStyle.Bold))
                                    {
                                        g.DrawString(
                                            attackerUsedCount.ToString(),
                                            font,
                                            Brushes.Black,
                                            attackerLocation.X + 0,
                                            attackerLocation.Y - 0);
                                    }
                                }
                            }
                            else if (villageSize.Width > 15)
                            {
                                Image smallAttackerImage = attackerUsedCount > 1 ? AttackIcons.Flag_redHS : Resources.FlagBlue;
                                attackerLocation.Offset(-10, -17);
                                g.DrawImage(smallAttackerImage, attackerLocation);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region User Input Handlers
        protected internal override bool MouseDownCore(MapMouseEventArgs e)
        {
            IsAddingTarget = false;
            if (e.Village != null)
            {
                AttackPlan existingPlan = GetExistingPlan(e.Village, true);
                AttackPlanFrom[] existingAttacks = GetAttackers(e.Village).ToArray();

                if (e.MouseEventArgs.Button == MouseButtons.Left)
                {
                    if (existingPlan == null)
                    {
                        if (!existingAttacks.Any())
                        {
                            _map.EventPublisher.AttackAddTarget(this, e.Village);
                        }
                        else
                        {
                            if (!existingAttacks.Contains(ActiveAttacker))
                            {
                                _map.EventPublisher.AttackSelect(this, existingAttacks.First());
                            }
                            else
                            {
                                // Already selected village is perhaps used in multiple plans
                                if (existingAttacks.Length == 1)
                                {
                                    return false;
                                }
                                else
                                {
                                    // Cycle through the attackers
                                    AttackPlanFrom selectAttacker;
                                    if (ActiveAttacker == null || !existingAttacks.Contains(ActiveAttacker) || existingAttacks.Last() == ActiveAttacker)
                                    {
                                        selectAttacker = existingAttacks.First();
                                    }
                                    else
                                    {
                                        selectAttacker = existingAttacks.SkipWhile(x => x != ActiveAttacker).Take(2).Last();
                                    }
                                    _map.EventPublisher.AttackSelect(this, selectAttacker);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (existingPlan == ActivePlan && ActivePlan != null)
                        {
                            var existingAttack = existingAttacks.FirstOrDefault();
                            if (existingAttack != ActiveAttacker)
                            {
                                if (existingAttack == null)
                                {
                                    _map.EventPublisher.AttackSelect(this, ActivePlan);
                                }
                                else
                                {
                                    _map.EventPublisher.AttackSelect(this, existingAttack);
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            _map.EventPublisher.AttackSelect(this, existingPlan);
                        }
                    }
                    return true;
                }
                else if (e.MouseEventArgs.Button == MouseButtons.Right)
                {
                    if (e.Village.Player == World.Default.You && ActivePlan != null)
                    {
                        if (e.Village == ActivePlan.Target)
                        {
                            // Can't add attacker to target
                            return false;
                        }
                        else
                        {
                            if (existingAttacks.Any())
                            {
                                // Show contextmenu instead
                                return false;
                            }
                            else
                            {
                                // Add new attacker
                                var attackEventArgs = AttackUpdateEventArgs.AddAttackFrom(new AttackPlanFrom(ActivePlan, e.Village, WorldUnits.Default[World.Default.Map.Manipulators.AttackManipulator.DefaultSpeed]));
                                _map.EventPublisher.AttackUpdateTarget(this, attackEventArgs);
                                IsAddingTarget = true;
                                return true;                                
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected internal override bool MouseMoveCore(MapMouseMoveEventArgs e)
        {
            // This is for the MiniMap:
            // Inform the MiniMap that the selected village changed so that
            // the minimap still pinpoints what we hover while the main map
            // keeps track of just the AttackPlans
            if (e.Village != null)
            {
                if (_hoverVillage != e.Village)
                {
                    _map.EventPublisher.SelectVillages(this, e.Village, VillageTools.SelectVillage);

                    _hoverVillage = e.Village;
                    return true;
                }
            }
            if (e.Village == null && _hoverVillage != null)
            {
                _map.EventPublisher.Deselect(this);

                _hoverVillage = null;
                return true;
            }
            return false;
        }

        protected internal override bool OnKeyDownCore(MapKeyEventArgs e)
        {
            switch (e.KeyEventArgs.KeyCode)
            {
                case Keys.Delete:
                    if (ActiveAttacker != null)
                    {
                        _map.EventPublisher.AttackUpdateTarget(this, AttackUpdateEventArgs.DeleteAttackFrom(ActiveAttacker));
                    }
                    else if (ActivePlan != null)
                    {
                        _map.EventPublisher.AttackRemoveTarget(this, ActivePlan);
                    }
                    break;
            }

            return false;
        }
        #endregion

        #region Public Methods
        public IEnumerable<AttackPlan> GetPlans()
        {
            return _plans;
        }

        public AttackPlan GetPlan(Village village, out AttackPlanFrom attacker, bool cycleVillage)
        {
            AttackPlan asTarget = GetExistingPlan(village, cycleVillage);
            if (asTarget != null)
            {
                attacker = null;
                return asTarget;
            }

            AttackPlanFrom asAttacker = GetAttacker(village);
            if (asAttacker != null)
            {
                attacker = asAttacker;
                return asAttacker.Plan;
            }

            attacker = null;
            return null;
        }

        public override void Dispose()
        {
        }
        #endregion

        #region Private
        private AttackPlan GetExistingPlan(Village village, bool cycleVillage)
        {
            if (ActivePlan != null && ActivePlan.Target == village)
            {
                if (!cycleVillage)
                {
                    return ActivePlan;
                }

                var existingPlans = _plans.Where(x => x.Target == village).ToList();
                if (existingPlans.Count() > 1)
                {
                    // Cycle through the attack plans
                    if (existingPlans.Last() == ActivePlan)
                    {
                        return existingPlans.First();
                    }
                    else
                    {
                        return existingPlans[existingPlans.IndexOf(ActivePlan) + 1];
                    }
                }
            }

            // LastOrDefault: In PaintNonActivePlans the last plan is painted over the previous ones
            // So that the Delete plan from the VillageContextMenu works properly
            var existingPlan = _plans.LastOrDefault(x => x.Target == village); 
            return existingPlan;
        }

        private IEnumerable<AttackPlanFrom> GetAttackers(Village village)
        {
            return _plans.SelectMany(plan => plan.Attacks).Where(attack => attack.Attacker == village);
        }

        private AttackPlanFrom GetAttacker(Village village)
        {
            AttackPlanFrom existingAttack = GetAttackers(village).FirstOrDefault();
            return existingAttack;
        }

        public int VillageUsedCount(Village village)
        {
            return _plans.SelectMany(x => x.Attacks).Count(x => x.Attacker == village);
        }

        /// <summary>
        /// Filter out all attacks that don't need drawing
        /// </summary>
        private IEnumerable<AttackPlanFrom> FilterAttacksForDrawing(IEnumerable<AttackPlanFrom> attacks, Rectangle gameSize)
        {
            return attacks.Where(attack => gameSize.Contains(attack.Attacker.Location));
        }
        #endregion

        #region Persistence
        /// <summary>
        /// Global settings for <see cref="AttackManipulator"/>.
        /// Add something, also update Write/ReadXml for it to be persisted
        /// </summary>
        public class SettingsInfo
        {
            #region Properties
            /// <summary>
            /// True: Shows all targets
            /// False: Show only actively selected target.
            /// </summary>
            public bool ShowOtherTargets { get; set; }

            /// <summary>
            /// True: Show all attacking villages.
            /// False: Show only actively selected target attackers.
            /// </summary>
            public bool ShowOtherAttackers { get; set; }

            /// <summary>
            /// True: Show the targets/attackers even when we're not in AttackManipulator modus.
            /// False: Only show when the AttackManipulator is the CurrentManipulator.
            /// </summary>
            public bool ShowIfNotActiveManipulator { get; set; }

            /// <summary>
            /// Show attack arrival time when sent NOW in the <see cref="AttackPlanFromControl"/>s
            /// </summary>
            public bool ShowArrivalTimeWhenSentNow { get; set; }
            #endregion

            #region Constructors
            public SettingsInfo()
            {
                ShowOtherTargets = true;
                ShowOtherAttackers = true;
                ShowIfNotActiveManipulator = true;
                ShowArrivalTimeWhenSentNow = false;
            }
            #endregion
        }

        public override string WriteXml()
        {
            var output = new XDocument(
                new XElement("Plans",
                    new XAttribute("ShowOtherTargets", Settings.ShowOtherTargets),
                    new XAttribute("ShowOtherAttackers", Settings.ShowOtherAttackers),
                    new XAttribute("ShowIfNotActiveManipulator", Settings.ShowIfNotActiveManipulator),
                    new XAttribute("ShowArrivalTimeWhenSentNow", Settings.ShowArrivalTimeWhenSentNow),
                    _plans.Select(plan =>
                        new XElement("Plan",
                            new XAttribute("Target", plan.Target.LocationString),
                            new XAttribute("ArrivalTime", plan.ArrivalTime.ToFileTimeUtc()),
                            new XAttribute("Comments", plan.Comments ?? ""),
                            new XElement("Attackers",
                                plan.Attacks.Select(attacker =>
                                    new XElement("Attacker",
                                        new XAttribute("Attacker", attacker.Attacker.LocationString),
                                        new XAttribute("SlowestUnit", attacker.SlowestUnit.Type))))))));

            return output.ToString();
        }

        public override void ReadXml(XDocument doc)
        {
            XElement attackManipulator = 
                doc.Descendants("Manipulator")
                   .SingleOrDefault(manipulator => manipulator.Attribute("Type").Value == "Attack");

            if (attackManipulator != null)
            {
                // Settings
                var settingsNode = attackManipulator.Element("Plans");
                Debug.Assert(settingsNode != null);

                Func<string, bool, bool> readSetting = (settingName, defaultValue) =>
                {
                    XAttribute value = settingsNode.Attribute(settingName);
                    return value != null ? Convert.ToBoolean(value.Value) : defaultValue;
                };

                Settings.ShowOtherTargets = readSetting("ShowOtherTargets", true);
                Settings.ShowOtherAttackers = readSetting("ShowOtherAttackers", true);
                Settings.ShowIfNotActiveManipulator = readSetting("ShowIfNotActiveManipulator", true);
                Settings.ShowArrivalTimeWhenSentNow = readSetting("ShowArrivalTimeWhenSentNow", false);

                // AttackPlans
                var plans = attackManipulator.Descendants("Plan");
                foreach (XElement xmlPlan in plans)
                {
                    var plan = new AttackPlan(
                        World.Default.GetVillage(xmlPlan.Attribute("Target").Value),
                        DateTime.FromFileTimeUtc(long.Parse(xmlPlan.Attribute("ArrivalTime").Value)));

                    if (xmlPlan.Attribute("Comments") != null)
                    {
                        plan.Comments = xmlPlan.Attribute("Comments").Value;
                    }

                    if (plan.Target != null)
                    {
                        foreach (var attackerXml in xmlPlan.Descendants("Attacker"))
                        {
                            var slowestUnit = (UnitTypes)Enum.Parse(typeof(UnitTypes), attackerXml.Attribute("SlowestUnit").Value);
                            var attacker = new AttackPlanFrom(
                                plan,
                                World.Default.GetVillage(attackerXml.Attribute("Attacker").Value),
                                WorldUnits.Default[slowestUnit]);

                            plan.AddAttacker(attacker);
                        }

                        _plans.Add(plan);
                    }
                }
            }
        }

        /// <summary>
        /// Cleanup anything when switching worlds or settings
        /// </summary>
        protected internal override void CleanUp()
        {
            _plans.Clear();
            ActivePlan = null;
            ActiveAttacker = null;
        }
        #endregion
    }
}