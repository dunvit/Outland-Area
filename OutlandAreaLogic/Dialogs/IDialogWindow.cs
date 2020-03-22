using OutlandAreaLogic.DialogSystems.Schemes;
using Engine.Compartments;
using System.Windows.Forms;

namespace Engine.Dialogs
{
    public interface IDialogWindow
    {
        void Execute(DialogRowScheme id);

        void ShowCompartment(UserControl compartment);
    }
}
