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

            commandMoveForward.ImageActive = Properties.Resources.Propulsion_ResumeMovementActive;
            commandMoveForward.ImageInActive = Properties.Resources.Propulsion_ResumeMovementInActive;
            commandMoveForward.ImageContinued = Properties.Resources.Propulsion_ResumeMovementResume;
            commandMoveForward.OnExecute += MoveForwardCommandExecute;

            commandTurn.OnTurn += ChangeNavigationDirection;

            commandForwardStop.OnChangeMode += ChangeNavigationDirection;

            commandMoveForward.OnActivateModule += EventActivateModule;
            commandForwardStop.OnActivateModule += EventActivateModule;
            commandTurn.OnActivateModule += EventActivateModule;

            commandMoveForward.OnDeactivateModule += EventDeactivateModule;
            commandForwardStop.OnDeactivateModule += EventDeactivateModule;
            commandTurn.OnDeactivateModule += EventDeactivateModule;

            commandMoveForward.OnExecuteModule += EventExecuteModule;
            commandForwardStop.OnExecuteModule += EventExecuteModule;
            commandTurn.OnExecuteModule += EventExecuteModule;
        }

        private void EventExecuteModule(IModule module)
        {
            Global.Game.ActivateModule(module); 
        }

        private void EventDeactivateModule(IModule module)
        {
            Global.Game.DeactivateModule(module);
        }

        private void EventActivateModule(IModule module)
        {
            Global.Game.ActivateModule(module);
        }

        private void MoveForwardCommandExecute(CommandTypes directionType)
        {
            OnChangeDirection?.Invoke(PropulsionModule, directionType);
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

            var command = gameSession.GetSpaceShipCommands(gameSession.GetPlayerSpaceShip().Id)
                .Where(c => c.Type.ToInt() > 199 && c.Type.ToInt() < 299).FirstOrDefault();

            if (command == null)
            {
                commandTurn.Type = CommandTypes.MoveForward;
                commandForwardStop.Type = CommandTypes.MoveForward;
                command = new Command{Type = CommandTypes.MoveForward};
            }
            else
            {
                commandTurn.Type = command.Type;
                commandForwardStop.Type = command.Type;
            }

            commandTurn.UpdateNavigationIcon(command.Type);
            commandForwardStop.UpdateNavigationIcon(command.Type);
            commandMoveForward.Update(command.Type);
        }

        public void Initialization(List<IModule> modules)
        {
            PropulsionModule = modules.FirstOrDefault();
        }
    }
}
