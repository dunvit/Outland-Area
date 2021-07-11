using EngineCore.Universe.Characters;
using System.Windows.Forms;

namespace Engine.UI.Controls
{
    public partial class DialoguePersonInfoSmall : UserControl
    {
        public DialoguePersonInfoSmall()
        {
            InitializeComponent();
        }

        internal void RefreshPersonInfo(Character longRangeDefenseOfficer)
        {
            pictureBox1.Image = UITools.LoadCharacterImage(longRangeDefenseOfficer.Id.ToString(), "Front");

            label3.Text = longRangeDefenseOfficer.Name;
        }
    }
}
