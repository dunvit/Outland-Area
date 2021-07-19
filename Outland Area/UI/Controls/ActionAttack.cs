using System.Windows.Forms;
using EngineCore.Session;

namespace Engine.UI.Controls
{
    public partial class ActionAttack : UserControl
    {
        public int ModuleId { get; }

        public int Id { get; }

        private GameSession Session;

        public ActionAttack(int moduleId, int id, GameSession gameSession)
        {
            InitializeComponent();

            ModuleId = moduleId;
            Id = id;
            Session = gameSession;
        }
    }
}
