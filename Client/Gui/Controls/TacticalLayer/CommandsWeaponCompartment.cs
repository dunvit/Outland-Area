using System;
using System.Drawing;
using System.Windows.Forms;
using Engine.Tools;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CommandsWeaponCompartment : UserControl
    {
        public event Action<ICelestialObject> OnActivateModule;

        private Point _location;

        public CommandsWeaponCompartment()
        {
            InitializeComponent();
        }

        private void CommandsWeaponCompartment_Load(object sender, EventArgs e)
        {
            if (DebugTools.IsInDesignMode())
                return;

            _location = Location;

            panel1_Click(null, null);

            picWeaponImage.Image = UI.LoadGenericImage("Ship_Equipment/Missile_Launchers/Light_Missile_Launcher_I");
            txtWeaponName.Text = @"LIGHT MISSILE LAUNCHER I";

            picCrewMember.Image = UI.LoadCharacterImage("637066561468099897");
        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            if (Height == 207)
            {
                Height = 56;
                Location = new Point(_location.X, 1010);
            }
            else
            {
                Height = 207;
                Location = new Point(_location.X, 861);
            }
        }

        private void Event_ActivateModule(object sender, EventArgs e)
        {
            var missile = new Missile
            {
                Name = "Light missile",
                Speed = 30,
                Classification = (int) CelestialObjectTypes.Missile,
                Signature = 10,
                Damage = 30,
                Radius = 50
            };

            OnActivateModule?.Invoke(missile);
        }
    }
}
