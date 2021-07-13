using System;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Objects;
using log4net;

namespace Engine.UI.Controls
{
    public partial class ShowShipInfo : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TacticalEnvironment _environment;

        public ShowShipInfo()
        {
            InitializeComponent();

            txtCelestialObjectName.Text = "";

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_Refresh;
        }

        private void Event_Refresh(TacticalEnvironment environment)
        {
            _environment = environment;

            Logger.Debug($"Refresh game information for turn '{_environment.Session.Turn}'.");

            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            var activeObject = _environment.GetActiveObject();

            if (activeObject is null)
            {
                txtCelestialObjectName.Text = @"There is no active object".ToUpper();
                containerData.Visible = false;
                return;
            }

            var playerShip = _environment.Session.GetPlayerSpaceShip();
            var spacecraft = activeObject.ToSpaceship();

            txtCelestialObjectName.Text = activeObject.Name;

            crlShields.Maximum = (int) spacecraft.ShieldsMax;
            crlShields.CurrentValue = (int)spacecraft.Shields;

            txtDirection.Text = Math.Round(spacecraft.Direction, 2) + "";
            txtSpeed.Text = Math.Round(spacecraft.Speed, 2) + "";
            txtDistance.Text = Math.Round(GeometryTools.Distance(spacecraft.GetLocation(), playerShip.GetLocation()), 2) + "";

            containerData.Visible = true;
        }
    }
}
