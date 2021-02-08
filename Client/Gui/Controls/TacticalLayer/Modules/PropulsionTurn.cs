using System;
using Engine.Gui.Controls.Common;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    public partial class PropulsionTurn : GenericActiveModule
    {
        private MouseLocationTracker _mouseLocationTrackerLeft;
        private MouseLocationTracker _mouseLocationTrackerRight;

        public event Action<CommandTypes> OnTurn;

        public CommandTypes Type { get; set; }

        public PropulsionTurn()
        {
            InitializeComponent();

            Type = CommandTypes.MoveForward;

            imageLeftPart.Click += TurnLeft;
            imageRightPart.Click += TurnRight;
        }

        private void TurnRight(object sender, EventArgs e)
        {
            Turn(CommandTypes.TurnRight);
        }

        private void TurnLeft(object sender, EventArgs e)
        {
            Turn(CommandTypes.TurnLeft);
        }

        private void Turn(CommandTypes type)
        {
            if (Type != type)
            {
                // Send command to server
                OnTurn?.Invoke(type);
            }
        }

        private void InvokeClick(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void PropulsionTurn_Load(object sender, EventArgs e)
        {
            _mouseLocationTrackerLeft = new MouseLocationTracker(imageLeftPart);
            

            _mouseLocationTrackerLeft.OnMouseInControl += delegate
            {
                imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftActive;
            };

            _mouseLocationTrackerLeft.OnMouseOutControl += delegate
            {
                imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
            };

            _mouseLocationTrackerRight = new MouseLocationTracker(imageRightPart);

            _mouseLocationTrackerRight.OnMouseInControl += delegate
            {
                imageRightPart.Image = Properties.Resources.Propulsion_TurnRightActive;
            };

            _mouseLocationTrackerRight.OnMouseOutControl += delegate
            {
                imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
            };
        }
    }
}
