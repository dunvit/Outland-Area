using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandAreaLogic.DialogSystems.Schemes;

namespace Prototypes.Dialogs
{
    public interface IDialogWindow
    {
        void Execute(DialogRowScheme id);
    }
}
