using System;
using Engine.Gui.Controls.Common;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    public partial class Propulsion_ForwardStop : GenericActiveModule
    {
        private MouseLocationTracker _mouseLocationTrackerStop;
        private MouseLocationTracker _mouseLocationTrackerAcceleration;

        public event Action<CommandTypes> OnChangeMode;

        public CommandTypes Type { get; set; }

        public Propulsion_ForwardStop()
        {
            InitializeComponent();

            Type = CommandTypes.MoveForward;
        }

        private void Propulsion_ForwardStop_Load(object sender, EventArgs e)
        {
            _mouseLocationTrackerStop = new MouseLocationTracker(imageStop);


            _mouseLocationTrackerStop.OnMouseInControl += delegate
            {
                imageStop.Image = Properties.Resources.Propulsion_StopActive;
            };

            _mouseLocationTrackerStop.OnMouseOutControl += delegate
            {
                if (Type == CommandTypes.TurnLeft)
                {
                    imageStop.Image = Properties.Resources.Propulsion_StopResume;
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
                }
                else
                {
                    imageStop.Image = Properties.Resources.Propulsion_StopInActive;
                }
            };

            _mouseLocationTrackerAcceleration = new MouseLocationTracker(imageAcceleration);

            _mouseLocationTrackerAcceleration.OnMouseInControl += delegate
            {
                imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationActive;
            };

            _mouseLocationTrackerAcceleration.OnMouseOutControl += delegate
            {
                if (Type == CommandTypes.TurnRight)
                {
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationResume;
                    imageStop.Image = Properties.Resources.Propulsion_StopInActive;
                }
                else
                {
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
                }
            };
        }

        private void Acceleration(object sender, EventArgs e)
        {
            imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationResume;
            imageStop.Image = Properties.Resources.Propulsion_StopInActive;

            OnChangeMode?.Invoke(CommandTypes.Acceleration);
        }

        private void Stop(object sender, EventArgs e)
        {
            imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
            imageStop.Image = Properties.Resources.Propulsion_StopResume;

            OnChangeMode?.Invoke(CommandTypes.StopShip);
        }

        public void UpdateNavigationIcon(CommandTypes commandType)
        {
            switch (commandType)
            {
                case CommandTypes.MoveForward:
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
                    imageStop.Image = Properties.Resources.Propulsion_StopInActive;
                    break;
                case CommandTypes.TurnLeft:
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
                    imageStop.Image = Properties.Resources.Propulsion_StopInActive;
                    break;
                case CommandTypes.TurnRight:
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
                    imageStop.Image = Properties.Resources.Propulsion_StopInActive;
                    break;
                case CommandTypes.StopShip:
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationInActive;
                    imageStop.Image = Properties.Resources.Propulsion_StopResume;
                    break;
                case CommandTypes.Acceleration:
                    imageAcceleration.Image = Properties.Resources.Propulsion_AccelerationResume;
                    imageStop.Image = Properties.Resources.Propulsion_StopInActive;
                    break;

            }
        }
    }
}
