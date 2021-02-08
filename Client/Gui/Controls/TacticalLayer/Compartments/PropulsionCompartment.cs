using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace Engine.Gui.Controls.TacticalLayer.Compartments
{
    public partial class PropulsionCompartment : BaseCompartment
    {
        private IModule PropulsionModule { get; set; }
        public event Action<IModule, CommandTypes> OnChangeDirection;

        public PropulsionCompartment()
        {
            InitializeComponent();

            CompartmentModuleName = "Propulsion Compartment";

            commandTurn.OnTurn += ChangeNavigationDirection;
        }

        private void ChangeNavigationDirection(CommandTypes directionType)
        {
            OnChangeDirection?.Invoke(PropulsionModule, directionType);
        }

        public void ResetData(GameSession gameSession, List<IModule> modules)
        {
            PropulsionModule = modules.FirstOrDefault();

            var spaceShip = gameSession.GetPlayerSpaceShip().ToSpaceship();

            txtDirection.Invoke(new MethodInvoker(delegate () {
                txtDirection.Text = spaceShip.Direction.ToString("0.##");
            }));

            txtVelocity.Invoke(new MethodInvoker(delegate () {
                txtVelocity.Text = spaceShip.Speed.ToString("0.##");
            }));
        }

        public void Initialization(List<IModule> modules)
        {
            PropulsionModule = modules.FirstOrDefault();
        }
    }
}
