using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EngineCore.Session;
using EngineCore.Universe.Equipment;

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

            var module = gameSession.GetPlayerSpaceShip().GetWeaponModule(moduleId);

            ModuleId = moduleId;
            Id = id;
            Session = gameSession;

            var skill = (module as IModule)?.Skills.FirstOrDefault(s => s.Id == id);

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Images\Equipment\Skills\{skill.ImageFile}.png");


            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Image.FromFile(path);
        }
    }
}
