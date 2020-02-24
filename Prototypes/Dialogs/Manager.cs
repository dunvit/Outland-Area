using OutlandAreaLogic;

namespace Prototypes.Dialogs
{
    public class Manager
    {
        public IDialogWindow Container { get; set; }

        public void Show(long id)
        {
            var dialogRow = Global.GameManager.Dialogs.Get(id);

            Container.Execute(dialogRow);
        }
    }
}
