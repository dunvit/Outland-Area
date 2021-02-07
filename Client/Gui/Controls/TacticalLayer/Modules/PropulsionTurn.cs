using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Gui.Controls.Common;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    public partial class PropulsionTurn : GenericActiveModule
    {
        private MouseLocationTracker _mouseLocationTrackerLeft;
        private MouseLocationTracker _mouseLocationTrackerRight;

        public CommandTypes Type { get; set; }

        public PropulsionTurn()
        {
            InitializeComponent();

            Type = CommandTypes.MoveForward;
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
