using System;
using Engine.Gui.Controls.Common;
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

            imageRightPart.Image = Properties.Resources.Propulsion_TurnRightResume;
            imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
        }

        private void TurnLeft(object sender, EventArgs e)
        {
            Turn(CommandTypes.TurnLeft);

            imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftResume;
            imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
        }

        private void Turn(CommandTypes type)
        {
            if (Type != type)
            {
                // Send command to server
                OnTurn?.Invoke(type);
            }
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
                if (Type == CommandTypes.TurnLeft)
                {
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftResume;
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
                }
                else
                {
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
                }
            };

            _mouseLocationTrackerRight = new MouseLocationTracker(imageRightPart);

            _mouseLocationTrackerRight.OnMouseInControl += delegate
            {
                imageRightPart.Image = Properties.Resources.Propulsion_TurnRightActive;
            };

            _mouseLocationTrackerRight.OnMouseOutControl += delegate
            {
                if (Type == CommandTypes.TurnRight)
                {
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightResume;
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
                }
                else
                {
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
                }
            };
        }

        public void UpdateNavigationIcon(CommandTypes commandType)
        {
            if (_mouseLocationTrackerLeft.IsActive) return;
            if (_mouseLocationTrackerRight.IsActive) return;

            switch (commandType)
            {
                case CommandTypes.MoveForward:
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
                    break;
                case CommandTypes.TurnLeft:
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftResume;
                    break;
                case CommandTypes.TurnRight:
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightResume;
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
                    break;
                case CommandTypes.StopShip:
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
                    break;
                case CommandTypes.Acceleration:
                    imageRightPart.Image = Properties.Resources.Propulsion_TurnRightInActive;
                    imageLeftPart.Image = Properties.Resources.Propulsion_TurnLeftInActive;
                    break;

            }
        }
    }
}
