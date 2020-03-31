using Engine.Compartments;
using Engine.Dialogs;
using OutlandAreaLogic;
using System.Windows.Forms;
using OutlandAreaLogic.Compartments;

namespace Engine
{
    public class Manager
    {
        public ICompartmentWindow Container { get; set; }

        readonly ICompartment _compartmentNavigation = new Navigation();
        readonly ICompartment _compartmentCargo = new Cargo();

        public void ShowDialog(long id)
        {
            var dialogRow = Global.GameManager.Dialogs.Get(id);

            Container.Execute(dialogRow);
        }

        public void ShowCompartment(string name)
        {
            switch (name)
            {
                case "Navigation":
                    Container.ShowCompartment((UserControl)_compartmentNavigation);
                    break;

                case "Cargo":
                    Container.ShowCompartment((UserControl)_compartmentCargo);
                    break;

                default:
                    break;
            }
        }
    }
}
