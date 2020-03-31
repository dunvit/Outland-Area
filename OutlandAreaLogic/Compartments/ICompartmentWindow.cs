using System.Windows.Forms;
using OutlandAreaLogic.DialogSystems.Schemes;

namespace OutlandAreaLogic.Compartments
{
    public interface ICompartmentWindow
    {
        string Name { get; set; }

        void Execute(DialogRowScheme id);

        void ShowCompartment(UserControl compartment);
    }
}
