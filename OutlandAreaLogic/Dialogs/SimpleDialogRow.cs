using System.Drawing;
using System.Windows.Forms;
using OutlandAreaLogic;
using OutlandAreaLogic.DialogSystems.Schemes;

//using WorkSpace.Prototypes.Dialog;

namespace WorkSpace.Prototypes
{
    public partial class SimpleDialogRow : UserControl
    {
        public SimpleDialogRow()
        {
            InitializeComponent();
        }

        public bool TryInitialize(DialogRowScheme row)
        {
            txtMessage.Text = "";
            txtMessage.Visible = false;
            simpleDialogCharacter2.Visible = false;
            simpleDialogCharacter1.Visible = false;

            var character = Global.Characters.GetCharacter(row.CharacterId);

            switch (row.Align)
            {
                case OutlandAreaLogic.DialogSystems.Alignment.Left:
                    txtMessage.TextAlign = ContentAlignment.TopLeft;
                    simpleDialogCharacter2.TryInitializeCharacter(character, row.Align);
                    simpleDialogCharacter2.Visible = true;
                    break;

                case OutlandAreaLogic.DialogSystems.Alignment.Right:
                    txtMessage.TextAlign = ContentAlignment.TopRight;
                    simpleDialogCharacter1.TryInitializeCharacter(character, row.Align);
                    simpleDialogCharacter1.Visible = true;
                    break;
            }

            txtMessage.Text = row.Message;
            txtMessage.Visible = true;

            return true;
        }
    }
}
