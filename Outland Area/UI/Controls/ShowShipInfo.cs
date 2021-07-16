using System;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Model;
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

            //txtCelestialObjectName.Text = "";

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

            FillControls(activeObject.ToSpaceship(), _environment.Session.GetPlayerSpaceShip());

            containerData.Visible = true;
        }

        private void FillControls(Spaceship targetSpaceship, ICelestialObject playerSpaceship)
        {
            txtCelestialObjectName.Text = targetSpaceship.Name;

            var shieldsMax = (int)targetSpaceship.ShieldsMax;
            var shieldCurrent = (int)targetSpaceship.Shields;

            //if(crlShields.Maximum != shieldsMax)
                crlShields.Maximum = shieldsMax;

            //if (crlShields.CurrentValue != shieldCurrent)
            {


                crlShields.CurrentValue = shieldCurrent;
                crlShields.Refresh();
            }

            if (txtDirection.Text != Math.Round(targetSpaceship.Direction, 2) + "")
                txtDirection.Text = Math.Round(targetSpaceship.Direction, 2) + "";

            if (txtSpeed.Text != Math.Round(targetSpaceship.Speed, 2) + "")
                txtSpeed.Text = Math.Round(targetSpaceship.Speed, 2) + "";

            if (txtDistance.Text != Math.Round(GeometryTools.Distance(targetSpaceship.GetLocation(), playerSpaceship.GetLocation()), 2) + "")
                txtDistance.Text = Math.Round(GeometryTools.Distance(targetSpaceship.GetLocation(), playerSpaceship.GetLocation()), 2) + "";
        }
    }
}
