
using Engine.Gui.Controls.Common;

namespace Engine.Gui.Controls.TacticalLayer.Compartments
{
    public partial class PropulsionCompartment : BaseCompartment
    {
        private MouseLocationTracker _mouseLocationTracker;

        public PropulsionCompartment()
        {
            InitializeComponent();

            CompartmentModuleName = "Propulsion Compartment";

            //commandTurn
        }
    }
}
