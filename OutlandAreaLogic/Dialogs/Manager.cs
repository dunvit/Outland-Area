using Engine.Dialogs;
using OutlandAreaLogic;

namespace Engine
{
    public class Manager
    {
        public IDialogWindow Container { get; set; }

        readonly Compartments.Navigation CompartmentNavigation = new Compartments.Navigation();
        readonly Compartments.Cargo CompartmentCargo = new Compartments.Cargo();

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
                    Container.ShowCompartment(CompartmentNavigation);
                    break;

                case "Cargo":
                    Container.ShowCompartment(CompartmentCargo);
                    break;

                default:
                    break;
            }
        }
    }
}
