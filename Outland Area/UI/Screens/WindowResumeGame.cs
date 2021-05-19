using EngineCore.Events;
using EngineCore.Session;
using System.Windows.Forms;

namespace Engine.UI.Screens
{
    public partial class WindowResumeGame : Form
    {
        public GameEvent GameEvent { get; set; }

        public GameSession Session { get; set; }

        public WindowResumeGame()
        {
            InitializeComponent();
        }
    }
}
